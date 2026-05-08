using System.Net.NetworkInformation;

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
        static string[] temperatureUnits = ["°C", "°F", "K", "C", "c", "F", "f", "k", "°c", "°f"];

        public static double Convert(NumberToConvert numberObj)
        {
            double result = 0;
            if (lengthUnitType.Contains(numberObj.UnitType))
            {
                result = LengthConvert(numberObj);
            }
            else if (weightUnitType.Contains(numberObj.UnitType))
            {
                result = WeightConvert(numberObj);
            }
            else if (temperatureUnitType.Contains(numberObj.UnitType))
            {
                result = TemperatureConvert(numberObj);
            }

            return result;
        }

        public static double LengthConvert(NumberToConvert numberObj)
        {
            double result = 0;
                double value = numberObj.Number;

            if (numberObj.CurrentUnit == "mm")
            {
                if (numberObj.TargetUnit == "cm") result = value / 10.0;
                else if (numberObj.TargetUnit == "m") result = value / 1000.0;
                else if (numberObj.TargetUnit == "km") result = value / 1000000.0;
                else if (numberObj.TargetUnit == "in") result = value / 25.4;
                else if (numberObj.TargetUnit == "ft") result = value / 304.8;
                else if (numberObj.TargetUnit == "yd") result = value / 914.4;
                else if (numberObj.TargetUnit == "mi") result = value / 1609344.0;
                else result = value; // same unit
            }
            else if (numberObj.CurrentUnit == "cm")
            {
                if (numberObj.TargetUnit == "mm") result = value * 10.0;
                else if (numberObj.TargetUnit == "m") result = value / 100.0;
                else if (numberObj.TargetUnit == "km") result = value / 100000.0;
                else if (numberObj.TargetUnit == "in") result = value / 2.54;
                else if (numberObj.TargetUnit == "ft") result = value / 30.48;
                else if (numberObj.TargetUnit == "yd") result = value / 91.44;
                else if (numberObj.TargetUnit == "mi") result = value / 160934.4;
                else result = value;
            }
            else if (numberObj.CurrentUnit == "m")
            {
                if (numberObj.TargetUnit == "mm") result = value * 1000.0;
                else if (numberObj.TargetUnit == "cm") result = value * 100.0;
                else if (numberObj.TargetUnit == "km") result = value / 1000.0;
                else if (numberObj.TargetUnit == "in") result = value * 39.37007874;
                else if (numberObj.TargetUnit == "ft") result = value * 3.280839895;
                else if (numberObj.TargetUnit == "yd") result = value * 1.093613298;
                else if (numberObj.TargetUnit == "mi") result = value / 1609.344;
                else result = value;
            }
            else if (numberObj.CurrentUnit == "km")
            {
                if (numberObj.TargetUnit == "mm") result = value * 1000000.0;
                else if (numberObj.TargetUnit == "cm") result = value * 100000.0;
                else if (numberObj.TargetUnit == "m") result = value * 1000.0;
                else if (numberObj.TargetUnit == "in") result = value * 39370.07874;
                else if (numberObj.TargetUnit == "ft") result = value * 3280.839895;
                else if (numberObj.TargetUnit == "yd") result = value * 1093.613298;
                else if (numberObj.TargetUnit == "mi") result = value / 1.609344;
                else result = value;
            }
            else if (numberObj.CurrentUnit == "in")
            {
                if (numberObj.TargetUnit == "mm") result = value * 25.4;
                else if (numberObj.TargetUnit == "cm") result = value * 2.54;
                else if (numberObj.TargetUnit == "m") result = value * 0.0254;
                else if (numberObj.TargetUnit == "km") result = value * 0.0000254;
                else if (numberObj.TargetUnit == "ft") result = value / 12.0;
                else if (numberObj.TargetUnit == "yd") result = value / 36.0;
                else if (numberObj.TargetUnit == "mi") result = value / 63360.0;
                else result = value;
            }
            else if (numberObj.CurrentUnit == "ft")
            {
                if (numberObj.TargetUnit == "mm") result = value * 304.8;
                else if (numberObj.TargetUnit == "cm") result = value * 30.48;
                else if (numberObj.TargetUnit == "m") result = value * 0.3048;
                else if (numberObj.TargetUnit == "km") result = value * 0.0003048;
                else if (numberObj.TargetUnit == "in") result = value * 12.0;
                else if (numberObj.TargetUnit == "yd") result = value / 3.0;
                else if (numberObj.TargetUnit == "mi") result = value / 5280.0;
                else result = value;
            }
            else if (numberObj.CurrentUnit == "yd")
            {
                if (numberObj.TargetUnit == "mm") result = value * 914.4;
                else if (numberObj.TargetUnit == "cm") result = value * 91.44;
                else if (numberObj.TargetUnit == "m") result = value * 0.9144;
                else if (numberObj.TargetUnit == "km") result = value * 0.0009144;
                else if (numberObj.TargetUnit == "in") result = value * 36.0;
                else if (numberObj.TargetUnit == "ft") result = value * 3.0;
                else if (numberObj.TargetUnit == "mi") result = value / 1760.0;
                else result = value;
            }
            else if (numberObj.CurrentUnit == "mi")
            {
                if (numberObj.TargetUnit == "mm") result = value * 1609344.0;
                else if (numberObj.TargetUnit == "cm") result = value * 160934.4;
                else if (numberObj.TargetUnit == "m") result = value * 1609.344;
                else if (numberObj.TargetUnit == "km") result = value * 1.609344;
                else if (numberObj.TargetUnit == "in") result = value * 63360.0;
                else if (numberObj.TargetUnit == "ft") result = value * 5280.0;
                else if (numberObj.TargetUnit == "yd") result = value * 1760.0;
                else result = value;
            }
            else
            {
                result = value; // unknown current unit
            }

            return result;
        }
        public static double WeightConvert(NumberToConvert numberObj)
        {
            double result = 0;

            double value = numberObj.Number;
            if (numberObj.CurrentUnit == "mg")
            {
                if (numberObj.TargetUnit == "g") result = value / 1000.0;
                else if (numberObj.TargetUnit == "kg") result = value / 1000000.0;
                else if (numberObj.TargetUnit == "t") result = value / 1e9;
                else if (numberObj.TargetUnit == "oz") result = value / 28349.523125;
                else if (numberObj.TargetUnit == "lb") result = value / 453592.37;
                else result = value; // same unit
            }
            else if (numberObj.CurrentUnit == "g")
            {
                if (numberObj.TargetUnit == "mg") result = value * 1000.0;
                else if (numberObj.TargetUnit == "kg") result = value / 1000.0;
                else if (numberObj.TargetUnit == "t") result = value / 1e6;
                else if (numberObj.TargetUnit == "oz") result = value / 28.349523125;
                else if (numberObj.TargetUnit == "lb") result = value / 453.59237;
                else result = value;
            }
            else if (numberObj.CurrentUnit == "kg")
            {
                if (numberObj.TargetUnit == "mg") result = value * 1e6;
                else if (numberObj.TargetUnit == "g") result = value * 1000.0;
                else if (numberObj.TargetUnit == "t") result = value / 1000.0;
                else if (numberObj.TargetUnit == "oz") result = value * 35.27396195;
                else if (numberObj.TargetUnit == "lb") result = value * 2.204622622;
                else result = value;
            }
            else if (numberObj.CurrentUnit == "t")
            {
                if (numberObj.TargetUnit == "mg") result = value * 1e9;
                else if (numberObj.TargetUnit == "g") result = value * 1e6;
                else if (numberObj.TargetUnit == "kg") result = value * 1000.0;
                else if (numberObj.TargetUnit == "oz") result = value * 35273.96195;
                else if (numberObj.TargetUnit == "lb") result = value * 2204.622622;
                else result = value;
            }
            else if (numberObj.CurrentUnit == "oz")
            {
                if (numberObj.TargetUnit == "mg") result = value * 28349.523125;
                else if (numberObj.TargetUnit == "g") result = value * 28.349523125;
                else if (numberObj.TargetUnit == "kg") result = value / 35.27396195;
                else if (numberObj.TargetUnit == "t") result = value / 35273.96195;
                else if (numberObj.TargetUnit == "lb") result = value / 16.0;
                else result = value;
            }
            else if (numberObj.CurrentUnit == "lb")
            {
                if (numberObj.TargetUnit == "mg") result = value * 453592.37;
                else if (numberObj.TargetUnit == "g") result = value * 453.59237;
                else if (numberObj.TargetUnit == "kg") result = value / 2.204622622;
                else if (numberObj.TargetUnit == "t") result = value / 2204.622622;
                else if (numberObj.TargetUnit == "oz") result = value * 16.0;
                else result = value;
            }
            else
            {
                result = value; // unknown current unit
            }

            return result;
        }
        public static double TemperatureConvert(NumberToConvert numberObj)
        {
            double result = 0;

            double value = numberObj.Number;

            // Step 1: Normalize current and target unit strings to standard form
            string current = numberObj.CurrentUnit?.Trim().ToUpper() ?? "";
            string target = numberObj.TargetUnit?.Trim().ToUpper() ?? "";

            if (current == "C" || current == "°C") current = "C";
            else if (current == "F" || current == "°F") current = "F";
            else if (current == "K") current = "K";
            else current = "?";
                
            if (target == "C" || target == "°C") target = "C";
            else if (target == "F" || target == "°F") target = "F";
            else if (target == "K") target = "K";
            else target = "?";

            // Step 2: Perform conversion if both units are valid
            if (current == "C")
            {
                if (target == "C") result = value;
                else if (target == "F") result = (value * 9.0 / 5.0) + 32;
                else if (target == "K") result = value + 273.15;
                else result = value;
            }
            else if (current == "F")
            {
                if (target == "F") result = value;
                else if (target == "C") result = (value - 32) * 5.0 / 9.0;
                else if (target == "K") result = (value - 32) * 5.0 / 9.0 + 273.15;
                else result = value;
            }
            else if (current == "K")
            {
                if (target == "K") result = value;
                else if (target == "C") result = value - 273.15;
                else if (target == "F") result = (value - 273.15) * 9.0 / 5.0 + 32;
                else result = value;
            }
            else
            {
                result = value; // unknown unit
            }

            return result;
        }
        
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
                Console.Write("Unit to convert from\n(mm, cm, m, km, in, ft, yd, mi): ");
            }
            else if(weightUnitType.Contains(numberObj.UnitType))
            {
                Console.Write("Unit to convert from\n(mg, g, kg, t, oz, lb): ");
            }
            else if(temperatureUnitType.Contains(numberObj.UnitType))
            {
                Console.Write("Unit to convert from\n(°C, °F, K): ");
            }

            numberObj.CurrentUnit = Console.ReadLine()?.Trim().ToLower();

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
                Console.Write("Unit to convert to\n(mm, cm, m, km, in, ft, yd, mi): ");
            }
            else if(weightUnitType.Contains(numberObj.UnitType))
            {
                Console.Write("Unit to convert to\n(mg, g, kg, t, oz, lb): ");
            }
            else if(temperatureUnitType.Contains(numberObj.UnitType))
            {
                Console.Write("Unit to convert to\n(°C, °F, K): ");
            }

            numberObj.TargetUnit = Console.ReadLine()?.Trim().ToLower();

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