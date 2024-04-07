using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Логика взаимодействия для TakeTestPage.xaml
    /// </summary>
    public partial class TakeTestPage : Page
    {
        private int currentQuestionIndex = 0;
        private int correctAnswers = 0;
        private ObservableCollection<TestQuestion> questions;

        public TakeTestPage(ObservableCollection<TestQuestion> questions)
        {
            InitializeComponent();
            this.questions = questions;
            LoadQuestion(currentQuestionIndex);
        }

        private void LoadQuestion(int index)
        {
            if (index >= 0 && index < questions.Count)
            {
                TestQuestion currentQuestion = questions[index];
                QuestionTextBlock.Text = currentQuestion.Question;
                DescriptionTextBlock.Text = currentQuestion.Description;
                Option1Button.Content = currentQuestion.Option1;
                Option2Button.Content = currentQuestion.Option2;
                Option3Button.Content = currentQuestion.Option3;
            }
            else
            {
                ShowScore();
            }
        }

        private void Option_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            TestQuestion currentQuestion = questions[currentQuestionIndex];

            if (clickedButton != null && currentQuestion != null)
            {
                string selectedOption = clickedButton.Content.ToString();
                CorrectAnswer correctAnswer = currentQuestion.CorrectAnswer; 
                bool isCorrect = false;

                switch (correctAnswer)
                {
                    case CorrectAnswer.Option1:
                        isCorrect = selectedOption == currentQuestion.Option1;
                        break;
                    case CorrectAnswer.Option2:
                        isCorrect = selectedOption == currentQuestion.Option2;
                        break;
                    case CorrectAnswer.Option3:
                        isCorrect = selectedOption == currentQuestion.Option3;
                        break;
                }

                if (isCorrect)
                {
                    correctAnswers++;
                }
                currentQuestionIndex++;
                LoadQuestion(currentQuestionIndex);
            }
        }


        private void ShowScore()
        {
            MessageBox.Show($"Правильно: {correctAnswers} из {questions.Count}", "Результат");
        }
    }

}
