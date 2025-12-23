using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class EmployeeRepository : BaseRepository
    {
        private const string TableName = "Employee";
        private readonly StreetRepository _streetRepository;

        public EmployeeRepository(StreetRepository streetRepository)
        {
            _streetRepository = streetRepository;
        }

        public List<Employee> GetAll()
        {
            var list = new List<Employee>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, FirstName, MiddleName, LastName, BirthDate, Gender, WorkExperience, StreetId FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string firstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                string middleName = reader.IsDBNull(2) ? null : reader.GetString(2);
                string lastName = reader.IsDBNull(3) ? null : reader.GetString(3);
                string birthDateStr = reader.IsDBNull(4) ? null : reader.GetString(4);
                string genderStr = reader.IsDBNull(5) ? null : reader.GetString(5);
                string workExpStr = reader.IsDBNull(6) ? null : reader.GetString(6);
                int streetId = reader.GetInt32(7);

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

                decimal? workExp = null;
                if (!string.IsNullOrEmpty(workExpStr) && decimal.TryParse(workExpStr, out var we)) workExp = we;

                var emp = new Employee(id, firstName, middleName, lastName, birthDate, gender, workExp, streetId)
                {
                    Street = _streetRepository.GetById(streetId)
                };
                list.Add(emp);
            }
            return list;
        }

        public Employee GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, FirstName, MiddleName, LastName, BirthDate, Gender, WorkExperience, StreetId FROM {TableName} WHERE Id = @Id;";
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
            string workExpStr = reader.IsDBNull(6) ? null : reader.GetString(6);
            int streetId = reader.GetInt32(7);

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

            decimal? workExp = null;
            if (!string.IsNullOrEmpty(workExpStr) && decimal.TryParse(workExpStr, out var we)) workExp = we;

            var emp = new Employee(idDb, firstName, middleName, lastName, birthDate, gender, workExp, streetId)
            {
                Street = _streetRepository.GetById(streetId)
            };
            return emp;
        }

        public int Save(Employee model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            string birthDateStr = model.BirthDate.ToString("yyyy-MM-dd");

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, BirthDate = @BirthDate, Gender = @Gender, WorkExperience = @WorkExperience, StreetId = @StreetId WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (FirstName, MiddleName, LastName, BirthDate, Gender, WorkExperience, StreetId) VALUES (@FirstName, @MiddleName, @LastName, @BirthDate, @Gender, @WorkExperience, @StreetId); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@FirstName", model.FirstName ?? string.Empty);
            command.Parameters.AddWithValue("@MiddleName", model.MiddleName ?? string.Empty);
            command.Parameters.AddWithValue("@LastName", model.LastName ?? string.Empty);
            command.Parameters.AddWithValue("@BirthDate", birthDateStr);
            command.Parameters.AddWithValue("@Gender", model.Gender.ToString());
            command.Parameters.AddWithValue("@WorkExperience", model.WorkExperience.HasValue ? (object)model.WorkExperience.Value : DBNull.Value);
            command.Parameters.AddWithValue("@StreetId", model.StreetId);

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
