namespace TowersOfHanoi
{
    internal class GameLogic
    {
        public Tower A { get; set; }
        public Tower B { get; set; }
        public Tower C { get; set; }
        private int Moves { get; set; }

        public GameLogic(int amountOfDiscs)
        {
            Moves = 0;

            var tempA = new Stack<int>();
            for (int i = amountOfDiscs; i > 0; i--)
            {
                tempA.Push(i);
            }

            A = new Tower(tempA);
            B = new Tower(new Stack<int>(3));
            C = new Tower(new Stack<int>(3));

            // Make sure we're adding it correctly and that 1 is the value we get with peek
            Console.WriteLine("Top Value: " + A.TowerStack.Peek());
            Console.WriteLine("Count: " + tempA.Count);
            PlayGame(amountOfDiscs, A, B, C);
            DrawGame();

            Console.WriteLine("====================================================");
            Console.WriteLine($"Amount of moves to win: {Moves}");
            Console.WriteLine("====================================================");

            foreach (var a in A.TowerStack)
            {
                Console.WriteLine("A: " + a);
            }
            foreach (var b in B.TowerStack)
            {
                Console.WriteLine("B: " + b);
            }
            foreach (var c in C.TowerStack)
            {
                Console.WriteLine("C: " + c);
            }
        }

        public void PlayGame(int n, Tower source, Tower auxiliary, Tower destination)
        {
            Moves++;
            if (n == 1)
            {
                MoveTo(source, destination);

            }
            else
            {
                PlayGame(n - 1, source, destination, auxiliary);
                MoveTo(source, destination);

                PlayGame(n - 1, auxiliary, source, destination);
                MoveTo(auxiliary, source);
            }
        }


        public void MoveTo(Tower source, Tower destination)
        {

            if (source.Empty())
            {
                return;
            }

            DrawGame();

            if (destination.Empty())
            {
                destination.TowerStack.Push(source.TowerStack.Pop());
            }
            else
            {
                if (destination.ValidMove(source.TowerStack.Peek()))
                {
                    destination.TowerStack.Push(source.TowerStack.Pop());
                }

            }
        }

        public void DrawGame()
        {

            int max = 0;
            if (!A.Empty())
            {
                foreach (var val in A.TowerStack)
                {
                    if (max < val)
                    {
                        max = val;
                    }
                }
            }
            Console.Write($"| {(max == 0 ? " " : $"{max}")} ");


            max = 0;
            if (!B.Empty())
            {
                foreach (var val in B.TowerStack)
                {
                    if (max < val)
                    {
                        max = val;
                    }
                }
            }
            Console.Write($"| {(max == 0 ? " " : $"{max}")} ");

            max = 0;
            if (!C.Empty())
            {
                foreach (var val in C.TowerStack)
                {
                    if (max < val)
                    {
                        max = val;
                    }
                }

            }
            Console.Write($"| {(max == 0 ? " " : $"{max}")} |\n");
        }
    }
}
