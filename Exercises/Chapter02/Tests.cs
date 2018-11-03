using System;
using FluentAssertions;
using NSpec;
using static Exercises.Chapter2.BmiRules;

namespace bcbc.Unit.Member
{
    public class ChapterTwoSpec : nspec
    {
        void calculating_bmi()
        {
            context["unit tests the pure parts"] = () =>
              {
                  new Each<WeightType, string>
                  {
                      { WeightType.Under,  "Underweight" },
                      { WeightType.Healthy,  "Healthy" },
                      { WeightType.Over,  "Overweight" },
                  }.Do((given, expected) =>
                  {
                      it[$"should return {expected} for the given weight type ({given.ToString()})"] = () =>
                       {
                           var actual = Exercises.Chapter2.BmiRules.GetWeightTypeText(given);
                           actual.Should().Be(expected);
                       };
                  });

                  new Each<(double Height, double Weight), WeightType>
                  {
                      { (84, 100), WeightType.Under },
                      { (72, 350), WeightType.Healthy },
                      { (60, 300), WeightType.Over },
                  }.Do((given, expected) =>
                  {
                      it[$"should return {expected} when given BMI of {given.Height} Height and {given.Weight} Weight"] = () =>
                       {
                           var actual = Exercises.Chapter2.BmiRules.GetWeightType((given));
                           actual.Should().Be(expected);
                       };
                  });
              };
            context["unit tests the impure parts using HOF approach"] = () =>
              {
                  new Each<(double Height, double Weight), string>
                  {
                      { (84, 100),  "Your weight based on BMI: Underweight" },
                      { (72, 350),  "Your weight based on BMI: Healthy"  },
                      { (60, 300),  "Your weight based on BMI: Overweight"  },
                  }.Do((given, expected) =>
                  {
                      it[$"should return {expected} when given BMI of {given.Height} Height and {given.Weight} Weight"] = () =>
                       {
                           Func<(double Height, double Weight)> f = () => given;
                           var actual = Exercises.Chapter2.BmiOrchestrator.CalcBmi(f);
                           actual.Should().Be(expected);
                       };
                  });

              };
        }

    }
}
