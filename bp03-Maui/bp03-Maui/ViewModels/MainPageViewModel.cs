using bp03_Maui.Models;
using bp03_Maui.Services;
using System.Windows.Input;

namespace bp03_Maui.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    private readonly CalculatorModel _calculatorModel;
    public string Expression => _calculatorModel.Expression;
    public string Result => _calculatorModel.Result;

    public ICommand InsertCommand =>
      new Command(operation => Insert((string)operation));

    public void Insert(string digit)
    {
      _calculatorModel.Insert(digit);
      RaisePropertyChanged(nameof(Expression));
      RaisePropertyChanged(nameof(Result));
    }

    public ICommand InsertOperationCommand =>
      new Command(operation => InsertOperation((Operations)operation));

    public void InsertOperation(Operations operation)
    {
      _calculatorModel.InsertOperation(operation);
      RaisePropertyChanged(nameof(Expression));
      RaisePropertyChanged(nameof(Result));
    }

    public MainPageViewModel()
    {
      _calculatorModel = new CalculatorModel();
    }
  }
}
