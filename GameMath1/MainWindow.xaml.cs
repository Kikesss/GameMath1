using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;





namespace gamemath
{

    public partial class MainWindow : Window
    {
        Random rand = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        public int increment = 30;// Переменная для таймера
        public int num1 = 0;// Переменная для примера
        public int num2 = 0;// Переменная для примера

        int right = 0;// Переменная для верных действий 
        int wrong = 0;// Переменная для не верных действий 

        public int realSum { get; set; }
        public int[] number { get; set; }

        public MainWindow()
        {
            InitializeComponent();

        }

        public void timeticker(object sender, EventArgs e)//Секундомер
        {
            increment--;
            lblSeconds.Content = increment.ToString() + "s";

            if (increment == 0)
            {
                timer.Stop();
                ButtonDoesNotWork();
                Button1.Background = new SolidColorBrush(Color.FromRgb(89, 84, 84));
                Button2.Background = new SolidColorBrush(Color.FromRgb(89, 84, 84));
                Button3.Background = new SolidColorBrush(Color.FromRgb(89, 84, 84));
                Button4.Background = new SolidColorBrush(Color.FromRgb(89, 84, 84));

                Start.Background = new SolidColorBrush(Color.FromRgb(247, 108, 108));
                Start.IsEnabled = false;

            }
        }
        public void Timer()//Секундомер
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timeticker;
            timer.Start();
        }

        public void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            Timer();
            RandNum();
            ReturnColor();
            Start.IsEnabled = false;
            Start.Background = new SolidColorBrush(Color.FromRgb(89, 84, 84));//Серый цвет

        }


        public void RandNum() // Метод для случайного заполнения ответов и примера
        {
            int num1 = 0;
            int num2 = 0;

            num1 = rand.Next(20, 100);
            num2 = rand.Next(20, 100);
            example.Content = $"{num1} + {num2}";

            realSum = num1 + num2;

            number = new int[4];

            number[0] = realSum;
            number[1] = realSum + rand.Next(1, 6);
            number[2] = realSum + rand.Next(-10, -1);
            number[3] = realSum + rand.Next(6, 13);

            for (int i = number.Length - 1; i >= 1; i--)// Перемешивание массива(нужен из-за того что нулевому индексу передали правильное значение)
            {
                int j = rand.Next(i + 1);

                var temp = number[j];
                number[j] = number[i];
                number[i] = temp;
            }


            Button1.Content = number[0].ToString();
            Button2.Content = number[1].ToString();
            Button3.Content = number[2].ToString();
            Button4.Content = number[3].ToString();
        }

        public void ButtonWorks()
        {
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;

        }// Метод позволяет включить кнопки

        public void ButtonDoesNotWork()
        {
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;

        }// Метод позволяет выключить кнопки

        public void ReturnColor()
        {
            Button1.Background = new SolidColorBrush(Color.FromRgb(133, 189, 108));// Возврат цвета 
            Button2.Background = new SolidColorBrush(Color.FromRgb(133, 189, 108));
            Button3.Background = new SolidColorBrush(Color.FromRgb(133, 189, 108));
            Button4.Background = new SolidColorBrush(Color.FromRgb(133, 189, 108));
        }//Возврат цвета на зеленый

        public void Button1_Click(object sender, RoutedEventArgs e)
        {

            if (number[0] == realSum)
            {
                ButtonWorks();
                RandNum();
                right++;
                Right.Content = right.ToString();
                ReturnColor();

            }

            else
            {
                wrong++;
                Wrong.Content = wrong.ToString();
                Button1.Background = Brushes.Red;// Окрашивание кнопки если ответ неверен
                Button1.IsEnabled = false;
            }

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {

            if (number[1] == realSum)
            {
                ButtonWorks();
                RandNum();
                right++;
                Right.Content = right.ToString();
                ReturnColor();
            }
            else
            {
                wrong++;
                Wrong.Content = wrong.ToString();
                Button2.Background = Brushes.Red;// Окрашивание кнопки если ответ неверен
                Button2.IsEnabled = false;
            }

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {


            if (number[2] == realSum)
            {
                ButtonWorks();
                RandNum();
                right++;
                Right.Content = right.ToString();
                ReturnColor();
            }
            else
            {
                wrong++;
                Wrong.Content = wrong.ToString();
                Button3.Background = Brushes.Red;// Окрашивание кнопки если ответ неверен
                Button3.IsEnabled = false;
            }


        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {


            if (number[3] == realSum)
            {
                ButtonWorks();
                RandNum();
                right++;
                Right.Content = right.ToString();
                ReturnColor();
            }
            else
            {
                wrong++;
                Wrong.Content = wrong.ToString();
                Button4.Background = Brushes.Red;// Окрашивание кнопки если ответ неверен
                Button4.IsEnabled = false;
            }


        }
    }
}
