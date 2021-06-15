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
    /// Логика взаимодействия для AddPerson.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        public AddPerson()
        {
            InitializeComponent();
            CmbDepartment.ItemsSource = context.Department.ToList();
            CmbDepartment.DisplayMemberPath = "DepartmentName";
            CmbDepartment.SelectedIndex = 0;

            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "IdGender";
            CmbGender.SelectedIndex = 0;

            CmbPosition.ItemsSource = context.Position.ToList();
            CmbPosition.DisplayMemberPath = "PositionName";
        }

        public AddPerson(ViewPersons person)
        {
            InitializeComponent();
            CmbDepartment.ItemsSource = context.Department.ToList();
            CmbDepartment.DisplayMemberPath = "DepartmentName";
            CmbDepartment.SelectedIndex = person.IdDepartment - 1;

            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "IdGender";
            CmbGender.SelectedItem = person.Gender ;

            CmbPosition.ItemsSource = context.Position.ToList();
            CmbPosition.DisplayMemberPath = "PositionName";
            CmbPosition.SelectedIndex = person.IdPosition - 1;

            TxtPhone.Text = person.PhoneNumber;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var result = MessageBox.Show("Вы точно хотите удалить?", "Удаление",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    context.Person.Remove(context.Person.Where(i => i.IdPerson == VarId).FirstOrDefault());
                    context.SaveChanges();

                    MessageBox.Show("Removing ", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);




                }
        }

            catch
            {
                MessageBox.Show("Error ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (VarId == 0)
                {
                    Person addPers = new Person();
                    addPers.FirstName = TxtName.Text;
                    addPers.LastName = TxtLName.Text;
                    addPers.MiddleName = TxtMName.Text;
                    addPers.DateOfBirth = (DateTime)DPDate.SelectedDate;
                    addPers.DateOfHiring = (DateTime)DPHire.SelectedDate;

                    addPers.IdDepartment = CmbDepartment.SelectedIndex + 1;
                    addPers.IdPosition = CmbPosition.SelectedIndex + 1;
                    addPers.Password = TxtPassword.Text;
                    addPers.Address = TxtAddress.Text;
                    addPers.Gender = (string)CmbGender.SelectedItem;
                    addPers.Email = TxtEmail.Text;


                    context.Person.Add(addPers);
                    context.SaveChanges();
                    MessageBox.Show("Успешно добавлено", "Успешно изменено", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Close();
                }
                else
                {
                    var editDoc = context.Person.Where(i => i.IdPerson == VarId).FirstOrDefault();

                    editDoc.FirstName = TxtName.Text;
                    editDoc.LastName = TxtLName.Text;
                    editDoc.MiddleName = TxtMName.Text;
                    editDoc.DateOfBirth = (DateTime)DPDate.SelectedDate;
                    editDoc.DateOfHiring = (DateTime)DPHire.SelectedDate;

                    editDoc.IdDepartment = CmbDepartment.SelectedIndex + 1;
                    editDoc.IdPosition = CmbPosition.SelectedIndex + 1;
                    editDoc.Password = TxtPassword.Text;
                    editDoc.Address = TxtAddress.Text;
                    if(CmbGender.SelectedIndex == 0)
                    editDoc.Gender = (string)CmbGender.SelectedItem;
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
    }
}
