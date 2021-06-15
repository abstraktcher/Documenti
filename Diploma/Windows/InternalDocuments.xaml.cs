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
using System.Windows.Shapes;
using Diploma.AppData;
using static Diploma.AppData.AppDataClass;


namespace Diploma.Windows
{
    /// <summary>
    /// Логика взаимодействия для InternalDocuments.xaml
    /// </summary>
    public partial class InternalDocuments : Window
    {
        public InternalDocuments()
        {
            InitializeComponent();
            ListViewInternalDocs.ItemsSource = context.ViewInternalDocuments.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewInternalDocs.SelectedItem is ViewInternalDocuments document)
                {
                    VarId = document.IdDocument;
                    AddEditInternalDocs addEdit = new AddEditInternalDocs(ListViewInternalDocs.SelectedItem as ViewInternalDocuments);
                    this.Opacity = 0.3;
                    addEdit.ShowDialog();
                    this.Opacity = 1;
                }
                else
                {
                    MessageBox.Show("Выберите документ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddDocument_Click(object sender, RoutedEventArgs e)
        {
            AddEditInternalDocs window = new AddEditInternalDocs();
            this.Opacity = 0.3;
            window.ShowDialog();
            this.Opacity = 1;

        }
    }
}
