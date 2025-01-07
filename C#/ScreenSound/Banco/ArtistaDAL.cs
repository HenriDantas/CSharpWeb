using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        public IEnumerable<Artista> GetArtistas()
        {
            var lista = new List<Artista>();

            using (var connection = new Connection().Conectar())
            {
                connection.Open();

                string query = "SELECT * FROM Artistas";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nomeArtista = Convert.ToString(reader["Nome"]);
                        string bioArtista = Convert.ToString(reader["Bio"]);
                        int idArtista = Convert.ToInt32(reader["Id"]);

                        Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };

                        lista.Add(artista);
                    }
                }


            }

            return lista;
        }

        public void CreateArtista(Artista artista)
        {
            using (var connection = new Connection().Conectar())
            {
                connection.Open();

                string query = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";

                SqlCommand command = new SqlCommand(query, connection);

                //command.Parameters.Add(new SqlParameter()); n bota isso mds q da errorooo

                command.Parameters.AddWithValue("@nome", artista.Nome);
                command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
                command.Parameters.AddWithValue("@bio", artista.Bio);

                command.ExecuteNonQuery(); //that line is needed to execute change in DB

            }
        }

        public void UpdateArtista(Artista artista)
        {
            using (var connection = new Connection().Conectar())
            {
                connection.Open();

                string query = $"UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@nome", artista.Nome);
                command.Parameters.AddWithValue("@bio", artista.Bio);
                command.Parameters.AddWithValue("@fotoPerfil", artista.FotoPerfil);
                command.Parameters.AddWithValue("@id", artista.Id);

                int retorno = command.ExecuteNonQuery();
                Console.WriteLine($"Linhas afetadas: {retorno}");
            }

        }

        public void DeleteArtista(int id)
        {
            // recommended inativate artist but, this column dont exists in that situation

            using (var connection = new Connection().Conectar())
            {
                connection.Open();

                string query = "DELETE FROM Artistas WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

                int retorno = command.ExecuteNonQuery();
                Console.WriteLine($"Linhas afetadas: {retorno}");
            }
        }
    }
}
