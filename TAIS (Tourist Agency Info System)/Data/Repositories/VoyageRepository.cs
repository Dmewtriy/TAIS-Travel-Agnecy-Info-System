using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class VoyageRepository : BaseRepository
    {
        private const string TableName = "Voyage";
        private readonly CarrierRepository _carrierRepository;
        private readonly AircraftTypeRepository _aircraftTypeRepository;

        public VoyageRepository(CarrierRepository carrierRepository, AircraftTypeRepository aircraftTypeRepository)
        {
            _carrierRepository = carrierRepository;
            _aircraftTypeRepository = aircraftTypeRepository;
        }

        public List<Voyage> GetAll()
        {
            var list = new List<Voyage>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, CarrierId, AircraftTypeId FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int carrierId = reader.GetInt32(1);
                int aircraftTypeId = reader.GetInt32(2);

                var voyage = new Voyage(id, carrierId, aircraftTypeId)
                {
                    Carrier = _carrierRepository.GetById(carrierId),
                    AircraftType = _aircraftTypeRepository.GetById(aircraftTypeId)
                };
                list.Add(voyage);
            }
            return list;
        }

        public Voyage GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, CarrierId, AircraftTypeId FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            int carrierId = reader.GetInt32(1);
            int aircraftTypeId = reader.GetInt32(2);

            var voyage = new Voyage(idDb, carrierId, aircraftTypeId)
            {
                Carrier = _carrierRepository.GetById(carrierId),
                AircraftType = _aircraftTypeRepository.GetById(aircraftTypeId)
            };
            return voyage;
        }

        public int Save(Voyage model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET CarrierId = @CarrierId, AircraftTypeId = @AircraftTypeId WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (CarrierId, AircraftTypeId) VALUES (@CarrierId, @AircraftTypeId); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@CarrierId", model.CarrierId);
            command.Parameters.AddWithValue("@AircraftTypeId", model.AircraftTypeId);

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
