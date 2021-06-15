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
    /// Логика взаимодействия для AddEditExtDoc.xaml
    /// </summary>
    public partial class AddEditExtDoc : Window
    {
        public AddEditExtDoc()
        {
            InitializeComponent();
          
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

        public AddEditExtDoc(ViewExternalDocuments document)
        {
            InitializeComponent();

            CmbImportance.ItemsSource = context.TypeOfImportance.ToList();
            CmbImportance.DisplayMemberPath = "ImportanceName";
            CmbImportance.SelectedIndex = document.IdImportance;

            CmbResp.ItemsSource = context.ViewPersons.ToList();
            CmbResp.DisplayMemberPath = "Person";
            CmbResp.SelectedIndex = document.IdPerson - 1;

            CmbType.ItemsSource = context.TypeOfDocument.ToList();
            CmbType.DisplayMemberPath = "TypeName";
            CmbType.SelectedIndex = document.IdDocumentType - 1;

            DPDate.SelectedDate = document.CreationDate;
            TxtSrok.Text = document.PeriodOfExecution;

            TxtIsxNomer.Text = document.OutgoingNumber;
            TxtVxNomer.Text = document.IncomingNumber;
            TxtWhereTo.Text = document.FromWhere_Or_WhereTo;



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
                    addDoc.ResponsiblePerson = CmbResp.SelectedIndex + 1;
                    addDoc.PeriodOfExecution = TxtSrok.Text;
                    addDoc.Comments = TxtComments.Text;


                    context.Document.Add(addDoc);
                    context.SaveChanges();

                    IfDocumentIsExternal addExt = new IfDocumentIsExternal();
                    addExt.FromWhere_Or_WhereTo = TxtWhereTo.Text;
                    addExt.IncomingNumber = TxtVxNomer.Text;
                    addExt.OutgoingNumber = TxtIsxNomer.Text;
                    addExt.IdDocument = addDoc.IdDocument;

                    context.IfDocumentIsExternal.Add(addExt);
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
                    editDoc.ResponsiblePerson = CmbResp.SelectedIndex + 1;
                    editDoc.PeriodOfExecution = TxtSrok.Text;
                    editDoc.Comments = TxtComments.Text;

                    context.SaveChanges();

                    var editExt = context.IfDocumentIsExternal.Where(i => i.IdDocument == VarId).FirstOrDefault();
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

                    context.IfDocumentIsExternal.Remove(context.IfDocumentIsExternal.Where(i => i.IdDocument == VarId).FirstOrDefault());
                    context.SaveChanges();

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
