namespace Unit_Converter
{
    public class NumberToConvert
    {
        public string? UnitType {get; set;}
        public double Number {get; set;}
        public string? CurrentUnit {get; set;}
        public string? TargetUnit {get; set;}
    }

    public class Tools
    {
        // arrays for future use
        static string[] lengthUnitType = ["length", "len", "l"];
        static string[] weightUnitType = ["weight", "wei", "w"];
        static string[] temperatureUnitType = ["temperature", "temp", "t"];
        static string[] lengthUnits = ["mm", "cm", "m", "km", "in", "ft", "yd", "mi"];
        static string[] weightUnits = ["mg", "g", "kg", "t", "oz", "lb"];
        static string[] temperatureUnits = ["°C", "°F", "K", "C", "c", "F", "f", "k"];

        public static NumberToConvert GetInputAndValidate()
        {
            NumberToConvert numberObj = new();
            string[] acceptedUnitTypeValues = ["length", "weight", "temperature", "l", "w", "t", "len", "wei", "temp"];

            input_unit_type:
            Console.Write("What is the unit type? (length / weight / temperature) ");
            numberObj.UnitType = Console.ReadLine();
            if (!acceptedUnitTypeValues.Contains(numberObj.UnitType))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid unit type input, try again");
                Console.ResetColor();
                goto input_unit_type;
            }

            input_number_to_convert:
            Console.Write("Enter number to convert: ");
            if(!double.TryParse(Console.ReadLine(), out double numberUserInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid number input, try again");
                Console.ResetColor();
                goto input_number_to_convert;
            }
            numberObj.Number = numberUserInput;

            SetValidCurrentUnit(numberObj);
            SetValidTargetUnit(numberObj);
            
            return numberObj;
        }
        static void SetValidCurrentUnit(NumberToConvert numberObj)
        {
            input_current_unit:
            // give unit list that matches the unit type
            if(lengthUnitType.Contains(numberObj.UnitType))
            {
                Console.Write("Unit to covnvert from\n(mm, cm, m, km, in, ft, yd, mi): ");
            }
            else if(weightUnitType.Contains(numberObj.UnitType))
            {
                Console.Write("Unit to covnvert from\n(mg, g, kg, t, oz, lb): ");
            }
            else if(temperatureUnitType.Contains(numberObj.UnitType))
            {
                Console.Write("Unit to covnvert from\n(°C, °F, K): ");
            }

            numberObj.CurrentUnit = Console.ReadLine();

            // Check if entered unit matches the unit type
            if(lengthUnitType.Contains(numberObj.UnitType) && !lengthUnits.Contains(numberObj.CurrentUnit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid unit input, try again");
                Console.ResetColor();
                goto input_current_unit;
            }
            else if(weightUnitType.Contains(numberObj.UnitType) && !weightUnits.Contains(numberObj.CurrentUnit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid unit input, try again");
                Console.ResetColor();
                goto input_current_unit;
            }
            else if(temperatureUnitType.Contains(numberObj.UnitType) && !temperatureUnits.Contains(numberObj.CurrentUnit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid unit input, try again");
                Console.ResetColor();
                goto input_current_unit;
            }
        }
        static void SetValidTargetUnit(NumberToConvert numberObj)
        {
            input_target_unit:
            // give unit list that matches the unit type
            if(lengthUnitType.Contains(numberObj.UnitType))
            {
                Console.Write("Unit to covnvert to\n(mm, cm, m, km, in, ft, yd, mi): ");
            }
            else if(weightUnitType.Contains(numberObj.UnitType))
            {
                Console.Write("Unit to covnvert to\n(mg, g, kg, t, oz, lb): ");
            }
            else if(temperatureUnitType.Contains(numberObj.UnitType))
            {
                Console.Write("Unit to covnvert to\n(°C, °F, K): ");
            }

            numberObj.TargetUnit = Console.ReadLine();

            // Check if entered unit matches the unit type
            if(lengthUnitType.Contains(numberObj.UnitType) && !lengthUnits.Contains(numberObj.TargetUnit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid unit input, try again");
                Console.ResetColor();
                goto input_target_unit;
            }
            else if(weightUnitType.Contains(numberObj.UnitType) && !weightUnits.Contains(numberObj.TargetUnit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid unit input, try again");
                Console.ResetColor();
                goto input_target_unit;
            }
            else if(temperatureUnitType.Contains(numberObj.UnitType) && !temperatureUnits.Contains(numberObj.TargetUnit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid unit input, try again");
                Console.ResetColor();
                goto input_target_unit;
            }
        }
    }
}