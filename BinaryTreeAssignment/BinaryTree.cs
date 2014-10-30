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
    /// Class that handle all functions connected to the binary search tree.
    /// </summary>
    class BinaryTree
    {
        private TreeNode root = null;
        private TreeNode parentNode = null;
        private int count = 0;

        /// <summary>
        /// Property to the variable count, returns the number of nodes in the tree.
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Adds a value to the tree. If the tree allready has nodes it calls the function Add() to insert the value, if the 
        /// tree doesn't have any nodes it sets the value to the root node instead.
        /// If the value allready exists in the tree an exception is thrown.
        /// </summary>
        /// <param name="value">Value to be put in the tree</param>
        /// <returns>the node if it gets added else returns null.</returns>
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
                }
                count++;
                return node;
            }
            catch(Exception)
            {
                Console.WriteLine("Value allready exists");
                return null;
            }
        }

        /// <summary>
        /// A recursive method that calls itself with either the nodes left or right child depending on weather the 
        /// incoming value is smaller or greater than the value of the node. When the nodes children point at null 
        /// the function ends.
        /// </summary>
        /// <param name="node">node to be added in tree</param>
        /// <param name="tree">node to compare with the node to be added</param>
        public void Add(TreeNode node, ref TreeNode tree)
        {
            if (FindValue(node.Value) != null)
            {
                throw new Exception();
            }
           
            if (tree == null)
            {
                tree = node;
            }
            else if (node.Value < tree.Value)
            {
                Add(node, ref tree.left);
            }
            else if (node.Value > tree.Value)
            {
                Add(node, ref tree.right);
            }
        }

        /// <summary>
        /// Calls the function Find() if the tree isn't empty.
        /// </summary>
        /// <param name="value">Value to be found</param>
        /// <returns>Returns value and it's parent or null if the tree is without nodes</returns>
        public TreeNode FindValue(int value)
        {
            if (root != null)
            {
                return Find(value, ref root);
            }

            else
            {
                return null;
            }
        }

        /// <summary>
        /// Search through the tree until value is found. The search starts at the root node. The function is recursive so 
        /// it keeps calling itself until the value is found with either the nodes left or right child.
        /// Metoden letar efter ett värde i trädet, om värdet hittas returneras noden som innehåller detta värde. 
        /// Samtidigt så returneras nodens förälder genom parameter 'ref TreeNode parent'. Hittas inte värdet returneras 'null'. 
        /// Om den sökta noden är roten är föräldern null. 
        /// </summary>
        /// <param name="value">Value to be found</param>
        /// <param name="node">node to be compared with the value to be found</param>
        /// <returns>If the the value is found it returns the node containing the value else it returns null</returns>
        private TreeNode Find(int value, ref TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            else if (node.Value == value)
            {
                return node;
            }

            else if (value < node.Value)
            {
                parentNode = node;
                return Find(value, ref node.left);
            }

            else if (value > node.Value)
            {
                parentNode = node;
                return Find(value, ref node.right);
            }

            else
            {
                return null;
            }
        }

        /// <summary>
        /// FUnction that search for and returns the leftmost node in a subtree. The search starts at the right child of the node to be deleted.
        /// </summary>
        /// <param name="nodeToDelete">node that are to be deleted</param>
        /// <param name="parent">nodes parent</param>
        /// <returns>the node to be deleted</returns>
        public TreeNode LeftMostNodeOnRight(TreeNode nodeToDelete, ref TreeNode parent)
        {
            parent = nodeToDelete;
            nodeToDelete = nodeToDelete.Right;

            while (nodeToDelete.Left != null)
            {
                parent = nodeToDelete;
                nodeToDelete = nodeToDelete.Left;
            }
            
            return nodeToDelete;
        }

        /// <summary>
        /// Function to delete a node. It has different spproaches weather the node has no, one or two children.
        /// </summary>
        /// <param name="value">value to be deleted</param>
        public void Delete(int value)
        {
            TreeNode nodeToDelete = Find(value, ref root);
            
            //The value wasn't found in the tree
            if(nodeToDelete == null)
            {
                Console.WriteLine("The value wasn't in tree.");
                return;
            }

            //If the root contains the value the root gets deleted
            if (parentNode == null)
            {
                root = null;
                return;
            }
         
            //The node to be deleted has no children
            if (nodeToDelete.left == null && nodeToDelete.right == null)
            {
                if (nodeToDelete.Value == parentNode.left.Value)
                {
                    parentNode.left = null;
                }
                else
                {
                    parentNode.right = null;
                }
            }

            //The node to be deleted has one child
            else if (nodeToDelete.left == null || nodeToDelete.right == null)
            {
                if (nodeToDelete.Value == parentNode.left.Value)
                {
                    if (nodeToDelete.left != null)
                    {
                        parentNode.left = nodeToDelete.left;
                    }
                    else
                    {
                        parentNode.left = nodeToDelete.right;
                    }
                }
                else
                {
                    if (nodeToDelete.left != null)
                    {
                        parentNode.right = nodeToDelete.left;
                    }
                    else
                    {
                        parentNode.right = nodeToDelete.right;
                    }
                }
            }

            //The node to be deleted has two children
            else
            {
                TreeNode successor = LeftMostNodeOnRight(nodeToDelete, ref parentNode);
                TreeNode temp = new TreeNode(successor.Value);
                if (parentNode.Left == successor)
                {
                    parentNode.Left = successor.Right;
                }
                else
                {
                    parentNode.Right = successor.Right;
                }
                nodeToDelete.Value = temp.Value;
            }
            Console.WriteLine("Value " + value + " was deleted.");
        }

        /// <summary>
        /// Calls the function InorderTraversal(Treenode node)
        /// </summary>
        public void InorderTraversal()
        {
            InorderTraversal(root);
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the binary tree in ascending order of size
        /// </summary>
        /// <param name="node"></param>
        public void InorderTraversal(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            InorderTraversal(node.left);
            Console.Write(node.Value + " ");
            InorderTraversal(node.right);
        }

        /// <summary>
        /// Prints the tree
        /// </summary>
        /// <returns>the printed tree</returns>
        public string DrawTree()
        {
            return DrawNode(root); 
        }

        /// <summary>
        /// Prints the tree, recursive
        /// </summary>
        /// <param name="node">the current node in the tree</param>
        /// <returns>the all the values in the tree</returns>
        private string DrawNode(TreeNode node)
        {
            if (node == null)
            {
                return "empty";
            }

            if ((node.left == null) && (node.right == null))
            {
                return "" + node.Value;
            }

            if ((node.left != null) && (node.right == null))
            {
                return "" + node.Value + "(" + DrawNode(node.left) + ", _";
            }
            if ((node.right != null) && (node.left == null))
            {
                return "" + node.Value + "(_, " + DrawNode(node.right) + ")";
            }
            return node.Value + "(" + DrawNode(node.left) + ", " + DrawNode(node.right) + ")";
        }
    }
}
