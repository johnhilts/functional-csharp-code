using Exercises.Chapter3;
using FluentAssertions;
using LaYumba.Functional;
using NSpec;
using static Exercises.Chapter3.Exercises;

namespace Tests.Chapter3
{
    public class ChapterThreeSpec : nspec
    {
        void parsing_enums()
        {
            context["can parse an enum"] = () =>
              {
                  new Each<string, DayOfTheWeek>
                  {
                      {"Friday", DayOfTheWeek.Friday},
                      // {"Freeday", DayOfTheWeek.Invalid},
                  }.Do((given, expected) =>
                  {
                      it[$"should return {expected} for {given.ToString()}"] = () =>
                       {
                           var actual = ParseIt(given);
                           actual.Should().Be(expected);
                       };
                  });

                  new Each<string, Option<DayOfTheWeek>>
                  {
                      {"Friday", F.Some<DayOfTheWeek>(DayOfTheWeek.Friday)},
                      {"Freeday", F.None},
                  }.Do((given, expected) =>
                  {
                      it[$"extension should also return {expected} for {given.ToString()}"] = () =>
                       {
                           var actual = MyEnum.Parse<DayOfTheWeek>(given);
                           actual.Should().Be(expected);
                       };
                  });

              };
        }

    }
}

