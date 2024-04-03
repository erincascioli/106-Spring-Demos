using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeCentricTree_Demo
{
    internal class TreeNode
    {
        // Fields 
        private TreeNode leftChild;
        private TreeNode rightChild;
        private int data;

        // Properties
        public TreeNode Left
        {
            get { return leftChild; }
            set { leftChild = value; }
        }

        public TreeNode Right
        {
            get { return rightChild; }
            set { rightChild = value; }
        }

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        // Creates a tree node with specified data
        public TreeNode(int data)
        {
            this.leftChild = null;
            this.rightChild = null;
            this.data = data;
        }

        public void PrintInOrder()
        {
            // 1. Left
            if(leftChild != null)
            {
                leftChild.PrintInOrder();
            }

            // 2. Current/root/parent
            // "Do something with the current node"
            Console.WriteLine(this.data);

            // 3. Right
            if(rightChild != null)
            {
                rightChild.PrintInOrder();
            }
        }
    }
}
