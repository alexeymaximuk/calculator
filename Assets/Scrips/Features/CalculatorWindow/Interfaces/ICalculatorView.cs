using Scrips.UI.Interfaces;
using UnityEngine.UIElements;

namespace Scrips.Features.CalculatorWindow.Interfaces
{
    public interface ICalculatorView : ILayoutView
    {
        Button CalculateButton { get; }
        TextField InputField { get; }
        ScrollView ResultsScrollView { get; }
    }
}