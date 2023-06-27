using prac_s_ergis.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace prac_s_ergis.View
{
    /// <summary>
    /// Логика взаимодействия для ProductView.xaml
    /// </summary>
    public partial class ProductView : Page
    {
        public ProductView()
        {
            InitializeComponent();

            

        }
        static DataTable ExecuteSql(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(
                "Data Source=.\\SQLEXPRESS;Integrated Security=True;Initial Catalog=base"
                );

            using (conn)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader read = cmd.ExecuteReader();

                using (read)
                {
                    dt.Load(read);
                }
            }

            return dt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = ExecuteSql("SELECT * FROM product_b_import");
            lv_product.ItemsSource = dt.DefaultView;
        }
    }
}

