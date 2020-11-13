using System.Data.SqlClient;
using System.Windows.Forms;


namespace zapatosUPIICSA
{
    class ModelsCRUD
    {
        Connect newConnection = new Connect();



        public bool saveModel(string model, string size, string type, string color)
        {
            SqlConnection connection = newConnection.getConnection();
            SqlCommand statement;

            try
            {
                connection.Open();

                statement = new SqlCommand("INSERT INTO models (model_model, size_model, type_model, color_model) VALUES" +
                    "(@model, @size, @type, @color)", connection);
                statement.Parameters.AddWithValue("@model", model);
                statement.Parameters.AddWithValue("@size", size);
                statement.Parameters.AddWithValue("@type", type);
                statement.Parameters.AddWithValue("@color", color);
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

        public bool deleteModelById(string id)
        {
            SqlConnection connection = newConnection.getConnection();
            SqlCommand statement;

            try
            {
                connection.Open();

                statement = new SqlCommand("DELETE FROM models WHERE id_model = @id", connection);
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

        public bool updateModel(string id, string model, string size, string type, string color)
        {
            SqlConnection connection = newConnection.getConnection();
            SqlCommand statement;

            try
            {
                connection.Open();

                statement = new SqlCommand("UPDATE models SET model_model = @model, size_model = @size, type_model = @type, color_model = @color WHERE id_model = @id", connection);
                statement.Parameters.AddWithValue("@model", model);
                statement.Parameters.AddWithValue("@size", size);
                statement.Parameters.AddWithValue("@type", type);
                statement.Parameters.AddWithValue("@color", color);
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
