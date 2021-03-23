using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLCuaHangDienThoai.Entity
{
    class SQLServer
    {
        // private static readonly string tenServer = @"DESKTOP-L9SU1OT\SQLEXPRESS";
        private static readonly string tenServer = @"LAPTOP-I7PSPJDI\SQLEXPRESS";
        private static readonly string tenDataBase = "QLCuaHangDienThoaiDb";

        private static readonly string strConnect = "Data Source=" + tenServer + ";Initial Catalog=" +
            "" + tenDataBase + ";Integrated Security=True";


        public static bool ThucHienCauLenh(string strQuerry)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strConnect);
                connection.Open();
                SqlCommand command = new SqlCommand(strQuerry, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DataTable LayDuLieu(string strQuerry)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strConnect);
                connection.Open();
                SqlCommand command = new SqlCommand(strQuerry, connection);
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                sqlData.Fill(data);
                connection.Close();
                return data;
            }
            catch
            {
                MessageBox.Show("Lấy dữ liệu lỗi");
                return null;
            }

        }
    }
}
