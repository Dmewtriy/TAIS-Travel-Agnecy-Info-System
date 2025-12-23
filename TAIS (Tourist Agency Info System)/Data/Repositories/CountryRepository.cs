using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public class CountryRepository : BaseRepositorySimple<Country>
    {
        protected override string TableName => "Country";
        protected override string Name => "Name";

        protected override List<Country> Converter(Dictionary<int, string> data)
        {
            var list = new List<Country>();
            foreach (var kvp in data)
            {
                list.Add(new Country(kvp.Key, kvp.Value));
            }
            return list;
        }

        public override Country GetById(int Id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT Id, {Name} FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", Id);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception($"Нет записи в таблице {TableName} по такому id: {Id}");

            string name = reader.IsDBNull(1) ? null : reader.GetString(1);
            return new Country(Id, name);
        }

        public override int Update(Country model)
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
