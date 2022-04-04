using org.mariuszgromada.math.mxparser;
using System.Globalization;

namespace bp03_Maui.Models
{
  public enum Operations
  {
    Clear,
    Equal,
    Backspace,
    Save,
    Delete
  }

  public class CalculatorModel
  {
    public string Expression { get; private set; } = string.Empty;
    public string Result { get; private set; } = string.Empty;

    public CalculatorModel()
    {

    }

    public void InsertOperation(Operations operation)
    {
      switch (operation)
      {
        case Operations.Backspace:
          Backspace();
          break;
        case Operations.Clear:
          Clear();
          break;
        case Operations.Equal:
          Equal();
          break;
      }
    }

    private void Clear()
    {
      Expression = string.Empty;
      Result = string.Empty;
    }

    private void Equal()
    {
      Expression = Result;
    }

    private void Backspace()
    {
      if (string.IsNullOrEmpty(Expression)) return;
      Expression = Expression.Remove(Expression.Length - 1, 1);
      Result = CalculateExpression();
    }

    public void Insert(string element)
    {
      Expression += element;

      Result = CalculateExpression();
    }

    string CalculateExpression()
    {
      Expression expression = new Expression(Expression);

      if (expression.calculate().ToString(CultureInfo.InvariantCulture) == "NaN") return String.Empty;
      return expression.calculate().ToString(CultureInfo.InvariantCulture);
    }
  }
}
