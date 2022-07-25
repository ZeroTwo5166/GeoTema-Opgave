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
using System.Windows.Shapes;

namespace GeoTema
{
    /// <summary>
    /// Interaction logic for OpretBruger.xaml
    /// </summary>
    public partial class OpretBruger : Window
    {
        public OpretBruger()
        {
            InitializeComponent();
            LoadGrid();
        }

        SqlConnection con = new SqlConnection("Data Source=10.0.4.116;Initial Catalog=GeoTema;User ID=subarna;Password=DryOrc5166; Encrypt=False");

        private void opret_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem ComboItem = (ComboBoxItem)ComboBoxUser.SelectedItem;
            string user = ComboItem.Name;
            //string user = ComboBoxUser.SelectedItem.ToString();

            int userrole = 0;

            if (user == "Admin")
                userrole = 1101;

            else if (user == "SuperBruger")
                userrole = 1110;
            else if (user == "NormalBruger")
                userrole = 1011;

            else
                userrole = 1011;



            try
            {
                if (IsValidForUser())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES (@BrugerNavn, @Adgangskode, @UserRole)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@BrugerNavn", brugernavn.Text);
                    cmd.Parameters.AddWithValue("@Adgangskode", adgangskode.Text);
                    cmd.Parameters.AddWithValue("@UserRole", userrole);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    MessageBox.Show("Bruger oprettet", "Gemt", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                    LoadGrid();
                    
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show(msg, "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private bool IsValidForUser()
        {
            if (brugernavn.Text == string.Empty)
            {
                MessageBox.Show("Indtast Brugernavn", "FEJL", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (adgangskode.Text == string.Empty)
            {
                MessageBox.Show("Indtast Adgangskode", "FEJL", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void tilbage_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            admin.Show();
            this.Close();
        }

        private void ClearData()
        {
            id.Clear();
            brugernavn.Clear();
            adgangskode.Clear();
           
        }

        private void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("Select * from Users", con);

            con.Open();

            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            con.Close();

            datagridUsers.ItemsSource = dt.DefaultView;
        }

        private void slet_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID = " + id.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bruger slettet", "Slettet", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                ClearData();
                LoadGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Bruger bliver ikke slettet.");
            }
            finally
            {
                con.Close();
            }
        }

        private void rediger_Click(object sender, RoutedEventArgs e)
        {

            ComboBoxItem ComboItem = (ComboBoxItem)ComboBoxUser.SelectedItem;
            string user = ComboItem.Name;
            //string user = ComboBoxUser.SelectedItem.ToString();

            int userrole = 0;

            if (user == "Admin")
                userrole = 1101;

            else if (user == "SuperBruger")
                userrole = 1110;
            else if (user == "NormalBruger")
                userrole = 1011;

            else
                userrole = 1011;


            SqlCommand cmd = new SqlCommand("UPDATE Users set BrugerNavn = '" + brugernavn.Text + "',Adgangskode = '" + adgangskode.Text + "', UserRole = '" + userrole + "' WHERE UserID = '" + id.Text + "' ", con);


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bruger er opdateret", "Opdateret", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                ClearData();
                LoadGrid();


            }
        }
    }

}
