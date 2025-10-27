using System.Linq;
using Scrips.Features.CalculatorWindow.Presenters;
using Scrips.Features.CalculatorWindow.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scrips.Features.CalculatorWindow.Installers
{
    public class CalculatorViewLifetimeScope : LifetimeScope
    {
        [SerializeField] private CalculatorView _calculatorView;

        protected override void Configure(IContainerBuilder builder)
        {
            var viewTypes = _calculatorView.GetType().GetInterfaces().ToArray();
            builder.RegisterComponentInNewPrefab(_calculatorView, Lifetime.Scoped).As(viewTypes);

            builder.RegisterEntryPoint<CalculatorPresenter>();
        }
    }
}
