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

namespace DemoWpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ObservableCollection<Person> listItems;
        private void Window_Activated(object sender, EventArgs e)
        {
           
            listItems= new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++)
            {
                listItems.Add(new Person() { Name = "abc", Age = i * 2 });
            }

            lbData.ItemsSource = listItems;

            btAdd.Click += BtAdd_Click;
            tbMinAge.KeyDown += lbData_KeyDown;
            tbMaxAge.KeyDown += lbData_KeyDown;
           
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {

            listItems.Add(new Person() { Name = tbName.Text, Age = int.Parse(tbAge.Text) });
        }

        private void lbData_KeyDown(object sender, KeyEventArgs e)
        {
            int minValue = 0;
            int maxValue = 0;
            if(int.TryParse(tbMinAge.Text,out minValue) && int.TryParse(tbMaxAge.Text,out maxValue))
            {
                for(int i = 0; i < lbData.Items.Count-1; i++)
                {
                    if(listItems[i].Age>=minValue && listItems[i].Age <= maxValue)
                    {
                        (lbData.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Style = this.FindResource("listBoxControlStyle1") as Style;
                    }
                    else
                    {
                        (lbData.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Style = this.FindResource("listBoxControlRemoveStyle1") as Style;
                    }
                }
            }
        }
    }
  
}
