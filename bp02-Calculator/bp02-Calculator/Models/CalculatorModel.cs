using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace bp02_Calculator.Models
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
    static HttpClient _client = new();
    public string Expression { get; private set; } = string.Empty;
    public string Result { get; private set; } = string.Empty;
    public ObservableCollection<SavedCalculationsModel> SavedCalculations = new();

    public CalculatorModel()
    {
      _client = new HttpClient();
      _client.BaseAddress = new Uri("https://localhost:7140/");
      _client.DefaultRequestHeaders.Accept.Clear();
      _client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
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
        case Operations.Save:
          SaveCalculation();
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

      return expression.calculate().ToString(CultureInfo.InvariantCulture);
    }

    private async void SaveCalculation()
    {
      if (Expression != "")
      {
        try
        {
          var response = await _client.PostAsJsonAsync("/api/Calculator", new SavedCalculationsModel()
          {
            calculation = Expression
          });

          if (response.IsSuccessStatusCode)
          {
            LoadCalculations();
          }
        } catch(Exception e)
        {
          MessageBox.Show("Unable to save calculation due to no connection of the database. " + e.Message);
        }
      }
    }

    public async void DeleteCalculation(SavedCalculationsModel operation)
    {
      try
      {
        var response = await _client.DeleteAsync($"api/Calculator/{operation.id}");

        if (response.IsSuccessStatusCode)
        {
          SavedCalculations.Remove(operation);
        }
      } catch (Exception e)
      {
        MessageBox.Show("Unable to delete calculation, no connection to server. " + e.Message);
      }
    }

    public async void LoadCalculations()
    {
      try
      {
        ObservableCollection<SavedCalculationsModel> response = await _client.GetFromJsonAsync<ObservableCollection<SavedCalculationsModel>>("/api/Calculator");

        SavedCalculations.Clear();
        foreach (var item in response)
        {
          SavedCalculations.Add(item);
        }
      } catch (Exception e)
      {
        MessageBox.Show("No connection could be made to the server, did you turn it on? " + e.Message);
      }
    }

    public void LoadCalculationIntoCalculator(SavedCalculationsModel operation)
    {
      try
      {
        Expression = operation.calculation;
        Result = CalculateExpression();
      } catch(Exception e)
      {
        MessageBox.Show("Unable to load calculation, no database connection. " + e.Message);
      }
    }
  }
}