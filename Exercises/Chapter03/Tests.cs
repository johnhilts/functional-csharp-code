using System;
using System.Collections.Generic;
using Exercises.Chapter3;
using FluentAssertions;
using LaYumba.Functional;
using NSpec;
using static Exercises.Chapter3.Exercises;
using static LaYumba.Functional.F;

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
                      {"Friday", Some<DayOfTheWeek>(DayOfTheWeek.Friday)},
                      {"Freeday", None},
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

        void robust_lookup()
        {
            context["lookup extension"] = () =>
            {
                // either of these work
                Func<int, bool> isFuncOdd = (int i) => i % 2 == 1;
                bool isOdd(int i) => i % 2 == 1;

                new Each<(Func<int, bool> Predicate, IEnumerable<int> List), Option<int>>
                  {
                      {(isOdd, new List<int>()), None},
                      {(isOdd, new List<int>{1}), Some(1)},
                      {(isFuncOdd, new List<int>()), None},
                      {(isFuncOdd, new List<int>{1}), Some(1)},
                      {(isOdd, new List<int>{10,20,25,11}), Some(25)},
                  }.Do((given, expected) =>
                  {
                      // 2 Write a Lookup function that will take an IEnumerable and a predicate, and
                      // return the first element in the IEnumerable that matches the predicate, or None
                      // if no matching element is found. Write its signature in arrow notation:
                      it[$"should lookup the first element matching the predicate"] = () =>
                       {
                           var actual = given.List.Lookup(given.Predicate);
                           actual.Should().Be(expected);
                       };
                  });
            };
        }

    }
}

