namespace VisualCalc.Models.Calculator.Visualization
{    
    using FieldRow = List<DigitCell?>;

    public class ColumnCalculationModel<T> where T : IComparable<T>
    {
        private readonly T _firstOp, _secondOp;
        private readonly CalculateAction _calculateAction;
        private readonly IColumnFillStrategy<T> _columnFillStrategy;

        public readonly List<FieldRow> FieldOfRowDigits;

        public ColumnCalculationModel(T firstOp, T secondOp, CalculateAction action)
        {
            _firstOp = firstOp;
            _secondOp = secondOp;
            _calculateAction = action;

            switch (_calculateAction)
            {
                case CalculateAction.Plus:
                case CalculateAction.Minus:
                    _columnFillStrategy = new SumOrSubstractionFillStrategy<T>();
                    break;
                case CalculateAction.Multiplication:
                case CalculateAction.Division:
                    break;
                case CalculateAction.Unknown:
                default:
                    throw new NotImplementedException();
            }

            FieldOfRowDigits = _columnFillStrategy!.FillByOperands(_firstOp, _secondOp, _calculateAction);
        }
    }

    interface IColumnFillStrategy<T> where T : IComparable<T>
    {
        public List<FieldRow> FillByOperands(T firstOp, T secondOp, CalculateAction action);
    }

    internal sealed class SumOrSubstractionFillStrategy<T> : IColumnFillStrategy<T> where T : IComparable<T>
    {
        public List<FieldRow> FillByOperands(T firstOperand, T secondOperand, CalculateAction calcAction)
        {
            long firstOpConverted = Convert.ToInt64(firstOperand);
            long secondOpConverted = Convert.ToInt64(secondOperand);

            long? resultDigit =
                CalculateActionHelpers.CalculateActionToLong(calcAction,
                    firstOpConverted,
                    secondOpConverted);
            if (resultDigit == null)
            {
                throw new ArgumentException();
            }

            bool isFirstBiggerAbs = Math.Abs(firstOpConverted) > Math.Abs(secondOpConverted);
            if (!isFirstBiggerAbs)
            {
                (firstOpConverted, secondOpConverted) = (secondOpConverted, firstOpConverted);
            }

            FieldRow firstDigitFR = Helpers.DigitToCharRow(firstOpConverted);
            FieldRow secondDigitFR = Helpers.DigitToCharRow(secondOpConverted);
            FieldRow resultDigitFR = Helpers.DigitToCharRow(resultDigit);

            int columnWidthLength = Math.Max(Math.Max(firstDigitFR.Count, secondDigitFR.Count),
                resultDigitFR.Count);
            firstDigitFR = Helpers.AdjustListWithNullFromLeftToSize(firstDigitFR, columnWidthLength);
            secondDigitFR = Helpers.AdjustListWithNullFromLeftToSize(secondDigitFR, columnWidthLength);
            resultDigitFR = Helpers.AdjustListWithNullFromLeftToSize(resultDigitFR, columnWidthLength);

            FieldRow remindersFR = ComputeReminders(firstDigitFR, secondDigitFR, resultDigitFR, calcAction);
            remindersFR = Helpers.AdjustListWithNullFromLeftToSize(remindersFR, columnWidthLength);

            List<FieldRow> result = new() {
                remindersFR,
                firstDigitFR,
                secondDigitFR,
                resultDigitFR
            };

            return result;
        }

        private static FieldRow ComputeReminders(FieldRow firstOperand, FieldRow secondOperand, FieldRow operationResult, CalculateAction calcAction)
        {
            if (firstOperand.Count != secondOperand.Count &&
                firstOperand.Count != operationResult.Count ||
                !(calcAction == CalculateAction.Plus ||
                    calcAction == CalculateAction.Minus))
            {
                throw new ArgumentException();
            }

            FieldRow result = Enumerable.Repeat(default(DigitCell?), operationResult.Count).ToList();
            HashSet<BorderSide> borders = Helpers.GetSetWithAllBorders();
            bool firstIsPositive = !Helpers.FieldRowIsNegativeDigit(firstOperand);
            bool secondIsPositive = !Helpers.FieldRowIsNegativeDigit(secondOperand);
            bool calcActionIsPlus = calcAction == CalculateAction.Plus &&
                (firstIsPositive && secondIsPositive || !firstIsPositive && !secondIsPositive) ||
                calcAction == CalculateAction.Minus && firstIsPositive && !secondIsPositive;
            bool calcActionIsMinus = calcAction == CalculateAction.Minus && !calcActionIsPlus;

            for (int i = 0, operationResultSize = calcActionIsPlus ? operationResult.Count - 1 : operationResult.Count;
                i < operationResultSize;
                i++)
            {
                if (operationResult[i] == null || !operationResult[i]!.IsDigit())
                {
                    continue;
                }

                int resultDigitAtI = operationResult[i]!.GetDigit();
                int firstOperandDigitAtI = firstOperand[i] != null && firstOperand[i]!.IsDigit()
                    ? firstOperand[i]!.GetDigit()
                    : 0;
                int secondOperandDigitAtI = secondOperand[i] != null && secondOperand[i]!.IsDigit()
                    ? secondOperand[i]!.GetDigit()
                    : 0;

                if (calcActionIsPlus)
                {
                    if ((firstOperandDigitAtI + secondOperandDigitAtI) % 10 != resultDigitAtI)
                    {
                        result[i] = new DigitCell(
                            symbType: SymbolType.Reminder,
                            borders: new Borders(borders));
                    }
                }

                if (calcActionIsMinus)
                {
                    bool needAddReminderAtPrev = firstOperandDigitAtI - secondOperandDigitAtI < 0;
                    if (needAddReminderAtPrev)
                    {
                        result[i - 1] = new DigitCell(
                            symbType: SymbolType.SubstractionReminderDot,
                            borders: new Borders(borders));
                    }
                }
            }

            return result;
        }
    }

