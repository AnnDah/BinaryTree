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
    class TreeNode
    {
        private int value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public TreeNode Left
        {
            get { return left; }
            set { left = value; }
        }

        public TreeNode Right
        {
            get { return right; }
            set { right = value; }
        }
    }
}
