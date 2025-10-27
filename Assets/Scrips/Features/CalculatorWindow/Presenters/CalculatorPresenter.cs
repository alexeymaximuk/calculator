using System;
using System.Collections.Generic;
using R3;
using Scrips.Features.Calculation.Domain.Models;
using Scrips.Features.Calculation.Interfaces;
using Scrips.Features.CalculatorWindow.Interfaces;
using Scrips.UI.Presenters;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Scrips.Features.CalculatorWindow.Presenters
{
    public sealed class CalculatorPresenter : LayoutPresenterBase<ICalculatorView>
    {
        [Inject] private readonly ICalculator _calculator;
        private string _currentInput;
        private CompositeDisposable _compositeDisposable;
        private int _lastResultCount = 0;
        private bool _suppressInputUpdate;
        Color32 _labelColor = new (0, 181, 255, 255);

        public override void Initialize()
        {
            _compositeDisposable = new CompositeDisposable();
            _lastResultCount = 0;
            LayoutView.CalculateButton.clicked += Calculate;
            
            _calculator.Results.Subscribe(OnResultsChanged).AddTo(_compositeDisposable);
            _calculator.OnEquationValueLoaded.Subscribe(SetInputFieldFromModel).AddTo(_compositeDisposable);
            LayoutView.InputField.RegisterValueChangedCallback(OnInputFieldChanged);
            
            Activate();
        }

        private void SetInputFieldFromModel(string value)
        {
            _suppressInputUpdate = true;
            LayoutView.InputField.value = value;
            _suppressInputUpdate = false;
        }

        private void OnInputFieldChanged(ChangeEvent<string> evt)
        {
            if (_suppressInputUpdate)
                return;
            
            _currentInput = evt.newValue;
            _calculator.UpdateCurrentEquation(_currentInput);
        }

        private void Calculate()
        {
            _calculator.TryCalculate();
            LayoutView.InputField.value = string.Empty;
        }

        private void OnResultsChanged(IReadOnlyList<string> results)
        {
            for (var i = _lastResultCount; i < results.Count; i++)
            {
                var label = new Label(results[i]);
                label.style.color = new StyleColor(_labelColor);
                label.style.unityTextAlign = new StyleEnum<TextAnchor>(TextAnchor.MiddleRight);
                label.style.alignSelf = new StyleEnum<Align>(Align.Stretch);

                LayoutView.ResultsScrollView.Insert(0, label);
            }
            _lastResultCount = results.Count;
        }

        public override void Dispose()
        {
            _compositeDisposable?.Dispose();
            
            LayoutView.CalculateButton.clicked -= Calculate;
            LayoutView.InputField.UnregisterValueChangedCallback(OnInputFieldChanged);
            _lastResultCount = 0;
        }
    }
}