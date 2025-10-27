using Scrips.Features.CalculatorWindow.Interfaces;
using Scrips.UI.Views;
using UnityEngine.UIElements;

namespace Scrips.Features.CalculatorWindow.Views
{
    public partial class CalculatorView : LayoutViewBase, ICalculatorView
    {
        public Button CalculateButton { get; private set; }
        public TextField InputField { get; private set; }
        public ScrollView ResultsScrollView { get; private set; }

        public override void Awake()
        {
            base.Awake();
            CalculateButton = _root.Q<Button>(Buttons.CalculateButton);
            InputField = _root.Q<TextField>(TextFields.InputField);
            ResultsScrollView = _root.Q<ScrollView>(ScrollViews.ResultsScrollView);
        }
    }
}