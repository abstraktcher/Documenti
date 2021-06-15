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
using Diploma.Windows;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnDocuments_Click(object sender, RoutedEventArgs e)
        {
            InternalDocuments window = new InternalDocuments();
            this.Opacity = 0.3;
            window.ShowDialog();
            this.Opacity = 1;
        }

        private void BtnPersons_Click(object sender, RoutedEventArgs e)
        {
            Persons window = new Persons();
            this.Opacity = 0.3;
            window.ShowDialog();
            this.Opacity = 1;
        }

        private void BtnExternalDocuments_Click(object sender, RoutedEventArgs e)
        {
            ExternalDocuments window = new ExternalDocuments();
            this.Opacity = 0.3;
            window.ShowDialog();
            this.Opacity = 1;

        }
    }
}
