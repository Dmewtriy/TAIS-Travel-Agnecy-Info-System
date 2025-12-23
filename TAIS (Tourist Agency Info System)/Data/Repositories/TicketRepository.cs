using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class TicketRepository : BaseRepository
    {
        private const string TableName = "Ticket";
        private readonly ClientRepository _clientRepository;
        private readonly FlightRepository _flightRepository;

        public TicketRepository(ClientRepository clientRepository, FlightRepository flightRepository)
        {
            _clientRepository = clientRepository;
            _flightRepository = flightRepository;
        }

        public List<Ticket> GetAll()
        {
            var list = new List<Ticket>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, TicketClass, SeatNumber, Price, ClientId, FlightId FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string ticketClass = reader.IsDBNull(1) ? null : reader.GetString(1);
                string seat = reader.IsDBNull(2) ? null : reader.GetString(2);
                string priceStr = reader.IsDBNull(3) ? null : reader.GetString(3);
                int clientId = reader.GetInt32(4);
                int flightId = reader.GetInt32(5);

                decimal price = decimal.Parse(priceStr);
                var ticket = new Ticket(id, ticketClass, seat, price, clientId, flightId)
                {
                    Client = _clientRepository.GetById(clientId),
                    Flight = _flightRepository.GetById(flightId)
                };
                list.Add(ticket);
            }
            return list;
        }

        public Ticket GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, TicketClass, SeatNumber, Price, ClientId, FlightId FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            string ticketClass = reader.IsDBNull(1) ? null : reader.GetString(1);
            string seat = reader.IsDBNull(2) ? null : reader.GetString(2);
            string priceStr = reader.IsDBNull(3) ? null : reader.GetString(3);
            int clientId = reader.GetInt32(4);
            int flightId = reader.GetInt32(5);

            decimal price = decimal.Parse(priceStr);
            var ticket = new Ticket(idDb, ticketClass, seat, price, clientId, flightId)
            {
                Client = _clientRepository.GetById(clientId),
                Flight = _flightRepository.GetById(flightId)
            };
            return ticket;
        }

        public int Save(Ticket model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET TicketClass = @Class, SeatNumber = @Seat, Price = @Price, ClientId = @ClientId, FlightId = @FlightId WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (TicketClass, SeatNumber, Price, ClientId, FlightId) VALUES (@Class, @Seat, @Price, @ClientId, @FlightId); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@Class", model.TicketClass ?? string.Empty);
            command.Parameters.AddWithValue("@Seat", model.SeatNumber ?? string.Empty);
            command.Parameters.AddWithValue("@Price", model.Price);
            command.Parameters.AddWithValue("@ClientId", model.ClientId);
            command.Parameters.AddWithValue("@FlightId", model.FlightId);

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
