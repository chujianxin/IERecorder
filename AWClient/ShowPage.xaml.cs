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
using System.Xml;

namespace AWClient
{
    /// <summary>
    /// ShowPage.xaml 的交互逻辑
    /// </summary>
    public partial class ShowPage : Window
    {
        private ListBoxItem selectNode = null;
        private static int mapIndex;
        private static int eleIndex;
        private static string oldname = "";
        public ShowPage()
        {
            InitializeComponent();
            
            ListBoxItem it = (ListBoxItem)MainWindow.lboxmap.SelectedItem;
            if (it == null)
                return;
            mapIndex= MainWindow.lboxmap.SelectedIndex;
            XmlDocument xml = (XmlDocument)it.Tag;
            XmlNodeList nodes = xml.GetElementsByTagName("element");

            txtMapName.Text = xml.SelectSingleNode("map").Attributes["name"].Value.Replace(".map", "");
            oldname = txtMapName.Text+".map";
            for (int i = 0; i < nodes.Count; i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Style = (Style)Resources["listBoxItem"];
               
                item.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
                item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Blue"));
                item.Content ="◎ "+ nodes[i].Attributes["name"].Value;
                item.Tag = nodes[i];
                listbox.Items.Add(item);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                selectNode = listbox.SelectedItem as ListBoxItem;
                eleIndex = listbox.SelectedIndex;
                XmlNode node = (XmlNode)selectNode.Tag;

                //txtTag.Text = node.Attributes["tag"].Value;
                
                txtName.Text = node.Attributes["name"].Value;
                cboLoc.Text = node.ChildNodes[1].Attributes["selected"].Value;
                txtPath.Text = node.ChildNodes[2].Attributes["xpath"].Value;
                txtTag.Text = node.ChildNodes[2].Attributes["type"].Value;
            }
            catch
            { }
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            //int index = MainWindow.lboxmap.SelectedIndex;
            if (mapIndex == -1)
                return;
            XmlDocument doc = utils.xml[mapIndex];
            doc.SelectSingleNode("map").Attributes["name"].Value = txtMapName.Text+".map";
            doc.GetElementsByTagName("element")[eleIndex].ChildNodes[1].Attributes["selected"].Value = cboLoc.Text;
            doc.GetElementsByTagName("element")[eleIndex].ChildNodes[2].Attributes["xpath"].Value = txtPath.Text;
            utils.RefreshMapListBox();

            ItemCollection itc = MainWindow.lbox.Items;
            for (int i = 0; i < itc.Count;i++ )
            {
                ListBoxItem item =(ListBoxItem)itc[i];
                string json = item.Tag.ToString();

                var ele = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AW>>(json);

                if (ele[0].record[0].map ==oldname)
                {
                    ele[0].record[0].map = txtMapName.Text+".map";
                }
                string JSON = Newtonsoft.Json.JsonConvert.SerializeObject(ele);
                ((ListBoxItem)MainWindow.lbox.Items[i]).Tag = JSON;
            }
            

            utils.CreateAW();
            oldname = txtMapName.Text+".map";

            ListBoxItem it = (ListBoxItem)MainWindow.lboxmap.Items[mapIndex];
            XmlDocument xml = (XmlDocument)it.Tag;
            XmlNodeList nodes = xml.GetElementsByTagName("element");

            txtMapName.Text = xml.SelectSingleNode("map").Attributes["name"].Value.Replace(".map","");
            oldname = txtMapName.Text + ".map";


            ListBoxItem item1 = (ListBoxItem)listbox.Items[eleIndex];
            item1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));

            item1.Content = "◎ " + nodes[eleIndex].Attributes["name"].Value;
            item1.Tag = nodes[eleIndex];
            item1.IsSelected = true;
      
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            if ( listbox.SelectedItem != null)
            {
                listbox.Items.Remove(listbox.SelectedItem);
                txtName.Text = "";
                txtPath.Text = "";
                txtTag.Text = "";
                mapIndex = -1;

                
            }
        }
    }
}
