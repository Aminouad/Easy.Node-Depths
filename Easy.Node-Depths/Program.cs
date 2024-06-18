using Easy.Node_Depths;

internal class Program
{
    static void Main(string[] args)
    {
        var root = new BinaryTree(1);
        root.left = new BinaryTree(2);
        root.left.left = new BinaryTree(4);
        root.left.left.left = new BinaryTree(8);
        root.left.left.right = new BinaryTree(9);
        root.left.right = new BinaryTree(5);
        root.right = new BinaryTree(3);
        root.right.left = new BinaryTree(6);
        root.right.right = new BinaryTree(7);

        int result = NodeDepthsIterative(root);
        Console.WriteLine("Result: " + result);
    }

    //Recursive O(n) Time O(h) space with h: height of the stack 
    public static int NodeDepthsRecursive(BinaryTree root)
    {
        // Write your code here.
        return Treeiterate(root, -1);
    }

    private static int Treeiterate(BinaryTree root, int depth)
    {
        depth++;
        int sum = depth;
        if (root.left != null)
            sum = Treeiterate(root.left, depth) + depth;
        if (root.right != null)
            sum = Treeiterate(root.right, depth) + sum;

        return sum;
    }

    //iterative O(n) Time O(h) space with h: height of the stack 
    public static int NodeDepthsIterative(BinaryTree root)
    {
        int sumOfDepths = 0;
        var stack = new Stack<StackElement>();
        var rootNode = new StackElement(root, 0);
        stack.Push(rootNode);
        while (stack.Count > 0)
        {
            var nodeInfo = stack.Pop();
            var node = nodeInfo.Element;
            int depth = nodeInfo.Depth;
            if (node is null)
                continue;

            sumOfDepths += depth;
            stack.Push(new StackElement(node.left, depth + 1));
            stack.Push(new StackElement(node.right, depth + 1));
        }

        return sumOfDepths;
    }
}