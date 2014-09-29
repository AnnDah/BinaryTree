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
        private TreeNode left;
        private TreeNode right;

        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }
}
