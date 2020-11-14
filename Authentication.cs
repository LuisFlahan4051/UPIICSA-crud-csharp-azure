using System.Data.SqlClient;
using System.Windows.Forms;

namespace zapatosUPIICSA
{
    class Authentication
    {
        Connect newConnection = new Connect();

        

        public MainUserCapsule authentication(string user, string password)
        {
            SqlConnection connection = newConnection.getConnection();
            SqlCommand statement;
            SqlDataReader results;
            MainUserCapsule userCapsule = new MainUserCapsule();
            
            try
            {
                connection.Open();
                
                statement = new SqlCommand("SELECT * FROM users WHERE " +
                    "(name_user = @user AND password_user = @password) " +
                    "or (email_user = @user and password_user = @password) " +
                    "or(phone_user = @user and password_user = @password)", connection);
                statement.Parameters.AddWithValue("@user", user);
                statement.Parameters.AddWithValue("@password", password);
                
                results = statement.ExecuteReader();
                while (results.Read())
                {
                    userCapsule.Id_user = results.GetInt32(0);
                    userCapsule.Name_user = results.GetString(1);
                    userCapsule.Password_user = results.GetString(2);
                    userCapsule.Email_user = results.GetString(3);
                    userCapsule.Phone_user = results.GetString(4);
                }
                
                connection.Close();
                return userCapsule;
            } catch (SqlException e)
            {
                MessageBox.Show("Error en obtener el usuario" + e.Message);
                connection.Close();
                return null;
            }

        }

    }
}
