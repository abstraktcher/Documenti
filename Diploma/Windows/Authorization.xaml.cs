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
using System.Windows.Shapes;using Diploma.AppData;
using static Diploma.AppData.AppDataClass;

namespace Diploma.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            var accountPerson = context.Person.ToList().Where(i => i.IdPerson == Convert.ToInt32( TextLogin.Text) && i.Password == TextPassword.Password).FirstOrDefault();

            if (accountPerson == null)
            {
                MessageBox.Show("Wrong Id or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (accountPerson is Person person)
                {
                    VarCheckRole = accountPerson.IdPerson;
                    MainWindow main = new MainWindow();
                    this.Hide();
                    main.Show();
                    this.Close();
                }
              
                }
            }

        }
    }
