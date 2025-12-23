using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class StreetRepository : BaseRepositorySimple<Street>
    {
        protected override string TableName => "Street";
        protected override string Name => "Name";

        protected override List<Street> Converter(Dictionary<int, string> data)
        {
            var list = new List<Street>();
            foreach (var kvp in data)
            {
                list.Add(new Street(kvp.Key, kvp.Value));
            }
            return list;
        }

        public override Street GetById(int Id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, {Name} FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", Id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {Id}");

            string name = reader.IsDBNull(1) ? null : reader.GetString(1);
            return new Street(Id, name);
        }

        public override int Update(Street model)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $@"UPDATE {TableName} SET {Name} = @Name WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Name", model.Name ?? string.Empty);
            command.Parameters.AddWithValue("@Id", model.Id);
            return command.ExecuteNonQuery();
        }
    }
}
