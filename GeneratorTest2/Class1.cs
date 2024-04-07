using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;


namespace GeneratorTest2
{
    public static class TestSerializer
    {
        public static void Serialize(Test test, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Test));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, test);
            }
        }

        public static Test Deserialize(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Test));
            using (TextReader reader = new StreamReader(filePath))
            {
                return (Test)serializer.Deserialize(reader);
            }
        }
    }

    public enum CorrectAnswer
    {
        Option1,
        Option2,
        Option3
    }

    public class TestQuestion
    {
        public string Question { get; set; }
        public string Description { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public CorrectAnswer CorrectAnswer { get; set; }
    }


    public class Test
    {

        public ObservableCollection<TestQuestion> Questions { get; set; }

        public Test()
        {
            Questions = new ObservableCollection<TestQuestion>();
        }
    }
}

