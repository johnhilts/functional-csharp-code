using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Chapter1
{
    static class Exercises
   {
       public static void RunIt1()
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
        public static void RunIt2()
        {
            OutputRunIt2(new[] { 4, 5, 6, 1, 3, 2, 7 });
            OutputRunIt2(new[] { 322, 126, 258, 78, 233, 90, 42 });
            OutputRunIt2(new[] { 10, 7, 8, 9, 6 });
        }
        private static void OutputRunIt2(int[] l)
        {
            Console.WriteLine(string.Join(",", l.Select(i => i.ToString()).ToList()));
            Console.WriteLine(string.Join(",", quicksort(l)));
            Console.WriteLine();
        }

        private static int[] quicksort(int[] origArray)
        {
            if (origArray.Length <= 1)
            {
                return origArray;
            }
            else
            {
                var pivot = origArray[origArray.Length - 1];
                var newArray = origArray.Take(origArray.Length - 1);

                var left = newArray.Where(a => a <= pivot).Select(a => a).ToArray();
                var right = newArray.Where(a => a > pivot).Select(a => a).ToArray();

                return quicksort(left).Concat(new[] { pivot }).Concat(quicksort(right)).ToArray();
            }
        }


        // 3. Generalize your implementation to take a `List<T>`, and additionally a 
        // `Comparison<T>` delegate.

        // 4. In this chapter, you've seen a `Using` function that takes an `IDisposable`
        // and a function of type `Func<TDisp, R>`. Write an overload of `Using` that
        // takes a `Func<IDisposable>` as first
        // parameter, instead of the `IDisposable`. (This can be used to fix warnings
        // given by some code analysis tools about instantiating an `IDisposable` and
        // not disposing it.)
        private static R Using<TDisp, R>(Func<IDisposable> d, Func<IDisposable, R> f) where TDisp : IDisposable
        {
            return f(d());
        }
    }
}
