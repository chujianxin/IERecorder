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
    /// Repeat.xaml 的交互逻辑
    /// </summary>
    public partial class Repeat : UserControl
    {
        public Repeat()
        {
            InitializeComponent();
        }

        private void onPause(object sender, RoutedEventArgs e)
        {
            MainWindow.isPause =!MainWindow.isPause;
            // <Button.Background>
            //    <ImageBrush Stretch="None" ImageSource="img/pause.png"/>
            if (MainWindow.isPause)
            {
                btnPause.Content = "继续";
                btnPause.Background = null;
                ImageBrush b = new ImageBrush();
                b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/img/Repeat-1.png", UriKind.RelativeOrAbsolute));
                b.Stretch = Stretch.None;
                btnPause.Background = b;
            }
            else
            {
                btnPause.Content = "暂停";
                btnPause.Background = null;
                ImageBrush b = new ImageBrush();
                b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/img/pause.png", UriKind.RelativeOrAbsolute));
                b.Stretch = Stretch.None;
                btnPause.Background = b;
            }
        }
        
    }
}
