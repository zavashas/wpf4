using GeneratorTest2;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace GeneratorTest2
{
    public partial class EditPage : Page
    {
        private Test test;
        private string testFilePath;

        public EditPage(Test test, string testFilePath)
        {
            InitializeComponent();
            this.test = test;
            this.testFilePath = testFilePath;
            DataContext = test;
        }

    }
}
