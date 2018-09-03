using System;

namespace TracktorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var fuel = 13;
            var fuelCoef = 2;
            var fuelItem = 1;

            var field = new int[2, 3]
            {
                {1, 3, 5},
                {2, 4, 6}
            };

            var totalUsedFuel = 0;
            var currentStep = 0;
            var stepFuelUsed = 0;
            while (true)
            {
                for (int tracktor = 0; tracktor < field.GetLength(0); tracktor++)
                {
                    var tracktorBorder = field[tracktor, currentStep];
                    var itWasHardLine = currentStep % 2 != 0;
                    var lineItemsDone = currentStep > 0 ? field[tracktor, currentStep - 1] : 0;
                    if (itWasHardLine)
                    {
                        stepFuelUsed += (tracktorBorder - lineItemsDone) * fuelItem * fuelCoef;
                    }
                    else
                    {
                        stepFuelUsed += (tracktorBorder - lineItemsDone) * fuelItem;
                    }
                }

                if (totalUsedFuel + stepFuelUsed >= fuel)
                    break;


                totalUsedFuel += stepFuelUsed;
                stepFuelUsed = 0;
                currentStep++;
            }

            Console.WriteLine($"Steps done {currentStep}");
            Console.WriteLine($"Fuel used {totalUsedFuel}/{fuel}");
        }
    }
}