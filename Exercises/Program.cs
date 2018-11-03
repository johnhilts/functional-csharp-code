using System;
using System.Linq;
using NSpec;
using NSpec.Domain; // SpecFinder
using NSpec.Domain.Formatters; // ConsoleFormatter
using System.Collections.Generic;

namespace Exercises
{
    class Program 
    {
        /*
         * Original version, from NSpec documentation, or Gist example:
            var types = GetType().GetTypeInfo().Assembly.GetTypes();
  
         * leads to: 
            Program.cs(17,21): error CS0120: An object reference is required for 
                                the nonstatic field, method, or property 'member' 
                                'object.GetType()' [./Calculator/specs/specs.csproj]            
         */
        static void Main(string[] args)
        {
            var types = typeof(Program).Assembly.GetTypes();
            var finder = new SpecFinder(types, "");
            var tags = new Tags { ExcludeTags = new List<string> { "slow" }, };
            var tagsFilter = tags.Parse("");
            var builder = new ContextBuilder(finder, tagsFilter, new DefaultConventions());
            var runner = new ContextRunner(tagsFilter, new ConsoleFormatter(), false);
            var results = runner.Run(builder.Contexts().Build());
 
            if(results.Failures().Count() > 0)
            {
                Environment.Exit(1);
            }
        }
    }
}


/* 
using System;

namespace Exercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Chapter1.Exercises.RunIt2();
            // run the program you've written, for example:
            // Chapter2.Solutions.Bmi.Run();
            Chapter2.BmiOrchestrator.CalcBmi(Chapter2.BmiIo.GetBmiInput);
            Func<(double Height, double Weight)> f = () => (6.0, 200.0);
            var expected = "Overweight";
            var actual = Chapter2.BmiOrchestrator.CalcBmi(f);
            if (expected!=actual) throw new Exception($"{actual} doesn't equal {expected}!");
        }
    }
}
*/
