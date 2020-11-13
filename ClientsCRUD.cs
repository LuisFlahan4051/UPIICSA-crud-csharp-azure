using System.Data.SqlClient;
using System.Windows.Forms;


namespace zapatosUPIICSA
{
    class ClientsCRUD
    {
        Connect newConnection = new Connect();



        public bool saveClient(string name, string email, string phone)
        {
            SqlConnection connection = newConnection.getConnection();
            SqlCommand statement;

            try
            {
                connection.Open();

                statement = new SqlCommand("INSERT INTO clients (name_client, email_client, phone_client) VALUES" +
                    "(@name, @email, @phone)", connection);
                statement.Parameters.AddWithValue("@name", name);
                statement.Parameters.AddWithValue("@email", email);
                statement.Parameters.AddWithValue("@phone", phone);
                statement.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("¡Se ha guardado correctamente!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("¡Error al guardado! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return false;
            }
        }

        public bool deleteClientById(string id)
        {
            SqlConnection connection = newConnection.getConnection();
            SqlCommand statement;

            try
            {
                connection.Open();

                statement = new SqlCommand("DELETE FROM clients WHERE id_client = @id", connection);
                statement.Parameters.AddWithValue("@id", id);
                statement.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("¡Se ha eliminado correctamente!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("¡Error al eliminar! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return false;
            }
        }

        public bool updateClient(string id, string name, string email, string phone)
        {
            SqlConnection connection = newConnection.getConnection();
            SqlCommand statement;

            try
            {
                connection.Open();

                statement = new SqlCommand("UPDATE clients SET name_client = @name, email_client = @email, phone_client = @phone WHERE id_client = @id", connection);
                statement.Parameters.AddWithValue("@name", @name);
                statement.Parameters.AddWithValue("@email", email);
                statement.Parameters.AddWithValue("@phone", phone);
                statement.Parameters.AddWithValue("id", id);
                statement.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("¡Se ha actualizado correctamente!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("¡Error al actualizar!" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return false;
            }
        }
    }
}
