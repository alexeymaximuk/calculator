using System.Collections.Generic;
using System.Linq;
using Scrips.Features.Calculation.Interfaces;

namespace Scrips.Features.Calculation.Domain.Models
{
    public class CalculatorData
    {
        public List<string> Results { get; set; }
        public string CurrentEquation { get; set; }

        public CalculatorData() { }

        public CalculatorData(ICalculator calculator)
        {
            Results = calculator.Results.Value != null
                ? new List<string>(calculator.Results.Value)
                : new List<string>();
            CurrentEquation = calculator.CurrentEquation;
        }
    }
}