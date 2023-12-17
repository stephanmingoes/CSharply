using CSharpLearning.Interfaces;

namespace CSharpLearning.Programs
{
    class Exercise1 : IExercise
    {
        public void Run()
        {
            Console.Write("Enter Number between 1 and 10: ");
            string? userInput = Console.ReadLine();
            int userInputParsed;
            if (ParseInput(userInput, out userInputParsed))
            {
                Console.WriteLine($"{userInputParsed} is a Valid Input");
            }
            else
            {
                Console.WriteLine("The Input was Invalid");
            }

        }

        private bool ParseInput(string? userInput, out int userInputParsed)
        {
            return int.TryParse(userInput, out userInputParsed) && userInputParsed > 1 && userInputParsed < 10;
        }
    }

    class Exercise2 : IExercise
    {
        public void Run()
        {
            Console.Write("Enter Number 1: ");
            string? userInput = Console.ReadLine();
            Console.Write("Enter Number 2: ");
            string? userInput2 = Console.ReadLine();
            int userInputParsed;
            int userInputParsed2;
            if (ParseInput(userInput, out userInputParsed) && ParseInput(userInput2, out userInputParsed2))
            {
                Console.WriteLine($"The larger number is {Math.Max(userInputParsed, userInputParsed2)}");
            }
            else
            {
                Console.WriteLine("One of the input you entered is invalid.");
            }


        }
        private bool ParseInput(string? userInput, out int userInputParsed) => int.TryParse(userInput, out userInputParsed);

    }

    class Exercise3 : IExercise
    {
        public void Run()
        {
            int count = 0;
            int start = 0;
            int end = 100;
            int divisor = 3;
            for (int i = start; i < end; i++)
            {
                if (i % divisor == 0) count++;

            }

            Console.WriteLine($"{count} numbers are divisible by {divisor} from {start} to {end}");
        }
    }

    class Exercise4 : IExercise
    {

        public void Run()
        {
            Console.WriteLine("Enter comma seperated numbers for eg. '1, 2, 3, 4, 5, 6, 7'");
            Console.Write("Numbers: ");
            string? userInput = Console.ReadLine();
            int[] parsedInput = ParseInput(userInput);
            Array.Sort(parsedInput);

            Console.WriteLine($"The maximum number is {parsedInput[parsedInput.Length - 1]}");

        }


        private int[] ParseInput(string? userInput)
        {
            if (string.IsNullOrEmpty(userInput)) throw new Exception("Input is null or Empty");

            string[] parsedStringInput = userInput.Split(",");

            int[] parsedStringArray = new int[parsedStringInput.Length];

            for (int i = 0; i < parsedStringInput.Length; i++)
            {
                parsedStringArray[i] = int.Parse(parsedStringInput[i].Trim());
            }



            return parsedStringArray;
        }
    }

    class Exercise5 : IExercise
    {

        class Friend
        {
            public required string Name { get; set; }
        }

        private List<Friend> _friends = new List<Friend>();
        public void Run()
        {
            while (true)
            {
                Console.Write("Enter The name of a Friend who liked your image, leave blank and press enter to exit: ");
                var friendName = Console.ReadLine();

                if (string.IsNullOrEmpty(friendName) || string.IsNullOrWhiteSpace(friendName))
                {
                    break;
                }

                _friends.Add(new Friend { Name = friendName });
            }

            int likes = _friends.Count;

            if (likes <= 0)
            {
                Console.WriteLine("Likes: ");
            }
            else if (likes == 1)
            {

                Console.WriteLine($"Likes: {_friends[0].Name} liked your post");
            }
            else if (likes == 2)
            {
                Console.WriteLine($"Likes: {_friends[0].Name} and {_friends[1].Name} liked your post");
            }
            else
            {
                Console.WriteLine($"Likes: {_friends[0].Name}, {_friends[1].Name} and {likes - 2} others liked your post");
            }

        }
    }
}
