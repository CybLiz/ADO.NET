using DAO.Classes;
using Microsoft.Data.SqlClient;



namespace DAO.Dao
{
    internal class OrderDAO : BaseDao<Order>
    {
        public override Order Save(Order entity)
        {
              request = "INSERT INTO Orders (dateOrder, totalAmount, client_id) " +
                  "VALUES (@DateOrder, @TotalAmount, @ClientId); " +
                  "SELECT CAST(SCOPE_IDENTITY() as int);";


                using SqlConnection connection = DataConnection.GetConnection;
                using SqlCommand command = new SqlCommand(request, connection);

                command.Parameters.AddWithValue("@DateOrder", entity.DateOrder);
                command.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
                command.Parameters.AddWithValue("@ClientId", entity.ClientId);

                connection.Open();
                entity.Id = (int)command.ExecuteScalar();

                return entity;

        }
        public override Order Update(Order entity)
        {
            request = "UPDATE Orders SET dateOrder = @DateOrder, totalAmount = @TotalAmount, client_id = @ClientId WHERE idOrder = @Id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@DateOrder", entity.DateOrder);
            command.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
            command.Parameters.AddWithValue("@ClientId", entity.ClientId);
            command.Parameters.AddWithValue("@Id", entity.Id);

            connection.Open();
            command.ExecuteNonQuery();

            return entity;
        }
        public override List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();

            request = "SELECT * FROM Orders";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Order order = new Order(reader.GetInt32(0),
                                           reader.GetDateTime(1),
                                           reader.GetDecimal(2),
                                           reader.GetInt32(3));
                orders.Add(order);
            }
            return orders;
        }
        public override Order GetById(int id)
        {
            Order? order = null;
            request = "SELECT * FROM Orders WHERE idOrder = @Id";
            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                order = new Order(reader.GetInt32(0),
                                    reader.GetDateTime(1),
                                    reader.GetDecimal(2),
                                    reader.GetInt32(3));
            }
            return order;
        }
        public override void DeleteById(int id)
        {
            Order? order = null;
            request = "DELETE FROM Orders WHERE idOrder = @Id";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@Id", id);
            connection.Open();

            command.ExecuteNonQuery();

        }
    }
}
