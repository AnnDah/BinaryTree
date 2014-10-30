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
    /// <summary>
    /// Class that holds the nodes value and references to to the nodes left and right child. 
    /// </summary>
    class TreeNode
    {
        private int value;
        public TreeNode left;
        public TreeNode right;

        /// <summary>
        /// Constructor that takes the nodes value and sets it's children to null
        /// </summary>
        /// <param name="value"></param>
        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }

        /// <summary>
        /// Property for variable value
        /// </summary>
        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Property for variable left
        /// </summary>
        public TreeNode Left
        {
            get { return left; }
            set { left = value; }
        }

        /// <summary>
        /// Property for variable right
        /// </summary>
        public TreeNode Right
        {
            get { return right; }
            set { right = value; }
        }
    }
}
