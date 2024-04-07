using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Linq;
using System.Xml.Serialization;
using GeneratorTest2;
using static System.Net.Mime.MediaTypeNames;

namespace GeneratorTest2
{
    public partial class UserWindow : Window
    {
        private bool isEditor;
        private string testFilePath;
        private Test test;

        public UserWindow(bool isEditor, string testFilePath)
        {
            InitializeComponent();
            this.isEditor = isEditor;
            this.testFilePath = testFilePath;
            EditTest.IsEnabled = isEditor;

            LoadTest();
        }

        private void LoadTest()
        {
            if (File.Exists(testFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Test));
                using (FileStream fs = new FileStream(testFilePath, FileMode.Open))
                {
                    test = (Test)serializer.Deserialize(fs);
                    DataContext = test;
                }
            }
            else
            {
                test = new Test();
                DataContext = test;
            }
        }

        private void SaveTest()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Test));
            using (FileStream fs = new FileStream(testFilePath, FileMode.Create))
            {
                serializer.Serialize(fs, test);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SaveTest();
            this.Close();
        }

        private void EditTest_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new EditPage(test, testFilePath);
        }
        private void UserWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveTest();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(testFilePath) || VoidFile(testFilePath))
                {
                    PageFrame.Content = new VoidPage();
                }
                else
                {
                    PageFrame.Content = new TakeTestPage(test.Questions);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool VoidFile(string filePath)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(filePath);

                XElement questionsElement = xmlDoc.Root.Element("Questions");

                return questionsElement == null || !questionsElement.HasElements;
            }
            catch (Exception)
            {
                return true;
            }
        }

    }
}
