using System.Data.SqlClient;
using System.Windows.Forms;

namespace zapatosUPIICSA
{
    class UsersCRUD
    {
        Connect newConnection = new Connect();

        

        public bool saveUser(string name, string password, string email, string phone)
        {
            SqlConnection connection = newConnection.getConnection();
            SqlCommand statement;

            try
            {
                connection.Open();

                statement = new SqlCommand("INSERT INTO users (name_user, password_user, email_user, phone_user) VALUES" +
                    "(@name, @password, @email, @phone)", connection);
                statement.Parameters.AddWithValue("@name", name);
                statement.Parameters.AddWithValue("@password", password);
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

        public bool deleteUserById(string id)
        {
            SqlConnection connection = newConnection.getConnection();
            SqlCommand statement;

            try
            {
                connection.Open();

                statement = new SqlCommand("DELETE FROM users WHERE id_user = @id" , connection);
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

        public bool updateUser(string id, string name, string password, string email, string phone)
        {
            SqlConnection connection = newConnection.getConnection();
            SqlCommand statement;

            try
            {
                connection.Open();

                statement = new SqlCommand("UPDATE users SET name_user = @name, password_user = @password, email_user = @email, phone_user = @phone WHERE id_user = @id", connection);
                statement.Parameters.AddWithValue("@name", name);
                statement.Parameters.AddWithValue("@password", password);
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
