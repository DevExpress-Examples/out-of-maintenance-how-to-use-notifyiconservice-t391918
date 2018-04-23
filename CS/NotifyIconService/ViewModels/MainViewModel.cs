using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;

namespace NotifyIconService.ViewModels {
    [POCOViewModel]
    public class MainViewModel {

        public MainViewModel() {
            IsConnected = null;
        }

        protected ICurrentWindowService CurrentWindowService { get { return this.GetService<ICurrentWindowService>(); } }
        protected INotifyIconService NotifyIconService { get { return this.GetService<INotifyIconService>(); } }
        protected IMessageBoxService MessageBoxService { get { return this.GetService<IMessageBoxService>(); } }

        public void ActivateMainWindow() {
            CurrentWindowService.SetWindowState(System.Windows.WindowState.Normal);
            CurrentWindowService.Activate();
        }
        public void Connect() {
            NotifyIconService.SetStatusIcon("connected");
            IsConnected = true;
        }
        public bool CanConnect() {
            return IsConnected != true;
        }

        public void Disconnect() {
            NotifyIconService.SetStatusIcon("disconnected");
            IsConnected = false;
        }
        public bool CanDisconnect() {
            return IsConnected == true;
        }

        public void Reset() {
            NotifyIconService.ResetStatusIcon();
            IsConnected = null;
        }

        public void About() {
            MessageBoxService.ShowMessage("This example demonstrates how to use NotifyIconService ", "About");
        }

        public virtual bool? IsConnected { get; set; }
    }
}