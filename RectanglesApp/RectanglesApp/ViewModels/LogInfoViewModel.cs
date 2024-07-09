


namespace RectanglesApp.ViewModels
{
    public class LogInfoViewModel : BaseViewModel
    {
        private string logInfoText;


        public LogInfoViewModel() 
        {
        }


        public string LogInfoText
        {
            get => this.logInfoText;
            set => SetProperty(ref this.logInfoText, value);
        }


        public void ShowLog(string message) => LogInfoText = $"\n {message}{LogInfoText}";
    }
}
