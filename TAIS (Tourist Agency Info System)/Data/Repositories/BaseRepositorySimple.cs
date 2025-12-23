using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public abstract class BaseRepositorySimple<T> : BaseRepository where T : class
    {
        // Название таблицы
        protected abstract string TableName { get; }
        protected abstract string Name { get; }

        /// <summary>
        /// Находит ID по имени или создает новую запись.
        /// </summary>
        public int GetOrCreate(string name)
        {
            int existingId = FindIdByName(name);
            if (existingId > 0)
                return existingId;

            return CreateNew(name);
        }

        public int GetIdByName(string name)
        {
            int existingId = FindIdByName(name);
            if (existingId > 0)
                return existingId;

            throw new Exception($"Такого объекта не существует: {name}");
        }

        private int FindIdByName(string name)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = $"SELECT Id FROM {TableName} WHERE {Name} = @name COLLATE NOCASE;";
            command.Parameters.AddWithValue("@name", name ?? string.Empty);

            object result = command.ExecuteScalar();

            if (result == null || result == DBNull.Value)
                return 0;

            return (int)(long)result;
        }

        private int CreateNew(string name)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = $@"
                INSERT INTO {TableName} ({Name}) 
                VALUES (@name)";

            command.Parameters.AddWithValue("@name", name ?? string.Empty);

            command.ExecuteNonQuery();

            command.CommandText = "SELECT last_insert_rowid();";
            long newIdLong = (long)command.ExecuteScalar();

            return (int)newIdLong;
        }

        /// <summary>
        /// Удаляет строку из БД по ключу.
        /// </summary>
        /// <param name="id">Id для удаления.</param>
        /// <returns>Количество удаленных строк (0 или 1).</returns>
        public int Delete(int id)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = $"DELETE FROM {TableName} WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// Удаляет строку из БД по ее имени. Поиск нечувствителен к регистру (COLLATE NOCASE).
        /// </summary>
        /// <param name="name">Имя для удаления.</param>
        /// <returns>Количество удаленных строк (0 или 1).</returns>
        public virtual int Delete(string name)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = $"DELETE FROM {TableName} WHERE {Name} = @name;";
            command.Parameters.AddWithValue("@name", name ?? string.Empty);

            return command.ExecuteNonQuery();
        }

        public List<T> GetAll()
        {
            var data = new Dictionary<int, string>();

            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = $"SELECT Id, {Name} FROM {TableName};";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string value = reader.IsDBNull(1) ? null : reader.GetString(1);
                data.Add(id, value);
            }

            return Converter(data);
        }

        protected abstract List<T> Converter(Dictionary<int, string> data);

        public abstract T GetById(int Id);

        public abstract int Update(T model);
    }
}
