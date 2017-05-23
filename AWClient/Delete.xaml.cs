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

namespace AWClient
{
    /// <summary>
    /// Delete.xaml 的交互逻辑
    /// </summary>
    public partial class Delete : UserControl
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lbox.SelectedItem != null)
            {
                int i = MainWindow.lbox.SelectedIndex;

                MainWindow.lbox.Items.Remove(MainWindow.lbox.SelectedItem);
                MainWindow.lIndex.Items.RemoveAt(MainWindow.lIndex.Items.Count - 1);
                
                MainWindow.index--;

                if(i!=0)
                    MainWindow.lbox.SelectedItem = MainWindow.lbox.Items[i-1];

                //add 2017509
                utils.awjson = utils.CreateAW();
                utils.CreateMap();
            }
        }
    }
}
