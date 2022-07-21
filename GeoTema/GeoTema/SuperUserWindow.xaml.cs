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
    /// Interaction logic for SuperUserWindow.xaml
    /// </summary>
    public partial class SuperUserWindow : Window
    {
        public SuperUserWindow()
        {
            InitializeComponent();
            LoadGridLand();
            LoadGridRang();
        }

        SqlConnection con = new SqlConnection("Data Source=10.0.4.116;Initial Catalog=GeoTema;User ID=subarna;Password=DryOrc5166; Encrypt=False");

        private void LoadGridLand()
        {

            SqlCommand cmd = new SqlCommand("Select * from Land", con);

            con.Open();

            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            con.Close();

            datagridLand.ItemsSource = dt.DefaultView;
        }

        private void LoadGridRang()
        {

            SqlCommand cmd = new SqlCommand("Select * from Rang", con);

            con.Open();

            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            con.Close();

            datagridRang.ItemsSource = dt.DefaultView;
        }

        public bool IsValidForLand()
        {
            if (land_txt.Text == string.Empty)
            {
                MessageBox.Show("Indtast Land", "FEJL", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (verdensdel1_txt.Text == string.Empty)
            {
                MessageBox.Show("Indtast Verdensdel 1", "FEJL", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (verdensdel2_txt.Text == string.Empty)
            {
                MessageBox.Show("Indtast Verdensdel 2", "FEJL", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        private void ClearData()
        {
            id_txt.Clear();
            land_txt.Clear();
            verdensdel1_txt.Clear();
            verdensdel2_txt.Clear();
            rang_txt.Clear();
            fødselsrate_txt.Clear();
        }

        public bool IsValidForRang()
        {
            if (rang_txt.Text == string.Empty)
            {
                MessageBox.Show("Indtast Rang", "FEJL", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (fødselsrate_txt.Text == string.Empty)
            {
                MessageBox.Show("Indtast Fødselsrate", "FEJL", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void opretLand_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsValidForLand())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Land VALUES (@Land, @Verdensdel1, @Verdensdel2)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Land", land_txt.Text);
                    cmd.Parameters.AddWithValue("@Verdensdel1", verdensdel1_txt.Text);
                    cmd.Parameters.AddWithValue("@Verdensdel2", verdensdel2_txt.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGridLand();
                    

                    MessageBox.Show("Land data oprettet", "Gemt", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show(msg, "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void logud_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void opretRang_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsValidForRang())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Rang VALUES (@Rang, @Fødselsrate)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Rang", rang_txt.Text);
                    cmd.Parameters.AddWithValue("@Fødselsrate", fødselsrate_txt.Text);
                    

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGridRang();

                    MessageBox.Show("Rang data oprettet", "Gemt", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show(msg, "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
