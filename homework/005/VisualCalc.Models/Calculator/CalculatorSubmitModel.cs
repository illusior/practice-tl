using System.ComponentModel.DataAnnotations;

namespace VisualCalc.Models.Calculator
{
    using DataT = long;

    public class CalculatorSubmitModel
    {
        private bool _hasPosted = false;

        [Required, EnumDataType(typeof(CalculateAction))]
        public CalculateAction Action { set; get; } = (CalculateAction)new Random().Next(0, 4);

        [Required]
        public DataT FirstOp { get; set; }
        [Required]
        public DataT SecondOp { get; set; }

        public bool HasPosted { get => _hasPosted; }

        public DataT Max { get; } = 999999999999;
        public DataT Min { get; } = -999999999999;

        public CalculatorSubmitModel()
        {
            var rnd = new Random();
            FirstOp = rnd.Next(-999, 1000);
            SecondOp = rnd.Next(-999, 1000);
        }
        public void ToggleHasPosted()
        {
            _hasPosted = !_hasPosted;
        }
    }
}
