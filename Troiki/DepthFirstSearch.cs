namespace Troiki
{
    public class DepthFirstSearch
    {
        //We use IEnumerable because it's a good practice in our opinion.
        private IEnumerable<int[]> matrix;
        private bool[] used;
        private int n;
        private int target;
        private bool isConflict;

        private void DepthSearch(int node)
        {
            //Bottom of recursion (дъно на рекурсията).
            if (node == target)
            {
                if (isConflict)
                {
                    isConflict = false;
                }
                return;
            }

            used[node] = true;

            //Iterates through the matrix and goes to the next node.
            //Use recursion and the method accepts the next node.
            for (int i = 0; i < n; i++)
            {
                if (!used[i] && matrix.ElementAt(node)[i] > 0)
                {
                    DepthSearch(i);
                }
            }

            used[node] = false;
        }

        public bool FindConflict(IEnumerable<int[]> matrix, int cities, int startNode, int searchedNode)
        {
            //We add 1 to exclude the 0 index.
            n = cities + 1;
            this.matrix = GetEdges(matrix);

            target = searchedNode;
            isConflict = true;

            //Saves information whether the node is used
            used = new bool[n];

            DepthSearch(startNode);

            return isConflict;
        }

        public void AddEdge(IEnumerable<int[]> matrix, int a, int b, int weight = 1)
        {
            matrix.ElementAt(a)[b] = weight;
            matrix.ElementAt(b)[a] = weight;
        }

        //Returns an array with information about edges in the graph.
        //Because the array is two dimensional, we use two indexes to check for edges between two nodes.
        //If the value of the indexes is 0 they don't have an edge, otherwise they do.
        private IEnumerable<int[]> GetEdges(IEnumerable<int[]> matrix)
        {
            var list = new int[n][];

            for (int i = 0; i < n; i++)
            {
                list[i] = new int[n];
            }

            foreach (var edge in matrix)
            {
                AddEdge(list, edge.ElementAt(0), edge.ElementAt(1));
                AddEdge(list, edge.ElementAt(0), edge.ElementAt(2));
                AddEdge(list, edge.ElementAt(1), edge.ElementAt(2));
            }

            return list;
        }
    }
}