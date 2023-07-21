using System.ComponentModel.DataAnnotations;

namespace VisualCalc.Models
{
    using DataT = long;

    public class CalculatorSubmitModel
    {
        private bool _needDefault = true;
        private bool _hasPosted = false;
        private readonly DataT _defaultFirstOp = 0;
        private readonly DataT _defaultSecondOp = 0;
        private DataT _secondOp { set; get; } = 0;
        private DataT _firstOp { set; get; } = 0;

        [Required, EnumDataType(typeof(CalculateAction))]
        public CalculateAction Action { set; get; } = (CalculateAction)(new Random().Next(0, 4));

        [Required]
        public DataT FirstOp
        {
            set => _firstOp = value;
            get
            {
                return _needDefault ? _defaultFirstOp : _firstOp;
            }
        }
        [Required]
        public DataT SecondOp
        {
            set => _secondOp = value;
            get
            {
                return _needDefault ? _defaultSecondOp : _secondOp;
            }
        }

        public bool HasPosted { get => _hasPosted; }

        public DataT Max { get; } = 999999999999;
        public DataT Min { get; } = -999999999999;

        public CalculatorSubmitModel()
        {
            var rnd = new Random();
            _defaultFirstOp = rnd.Next(-999, 1000);
            _defaultSecondOp = rnd.Next(-999, 1000);
            _firstOp = _defaultFirstOp;
            _secondOp = _defaultSecondOp;
        }

        public void ToggleDefaultValues()
        {
            _needDefault = !_needDefault;
        }

        public void ToggleHasPosted()
        {
            _hasPosted = !_hasPosted;
        }

        public bool IsDefault()
        {
            return _firstOp == _defaultFirstOp && _secondOp == _defaultSecondOp;
        }
    }
}
