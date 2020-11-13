using System.Data.SqlClient;
using System.Windows.Forms;

namespace zapatosUPIICSA
{
    class Connect
    {

        public SqlConnection getConnection()
        {
            //BD in Azure.
            //string connectionString = "Server=tcp:servidor-proyectos-upiicsa.database.windows.net,1433;Initial Catalog=zapatosUPIICSA-dbazure;Persist Security Info=False;User ID=administrador;Password=404080loisSQLServer;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            //BD for testing.
            string connectionString = "data source = (localdb)\\MSSQLLocalDB; initial catalog = zapatosUPIICSA; user id = root; password = root";            
            
            SqlConnection connection;

            try
            {
                connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (SqlException e)
            {
                MessageBox.Show("¡Conexión fallida! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public SqlDataReader testConnectionQuery(string query)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand statement;
            SqlDataReader results;
            

            try
            {
                statement = new SqlCommand(query, connection);
                results = statement.ExecuteReader();

                while (results.Read())
                {
                    MessageBox.Show(results.GetValue(0) + " " + results.GetValue(2));
                }
                connection.Close();
                return results;
            }
            catch (SqlException e)
            {
                MessageBox.Show("No se ejecutó la consulta! " + e.Message);
                connection.Close();
                return null;
            }
        }
    }
}
