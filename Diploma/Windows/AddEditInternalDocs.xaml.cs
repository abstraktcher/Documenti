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
    /// Логика взаимодействия для AddEditInternalDocs.xaml
    /// </summary>
    public partial class AddEditInternalDocs : Window
    {
        public AddEditInternalDocs()
        {
            InitializeComponent();

            CmbDepartment.ItemsSource = context.Department.ToList();
            CmbDepartment.DisplayMemberPath = "DepartmentName";
            CmbDepartment.SelectedIndex = 0;

            CmbImportance.ItemsSource = context.TypeOfImportance.ToList();
            CmbImportance.DisplayMemberPath = "ImportanceName";
            CmbImportance.SelectedIndex = 0;

            CmbResp.ItemsSource = context.ViewPersons.ToList();
            CmbResp.DisplayMemberPath = "Person";
            CmbResp.SelectedIndex = 0;

            CmbType.ItemsSource = context.TypeOfDocument.ToList();
            CmbType.DisplayMemberPath = "TypeName";
            CmbType.SelectedIndex = 0;

        }

        public AddEditInternalDocs(ViewInternalDocuments document)
        {
            InitializeComponent();
            CmbDepartment.ItemsSource = context.Department.ToList();
            CmbDepartment.DisplayMemberPath = "DepartmentName";
            CmbDepartment.SelectedIndex = document.IdDepartment;

            CmbImportance.ItemsSource = context.TypeOfImportance.ToList();
            CmbImportance.DisplayMemberPath = "ImportanceName";
            CmbImportance.SelectedIndex = document.IdImportance;

            CmbResp.ItemsSource = context.ViewPersons.ToList();
            CmbResp.DisplayMemberPath = "Person";
            CmbResp.SelectedIndex = document.IdPerson;

            CmbType.ItemsSource = context.TypeOfDocument.ToList();
            CmbType.DisplayMemberPath = "TypeName";
            CmbType.SelectedIndex = document.IdDocumentType;

            DPDate.SelectedDate = document.CreationDate;
            TxtSrok.Text = document.PeriodOfExecution;


        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (VarId == 0)
                {
                    Document addDoc = new Document();
                    addDoc.IdDocumentType = CmbImportance.SelectedIndex + 1;
                    addDoc.CreationDate = (DateTime)DPDate.SelectedDate;
                    addDoc.IdImportance = CmbImportance.SelectedIndex + 1;
                    addDoc.IsInternal = true;
                    addDoc.IdCreator = VarCheckRole;
                    addDoc.WhereIsItDirected_IdDepartment = CmbDepartment.SelectedIndex + 1;
                    addDoc.ResponsiblePerson = CmbResp.SelectedIndex + 1;
                    addDoc.PeriodOfExecution = TxtSrok.Text;
                    addDoc.Comments = TxtComments.Text;


                    context.Document.Add(addDoc);
                    context.SaveChanges();
                    MessageBox.Show("Успешно добавлено", "Успешно изменено", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Close();
                }
                else
                {
                    var editDoc = context.Document.Where(i => i.IdDocument == VarId).FirstOrDefault();

                    editDoc.IdDocumentType = CmbImportance.SelectedIndex + 1;
                    editDoc.CreationDate = (DateTime)DPDate.SelectedDate;
                    editDoc.IdImportance = CmbImportance.SelectedIndex + 1;
                    editDoc.IsInternal = true;
                    editDoc.IdCreator = VarCheckRole;
                    editDoc.WhereIsItDirected_IdDepartment = CmbDepartment.SelectedIndex + 1;
                    editDoc.ResponsiblePerson = CmbResp.SelectedIndex + 1;
                    editDoc.PeriodOfExecution = TxtSrok.Text;
                    editDoc.Comments = TxtComments.Text;

                    context.SaveChanges();
                    VarId = 0;
                    MessageBox.Show("Успешно", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Close();
                }
            }
            
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                    var result = MessageBox.Show("Вы точно хотите удалить?", "Удаление",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.Document.Remove(context.Document.Where(i => i.IdDocument == VarId).FirstOrDefault());
                        context.SaveChanges();
                        MessageBox.Show("Removing ", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);


                    }
                }
            
            catch
            {
                MessageBox.Show("Error ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
