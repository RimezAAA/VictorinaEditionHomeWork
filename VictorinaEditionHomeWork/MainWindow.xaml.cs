using EditorPerson;
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

namespace VictorinaEditionHomeWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd;
        Button[] buttonsAnswer;
        Button[] buttonsLetters;
        string answer;
        Questions questions;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            AddQuestion addQuestion = new AddQuestion();
            addQuestion.Show();
        }

        private void GetQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            rnd = new Random();
            answer = "";
            int maxVal = MongoExamples.FindAll().Count + 1;
            int rndVal = rnd.Next(1,maxVal);
            questions = MongoExamples.Find(rndVal);
            GetQuestionBtn.Visibility= Visibility.Hidden;
            ClearAnswerBtn.Visibility= Visibility.Visible;
            buttonsAnswer = new Button[questions.answer.Length];
            for (int i = 0; i < questions.answer.Length; i++)
            {
                buttonsAnswer[i] = new Button()
                {
                    Width = 40,
                    Height = 40,
                    IsEnabled = false
                };
                AnswerStackPanel.Children.Add(buttonsAnswer[i]);
            }
            TextBlock textBlock = new TextBlock()
            {
                Text = questions.question
            };
            QuestionStackPanel.Children.Add(textBlock);
            Char[] chars = new Char[40];
            for (int i = 0; i < questions.answer.Length; i++)
            {
                chars[i] = questions.answer[i];
            }
            for (int i = questions.answer.Length; i < 40; i++)
            {
                chars[i] = (char)rnd.Next(1072, 1104);
            }
            rnd.Shuffle(chars);
            buttonsLetters = new Button[40];

            int count = 0;
            
            for (int i = 0; i < 10; i++)
            {
                int left = 0;
                int top = -120;
                for (int j = 0; j < 4; j++)
                {
                    if (j == 1)
                    {
                        left -= 40;
                    }
                    Button btn = new Button()
                    {
                        Width = 40,
                        Height = 40,
                        Margin = new Thickness(left, top, 0, 0),
                        Content = chars[count]
                    };
                    btn.Click += Btn_Click;
                    buttonsLetters[count] = btn;
                    LettersStackPanel.Children.Add(btn);
                    ++count;
                    top += 80;
                    
                    
                }

            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled= false;
            buttonsAnswer[answer.Length].Content = btn.Content;
            answer += btn.Content;
            if (answer.Length == questions.answer.Length)
            {
                if (answer == questions.answer)
                {
                    MessageBox.Show("Вы победили!");
                    AnswerStackPanel.Children.Clear();
                    QuestionStackPanel.Children.Clear();
                    LettersStackPanel.Children.Clear();
                    GetQuestionBtn.Visibility = Visibility.Visible;
                    ClearAnswerBtn.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Ответ неверный, попробуйте ещё раз!");
                    ClearAnswer();
                }
            }
        }

        private void ClearAnswer()
        {
            for (int i = 0; i < buttonsAnswer.Length; i++)
            {
                buttonsAnswer[i].Content = "";
            }
            for (int i = 0; i < buttonsLetters.Length; i++)
            {
                buttonsLetters[i].IsEnabled = true;
            }
            answer = "";
        }

        private void ClearAnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearAnswer();
        }
    }
}
