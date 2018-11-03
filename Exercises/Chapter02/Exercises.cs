using System;

namespace Exercises.Chapter2
{
    // 1. Write a console app that calculates a user's Body-Mass Index:
    //   - prompt the user for her height in metres and weight in kg
    //   - calculate the BMI as weight/height^2
    //   - output a message: underweight(bmi<18.5), overweight(bmi>=25) or healthy weight
    // 2. Structure your code so that structure it so that pure and impure parts are separate
    // 3. Unit test the pure parts
    // 4. Unit test the impure parts using the HOF-based approach

    public static class BmiRules
    {
        public enum WeightType { Under, Over, Healthy, }

        public static WeightType GetWeightType((double Height, double Weight) bmiUnits)
        {
            var bmi = Math.Pow(bmiUnits.Weight / bmiUnits.Height, 2);
            var weightType =
                bmi < 18.5 ? WeightType.Under
                    : bmi >= 25 ? WeightType.Over
                        : WeightType.Healthy;

            return weightType;
        }

        public static string GetWeightTypeText(WeightType weightType)
        {
            switch (weightType)
            {
                case WeightType.Healthy:
                    return "Healthy";
                case WeightType.Over:
                    return "Overweight";
                case WeightType.Under:
                default:
                    return "Underweight";
            }
        }

    }
    public static class BmiIo
    {
        public static (double Height, double Weight) GetBmiInput()
        {
            Console.Write("Enter height: ");
            var inputHeight = Console.ReadLine();
            Console.Write("Enter weight: ");
            var inputWeight = Console.ReadLine();
            var canParse =
                double.TryParse(inputHeight, out var height)
                & double.TryParse(inputWeight, out var weight);
            if (canParse)
                Console.WriteLine($"height = {height}, weight = {weight}");
            else
                Console.WriteLine($"Unable to parse input: height = {inputHeight}, weight = {inputWeight}");

            return (height, weight);
        }
    }

    public static class BmiOrchestrator
    {
        public static string CalcBmi(Func<(double Height, double Weight)> getBmiInput)
        {
            var bmiUnits = getBmiInput();
            var weightType = BmiRules.GetWeightType(bmiUnits);
            var weightTypeText = BmiRules.GetWeightTypeText(weightType);
            return ($"Your weight based on BMI: {weightTypeText}");
        }

    }
}
