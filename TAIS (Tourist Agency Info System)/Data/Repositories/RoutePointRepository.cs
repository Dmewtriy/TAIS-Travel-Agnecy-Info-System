using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class RoutePointRepository : BaseRepository
    {
        private const string TableName = "RoutePoint";
        private readonly RouteRepository _routeRepository;
        private readonly CityRepository _cityRepository;
        private readonly HotelRepository _hotelRepository;
        private readonly EmployeeRepository _employeeRepository;

        public RoutePointRepository(RouteRepository routeRepository,
            CityRepository cityRepository, HotelRepository hotelRepository, EmployeeRepository employeeRepository)
        {
            _routeRepository = routeRepository;
            _cityRepository = cityRepository;
            _hotelRepository = hotelRepository;
            _employeeRepository = employeeRepository;
        }

        public List<RoutePoint> GetAll()
        {
            var list = new List<RoutePoint>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, SequenceNumber, StayDuration, ExcursionProgram, RouteId, CityId, HotelId, CreatedByEmployeeId FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int? seq = reader.IsDBNull(1) ? null : (int?)reader.GetInt32(1);
                int? stay = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                string program = reader.IsDBNull(3) ? null : reader.GetString(3);
                int routeId = reader.GetInt32(4);
                int cityId = reader.GetInt32(5);
                int? hotelId = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);
                int createdBy = reader.GetInt32(7);

                var rp = new RoutePoint(id, seq, stay, program, routeId, cityId, hotelId, createdBy)
                {
                    Route = _routeRepository.GetById(routeId),
                    City = _cityRepository.GetById(cityId),
                    Hotel = hotelId.HasValue ? _hotelRepository.GetById(hotelId.Value) : null,
                    CreatedByEmployee = _employeeRepository.GetById(createdBy)
                };
                list.Add(rp);
            }
            return list;
        }

        public RoutePoint GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, SequenceNumber, StayDuration, ExcursionProgram, RouteId, CityId, HotelId, CreatedByEmployeeId FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            int? seq = reader.IsDBNull(1) ? null : (int?)reader.GetInt32(1);
            int? stay = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
            string program = reader.IsDBNull(3) ? null : reader.GetString(3);
            int routeId = reader.GetInt32(4);
            int cityId = reader.GetInt32(5);
            int? hotelId = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);
            int createdBy = reader.GetInt32(7);

            var rp = new RoutePoint(idDb, seq, stay, program, routeId, cityId, hotelId, createdBy)
            {
                Route = _routeRepository.GetById(routeId),
                City = _cityRepository.GetById(cityId),
                Hotel = hotelId.HasValue ? _hotelRepository.GetById(hotelId.Value) : null,
                CreatedByEmployee = _employeeRepository.GetById(createdBy)
            };
            return rp;
        }

        public int Save(RoutePoint model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET SequenceNumber = @Seq, StayDuration = @Stay, ExcursionProgram = @Program, RouteId = @RouteId, CityId = @CityId, HotelId = @HotelId, CreatedByEmployeeId = @CreatedBy WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (SequenceNumber, StayDuration, ExcursionProgram, RouteId, CityId, HotelId, CreatedByEmployeeId) VALUES (@Seq, @Stay, @Program, @RouteId, @CityId, @HotelId, @CreatedBy); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@Seq", model.SequenceNumber.HasValue ? model.SequenceNumber.Value : (object)DBNull.Value);
            command.Parameters.AddWithValue("@Stay", model.StayDuration.HasValue ? model.StayDuration.Value : (object)DBNull.Value);
            command.Parameters.AddWithValue("@Program", model.ExcursionProgram ?? string.Empty);
            command.Parameters.AddWithValue("@RouteId", model.RouteId);
            command.Parameters.AddWithValue("@CityId", model.CityId);
            command.Parameters.AddWithValue("@HotelId", model.HotelId.HasValue ? model.HotelId.Value : (object)DBNull.Value);
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
