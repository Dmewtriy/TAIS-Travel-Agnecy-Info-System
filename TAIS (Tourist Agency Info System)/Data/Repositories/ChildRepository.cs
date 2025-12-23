using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class ChildRepository : BaseRepository
    {
        private const string TableName = "Child";
        private readonly ClientRepository _clientRepository;

        public ChildRepository(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Child> GetAll()
        {
            var list = new List<Child>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, FirstName, MiddleName, LastName, BirthDate, Gender, ClientId FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string firstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                string middleName = reader.IsDBNull(2) ? null : reader.GetString(2);
                string lastName = reader.IsDBNull(3) ? null : reader.GetString(3);
                string birthDateStr = reader.IsDBNull(4) ? null : reader.GetString(4);
                string genderStr = reader.IsDBNull(5) ? null : reader.GetString(5);
                int clientId = reader.GetInt32(6);

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

                var child = new Child(id, firstName, middleName, lastName, birthDate, gender, clientId)
                {
                    Client = _clientRepository.GetById(clientId)
                };
                list.Add(child);
            }
            return list;
        }

        public Child GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, FirstName, MiddleName, LastName, BirthDate, Gender, ClientId FROM {TableName} WHERE Id = @Id;";
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
            int clientId = reader.GetInt32(6);

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

            var child = new Child(idDb, firstName, middleName, lastName, birthDate, gender, clientId)
            {
                Client = _clientRepository.GetById(clientId)
            };
            return child;
        }

        public int Save(Child model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            string birthDateStr = model.BirthDate.ToString("yyyy-MM-dd");

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, BirthDate = @BirthDate, Gender = @Gender, ClientId = @ClientId WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (FirstName, MiddleName, LastName, BirthDate, Gender, ClientId) VALUES (@FirstName, @MiddleName, @LastName, @BirthDate, @Gender, @ClientId); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@FirstName", model.FirstName ?? string.Empty);
            command.Parameters.AddWithValue("@MiddleName", model.MiddleName ?? string.Empty);
            command.Parameters.AddWithValue("@LastName", model.LastName ?? string.Empty);
            command.Parameters.AddWithValue("@BirthDate", birthDateStr);
            command.Parameters.AddWithValue("@Gender", model.Gender.ToString());
            command.Parameters.AddWithValue("@ClientId", model.ClientId);

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
