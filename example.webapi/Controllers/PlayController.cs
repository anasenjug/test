/*using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace example.webapi.Controllers
{
    public class PlayController : ApiController
    {
        public string connectionString;

        public PlayController()
        {
            connectionString = "Server=localhost;Port=5432;Username=postgres;Password=admin;Database=postgres";
        }
        public HttpResponseMessage GetPlays()
        {
            List<Play> plays = new List<Play>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM \"Play\"";
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))

                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                Play play = new Play();
                                play.id = reader.GetGuid(reader.GetOrdinal("Id"));
                                play.name = reader.GetString(reader.GetOrdinal("Name"));
                                play.description = reader.GetString(reader.GetOrdinal("Description"));
                                play.genre = reader.GetString(reader.GetOrdinal("Genre"));
                                play.date = reader.GetDateTime(reader.GetOrdinal());

                                play.Add(play);

                            }
                        }

                    }
                }
                connection.Close();

            }
            if (theaters.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error retrieving theater list");
            }
            else
            {

                return Request.CreateResponse(HttpStatusCode.OK, theaters);
            }

        }

        // GET: api/Theater/5
        public HttpResponseMessage GetTheaterById(Guid id)
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
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error retrieving theater");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, theater);
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage AddTheater([FromBody] Theater theater)
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
                        return Request.CreateResponse(HttpStatusCode.Created, "Theater created successfully");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Error creating theater");
                    }
                }
            }
        }

        [HttpPut]
        public HttpResponseMessage ChangeName(Guid id, [FromBody] Theater updatedTheater)
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
                    if (rowsAffected > 0)
                    {
                        Theater updatedTheaterResponse = new Theater
                        {
                            id = id,
                            name = updatedTheater.name,
                            address = updatedTheater.address
                        };

                        return Request.CreateResponse(HttpStatusCode.OK, updatedTheaterResponse);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Error changing theater");
                    }
                }
            }
        }

        // DELETE: api/Theater/5
        public HttpResponseMessage Delete(Guid id)
        {


            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "DELETE FROM \"Theater\" WHERE \"Id\" =@id";
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {

                        return Request.CreateResponse(HttpStatusCode.OK, "Theater removed");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Error deleting theater");
                    }

                }

                connection.Close();



            }
        }
    }
}
