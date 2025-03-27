using RegulatorClient.Views;
using RegulatorClient.WPFUtils;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;

namespace RegulatorClient.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string FirstValue { get; set; }
        public string SecondValue { get; set; }
        public double Result { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand AddCommand { get; }
        public ICommand ShowHistoryCommand { get; }
        public MainViewModel()
        {
            AddCommand = new SimpleCommand(ExecuteAdd, CanExecuteAdd);
            ShowHistoryCommand = new SimpleCommand(ExecuteShowHistory);
        }
        private async void ExecuteAdd(object parameter)
        {
            var firstValue = double.Parse(FirstValue);
            var secondValue = double.Parse(SecondValue);
            var httpClient = new HttpClient();
            var client = new Client("http://localhost:5168/", httpClient);
            Result = await client.OperationAsync(firstValue, secondValue);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
        }
        private bool CanExecuteAdd(object parameter)
        {
            return double.TryParse(FirstValue, out _) && double.TryParse(SecondValue, out _);
        }
        private async void ExecuteShowHistory(object parameter)
        {
            var httpClient = new HttpClient();
            var client = new Client("http://localhost:5168/", httpClient);
            var result = await client.OperationAllAsync();
            var operationHistory = new OperationHistoryViewModel(result);
            var historyWindow = new HistoryWindow() 
            {
                DataContext = operationHistory 
            };
            historyWindow.ShowDialog();
        }
    }
}
