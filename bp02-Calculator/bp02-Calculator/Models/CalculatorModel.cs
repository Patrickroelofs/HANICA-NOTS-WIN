using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using org.mariuszgromada.math.mxparser;

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
                case Operations.Save:
                    SaveCalculation();
                    break;
            }
        }

        string CalculateExpression()
        {
            Expression expression = new Expression(Expression);

            return expression.calculate().ToString(CultureInfo.InvariantCulture);
        }
        
        static void ConnectToApi()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7140/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void SaveCalculation()
        {
            ConnectToApi();
            var response = await _client.PostAsJsonAsync("/api/Calculator", new SavedCalculationsModel()
            {
                calculation = Expression
            });

            if (response.IsSuccessStatusCode)
            {
                LoadCalculations();
            }
        }

        public async void DeleteCalculation(SavedCalculationsModel operation)
        {
            ConnectToApi();
            var response = await _client.DeleteAsync($"api/Calculator/{operation.id}");

            if (response.IsSuccessStatusCode)
            {
                SavedCalculations.Remove(operation);
            }
        }

        public async void LoadCalculations()
        {
            ConnectToApi();
            SavedCalculations.Clear();
            var response = await _client.GetFromJsonAsync<ObservableCollection<SavedCalculationsModel>>("/api/Calculator");

            foreach (var item in response)
            {
                SavedCalculations.Add(item);
            }
        }

        public void LoadCalculationIntoCalculator(SavedCalculationsModel operation)
        {

            Expression = operation.calculation;
            Result = CalculateExpression();
        }
    }
}