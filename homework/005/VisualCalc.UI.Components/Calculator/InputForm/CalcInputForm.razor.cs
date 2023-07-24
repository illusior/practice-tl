using Microsoft.AspNetCore.Components;
using VisualCalc.Models.Calculator;

namespace VisualCalc.UI.Components.Calculator.InputForm
{
    public partial class CalcInputForm
    {
        private bool _hasEverPosted = false;
        private CalculatorSubmitModel _calculatorSubmitModel { set; get; } = new();

        private void OnFirstOpInput(ChangeEventArgs e)
        {
            if (e.Value == null) return;
            _calculatorSubmitModel.FirstOp = ParseInput(e.Value.ToString());
        }

        private void OnSecondOpInput(ChangeEventArgs e)
        {
            if (e.Value == null) return;
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
        }

        private bool HasEverPosted()
        {
            return _hasEverPosted;
        }

        private static long ParseInput(string? value)
        {
            value ??= "0";
            _ = long.TryParse(value, out long result);
            return result;
        }

        private void SwapArguments()
        {
            (_calculatorSubmitModel.FirstOp, _calculatorSubmitModel.SecondOp) =
                (_calculatorSubmitModel.SecondOp, _calculatorSubmitModel.FirstOp);
        }
    }
}
