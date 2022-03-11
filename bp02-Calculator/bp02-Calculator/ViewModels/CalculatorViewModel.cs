using System.Collections.ObjectModel;
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

  public ICommand InsertCommand => 
    new DelegatingCommand(operation => Insert((string) operation));

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

  public ICommand SaveOperationCommand =>
    new DelegatingCommand(operation => SaveOperation((Operations) operation));

  public void SaveOperation(Operations operation)
  {
    _calculatorModel.InsertOperation(operation);
    OnPropertyChanged(nameof(Expression));
    OnPropertyChanged(nameof(Result));
    OnPropertyChanged(nameof(SavedCalculations));
  }

  public ICommand DeleteOperationCommand =>
    new DelegatingCommand(operation => DeleteOperation((SavedCalculationsModel) operation));

  public void DeleteOperation(SavedCalculationsModel operation)
  {
    _calculatorModel.DeleteCalculation(operation);
    OnPropertyChanged(nameof(Expression));
    OnPropertyChanged(nameof(Result));
    OnPropertyChanged(nameof(SavedCalculations));
  }

  public ICommand LoadOperationCommand =>
    new DelegatingCommand(operation => LoadCalculationOperation((SavedCalculationsModel) operation));

  public void LoadCalculationOperation(SavedCalculationsModel operation)
  {
    _calculatorModel.LoadCalculationIntoCalculator(operation);
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