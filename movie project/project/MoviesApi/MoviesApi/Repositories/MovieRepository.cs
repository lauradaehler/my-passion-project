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
            string queryString =
                "SELECT * from dbo.MotionPictures WHERE ID = @ID;";

            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = id;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Movie movie = new Movie();

                    while (reader.Read())
                    {
                        movie.ID = (int)reader["ID"];
                        movie.Name = reader["Name"].ToString();
                        movie.Description = reader["Description"].ToString();
                        movie.ReleaseYear = (int)reader["Release Year"];
                        movie.AcademyAward = (bool)reader["AcademyAward"];
                        movie.DirectorId = reader["DirectorId"].GetType() == typeof(System.DBNull) ? null : (int)reader["DirectorId"];   
                    }
                    return movie;


                }


            }

            //throw new NotImplementedException();


        }

        public List<Movie> GetMovies()
        {
            string queryString =
                "SELECT * from dbo.MotionPictures;";
            List<Movie> results = new List<Movie>();

            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
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
                            ReleaseYear = (int)reader["Release Year"],
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
            string queryString =
                "INSERT into dbo.MotionPictures ([Name], [Description], [Release Year], [AcademyAward], [DirectorId]) VALUES ('{Param[0]}','{Param[1]}','{Param[2]}','{Param[3]}', '{Param[4]}')";

            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                {
                    try
                    {
                        var result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return true;
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }
                    return false;


                }



            }

            throw new NotImplementedException();
        }

        public bool MovieExists(int id)
        {
            throw new NotImplementedException();
        }

        public Movie UpdateMovie(Movie movie, int id)
        {
            string queryString =
                "UPDATE dbo.MotionPictures ([Name], [Description], [Release Year], [AcademyAward], [DirectorId]) VALUES (?,?,?,?,?)";

            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                throw new NotImplementedException();
            }
        }

        public bool DeleteMovie(int id)
        {
            string queryString =
                "DELETE from dbo.MotionPictures WHERE ID = @ID;";
            try
            {
                using (SqlConnection connection = new SqlConnection(
                           connectionString))
                {
                    SqlCommand command = new SqlCommand(
                        queryString, connection);
                    command.Parameters.Add("@ID", SqlDbType.Int);
                    command.Parameters["@ID"].Value = id;

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        return false;
                    }

                    return true;
                    //throw new NotImplementedException();
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
