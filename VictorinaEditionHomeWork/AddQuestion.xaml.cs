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
using System.Windows.Shapes;

namespace VictorinaEditionHomeWork
{
    /// <summary>
    /// Логика взаимодействия для AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        public AddQuestion()
        {
            InitializeComponent();
        }

        private void AddToDBBtn_Click(object sender, RoutedEventArgs e)
        {
            Questions questions = new Questions(QuestionTextBox.Text, AnswerTextBox.Text);
            MongoExamples.AddToDB(questions);
            QuestionTextBox.Text = String.Empty;
            AnswerTextBox.Text = String.Empty;
            MessageBox.Show("Добавлнео!");
        }
    }
}
