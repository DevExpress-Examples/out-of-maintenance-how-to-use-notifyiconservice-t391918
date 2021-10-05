Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Xpf.Core

Namespace NotifyIconService.ViewModels

    <POCOViewModel>
    Public Class MainViewModel

        Public Sub New()
            IsConnected = Nothing
        End Sub

        Protected ReadOnly Property CurrentWindowService As ICurrentWindowService
            Get
                Return Me.GetService(Of ICurrentWindowService)()
            End Get
        End Property

        Protected ReadOnly Property NotifyIconService As INotifyIconService
            Get
                Return Me.GetService(Of INotifyIconService)()
            End Get
        End Property

        Protected ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return Me.GetService(Of IMessageBoxService)()
            End Get
        End Property

        Public Sub ActivateMainWindow()
            CurrentWindowService.SetWindowState(System.Windows.WindowState.Normal)
            CurrentWindowService.Activate()
        End Sub

        Public Sub Connect()
            NotifyIconService.SetStatusIcon("connected")
            IsConnected = True
        End Sub

        Public Function CanConnect() As Boolean
            Return IsConnected <> True
        End Function

        Public Sub Disconnect()
            NotifyIconService.SetStatusIcon("disconnected")
            IsConnected = False
        End Sub

        Public Function CanDisconnect() As Boolean
            Return IsConnected = True
        End Function

        Public Sub Reset()
            NotifyIconService.ResetStatusIcon()
            IsConnected = Nothing
        End Sub

        Public Sub About()
            MessageBoxService.ShowMessage("This example demonstrates how to use NotifyIconService ", "About")
        End Sub

        Public Overridable Property IsConnected As Boolean?
    End Class
End Namespace
