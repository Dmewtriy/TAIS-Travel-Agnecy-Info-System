using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class HotelRepository : BaseRepository
    {
        private const string TableName = "Hotel";
        private readonly CityRepository _cityRepository;

        public HotelRepository(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public List<Hotel> GetAll()
        {
            var list = new List<Hotel>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, Name, CityId, Stars FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.IsDBNull(1) ? null : reader.GetString(1);
                int cityId = reader.GetInt32(2);
                int stars = reader.GetInt32(3);

                var hotel = new Hotel(id, name, cityId, stars)
                {
                    City = _cityRepository.GetById(cityId)
                };
                list.Add(hotel);
            }
            return list;
        }

        public Hotel GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, Name, CityId, Stars FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            string name = reader.IsDBNull(1) ? null : reader.GetString(1);
            int cityId = reader.GetInt32(2);
            int stars = reader.GetInt32(3);

            var hotel = new Hotel(idDb, name, cityId, stars)
            {
                City = _cityRepository.GetById(cityId)
            };
            return hotel;
        }

        public int Save(Hotel model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET Name = @Name, CityId = @CityId, Stars = @Stars WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (Name, CityId, Stars) VALUES (@Name, @CityId, @Stars); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@Name", model.Name ?? string.Empty);
            command.Parameters.AddWithValue("@CityId", model.CityId);
            command.Parameters.AddWithValue("@Stars", model.Stars);

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
