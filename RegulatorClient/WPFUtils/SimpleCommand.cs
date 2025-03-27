using System.Windows.Input;

namespace RegulatorClient.WPFUtils
{
    internal class SimpleCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;

        public SimpleCommand(Action<Object> action, Predicate<Object> predicate)
        {
            this._action = action;
            this._predicate = predicate;
        }
        public SimpleCommand(Action<Object> action)
        {
            this._action = action;
            this._predicate = (_) => true;
        }
        public bool CanExecute(object? parameter)
        {
            return _predicate.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            _action.Invoke(parameter);
        }
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
