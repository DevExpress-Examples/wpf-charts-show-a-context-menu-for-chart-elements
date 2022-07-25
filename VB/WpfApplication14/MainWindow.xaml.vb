Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Charts
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input

Namespace WpfApplication14

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub ccmHide_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            Dim menu As PopupMenu = TryCast(CType(sender, BarItem).Parent, PopupMenu)
            Dim targetObjects As Object() = TryCast(menu.Tag, Object())
            Dim series As Series = TryCast(targetObjects(0), Series)
            series.Visible = False
        End Sub

        Private Sub ccmInfo_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            Dim menu As PopupMenu = TryCast(CType(sender, BarItem).Parent, PopupMenu)
            Dim targetObjects As Object() = TryCast(menu.Tag, Object())
            Dim series As Series = TryCast(targetObjects(0), Series)
            Title = series.DisplayName
        End Sub

        Private Sub PopupMenu_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            Dim hitInfo = Me.chartControl1.CalcHitInfo(Mouse.GetPosition(Application.Current.MainWindow))
            If Not hitInfo.InSeries Then
                e.Cancel = True
            Else
                Dim menu As PopupMenu = CType(sender, PopupMenu)
                menu.Tag = New Object() {hitInfo.Series}
            End If
        End Sub
    End Class
End Namespace
