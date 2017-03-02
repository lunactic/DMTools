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
using DMTools.models;

namespace DMTools
{
    /// <summary>
    /// Interaction logic for ItemDetails.xaml
    /// </summary>
    public partial class ItemDetails : Window
    {
        public ItemDetails()
        {
            InitializeComponent();
        }

        public ItemDetails(Item item)
        {
            InitializeComponent();
            this.Title = item.Name;
            this.HtmlPanel.Text = item.HtmlContent;
            

        }
    }
}
