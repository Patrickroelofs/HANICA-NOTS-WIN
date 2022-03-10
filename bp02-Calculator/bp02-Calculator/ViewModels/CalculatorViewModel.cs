using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using bp02_Calculator.Commands;
using bp02_Calculator.Models;

namespace bp02_Calculator.ViewModels;

public class CalculatorViewModel : ViewModelBase
{
    private readonly CalculatorModel _calculatorModel;
    public string Expression => _calculatorModel.Expression;
    public string Result => _calculatorModel.Result;
    public ObservableCollection<SavedCalculationsModel> SavedCalculations => _calculatorModel.SavedCalculations;

    public ICommand InsertCommand => new DelegatingCommand(operation => Insert((string) operation));

    public void Insert(string digit)
    {
        _calculatorModel.Insert(digit);
        OnPropertyChanged(nameof(Expression));
        OnPropertyChanged(nameof(Result));
        OnPropertyChanged(nameof(SavedCalculations));
    }

    public ICommand InsertOperationCommand =>
        new DelegatingCommand(operation => InsertOperation((Operations) operation));

    public void InsertOperation(Operations operation)
    {
        _calculatorModel.InsertOperation(operation);
        OnPropertyChanged(nameof(Expression));
        OnPropertyChanged(nameof(Result));
        OnPropertyChanged(nameof(SavedCalculations));
    }

    public CalculatorViewModel()
    {
        _calculatorModel = new CalculatorModel();

        _calculatorModel.LoadCalculations();
        OnPropertyChanged(nameof(SavedCalculations));
    }
}