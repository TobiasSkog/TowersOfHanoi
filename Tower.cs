namespace TowersOfHanoi
{
    public class Tower
    {
        public Stack<int> TowerStack { get; set; }

        public Tower(Stack<int> contains)
        {
            TowerStack = contains;
        }
        public bool ValidMove(int value)
        {
            if (value > TowerStack.Peek())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Empty()
        {
            return TowerStack.Count == 0 ? true : false;
        }
        public int Value()
        {
            return TowerStack.Count();
        }
    }
}
