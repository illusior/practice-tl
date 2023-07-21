using Microsoft.AspNetCore.Components;
using VisualCalc.Models;

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
    }
}
