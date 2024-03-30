using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.SqlClient;
using System.Data;

namespace lab03dapa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DataTable dataTable;
        public MainWindow()
        {
            InitializeComponent();
            dataTable = new DataTable();

        } 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-30\\SQLEXPRESS; Initial Catalog=LaMiel;User Id=eber; Password=123456;";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);

                connection.Close();

                waza.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-30\\SQLEXPRESS; Initial Catalog=LaMiel;User Id=eber; Password=123456;";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);

                SqlDataReader reader = command.ExecuteReader();

                dataTable.Clear();

                while (reader.Read())
                {
                    DataRow row = dataTable.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }
                    dataTable.Rows.Add(row);
                }

                connection.Close();

                waza.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

};