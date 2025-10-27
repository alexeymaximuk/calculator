using Scrips.Features.Calculation.Domain.Models;
using Scrips.Features.Calculation.Interfaces;
using Scrips.Features.Saving.Domain.Models;

namespace Scrips.Features.Saving.UseCases
{
    public class SaveCalculatorStateUseCase
    {
        private readonly PlayerPrefsSavingService _savingService;
        public SaveCalculatorStateUseCase(PlayerPrefsSavingService savingService)
        {
            _savingService = savingService;
        }
        
        public void Execute(ICalculator calculator)
        {
            var data = new CalculatorData(calculator);
            _savingService.SaveData(data);
        }
    }
}
