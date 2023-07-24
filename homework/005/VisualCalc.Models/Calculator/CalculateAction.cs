namespace VisualCalc.Models.Calculator
{
    public enum CalculateAction
    {
        Unknown = -1,
        Plus = 0,
        Minus,
        Multiplication,
        Division,
    }

    public class CalculateActionHelpers
    {
        public static string? CalculateActionToString(CalculateAction action)
        {
            switch (action)
            {
                case CalculateAction.Plus:
                    return "+";
                case CalculateAction.Minus:
                    return "-";
                case CalculateAction.Multiplication:
                    return "*";
                case CalculateAction.Division:
                    return "/";
                case CalculateAction.Unknown:
                default:
                    return null;
            }
        }

        public static long? CalculateActionToLong(CalculateAction action, long firstOp, long secondOp)
        {
            switch (action)
            {
                case CalculateAction.Plus:
                    return firstOp + secondOp;
                case CalculateAction.Minus:
                    return firstOp - secondOp;
                case CalculateAction.Multiplication:
                    return firstOp * secondOp;
                case CalculateAction.Division:
                    return firstOp / secondOp;
            }
            return null;
        }
    }
}
