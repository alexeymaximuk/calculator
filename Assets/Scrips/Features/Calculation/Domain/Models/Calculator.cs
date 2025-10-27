using System.Collections.Generic;
using R3;
using Scrips.Features.Calculation.Interfaces;
using VContainer;


namespace Scrips.Features.Calculation.Domain.Models
{
    public sealed class Calculator : ICalculator
    {
        [Inject] private readonly ICalculateEquationUseCase _useCase;
        
        private readonly List<string> _results = new();
        private readonly ReactiveProperty<IReadOnlyList<string>> _resultsProperty = new(new List<string>());
        public ReactiveProperty<IReadOnlyList<string>> Results => _resultsProperty;
        public Subject<string> OnEquationValueLoaded { get; } = new ();

        private string _currentEquation = string.Empty;
        public string CurrentEquation => _currentEquation;


        public void Load(CalculatorData data)
        {
            _results.Clear();
            _results.AddRange(data.Results);
            _resultsProperty.Value = new List<string>(_results);
            _currentEquation = data.CurrentEquation;
            
            OnEquationValueLoaded.OnNext(_currentEquation);
        }

        public void UpdateCurrentEquation(string equation)
        {
            _currentEquation = equation;
        }
        
        public void TryCalculate()
        {
            var result = _useCase.Execute(_currentEquation);
            _results.Add($"{_currentEquation}={result}");
            _resultsProperty.Value = new List<string>(_results);
        }
    }
}
