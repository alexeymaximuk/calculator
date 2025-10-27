using System.Text.RegularExpressions;
using Scrips.Features.Calculation.Interfaces;

namespace Scrips.Features.Calculation.UseCases
{
    public class CalculateEquationUseCase : ICalculateEquationUseCase
    {
        public string Execute(string equation)
        {
            var isEquationEmpty = CheckEquation(equation);
            if (!isEquationEmpty)
                return "ERROR";
            
            var result = TryParseEquation(equation, out var match);
            if (!result)
                return "ERROR";

            var left = int.Parse(match.Groups[1].Value);
            var right = int.Parse(match.Groups[2].Value);
            var sum = left + right;
            return sum.ToString();
        }

        private bool CheckEquation(string equation)
        {
            if (string.IsNullOrWhiteSpace(equation))
            {
                UnityEngine.Debug.LogError("Equation is empty");
                return false;
            }

            return true;
        }

        private bool TryParseEquation(string equation, out Match result)
        {
            result = Regex.Match(equation.Trim(), @"^(-?\d+)\+(-?\d+)$");
            if (!result.Success)
            {
                UnityEngine.Debug.LogError("Equation must be two integers separated by a plus sign");
                return false;
            }

            return true;
        }
    }
}
