using MoviesApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.IO;

// dao open in vs

namespace MoviesApi.Repositories
{
    public class MovieRepository : IMovieRepository

    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MotionPictures;Integrated Security=True;";
        public Movie GetMovieById(int id)
        {
            string queryString = "SELECT * from dbo.MotionPictures WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Movie movie = new Movie();

                    movie.ID = -1;

                    while (reader.Read())
                    {
                        movie.ID = (int)reader["ID"];
                        movie.Name = reader["Name"].ToString();
                        movie.Description = reader["Description"].ToString();
                        movie.ReleaseYear = (int)reader["ReleaseYear"];
                        movie.AcademyAward = (bool)reader["AcademyAward"];
                        movie.DirectorId = reader["DirectorId"].GetType() == typeof(System.DBNull) ? null : (int)reader["DirectorId"];
                    }
                    return movie;

                }

            }

        }

        public List<Movie> GetMovies()
        {
            string queryString = "SELECT * from dbo.MotionPictures;";
            List<Movie> results = new List<Movie>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new Movie()
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            ReleaseYear = (int)reader["ReleaseYear"],
                            AcademyAward = (bool)reader["AcademyAward"],
                            DirectorId = reader["DirectorId"].GetType() == typeof(System.DBNull) ? null : (int)reader["DirectorId"]
                        });
                    }
                }
            }

            return results;
        }

        public bool InsertMovie(Movie movie)
        {
            string queryString = "INSERT into dbo.MotionPictures (Name, Description, ReleaseYear, AcademyAward, DirectorId) VALUES (@Name,@Description,@ReleaseYear,@AcademyAward,@DirectorId);";
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                using (command)
                {
                    command.Parameters.AddWithValue("@Name", movie.Name);
                    command.Parameters.AddWithValue("@Description", movie.Description);
                    command.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear);
                    command.Parameters.AddWithValue("@AcademyAward", movie.AcademyAward);
                    command.Parameters.AddWithValue("@DirectorId", movie.DirectorId);
                    
                    rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
                
                return rowsAffected > 0;
            }
        }

        public bool MovieExists(int id)
        {
            throw new NotImplementedException();
        }

        public Movie UpdateMovie(Movie movie)
        {
            string queryString = "UPDATE dbo.MotionPictures SET Name = @Name, Description = @Description, ReleaseYear = @ReleaseYear, AcademyAward = @AcademyAward, DirectorId = @DirectorId WHERE ID = @ID";
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                { 
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                    using (command)
                    {
                        command.Parameters.AddWithValue("@Name", movie.Name);
                        command.Parameters.AddWithValue("@Description", movie.Description);
                        command.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear);
                        command.Parameters.AddWithValue("@AcademyAward", movie.AcademyAward);
                        command.Parameters.AddWithValue("@DirectorId", movie.DirectorId);
                        command.Parameters.AddWithValue("@ID", movie.ID);

                        rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected);

                        if (rowsAffected != 0)
                        {
                            return movie;
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.Write("There was an error");
                }
                finally
                {
                    connection.Close();
                }
                return null;

            }
        }

        public bool DeleteMovie(int id)
        {
            string queryString = "DELETE from dbo.MotionPictures WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                using (command)
                {
                    command.Parameters.AddWithValue("@ID", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        return false;
                    }
                    return true;
                }
                
            }
        }

    }

}
