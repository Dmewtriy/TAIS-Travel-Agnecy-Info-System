using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class ClientRepository : BaseRepository
    {
        private const string TableName = "Client";

        public List<Client> GetAll()
        {
            var list = new List<Client>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, FirstName, MiddleName, LastName, BirthDate, Gender, PassportSeries, PassportNumber, PassportIssueDate, PassportIssuedBy, Phone FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string firstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                string middleName = reader.IsDBNull(2) ? null : reader.GetString(2);
                string lastName = reader.IsDBNull(3) ? null : reader.GetString(3);
                string birthDateStr = reader.IsDBNull(4) ? null : reader.GetString(4);
                string genderStr = reader.IsDBNull(5) ? null : reader.GetString(5);
                string pSeries = reader.IsDBNull(6) ? null : reader.GetString(6);
                string pNumber = reader.IsDBNull(7) ? null : reader.GetString(7);
                string pIssueDateStr = reader.IsDBNull(8) ? null : reader.GetString(8);
                string pIssuedBy = reader.IsDBNull(9) ? null : reader.GetString(9);
                string phone = reader.IsDBNull(10) ? null : reader.GetString(10);

                DateTime birthDate = DateTime.Parse(birthDateStr);

                Gender gender;
                if (!string.IsNullOrEmpty(genderStr))
                {
                    try
                    {
                        gender = GenderExtensions.GetEnumByString(genderStr);
                    }
                    catch
                    {
                        if (!Enum.TryParse<Gender>(genderStr, true, out gender))
                            gender = Gender.M;
                    }
                }
                else
                    gender = Gender.M;

                DateTime pIssueDate = DateTime.Parse(pIssueDateStr);

                var client = new Client(id, firstName, middleName, lastName, birthDate, gender, pSeries, pNumber, pIssueDate, pIssuedBy, phone);
                list.Add(client);
            }
            return list;
        }

        public Client GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, FirstName, MiddleName, LastName, BirthDate, Gender, PassportSeries, PassportNumber, PassportIssueDate, PassportIssuedBy, Phone FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            string firstName = reader.IsDBNull(1) ? null : reader.GetString(1);
            string middleName = reader.IsDBNull(2) ? null : reader.GetString(2);
            string lastName = reader.IsDBNull(3) ? null : reader.GetString(3);
            string birthDateStr = reader.IsDBNull(4) ? null : reader.GetString(4);
            string genderStr = reader.IsDBNull(5) ? null : reader.GetString(5);
            string pSeries = reader.IsDBNull(6) ? null : reader.GetString(6);
            string pNumber = reader.IsDBNull(7) ? null : reader.GetString(7);
            string pIssueDateStr = reader.IsDBNull(8) ? null : reader.GetString(8);
            string pIssuedBy = reader.IsDBNull(9) ? null : reader.GetString(9);
            string phone = reader.IsDBNull(10) ? null : reader.GetString(10);

            DateTime birthDate = DateTime.Parse(birthDateStr);

            Gender gender;
            if (!string.IsNullOrEmpty(genderStr))
            {
                try
                {
                    gender = GenderExtensions.GetEnumByString(genderStr);
                }
                catch
                {
                    if (!Enum.TryParse<Gender>(genderStr, true, out gender))
                        gender = Gender.M;
                }
            }
            else
                gender = Gender.M;

            DateTime pIssueDate = DateTime.Parse(pIssueDateStr);

            var client = new Client(idDb, firstName, middleName, lastName, birthDate, gender, pSeries, pNumber, pIssueDate, pIssuedBy, phone);
            return client;
        }

        public int Save(Client model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            string birthDateStr = model.BirthDate.ToString("yyyy-MM-dd");
            string pIssueStr = model.PassportIssueDate.ToString("yyyy-MM-dd");

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, BirthDate = @BirthDate, Gender = @Gender, PassportSeries = @PSeries, PassportNumber = @PNumber, PassportIssueDate = @PIssue, PassportIssuedBy = @PIssuedBy, Phone = @Phone WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (FirstName, MiddleName, LastName, BirthDate, Gender, PassportSeries, PassportNumber, PassportIssueDate, PassportIssuedBy, Phone) VALUES (@FirstName, @MiddleName, @LastName, @BirthDate, @Gender, @PSeries, @PNumber, @PIssue, @PIssuedBy, @Phone); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@FirstName", model.FirstName ?? string.Empty);
            command.Parameters.AddWithValue("@MiddleName", model.MiddleName ?? string.Empty);
            command.Parameters.AddWithValue("@LastName", model.LastName ?? string.Empty);
            command.Parameters.AddWithValue("@BirthDate", birthDateStr);
            command.Parameters.AddWithValue("@Gender", model.Gender.ToString());
            command.Parameters.AddWithValue("@PSeries", model.PassportSeries ?? string.Empty);
            command.Parameters.AddWithValue("@PNumber", model.PassportNumber ?? string.Empty);
            command.Parameters.AddWithValue("@PIssue", pIssueStr);
            command.Parameters.AddWithValue("@PIssuedBy", model.PassportIssuedBy ?? string.Empty);
            command.Parameters.AddWithValue("@Phone", model.Phone ?? string.Empty);

            if (model.Id != 0)
            {
                return command.ExecuteNonQuery();
            }
            else
            {
                long newId = (long)command.ExecuteScalar();
                return (int)newId;
            }
        }

        public int Delete(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);
            return command.ExecuteNonQuery();
        }
    }
}
