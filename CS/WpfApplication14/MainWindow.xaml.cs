using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication14
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

        private void ccmHide_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            PopupMenu menu = ((BarItem)sender).Parent as PopupMenu;
            object[] targetObjects = menu.Tag as object[];
            Series series = targetObjects[0] as Series;
            series.Visible = false;
        }

        private void ccmInfo_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            PopupMenu menu = ((BarItem)sender).Parent as PopupMenu;
            object[] targetObjects = menu.Tag as object[];
            Series series = targetObjects[0] as Series;
            this.Title = series.DisplayName;
        }


        private void PopupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            var hitInfo = chartControl1.CalcHitInfo(Mouse.GetPosition(Application.Current.MainWindow));
            if (!hitInfo.InSeries) {
                e.Cancel = true;
            }
            else {
                PopupMenu menu = (PopupMenu)sender;
                menu.Tag = new object[] { hitInfo.Series };
            }
        }
    }
}
