using System;
using Scrips.Features.Calculation.Domain.Models;
using Scrips.Features.Calculation.Interfaces;
using Scrips.Features.Saving.UseCases;
using VContainer;
using VContainer.Unity;

namespace Scrips.Features.Saving.Domain.Models
{
    public class CalculatorAutoSaver : IInitializable, IDisposable
    {
        [Inject] private ICalculator _calculator;
        [Inject] private SaveCalculatorStateUseCase _saveUseCase;
        [Inject] private LoadCalculatorStateUseCase _loadUseCase;

        public void Initialize()
        {
            _loadUseCase?.Execute(_calculator);
        }

        public void Dispose()
        {
            _saveUseCase?.Execute(_calculator);
        }
    }
}
