using System.Deployment.Application;

namespace RandomWiki.WPF.MVVM.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        private string _version;

        public string Version { get => _version; set => base.SetProperty(ref _version, value); }

        public AboutViewModel()
        {
            try
            {
                this.Version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (System.Exception)
            {
                this.Version = "not installed";
            }
        }
    }
}