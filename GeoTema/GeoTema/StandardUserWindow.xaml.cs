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
    /// Interaction logic for StandardUserWindow.xaml
    /// </summary>
    public partial class StandardUserWindow : Window
    {
        public StandardUserWindow()
        {
            InitializeComponent();
            LoadGrid();
            
        }

        private void LoadGrid()
        {
            string connectionstring = "Data Source=10.0.4.116;Initial Catalog=GeoTema;User ID=subarna;Password=DryOrc5166; Encrypt=False";
            SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("Select Land.ID, Land.Land, Land.Verdensdel_1, Land.Verdensdel_2, Rang.Rang, Rang.Fødselsrate from Land inner join Rang on Land.ID = Rang.ID", con);

            con.Open();

            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            con.Close();

            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        
    }
}
