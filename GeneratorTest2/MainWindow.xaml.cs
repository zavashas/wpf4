using GeneratorTest2;
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


namespace GeneratorTest2
{
    public partial class MainWindow : Window
    {
        private string testFilePath = "test2.xml";
        private UserWindow userWindow;
        private string correctPassword = "слово";

        public MainWindow()
        {
            InitializeComponent();
            userWindow = new UserWindow(isEditor: false, testFilePath);
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            UserWindow window1 = new UserWindow(isEditor: false, testFilePath);
            window1.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Visibility = PasswordTextBox.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordTextBox.Text == correctPassword)
            {
                userWindow = new UserWindow(isEditor: true, testFilePath);
                userWindow.ShowDialog();

                PasswordTextBox.Text = string.Empty;
            }
        }

    }
}

