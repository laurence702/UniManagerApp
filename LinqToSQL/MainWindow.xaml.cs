using System;
using System.Collections.Generic;
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
using System.Configuration;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //LinqToSqlDataClassesDataContext dataContext;
        LaurenceDBEntities db;

        public MainWindow()
        {
            InitializeComponent();
            //string connectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.LaurenceDBConnectionString"].ConnectionString;
            //dataContext = new LinqToSqlDataClassesDataContext(connectionString);

            db = new LaurenceDBEntities();           
        }

        public async Task InsertUniversities()
        {
            University yale = new University();

            yale.Name = "Stanford";
            //dataContext.Universities.InsertOnSubmit(yale);

           var uniList = db.Universities;
           
           await db.SaveChangesAsync();

            MainDataGrid.ItemsSource = uniList; 
           
            //dataContext.SubmitChanges();

            //MainDataGrid.ItemsSource = dataContext.Universities;
        }

        private void MainDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
           await  InsertUniversities();
        }
    }
}
