using System;
using System.Collections.Generic;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class CarrierRepository : BaseRepositorySimple<Carrier>
    {
        protected override string TableName => "Carrier";
        protected override string Name => "Name";

        protected override List<Carrier> Converter(Dictionary<int, string> data)
        {
            var list = new List<Carrier>();
            foreach (var kvp in data)
            {
                list.Add(new Carrier(kvp.Key, kvp.Value));
            }
            return list;
        }

        public override Carrier GetById(int Id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, {Name} FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", Id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {Id}");

            string name = reader.IsDBNull(1) ? null : reader.GetString(1);
            return new Carrier(Id, name);
        }

        public override int Update(Carrier model)
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
