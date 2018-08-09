using QueueApplication.Common;
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

namespace QueueApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random _rnd = new Random();
        PriorityQueue<int> _queue = new PriorityQueue<int>();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _queue.Enqueue(_rnd.Next(0, 1000));
            UpdateGrid();
        }

        private void btnProcessar_Click(object sender, RoutedEventArgs e)
        {
            if (_queue.Count > 0)
            {
                listNumbers.Items.Add(_queue.Dequeue());
                UpdateGrid();
            }
        }


        private void UpdateGrid()
        {
            label1.Content = "";
            label2.Content = "";
            label3.Content = "";
            label4.Content = "";
            label5.Content = "";
            label6.Content = "";
            label7.Content = "";
            label8.Content = "";

            var index = 1;
            foreach (var message in _queue)
            {
                switch (index)
                {
                    case 1:
                        label1.Content = message;
                        break;
                    case 2:
                        label2.Content = message;
                        break;
                    case 3:
                        label3.Content = message;
                        break;
                    case 4:
                        label4.Content = message;
                        break;
                    case 5:
                        label5.Content = message;
                        break;
                    case 6:
                        label6.Content = message;
                        break;
                    case 7:
                        label7.Content = message;
                        break;
                    case 8:
                        label8.Content = message;
                        break;

                    default:
                        break;
                }

                index++;

                if (index > 8)
                {
                    break;
                }
            }
        }
    }
}
