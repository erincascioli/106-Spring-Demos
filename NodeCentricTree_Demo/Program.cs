namespace NodeCentricTree_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(50);
            TreeNode a = new TreeNode(73);
            TreeNode b = new TreeNode(24);
            TreeNode c = new TreeNode(50);

            // Root;s children
            root.Left = b;
            root.Right = a;

            // 73's children
            a.Left = c;

            // Call methods on the root!
            root.PrintInOrder();
        }
    }
}