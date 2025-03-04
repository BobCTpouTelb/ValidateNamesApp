using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using ValidateNames_WPF.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ValidateNames_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string JSON_PATH = "https://localhost:7172/api/User";
        private HttpClient _httpClient;
        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void getDataBTN_Click(object sender, RoutedEventArgs e)
        {
            var response = await _httpClient.GetStringAsync(JSON_PATH);
            namesLV.ItemsSource = JsonConvert.DeserializeObject<List<Models.User>>(response);
            User selectedUser = namesLV.SelectedItem as User;

            // Если выбранный пользователь не отсутствует в переменной..
            if (selectedUser != null)
            {
                // .. то, присваиваем ФИО в переменную _fullName, а значение из переменной _fullName передаём в сам TextBlock.
                string _fullname;
                fullNameTB.Text = _fullname = selectedUser.Fullname;
            }
            else // Иначе, ..
            {
                // .. отображаем сообщение об ошибке
                MessageBox.Show("Сначала выберите ФИО из списка.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void resultBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
