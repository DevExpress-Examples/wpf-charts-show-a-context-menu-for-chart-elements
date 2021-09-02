Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Charts
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace WpfApplication14
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub ccmHide_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Dim menu As PopupMenu = TryCast(DirectCast(sender, BarItem).Parent, PopupMenu)
			Dim targetObjects() As Object = TryCast(menu.Tag, Object())
			Dim series As Series = TryCast(targetObjects(0), Series)
			series.Visible = False
		End Sub

		Private Sub ccmInfo_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Dim menu As PopupMenu = TryCast(DirectCast(sender, BarItem).Parent, PopupMenu)
			Dim targetObjects() As Object = TryCast(menu.Tag, Object())
			Dim series As Series = TryCast(targetObjects(0), Series)
			Me.Title = series.DisplayName
		End Sub


		Private Sub PopupMenu_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
			Dim hitInfo = chartControl1.CalcHitInfo(Mouse.GetPosition(Application.Current.MainWindow))
			If Not hitInfo.InSeries Then
				e.Cancel = True
			Else
				Dim menu As PopupMenu = DirectCast(sender, PopupMenu)
				menu.Tag = New Object() { hitInfo.Series }
			End If
		End Sub
	End Class
End Namespace
