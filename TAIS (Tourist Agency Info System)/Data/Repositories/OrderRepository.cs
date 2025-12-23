using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class OrderRepository : BaseRepository
    {
        private const string TableName = "Orders";
        private readonly ClientRepository _clientRepository;
        private readonly TripRepository _tripRepository;

        public OrderRepository(ClientRepository clientRepository, TripRepository tripRepository)
        {
            _clientRepository = clientRepository;
            _tripRepository = tripRepository;
        }

        public List<Order> GetAll()
        {
            var list = new List<Order>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, OrderDate, OrderTime, ClientId, TripId FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string orderDate = reader.IsDBNull(1) ? null : reader.GetString(1);
                string orderTime = reader.IsDBNull(2) ? null : reader.GetString(2);
                int clientId = reader.GetInt32(3);
                int tripId = reader.GetInt32(4);

                DateTime date = DateTime.Parse(orderDate);
                TimeSpan time = TimeSpan.Parse(orderTime);

                var ord = new Order(id, date, time, clientId, tripId)
                {
                    Client = _clientRepository.GetById(clientId),
                    Trip = _tripRepository.GetById(tripId)
                };
                list.Add(ord);
            }
            return list;
        }

        public Order GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, OrderDate, OrderTime, ClientId, TripId FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            string orderDate = reader.IsDBNull(1) ? null : reader.GetString(1);
            string orderTime = reader.IsDBNull(2) ? null : reader.GetString(2);
            int clientId = reader.GetInt32(3);
            int tripId = reader.GetInt32(4);

            DateTime date = DateTime.Parse(orderDate);
            TimeSpan time = TimeSpan.Parse(orderTime);

            var ord = new Order(idDb, date, time, clientId, tripId)
            {
                Client = _clientRepository.GetById(clientId),
                Trip = _tripRepository.GetById(tripId)
            };
            return ord;
        }

        public int Save(Order model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            string dateStr = model.OrderDate.ToString("yyyy-MM-dd");
            string timeStr = model.OrderTime.ToString();

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET OrderDate = @OrderDate, OrderTime = @OrderTime, ClientId = @ClientId, TripId = @TripId WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (OrderDate, OrderTime, ClientId, TripId) VALUES (@OrderDate, @OrderTime, @ClientId, @TripId); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@OrderDate", dateStr);
            command.Parameters.AddWithValue("@OrderTime", timeStr);
            command.Parameters.AddWithValue("@ClientId", model.ClientId);
            command.Parameters.AddWithValue("@TripId", model.TripId);

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
