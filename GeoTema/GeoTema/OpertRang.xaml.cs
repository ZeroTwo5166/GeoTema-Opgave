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
    /// Interaction logic for OpertRang.xaml
    /// </summary>
    public partial class OpertRang : Window
    {
        public OpertRang()
        {
            InitializeComponent();
            LoadGridRang();
        }

        SqlConnection con = new SqlConnection("Data Source=10.0.4.116;Initial Catalog=GeoTema;User ID=subarna;Password=DryOrc5166; Encrypt=False");

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
        private void opret_btn_Click(object sender, RoutedEventArgs e)
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

        private void rediger_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Rang set Rang = '" + rang_txt.Text + "',Fødselsrate = '" + fødselsrate_txt.Text +  "' WHERE Id = '" + id_txt.Text + "' ", con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Rang data er opdateret", "Opdateret", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                ClearData();
                LoadGridRang();


            }
        }

        private void slet_btn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Rang WHERE Id = " + id_txt.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Rang data slettet", "Slettet", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                ClearData();
                LoadGridRang();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Rang data bliver ikke slettet.");
            }
            finally
            {
                con.Close();
            }
        }

        private void tilbage_btn_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void ClearData()
        {
            id_txt.Clear();
            rang_txt.Clear();
            fødselsrate_txt.Clear();
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

    }
}
