using Scrips.Features.Saving.Domain.Models;
using Scrips.Features.Saving.UseCases;
using VContainer;
using VContainer.Unity;

namespace Scrips.Features.Saving.Installers
{
    public class SavingModuleLifetimeScope : LifetimeScope
    {
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<LoadCalculatorStateUseCase>(Lifetime.Singleton);
            builder.Register<SaveCalculatorStateUseCase>(Lifetime.Singleton);
            builder.Register<PlayerPrefsSavingService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<CalculatorAutoSaver>();
        }
        
    }
}