using System;
using System.Collections.Generic;
using System.Globalization;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class TripRepository : BaseRepository
    {
        private const string TableName = "Trip";
        private readonly RouteRepository _routeRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly FlightRepository _flightRepository;

        public TripRepository(RouteRepository routeRepository, EmployeeRepository employeeRepository, FlightRepository flightRepository)
        {
            _routeRepository = routeRepository;
            _employeeRepository = employeeRepository;
            _flightRepository = flightRepository;
        }

        public List<Trip> GetAll()
        {
            var list = new List<Trip>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, DepartureDate, ArrivalDate, TripCost, Penalty, RouteId, RepresentativeEmployeeId, OutboundFlightId, ReturnFlightId FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string departure = reader.IsDBNull(1) ? null : reader.GetString(1);
                string arrival = reader.IsDBNull(2) ? null : reader.GetString(2);

                decimal? cost = null;
                if (!reader.IsDBNull(3))
                {
                    try
                    {
                        double d = reader.GetDouble(3);
                        cost = Convert.ToDecimal(d);
                    }
                    catch
                    {
                        string costStr = reader.GetString(3);
                        if (decimal.TryParse(costStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed))
                            cost = parsed;
                        else if (decimal.TryParse(costStr, NumberStyles.Any, CultureInfo.CurrentCulture, out parsed))
                            cost = parsed;
                    }
                }

                decimal? penalty = null;
                if (!reader.IsDBNull(4))
                {
                    try
                    {
                        double d = reader.GetDouble(4);
                        penalty = Convert.ToDecimal(d);
                    }
                    catch
                    {
                        string penStr = reader.GetString(4);
                        if (decimal.TryParse(penStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed))
                            penalty = parsed;
                        else if (decimal.TryParse(penStr, NumberStyles.Any, CultureInfo.CurrentCulture, out parsed))
                            penalty = parsed;
                    }
                }

                int routeId = reader.GetInt32(5);
                int repId = reader.GetInt32(6);
                int outboundId = reader.GetInt32(7);
                int returnId = reader.GetInt32(8);

                DateTime depDate = DateTime.Parse(departure);
                DateTime arrDate = DateTime.Parse(arrival);

                var trip = new Trip(id, depDate, arrDate, cost, penalty, routeId, repId, outboundId, returnId)
                {
                    Route = _routeRepository.GetById(routeId),
                    RepresentativeEmployee = _employeeRepository.GetById(repId),
                    OutboundFlight = _flightRepository.GetById(outboundId),
                    ReturnFlight = _flightRepository.GetById(returnId)
                };
                list.Add(trip);
            }
            return list;
        }

        public Trip GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, DepartureDate, ArrivalDate, TripCost, Penalty, RouteId, RepresentativeEmployeeId, OutboundFlightId, ReturnFlightId FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            string departure = reader.IsDBNull(1) ? null : reader.GetString(1);
            string arrival = reader.IsDBNull(2) ? null : reader.GetString(2);

            decimal? cost = null;
            if (!reader.IsDBNull(3))
            {
                try
                {
                    double d = reader.GetDouble(3);
                    cost = Convert.ToDecimal(d);
                }
                catch
                {
                    string costStr = reader.GetString(3);
                    if (decimal.TryParse(costStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed))
                        cost = parsed;
                    else if (decimal.TryParse(costStr, NumberStyles.Any, CultureInfo.CurrentCulture, out parsed))
                        cost = parsed;
                }
            }

            decimal? penalty = null;
            if (!reader.IsDBNull(4))
            {
                try
                {
                    double d = reader.GetDouble(4);
                    penalty = Convert.ToDecimal(d);
                }
                catch
                {
                    string penStr = reader.GetString(4);
                    if (decimal.TryParse(penStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed))
                        penalty = parsed;
                    else if (decimal.TryParse(penStr, NumberStyles.Any, CultureInfo.CurrentCulture, out parsed))
                        penalty = parsed;
                }
            }

            int routeId = reader.GetInt32(5);
            int repId = reader.GetInt32(6);
            int outboundId = reader.GetInt32(7);
            int returnId = reader.GetInt32(8);

            DateTime depDate = DateTime.Parse(departure);
            DateTime arrDate = DateTime.Parse(arrival);

            var trip = new Trip(idDb, depDate, arrDate, cost, penalty, routeId, repId, outboundId, returnId)
            {
                Route = _routeRepository.GetById(routeId),
                RepresentativeEmployee = _employeeRepository.GetById(repId),
                OutboundFlight = _flightRepository.GetById(outboundId),
                ReturnFlight = _flightRepository.GetById(returnId)
            };
            return trip;
        }

        public int Save(Trip model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            string depStr = model.DepartureDate.ToString("yyyy-MM-dd");
            string arrStr = model.ArrivalDate.ToString("yyyy-MM-dd");

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET DepartureDate = @DepartureDate, ArrivalDate = @ArrivalDate, TripCost = @TripCost, Penalty = @Penalty, RouteId = @RouteId, RepresentativeEmployeeId = @RepId, OutboundFlightId = @OutboundId, ReturnFlightId = @ReturnId WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (DepartureDate, ArrivalDate, TripCost, Penalty, RouteId, RepresentativeEmployeeId, OutboundFlightId, ReturnFlightId) VALUES (@DepartureDate, @ArrivalDate, @TripCost, @Penalty, @RouteId, @RepId, @OutboundId, @ReturnId); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@DepartureDate", depStr);
            command.Parameters.AddWithValue("@ArrivalDate", arrStr);
            command.Parameters.AddWithValue("@TripCost", model.TripCost.HasValue ? (object)model.TripCost.Value : DBNull.Value);
            command.Parameters.AddWithValue("@Penalty", model.Penalty.HasValue ? (object)model.Penalty.Value : DBNull.Value);
            command.Parameters.AddWithValue("@RouteId", model.RouteId);
            command.Parameters.AddWithValue("@RepId", model.RepresentativeEmployeeId);
            command.Parameters.AddWithValue("@OutboundId", model.OutboundFlightId);
            command.Parameters.AddWithValue("@ReturnId", model.ReturnFlightId);

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
