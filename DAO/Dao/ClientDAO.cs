using DAO.Classes;
using Microsoft.Data.SqlClient;

namespace DAO.Dao
{
    internal class ClientDAO : BaseDao<Client>
    {
        public override List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();
            request = "SELECT * FROM Client";
            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Client client = new Client(reader.GetInt32(0),
                                           reader.GetString(1),
                                           reader.GetString(2),
                                           "","","","");
                clients.Add(client);
            }
            return clients;
        }

        public override Client? GetById(int id)
        {
            Client? client = null;
            request = "SELECT * FROM Client WHERE idClient = @Id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@Id", id);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                client = new Client(reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetString(5),
                                    reader.GetString(6));
            }
            return client;
        }

        public override Client Save(Client entity)
        {
            request = "INSERT INTO Client (nom, prenom, email, telephone, adresse, codePostal) " +
                      "OUTPUT INSERTED.idClient " +
                      "VALUES (@Nom, @Prenom, @Email, @Telephone, @Adresse, @CodePostal)";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@Nom", entity.Nom);
            command.Parameters.AddWithValue("@Prenom", entity.Prenom);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@Telephone", entity.Telephone);
            command.Parameters.AddWithValue("@Adresse", entity.Adresse);
            command.Parameters.AddWithValue("@CodePostal", entity.CodePostal);

            connection.Open();
            entity.Id = (int)command.ExecuteScalar();
            return entity;
        }


        public override Client Update(Client entity)
        {
            request = "UPDATE Client SET nom = @Nom, prenom = @Prenom, email = @Email, " +
                      "Telephone = @Telephone, Adresse = @Adresse, CodePostal = @CodePostal " +
                      "WHERE idClient = @Id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@Nom", entity.Nom);
            command.Parameters.AddWithValue("@Prenom", entity.Prenom);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@Telephone", entity.Telephone);
            command.Parameters.AddWithValue("@Adresse", entity.Adresse);
            command.Parameters.AddWithValue("@CodePostal", entity.CodePostal);
            command.Parameters.AddWithValue("@Id", entity.Id);

            connection.Open();
            command.ExecuteNonQuery();

            return entity;
        }

        public override void DeleteById(int id)
        {
            request = "DELETE FROM Client WHERE idClient = @Id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }

    }
}
