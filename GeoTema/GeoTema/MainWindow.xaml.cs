using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeoTema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        SqlConnection sqlCon = new SqlConnection(@"Data Source=10.0.4.116;Initial Catalog=GeoTema;User ID=subarna;Password=DryOrc5166; Encrypt=False");


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxUser.SelectedItem != null) 
            {
                string s1 = ComboBoxUser.SelectedValue.ToString();
                MessageBox.Show(s1);
            } 
                
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                string query = "SELECT UserRole FROM Users Where BrugerNavn=@BrugerNavn and Adgangskode=@Adgangskode";
                SqlCommand sqlCmd = new SqlCommand(query,sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@BrugerNavn", BrugerNavn.Text);
                sqlCmd.Parameters.AddWithValue("@Adgangskode", Adgangskode.Text);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                


                if(count == 1101) {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                }
                else if (count == 1110)
                {
                    SuperUserWindow superUserWindow = new SuperUserWindow();
                    superUserWindow.Show();
                    this.Close();
                }
                else if (count == 1011)
                {
                    StandardUserWindow standardUserWindow = new StandardUserWindow();
                    standardUserWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Brugernavn eller adgangskode er forkert");
                }
            
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlCon.Close();
            }
        
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
