using Microsoft.AspNetCore.Components;
using VisualCalc.Models;

namespace VisualCalc.UI.Components.Calculator.InputForm
{
    public partial class CalcInputForm
    {
        private bool _hasEverPosted = false;
        private CalculatorSubmitModel _calculatorSubmitModel { set; get; } = new();

        private void OnFirstOpInput(ChangeEventArgs e)
        {
            if (e.Value == null) return;
            if (_calculatorSubmitModel.IsDefault())
            {
                _calculatorSubmitModel.ToggleDefaultValues();
            }
            _calculatorSubmitModel.FirstOp = ParseInput(e.Value.ToString());
        }

        private void OnSecondOpInput(ChangeEventArgs e)
        {
            if (e.Value == null) return;
            if (_calculatorSubmitModel.IsDefault())
            {
                _calculatorSubmitModel.ToggleDefaultValues();
            }
            _calculatorSubmitModel.SecondOp = ParseInput(e.Value.ToString());
        }

        private void OnCalcActionSelect(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            _calculatorSubmitModel.Action = (CalculateAction)Enum.Parse(typeof(CalculateAction), e.Value.ToString(), true);
        }

        private void OnSubmit()
        {
            _calculatorSubmitModel.ToggleHasPosted();
            if (!_hasEverPosted)
            {
                _hasEverPosted = true;
            }
            Console.WriteLine($@"
                FirstOp: {_calculatorSubmitModel.FirstOp}
                SecondOp: {_calculatorSubmitModel.SecondOp}
                Action: {_calculatorSubmitModel.Action}
            ");
        }

        private bool HasEverPosted()
        {
            return _hasEverPosted;
        }

        private static long ParseInput(string? value)
        {
            value = value ?? "0";
            long result = 0;
            long.TryParse(value, out result);
            return result;
        }
    }
}
