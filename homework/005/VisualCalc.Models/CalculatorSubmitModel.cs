namespace VisualCalc.Models
{
    public class CalculatorSubmitModel
    {
        public int? FirstOp { set; get; }
        public int? SecondOp { set; get; }

        public CalculateAction Action { set; get; }
    }
}
