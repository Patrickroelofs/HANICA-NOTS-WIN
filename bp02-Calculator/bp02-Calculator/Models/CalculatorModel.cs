using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using org.mariuszgromada.math.mxparser;

namespace bp02_Calculator.Models
{
    public enum Operations
    {
        Clear,
        Equal,
        Backspace
    }
    
    public interface IOperations
    {
        void Insert(string digit);
        void InsertOperation(Operations operation);
    }
    
    public class CalculatorModel : IOperations
    {
        public string Expression { get; private set; } = string.Empty;
        public string Result { get; private set; } = string.Empty;

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

        string CalculateExpression()
        {
            Expression expression = new Expression(Expression);

            return expression.calculate().ToString(CultureInfo.InvariantCulture);
        }
    }
}