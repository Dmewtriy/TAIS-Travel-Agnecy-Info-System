using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class CityRepository : BaseRepository
    {
        private const string TableName = "City";
        private readonly CountryRepository _countryRepository;

        public CityRepository(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public List<City> GetAll()
        {
            var list = new List<City>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, Name, CountryId FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.IsDBNull(1) ? null : reader.GetString(1);
                int countryId = reader.GetInt32(2);

                var city = new City(id, name, countryId)
                {
                    Country = _countryRepository.GetById(countryId)
                };
                list.Add(city);
            }
            return list;
        }

        public City GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, Name, CountryId FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            string name = reader.IsDBNull(1) ? null : reader.GetString(1);
            int countryId = reader.GetInt32(2);

            var city = new City(idDb, name, countryId)
            {
                Country = _countryRepository.GetById(countryId)
            };
            return city;
        }

        public int Save(City model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET Name = @Name, CountryId = @CountryId WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (Name, CountryId) VALUES (@Name, @CountryId); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@Name", model.Name ?? string.Empty);
            command.Parameters.AddWithValue("@CountryId", model.CountryId);

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
