using Scrips.Features.Calculation.Domain.Models;
using Scrips.Features.Calculation.Interfaces;
using Scrips.Features.Saving.Domain.Models;

namespace Scrips.Features.Saving.UseCases
{
    public class LoadCalculatorStateUseCase
    {
        private readonly PlayerPrefsSavingService _savingService;
        public LoadCalculatorStateUseCase(PlayerPrefsSavingService savingService)
        {
            _savingService = savingService;
        }
        
        public void Execute(ICalculator calculator)
        {
            var data = _savingService.LoadData();
            if (data != null)
            {
                calculator.Load(data);
            }
        }
    }
}
