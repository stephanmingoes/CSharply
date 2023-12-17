using CSharpLearning.Interfaces;
using CSharpLearning.Programs;

namespace CSharpLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var exercises = new Dictionary<int, IExercise>
            {
                { 1, new Exercise1() },
                { 2, new Exercise2() },
                { 3, new Exercise3() },
                { 4, new Exercise4() },
                { 5, new Exercise5() },
            };
            while (true)
            {
                foreach (var exercise in exercises)
                {
                    Console.WriteLine($"Enter {exercise.Key} to run => {exercise.Value.GetType().Name}.");
                }
                Console.WriteLine($"Enter 0 to run => Exit.");
                Console.Write("Enter Option: ");
                var input = Console.ReadLine();
                int inputParsed;
                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out inputParsed))
                {
                    throw new Exception("You must Enter a valid number");

                }
                if (inputParsed == 0)
                {
                    break;
                }
                exercises[inputParsed].Run();


            }


        }
    }
}