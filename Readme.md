<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128570167/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T381476)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# How to Show a Custom Context/Popup Menu for Certain Chart Elements

This example demonstrates how to use [Menus](https://docs.devexpress.com/WPF/115388/controls-and-libraries/ribbon-bars-and-menu/menus) and [Bars](https://docs.devexpress.com/WPF/6194/controls-and-libraries/ribbon-bars-and-menu/bars) to show a custom context menu for chart series. 

![Resulting chart](images/resulting-chart.png)

Use the [BarManager.DXContextMenu](https://docs.devexpress.com/WPF/DevExpress.Xpf.Bars.BarManager.DXContextMenu) attached property to attach a context menu to a chart control. 

```xaml
xmlns:dxb="http://schemas.devexpress.com/winfx/2008/xaml/bars"
xmlns:dxc="http://schemas.devexpress.com/winfx/2008/xaml/charts"
<!--...-->
    <dxc:ChartControl x:Name="chartControl1" >  
        <dxb:BarManager.DXContextMenu>  
            <dxb:PopupMenu Opening="PopupMenu_Opening"  >  
                <dxb:PopupMenu.Items>  
                    <dxb:BarButtonItem Name="ccmHide"  Content="Hide" ItemClick="ccmHide_ItemClick" />  
                    <dxb:BarButtonItem Name="ccmInfo" Content="Info" ItemClick="ccmInfo_ItemClick" />  
                </dxb:PopupMenu.Items>  
            </dxb:PopupMenu>  
        </dxb:BarManager.DXContextMenu>  
        ...  
    </dxc:ChartControl>  
```

In the popup menu's [Opening](https://docs.devexpress.com/WPF/DevExpress.Xpf.Bars.BarPopupBase.Opening) event handler, call the [ChartControl.CalcHitInfo](https://docs.devexpress.com/WPF/DevExpress.Xpf.Charts.ChartControl.CalcHitInfo(System.Windows.Point)) method to obtain information about clicked items. If the clicked item is not a series, set the [Cancel](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.canceleventargs.cancel?view=net-6.0#System_ComponentModel_CancelEventArgs_Cancel) property to `true`. Otherwise, save information about the target element to the menu's [Tag](https://docs.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement.tag?view=windowsdesktop-6.0) property:

```cs
private void PopupMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
    var hitInfo = chartControl1.CalcHitInfo(Mouse.GetPosition(this.chartControl1));
    if (!hitInfo.InSeries) {
        e.Cancel = true;
    }
    else {
        PopupMenu menu = (PopupMenu)sender;
        menu.Tag = new object[] { hitInfo.Series };
    }  
}  
```

## Files to Look At

* [MainWindow.xaml](./CS/WpfApplication14/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfApplication14/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/WpfApplication14/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication14/MainWindow.xaml.vb))

## Documentation 

* [Popup Menu](https://docs.devexpress.com/WPF/115388/controls-and-libraries/ribbon-bars-and-menu/menus?p=netframework#popup-menu)
* [Chart Control - Hit-Testing](https://docs.devexpress.com/WPF/4290/controls-and-libraries/charts-suite/chart-control/hit-testing?p=netframework)

## More Examples

* [How to determine which chart element is hovered by the mouse pointer](https://github.com/DevExpress-Examples/how-to-determine-which-chart-element-is-hovered-by-the-mouse-pointer-e4511)
* [How to display custom tooltips over the data point currently hovered by the mouse pointer](https://github.com/DevExpress-Examples/how-to-display-custom-tooltips-over-the-data-point-currently-hovered-by-the-mouse-pointer-e1376)