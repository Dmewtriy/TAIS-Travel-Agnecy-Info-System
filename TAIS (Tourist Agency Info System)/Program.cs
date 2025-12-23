using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;

namespace TAIS__Tourist_Agency_Info_System_
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Репозитории (для SQL-выборок используем метод SqlCommand)
            var countryRepo = new CountryRepository();
            var streetRepo = new StreetRepository();
            var aircraftRepo = new AircraftTypeRepository();
            var carrierRepo = new CarrierRepository();
            var positionRepo = new PositionRepository();

            var cityRepo = new CityRepository(countryRepo);
            var hotelRepo = new HotelRepository(cityRepo);
            var voyageRepo = new VoyageRepository(carrierRepo, aircraftRepo);
            var flightRepo = new FlightRepository(voyageRepo);
            var employeeRepo = new EmployeeRepository(streetRepo);
            var routeRepo = new RouteRepository(countryRepo, employeeRepo);
            var tripRepo = new TripRepository(routeRepo, employeeRepo, flightRepo);

            var clientRepo = new ClientRepository();

            Console.WriteLine("Запросы информационной системы:\n");

            // Параметры для примеров
            //string date = DateTime.Today.ToString("yyyy-MM-dd"); // конкретная дата
            string date = new DateTime(2026, 01, 22).ToString("yyyy-MM-dd");
            string from = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
            string to = DateTime.Today.ToString("yyyy-MM-dd");
            int sampleCountryId = 1; // замените реальным Id страны
            int sampleClientId = 1; // замените реальным Id клиента
            int sampleFlightId = 1; // замените реальным Id рейса
            int topN = 5;

            // 1) Списочный состав групп на конкретную дату
            Console.WriteLine("1) Списочный состав групп на дату: " + date);
            var q1 = $@"
                SELECT Trip.Id, Route.Name, Client.Id, Client.FirstName || ' ' || Client.LastName
                FROM Trip
                JOIN Route ON Trip.RouteId = Route.Id
                JOIN Orders ON Orders.TripId = Trip.Id
                JOIN Client ON Orders.ClientId = Client.Id
                WHERE '{date}' BETWEEN Trip.DepartureDate AND Trip.ArrivalDate;";
            foreach (var row in countryRepo.SqlCommand(q1)) Console.WriteLine(row);
            Console.WriteLine();

            // 2) Количество туристов, побывавших в заданной стране за период (в целом и по полу)
            Console.WriteLine($"2) Количество туристов в стране (Id={sampleCountryId}) с {from} по {to} (в целом и по полу):");
            var q2_total = $@"
                SELECT COUNT(DISTINCT Orders.ClientId) AS Total
                FROM Trip
                JOIN Orders ON Orders.TripId = Trip.Id
                JOIN Route ON Trip.RouteId = Route.Id
                WHERE Route.CountryId = {sampleCountryId}
                  AND NOT (Trip.ArrivalDate < '{from}' OR Trip.DepartureDate > '{to}');";
            foreach (var row in countryRepo.SqlCommand(q2_total)) Console.WriteLine(row);

            var q2_by_gender = $@"
                SELECT Client.Gender, COUNT(DISTINCT Client.Id) AS CountByGender
                FROM Trip
                JOIN Orders ON Orders.TripId = Trip.Id
                JOIN Route ON Trip.RouteId = Route.Id
                JOIN Client ON Orders.ClientId = Client.Id
                WHERE Route.CountryId = {sampleCountryId}
                  AND NOT (Trip.ArrivalDate < '{from}' OR Trip.DepartureDate > '{to}')
                GROUP BY Client.Gender;";
            foreach (var row in countryRepo.SqlCommand(q2_by_gender)) Console.WriteLine(row);
            Console.WriteLine();

            // 3) Сведения о конкретном туристе: сколько раз был в стране, даты и гостиницы
            Console.WriteLine($"3) Сведения о туристе Id={sampleClientId} по стране Id={sampleCountryId}:");
            var q3_count = $@"
                SELECT COUNT(DISTINCT Trip.Id)
                FROM Orders
                JOIN Trip ON Orders.TripId = Trip.Id
                JOIN Route ON Trip.RouteId = Route.Id
                WHERE Orders.ClientId = {sampleClientId} AND Route.CountryId = {sampleCountryId};";
            foreach (var row in countryRepo.SqlCommand(q3_count)) Console.WriteLine("Количество поездок: " + row);

            var q3_dates = $@"
                SELECT Trip.Id, Trip.DepartureDate, Trip.ArrivalDate
                FROM Orders
                JOIN Trip ON Orders.TripId = Trip.Id
                JOIN Route ON Trip.RouteId = Route.Id
                WHERE Orders.ClientId = {sampleClientId} AND Route.CountryId = {sampleCountryId};";
            foreach (var row in countryRepo.SqlCommand(q3_dates)) Console.WriteLine(row);

            var q3_hotels = $@"
                SELECT DISTINCT Hotel.Id, Hotel.Name
                FROM Orders
                JOIN Trip ON Orders.TripId = Trip.Id
                JOIN Route ON Trip.RouteId = Route.Id
                JOIN RoutePoint ON RoutePoint.RouteId = Route.Id
                JOIN Hotel ON RoutePoint.HotelId = Hotel.Id
                WHERE Orders.ClientId = {sampleClientId} AND Route.CountryId = {sampleCountryId};";
            foreach (var row in countryRepo.SqlCommand(q3_hotels)) Console.WriteLine(row);
            Console.WriteLine();

            // 4) Список гостиниц, в которых производится расселение туристов за период
            Console.WriteLine($"4) Список гостиниц за период {from} - {to}:");
            var q4 = $@"
                SELECT DISTINCT Hotel.Id, Hotel.Name
                FROM Trip
                JOIN Route ON Trip.RouteId = Route.Id
                JOIN RoutePoint ON RoutePoint.RouteId = Route.Id
                JOIN Hotel ON RoutePoint.HotelId = Hotel.Id
                WHERE NOT (Trip.ArrivalDate < '{from}' OR Trip.DepartureDate > '{to}');";
            foreach (var row in countryRepo.SqlCommand(q4)) Console.WriteLine(row);
            Console.WriteLine();

            // 5) Самые популярные маршруты и страны (по количеству бронирований)
            Console.WriteLine("5) Топ маршрутов по бронированиям:");
            var q5_routes = $@"
                SELECT Route.Id, Route.Name, COUNT(Orders.Id) AS Bookings
                FROM Orders
                JOIN Trip ON Orders.TripId = Trip.Id
                JOIN Route ON Trip.RouteId = Route.Id
                GROUP BY Route.Id
                ORDER BY Bookings DESC
                LIMIT {topN};";
            foreach (var row in countryRepo.SqlCommand(q5_routes)) Console.WriteLine(row);

            Console.WriteLine("5) Топ стран по бронированиям:");
            var q5_countries = $@"
                SELECT Country.Id, Country.Name, COUNT(Orders.Id) AS Bookings
                FROM Orders
                JOIN Trip ON Orders.TripId = Trip.Id
                JOIN Route ON Trip.RouteId = Route.Id
                JOIN Country ON Route.CountryId = Country.Id
                GROUP BY Country.Id
                ORDER BY Bookings DESC
                LIMIT {topN};";
            foreach (var row in countryRepo.SqlCommand(q5_countries)) Console.WriteLine(row);
            Console.WriteLine();

            // 6) Загрузка рейса на дату (количество проданных билетов)
            Console.WriteLine($"6) Загрузка рейса Id={sampleFlightId} на дату {date}:");
            var q6 = $@"
                SELECT COUNT(Ticket.Id) AS SoldTickets
                FROM Ticket
                JOIN Flight ON Ticket.FlightId = Flight.Id
                WHERE Ticket.FlightId = {sampleFlightId} AND Flight.DepartureDate = '{date}';";
            foreach (var row in countryRepo.SqlCommand(q6)) Console.WriteLine(row);
            Console.WriteLine();

            // 7) Финансовый отчет по группе (Trip)
            Console.WriteLine($"7) Финансовый отчет по поездке Id={tripRepo.GetAll().FirstOrDefault()?.Id ?? 0} (пример):");
            // выберем конкретный tripId = tripRepo.GetAll().First()
            var allTrips = tripRepo.GetAll();
            int reportTripId = allTrips.Count > 0 ? allTrips[0].Id : 0;
            if (reportTripId != 0)
            {
                var q7_ticket_revenue = $@"SELECT SUM(Price) FROM Ticket JOIN Orders ON Ticket.ClientId = Orders.ClientId WHERE Orders.TripId = {reportTripId};";
                foreach (var row in countryRepo.SqlCommand(q7_ticket_revenue)) Console.WriteLine("Доход от проданных билетов: " + row);

                var q7_package_revenue = $@"SELECT COUNT(Orders.Id) AS Pax, Trip.TripCost FROM Orders JOIN Trip ON Orders.TripId = Trip.Id WHERE Trip.Id = {reportTripId} GROUP BY Trip.TripCost;";
                foreach (var row in countryRepo.SqlCommand(q7_package_revenue)) Console.WriteLine("Пакет и число туристов: " + row);
            }
            else Console.WriteLine("Нет поездок для отчета.");
            Console.WriteLine();

            // 8) Доходы/расходы за период (ограничено доступной информацией)
            Console.WriteLine($"8) Доходы за период {from} - {to} (доступные):");
            var q8_ticket = $@"SELECT IFNULL(SUM(Ticket.Price),0) FROM Ticket JOIN Flight ON Ticket.FlightId = Flight.Id JOIN Trip ON (Trip.OutboundFlightId = Flight.Id OR Trip.ReturnFlightId = Flight.Id) WHERE NOT (Trip.ArrivalDate < '{from}' OR Trip.DepartureDate > '{to}');";
            foreach (var row in countryRepo.SqlCommand(q8_ticket)) Console.WriteLine("Доход от билетов: " + row);
            var q8_packages = $@"SELECT IFNULL(SUM(Trip.TripCost),0) FROM Trip WHERE NOT (Trip.ArrivalDate < '{from}' OR Trip.DepartureDate > '{to}');";
            foreach (var row in countryRepo.SqlCommand(q8_packages)) Console.WriteLine("Доход от путевок (без учёта числа пассажиров): " + row);
            Console.WriteLine("Расходы не хранятся в текущей схеме, их нужно учитывать отдельно.");
            Console.WriteLine();

            // 9) Рентабельность (примерный расчёт)
            Console.WriteLine("9) Рентабельность (пример):");
            var revRows = countryRepo.SqlCommand(q8_ticket);
            decimal revenue = 0;
            if (revRows.Count > 0 && decimal.TryParse(revRows[0].Split('|').Last().Trim(), out var rv)) revenue = rv;
            decimal expenses = 0; // нет данных
            if (expenses > 0) Console.WriteLine("Рентабельность: " + ((revenue - expenses) / expenses).ToString("P"));
            else Console.WriteLine("Невозможно вычислить рентабельность: нет данных по расходам.");
            Console.WriteLine();

            // 10) Сведения о туристах указанного рейса
            Console.WriteLine($"10) Туристы рейса Id={sampleFlightId} и связанные гостиницы:");
            var q10 = $@"
                SELECT DISTINCT Client.Id, Client.FirstName || ' ' || Client.LastName, Hotel.Id, Hotel.Name
                FROM Ticket
                JOIN Client ON Ticket.ClientId = Client.Id
                LEFT JOIN Orders ON Orders.ClientId = Client.Id
                LEFT JOIN Trip ON Orders.TripId = Trip.Id
                LEFT JOIN Route ON Trip.RouteId = Route.Id
                LEFT JOIN RoutePoint ON RoutePoint.RouteId = Route.Id
                LEFT JOIN Hotel ON RoutePoint.HotelId = Hotel.Id
                WHERE Ticket.FlightId = {sampleFlightId};";
            foreach (var row in countryRepo.SqlCommand(q10)) Console.WriteLine(row);

            Console.WriteLine("Запросы выполнены.");
        }
    }
}