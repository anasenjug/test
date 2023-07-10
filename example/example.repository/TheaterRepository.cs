using example.repository;
using example.webapi.Controllers;
using Npgsql;
using repository.common;
using System;
using System.Collections.Generic;
using System.Net;

namespace example.repository
{

    public class TheaterRepository : IRepository
    {
        public string connectionString;
        public TheaterRepository() {
            connectionString  = "Server=localhost;Port=5432;Username=postgres;Password=admin;Database=postgres";
        }


        public List<Theater> ListTheaters()
        {
            List<Theater> theaters = new List<Theater>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM \"Theater\"";
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))

                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                Theater theater = new Theater();
                                theater.id = reader.GetGuid(reader.GetOrdinal("Id"));
                                theater.name = reader.GetString(reader.GetOrdinal("Name"));
                                theater.address = reader.GetString(reader.GetOrdinal("Address"));
                                theaters.Add(theater);

                            }
                        }

                    }
                }
                connection.Close();

            }
            if (theaters.Count == 0)
            {
                return null;
            }
            else
            {

                return theaters;
            }
        }

        public Theater AddTheater(Theater theater)
        {
            theater.id = Guid.NewGuid();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO \"Theater\"  (\"Id\", \"Name\", \"Address\") VALUES (@id,@name,@address)";
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@id", theater.id);
                    command.Parameters.AddWithValue("@name", theater.name ?? "");
                    command.Parameters.AddWithValue("@address", theater.address ?? "");

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return theater;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public Theater GetTheaterById(Guid id)
        {
            Theater theater = null;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM \"Theater\" WHERE \"Id\" =@id";
                connection.Open();



                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Uuid).Value = id;
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                theater = new Theater();
                                theater.id = reader.GetGuid(reader.GetOrdinal("Id"));
                                theater.name = reader.GetString(reader.GetOrdinal("Name"));
                                theater.address = reader.GetString(reader.GetOrdinal("Address"));


                            }
                        }
                    }
                }
                connection.Close();

                if (theater == null)
                {
                    return null;
                }
                else
                {
                    return theater;
                }
            }
        }

        public bool ChangeName(Guid id, Theater updatedTheater)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "UPDATE \"Theater\" SET \"Name\" = @name, \"Address\" = @address WHERE \"Id\" = @id";
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", updatedTheater.name);
                    command.Parameters.AddWithValue("@address", updatedTheater.address);

                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                    if (rowsAffected > 0)
                    {
                        Theater updatedTheaterResponse = new Theater
                        {
                            id = id,
                            name = updatedTheater.name,
                            address = updatedTheater.address
                        };

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        
        public bool Delete(Guid id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "DELETE FROM \"Theater\" WHERE \"Id\" =@id";
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                    if (rowsAffected > 0)
                    {
                        
                        return true;
                    }
                    else
                    {
                        
                        return false;
                    }

                }


            }
        }

       
    }
}
