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
    /// Interaction logic for OpretLandSU.xaml
    /// </summary>
    public partial class OpretLandSU : Window
    {
        public OpretLandSU()
        {
            InitializeComponent();
            LoadGridLand();
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

        private void ClearData()
        {
            id_txt.Clear();
            land_txt.Clear();
            verdensdel1_txt.Clear();
            verdensdel2_txt.Clear();

        }


        private void opret_btn_Click(object sender, RoutedEventArgs e)
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


                    MessageBox.Show("Land data oprettet", "Gemt", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                    LoadGridLand();
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
            SqlCommand cmd = new SqlCommand("UPDATE Land set Land = '" + land_txt.Text + "',Verdensdel_1 = '" + verdensdel1_txt.Text + "', Verdensdel_2 = '" + verdensdel2_txt.Text + "' WHERE Id = '" + id_txt.Text + "' ", con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Land data er opdateret", "Opdateret", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                ClearData();
                LoadGridLand();


            }

        }

        private void slet_btn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Land WHERE Id = " + id_txt.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Land data slettet", "Slettet", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                ClearData();
                LoadGridLand();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Land data bliver ikke slettet.");
            }
            finally
            {
                con.Close();
            }
        }

        private void tilbage_btn_Click(object sender, RoutedEventArgs e)
        {
            SuperUserWindow suWindow = new SuperUserWindow();
            suWindow.Show();
            this.Close();
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


    }
}
