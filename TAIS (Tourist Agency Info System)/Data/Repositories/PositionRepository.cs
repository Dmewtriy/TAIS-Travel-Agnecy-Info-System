using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class PositionRepository : BaseRepositorySimple<Position>
    {
        protected override string TableName => "Position";
        protected override string Name => "Title";

        protected override List<Position> Converter(Dictionary<int, string> data)
        {
            var list = new List<Position>();
            foreach (var kvp in data)
            {
                list.Add(new Position(kvp.Key, kvp.Value, string.Empty));
            }
            return list;
        }

        public override Position GetById(int Id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, {Name}, OkpdtrCode FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", Id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {Id}");

            string title = reader.IsDBNull(1) ? null : reader.GetString(1);
            string okpdtr = reader.IsDBNull(2) ? null : reader.GetString(2);
            return new Position(Id, title, okpdtr);
        }

        public override int Update(Position model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $@"UPDATE {TableName} SET Title = @Title, OkpdtrCode = @Okpdtr WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Title", model.Title ?? string.Empty);
            command.Parameters.AddWithValue("@Okpdtr", model.OkpdtrCode ?? string.Empty);
            command.Parameters.AddWithValue("@Id", model.Id);
            return command.ExecuteNonQuery();
        }

        // Переопределяем GetOrCreate, так как для Position требуется поле OkpdtrCode (NOT NULL)
        public new int GetOrCreate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название не должно быть пустым", nameof(name));

            using var connection = GetConnection();

            // 1. Попробуем найти существующий Id
            using (var findCmd = connection.CreateCommand())
            {
                findCmd.CommandText = $"SELECT Id FROM {TableName} WHERE {Name} = @name COLLATE NOCASE;";
                findCmd.Parameters.AddWithValue("@name", name);
                object result = findCmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return (int)(long)result;
            }

            // 2. Если не найден — создаём с дефолтным OkpdtrCode
            using (var insertCmd = connection.CreateCommand())
            {
                insertCmd.CommandText = $@"INSERT INTO {TableName} (Title, OkpdtrCode) VALUES (@name, @ok); SELECT last_insert_rowid();";
                insertCmd.Parameters.AddWithValue("@name", name);
                insertCmd.Parameters.AddWithValue("@ok", "N/A");
                long newId = (long)insertCmd.ExecuteScalar();
                return (int)newId;
            }
        }
    }
}
