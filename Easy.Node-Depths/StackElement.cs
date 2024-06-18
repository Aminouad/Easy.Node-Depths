namespace Easy.Node_Depths
{
    internal class StackElement
    {
        public BinaryTree Element;
        public int Depth;

        public StackElement(BinaryTree element, int depth)
        {
            Element = element;
            Depth = depth;
        }
    }
}