    internal class Helpers
    {
        public static IEnumerable<char> DigitByChars(long number)
        {
            long absNumber = Math.Abs(number);

            Stack<char> digitChars = new();
            if (number == 0)
            {
                digitChars.Push('0');
            }

            while (absNumber > 0)
            {
                digitChars.Push((absNumber % 10).ToString()[0]);
                absNumber /= 10;
            }

            if (number < 0)
            {
                digitChars.Push('-');
            }

            do
            {
                yield return digitChars.Pop();
            } while (digitChars.Count > 0);
        }

        public static FieldRow DigitToCharRow<T>(T digit)
        {
            FieldRow result = new();
            long convertedDigit = Convert.ToInt64(digit);

            HashSet<BorderSide> borders = GetSetWithAllBorders();

            foreach (char? digitChar in DigitByChars(convertedDigit))
            {
                result.Add(new DigitCell(digitChar, new Borders(borders)));
            }

            return result;
        }

        public static List<T?> AdjustListWithNullFromLeftToSize<T>(List<T?> list, int size)
        {
            if (list.Count < size)
            {
                List<T?> nullRowToAdd = Enumerable.Repeat(default(T), size - list.Count).ToList();
                list = nullRowToAdd.Concat(list).ToList();
            }

            return list;
        }

        public static HashSet<BorderSide> GetSetWithAllBorders()
        {
            return new()
            {
                BorderSide.Bottom,
                BorderSide.Left,
                BorderSide.Right,
                BorderSide.Up,
            };
        }

        public static bool FieldRowIsNegativeDigit(FieldRow row)
        {
            return row.Any(digitCell => digitCell?.Symbol.Type == SymbolType.Minus);
        }
    }

    public enum BorderSide
    {
        Left = 0,
        Up,
        Right,
        Bottom,
    }

    public class Borders
    {
        public HashSet<BorderSide> BordersSet = new();
        public HashSet<BorderSide> BoldSidesSet = new();

        public Borders(HashSet<BorderSide> borders, HashSet<BorderSide> boldSides)
        {
            BordersSet = borders;
            BoldSidesSet = boldSides;
        }

        public Borders(HashSet<BorderSide> borders)
        {
            BordersSet = borders;
        }
    }

    public enum SymbolType
    {
        Unknown = -1,
        Digit = 0,
        Plus,
        Minus,
        Reminder,
        SubstractionReminderDot,
    }

    public class Symbol
    {
        public static readonly Dictionary<SymbolType, string?> s_typeToSymbString = new()
        {
            { SymbolType.Digit, "0" },
            { SymbolType.Plus, "+" },
            { SymbolType.Minus, "-" },
            { SymbolType.Reminder, "1" },
            { SymbolType.SubstractionReminderDot, "•" },
            { SymbolType.Unknown, null },
        };
        public static readonly HashSet<SymbolType> s_reminders = new()
        {
            SymbolType.Reminder,
            SymbolType.SubstractionReminderDot,
        };
        public readonly SymbolType Type;
        public readonly string? Symb;

        public Symbol(char? symb)
        {
            Symb = $"{symb}";
            if (symb != null && char.IsDigit((char)symb))
            {
                Type = SymbolType.Digit;
            }
            else
            {
                Type = s_typeToSymbString.FirstOrDefault(x => x.Value == Symb).Key;
            }
        }

        public Symbol(SymbolType symbType)
        {
            Symb = s_typeToSymbString.GetValueOrDefault(symbType);
            Type = symbType;
        }

        public string GetSymbol()
        {
            return $"{Symb}";
        }

        public bool IsSymbReminder()
        {
            return s_reminders.Any(reminder => reminder == Type);
        }

        public bool IsSymbZero()
        {
            return Symb == "0";
        }
    }

    public class DigitCell
    {
        public readonly Borders Borders;
        public readonly Symbol Symbol;

        public DigitCell(char? symbol, Borders borders)
        {
            Borders = borders;
            Symbol = new(symbol);
        }

        public DigitCell(SymbolType symbType, Borders borders)
        {
            Borders = borders;
            Symbol = new(symbType);
        }

        public bool IsDigit()
        {
            return Symbol.Type == SymbolType.Digit;
        }

        public int GetDigit()
        {
            if (!IsDigit())
            {
                throw new InvalidCastException();
            }

            char symb = Symbol.Symb == null ? '0' : Symbol.Symb[0];
            return symb - '0';
        }
    }
}
