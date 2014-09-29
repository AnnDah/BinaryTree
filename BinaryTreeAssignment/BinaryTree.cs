//BinaryTreeAssignment.cs
//Created by Annika Magnusson 2014-09-29
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAssignment
{
    class BinaryTree
    {
        private TreeNode root = null;
        private int size = 0;
        private int count = 0;

        public TreeNode Insert(int value)
        {
            TreeNode node = new TreeNode(value);
            try
            {
                if (root == null)
                {
                    root = node;
                }
                else
                {
                    Add(node, ref root);
                    count++;
                }
                return node; //in the example from teacher this is inside else
            }
            catch(Exception)
            {
                Console.WriteLine("Value allready exists");
                return null;
            }
        }

        public void Add(TreeNode node, ref TreeNode tree)
        {

        }
    }
}
