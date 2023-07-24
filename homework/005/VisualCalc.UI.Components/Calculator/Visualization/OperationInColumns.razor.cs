using Microsoft.AspNetCore.Components;
using VisualCalc.Models.Calculator;
using VisualCalc.Models.Calculator.Visualization;

namespace VisualCalc.UI.Components.Calculator.Visualization
{
    using DataT = long;
    public partial class OperationInColumns
    {
        [Parameter]
        public DataT FirstOp { get; set; }
        [Parameter]
        public DataT SecondOp { get; set; }
        [Parameter]
        public CalculateAction CalcAction { get; set; }

        private ColumnCalculationModel<DataT>? _columnCalculationModel;
        public ColumnCalculationModel<DataT> ColumnCalculationModel
        {
            get => _columnCalculationModel!;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _columnCalculationModel = new(FirstOp, SecondOp, CalcAction);
        }
    }
}
