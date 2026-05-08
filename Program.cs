namespace Unit_Converter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("\n");
            NumberToConvert numberObj = Tools.GetInputAndValidate();

            double result = Tools.Convert(numberObj);
            Console.WriteLine($"\nResult: {result:F2} {numberObj.TargetUnit}");
        }
    }
}