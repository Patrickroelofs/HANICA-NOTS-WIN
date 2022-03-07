using System;
using System.Windows.Input;

namespace bp02_Calculator.Commands;

// Source : https://www.wpftutorial.net/DelegateCommand.html
// And a bit of help from Github Copilot
public class DelegatingCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Func<object, bool> _canExecute;

    public DelegatingCommand(Action action) : this(obj => action()) {}
    public DelegatingCommand(Action<object> action) : this(action, obj => true) {}
    
    public DelegatingCommand(Action<object> execute, Func<object, bool> canExecute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
    }
    
    public bool CanExecute(object parameter)
    {
        return _canExecute(parameter);
    }
    
    public void Execute(object parameter)
    {
        _execute(parameter);
    }
    
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}