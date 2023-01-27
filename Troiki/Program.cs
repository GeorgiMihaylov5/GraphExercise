namespace Troiki
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse).ToArray();

            var cities = input[0];
            var nodes = input[1];

            //Creating jagged array.
            var arr = new int[nodes][];

            //Fills the array with elements.
            for (int i = 0; i < nodes; i++)
            {
                arr[i] = Console.ReadLine()
                .Split()
                .Select(int.Parse).ToArray();
            }

            //We use Depth First Search, because we think this is the better option for our project.
            var dfs = new DepthFirstSearch();
            //We use HashSet to remove dublicated conflict nodes.
            var conflicts = new HashSet<int>();

            //This for loop iterates the nodes(възлите)
            for (int i = 0; i < nodes; i++)
            {
                //Except the one node
                var currentArr = arr.Where(x => x != arr[i]).ToArray();


                //iterates throuth the cities from the current city, searching for the last city
                for (int j = 1; j < cities; j++)
                {
                    var isConflict = dfs.FindConflict(currentArr, cities, j, cities);

                    //Checking for conflicts and adding them to the hashset.
                    if (isConflict)
                    {
                       conflicts.Add(i + 1); 
                    }
                }
            }

            Console.WriteLine(conflicts.Count);
            Console.WriteLine(string.Join(" ", conflicts));
        }
    }
}