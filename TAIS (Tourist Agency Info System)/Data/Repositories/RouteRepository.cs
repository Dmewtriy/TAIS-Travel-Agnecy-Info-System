using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class RouteRepository : BaseRepository
    {
        private const string TableName = "Route";
        private readonly CountryRepository _countryRepository;
        private readonly EmployeeRepository _employeeRepository;

        public RouteRepository(CountryRepository countryRepository, EmployeeRepository employeeRepository)
        {
            _countryRepository = countryRepository;
            _employeeRepository = employeeRepository;
        }

        public List<Route> GetAll()
        {
            var list = new List<Route>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, Name, Duration, CountryId, CreatedByEmployeeId FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.IsDBNull(1) ? null : reader.GetString(1);
                int? duration = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                int countryId = reader.GetInt32(3);
                int createdBy = reader.GetInt32(4);

                var route = new Route(id, name, duration, countryId, createdBy)
                {
                    Country = _countryRepository.GetById(countryId),
                    CreatedByEmployee = _employeeRepository.GetById(createdBy)
                };
                list.Add(route);
            }
            return list;
        }

        public Route GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, Name, Duration, CountryId, CreatedByEmployeeId FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            string name = reader.IsDBNull(1) ? null : reader.GetString(1);
            int? duration = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
            int countryId = reader.GetInt32(3);
            int createdBy = reader.GetInt32(4);

            var route = new Route(idDb, name, duration, countryId, createdBy)
            {
                Country = _countryRepository.GetById(countryId),
                CreatedByEmployee = _employeeRepository.GetById(createdBy)
            };
            return route;
        }

        public int Save(Route model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET Name = @Name, Duration = @Duration, CountryId = @CountryId, CreatedByEmployeeId = @CreatedBy WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (Name, Duration, CountryId, CreatedByEmployeeId) VALUES (@Name, @Duration, @CountryId, @CreatedBy); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@Name", model.Name ?? string.Empty);
            command.Parameters.AddWithValue("@Duration", model.Duration.HasValue ? model.Duration.Value : (object)DBNull.Value);
            command.Parameters.AddWithValue("@CountryId", model.CountryId);
            command.Parameters.AddWithValue("@CreatedBy", model.CreatedByEmployeeId);

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
