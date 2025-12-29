using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class HREventRepository : BaseRepository
    {
        private const string TableName = "HREvent";
        private readonly StreetRepository _streetRepository;
        private readonly PositionRepository _positionRepository;
        private readonly EmployeeRepository _employeeRepository;

        public HREventRepository(StreetRepository streetRepository, PositionRepository positionRepository, EmployeeRepository employeeRepository)
        {
            _streetRepository = streetRepository;
            _positionRepository = positionRepository;
            _employeeRepository = employeeRepository;
        }

        public List<HREvent> GetAll()
        {
            var list = new List<HREvent>();
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, EventDate, EventType, Profession, Department, DocumentType, Reason, WorkPlaceStreetId, PositionId, EmployeeId, OrganizationName FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string eventDateStr = reader.IsDBNull(1) ? null : reader.GetString(1);
                string eventTypeStr = reader.IsDBNull(2) ? null : reader.GetString(2);
                string profession = reader.IsDBNull(3) ? null : reader.GetString(3);
                string department = reader.IsDBNull(4) ? null : reader.GetString(4);
                string documentTypeStr = reader.IsDBNull(5) ? null : reader.GetString(5);
                string reason = reader.IsDBNull(6) ? null : reader.GetString(6);
                int workPlaceStreetId = reader.GetInt32(7);
                int positionId = reader.GetInt32(8);
                int employeeId = reader.GetInt32(9);
                string organizationName = reader.IsDBNull(10) ? null : reader.GetString(10);

                DateTime eventDate = DateTime.Parse(eventDateStr);

                // parse EventType
                TypeEvent eventType;
                if (!string.IsNullOrEmpty(eventTypeStr))
                {
                    try { eventType = TypeEventExtensions.GetEnumByString(eventTypeStr); }
                    catch { if (!Enum.TryParse<TypeEvent>(eventTypeStr, true, out eventType)) eventType = TypeEvent.Hiring; }
                }
                else eventType = TypeEvent.Hiring;


                var ev = new HREvent(id, eventDate, workPlaceStreetId, eventType, profession, department, documentTypeStr, reason, positionId, employeeId, organizationName);

                // set navigation properties
                ev.WorkPlace = _streetRepository.GetById(workPlaceStreetId);
                ev.Position = _positionRepository.GetById(positionId);
                ev.Employee = _employeeRepository.GetById(employeeId);

                list.Add(ev);
            }
            return list;
        }

        public HREvent GetById(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, EventDate, EventType, Profession, Department, DocumentType, Reason, WorkPlaceStreetId, PositionId, EmployeeId, OrganizationName FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {id}");

            int idDb = reader.GetInt32(0);
            string eventDateStr = reader.IsDBNull(1) ? null : reader.GetString(1);
            string eventTypeStr = reader.IsDBNull(2) ? null : reader.GetString(2);
            string profession = reader.IsDBNull(3) ? null : reader.GetString(3);
            string department = reader.IsDBNull(4) ? null : reader.GetString(4);
            string documentTypeStr = reader.IsDBNull(5) ? null : reader.GetString(5);
            string reason = reader.IsDBNull(6) ? null : reader.GetString(6);
            int workPlaceStreetId = reader.GetInt32(7);
            int positionId = reader.GetInt32(8);
            int employeeId = reader.GetInt32(9);
            string organizationName = reader.IsDBNull(10) ? null : reader.GetString(10);

            DateTime eventDate = DateTime.Parse(eventDateStr);

            TypeEvent eventType;
            if (!string.IsNullOrEmpty(eventTypeStr))
            {
                try { eventType = TypeEventExtensions.GetEnumByString(eventTypeStr); }
                catch { if (!Enum.TryParse<TypeEvent>(eventTypeStr, true, out eventType)) eventType = TypeEvent.Hiring; }
            }
            else eventType = TypeEvent.Hiring;

            var ev = new HREvent(idDb, eventDate, workPlaceStreetId, eventType, profession, department, documentTypeStr, reason, positionId, employeeId, organizationName);
            ev.WorkPlace = _streetRepository.GetById(workPlaceStreetId);
            ev.Position = _positionRepository.GetById(positionId);
            ev.Employee = _employeeRepository.GetById(employeeId);
            return ev;
        }

        public int Save(HREvent model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            string eventDateStr = model.EventDate.ToString("yyyy-MM-dd");

            if (model.Id != 0)
            {
                command.CommandText = $@"UPDATE {TableName} SET EventDate = @EventDate, EventType = @EventType, Profession = @Profession, Department = @Department, DocumentType = @DocumentType, Reason = @Reason, WorkPlaceStreetId = @WorkPlaceStreetId, PositionId = @PositionId, EmployeeId = @EmployeeId WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", model.Id);
            }
            else
            {
                command.CommandText = $@"INSERT INTO {TableName} (EventDate, EventType, Profession, Department, DocumentType, Reason, WorkPlaceStreetId, PositionId, EmployeeId) VALUES (@EventDate, @EventType, @Profession, @Department, @DocumentType, @Reason, @WorkPlaceStreetId, @PositionId, @EmployeeId); SELECT last_insert_rowid();";
            }

            command.Parameters.AddWithValue("@EventDate", eventDateStr);
            command.Parameters.AddWithValue("@EventType", model.EventType.GetStringByEnum());
            command.Parameters.AddWithValue("@Profession", model.Profession ?? string.Empty);
            command.Parameters.AddWithValue("@Department", model.Department ?? string.Empty);
            command.Parameters.AddWithValue("@DocumentType", model.DocumentType.ToString());
            command.Parameters.AddWithValue("@Reason", model.Reason ?? string.Empty);
            command.Parameters.AddWithValue("@WorkPlaceStreetId", model.WorkPlaceStreetId);
            command.Parameters.AddWithValue("@PositionId", model.PositionId);
            command.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);

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
