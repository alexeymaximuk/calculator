using Scrips.Features.Calculation.Domain.Models;
using Scrips.Features.Calculation.UseCases;
using VContainer;
using VContainer.Unity;

namespace Scrips.Features.Calculation.Installers
{
    public class CalculatorLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterUseCases(builder);
            RegisterModels(builder);
        }
        
        private void RegisterUseCases(IContainerBuilder builder)
        {
            builder.Register<CalculateEquationUseCase>(Lifetime.Singleton).AsImplementedInterfaces();
        }
        
        private void RegisterModels(IContainerBuilder builder)
        {
            builder.Register<Calculator>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}
