using System.Collections.Generic;
using R3;
using Scrips.Features.Calculation.Domain.Models;

namespace Scrips.Features.Calculation.Interfaces
{
    public interface ICalculator
    {
        void Load(CalculatorData data);
        void UpdateCurrentEquation(string equation);
        string CurrentEquation { get; }
        void TryCalculate();
        ReactiveProperty<IReadOnlyList<string>> Results { get; }
        Subject<string> OnEquationValueLoaded { get; }
    }
}
