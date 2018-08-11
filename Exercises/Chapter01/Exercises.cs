﻿using System;

namespace Exercises.Chapter1
{
    static class Exercises
   {
       public static void RunIt()
       {
           var isNegative = IsPositive.Negate();
            Console.WriteLine(IsPositive(-1));
            Console.WriteLine(IsPositive(0));
            Console.WriteLine(IsPositive(1));
            Console.WriteLine(isNegative(-1));
            Console.WriteLine(isNegative(0));
            Console.WriteLine(isNegative(1));
            var isNegativeNumber = IsPositiveNumber.Negate();
            Console.WriteLine(IsPositiveNumber(-1));
            Console.WriteLine(IsPositiveNumber(-0));
            Console.WriteLine(IsPositiveNumber(1));
            Console.WriteLine(isNegativeNumber(-1));
            Console.WriteLine(isNegativeNumber(0));
            Console.WriteLine(isNegativeNumber(1));
       }

        // 1. Write a function that negates a given predicate: whenvever the given predicate
        // evaluates to `true`, the resulting function evaluates to `false`, and vice versa.
        private static Func<decimal, bool> IsPositive = (decimal d) => d > 0;
        private static Func<int, bool> IsPositiveNumber = (int d) => d > 0;

        static Func<T, bool> Negate<T>(this Func<T, bool> pred) => t => !pred(t);
      // 2. Write a method that uses quicksort to sort a `List<int>` (return a new list,
      // rather than sorting it in place).

      // 3. Generalize your implementation to take a `List<T>`, and additionally a 
      // `Comparison<T>` delegate.

      // 4. In this chapter, you've seen a `Using` function that takes an `IDisposable`
      // and a function of type `Func<TDisp, R>`. Write an overload of `Using` that
      // takes a `Func<IDisposable>` as first
      // parameter, instead of the `IDisposable`. (This can be used to fix warnings
      // given by some code analysis tools about instantiating an `IDisposable` and
      // not disposing it.)
   }
}
