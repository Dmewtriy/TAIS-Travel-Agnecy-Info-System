using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class FlightRepository : BaseRepository
    {
        private const string TableName = "Flight";
        private readonly VoyageRepository _voyageRepository;

        public FlightRepository(VoyageRepository voyageRepository)
        {
            _voyageRepository = voyageRepository;
        }

        public List<Flight> GetAll()
        {
            var list = new List<Flight>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, DepartureDate, DepartureTime, VoyageId FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string departureDate = reader.IsDBNull(1) ? null : reader.GetString(1);
                string departureTime = reader.IsDBNull(2) ? null : reader.GetString(2);
                int voyageId = reader.GetInt32(3);

                DateTime depDate = DateTime.Parse(departureDate);
                TimeSpan depTime = TimeSpan.Parse(departureTime);

                var flight = new Flight(id, depDate, depTime, voyageId)
                {
                    Voyage = _voyageRepository.GetById(voyageId)
                };
                list.Add(flight);
            }
            return list;
        }

        public Flight GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, DepartureDate, DepartureTime, VoyageId FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            string departureDate = reader.IsDBNull(1) ? null : reader.GetString(1);
            string departureTime = reader.IsDBNull(2) ? null : reader.GetString(2);
            int voyageId = reader.GetInt32(3);

            DateTime depDate = DateTime.Parse(departureDate);
            TimeSpan depTime = TimeSpan.Parse(departureTime);

            var flight = new Flight(idDb, depDate, depTime, voyageId)
            {
                Voyage = _voyageRepository.GetById(voyageId)
            };
            return flight;
        }

        public int Save(Flight model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            string dateStr = model.DepartureDate.ToString("yyyy-MM-dd");
            string timeStr = model.DepartureTime.ToString();

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET DepartureDate = @DepartureDate, DepartureTime = @DepartureTime, VoyageId = @VoyageId WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (DepartureDate, DepartureTime, VoyageId) VALUES (@DepartureDate, @DepartureTime, @VoyageId); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@DepartureDate", dateStr);
            command.Parameters.AddWithValue("@DepartureTime", timeStr);
            command.Parameters.AddWithValue("@VoyageId", model.VoyageId);

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
