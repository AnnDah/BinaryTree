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
    /// 
    /// </summary>
    class BinaryTree
    {
        private TreeNode root = null;
        private TreeNode parentNode = null;
        private int count = 0;

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Metoden 'Insert' lägger till ett värde i trädet genom att anropa metoden i det fallet då trädet redan har noder. 
        /// Om värdet redan finns i trädet ska ett 'Exception' kastas
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// Metoden 'Add' är rekursiv och anropar sig själv med antingen den aktuella nodens vänstra eller högra barn.
        /// Om värdet är mindre än den aktuella nodens barn anropas 'Add' metoden med det vänstra barnet. 
        /// Är värdet större än den aktuella nodens barn anropas 'Add' metoden med det högra barnet. 
        /// Detta sker ända tills den aktuella nodens barn pekar mot 'null'. Byt ut referensen till 'null' så att den pekar på den nya noden.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="tree"></param>
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
        /// Search through the tree until value is found. The search starts at the root node.
        /// Metoden jämför två värden, är värdet lika med den jämförande nodens värde har vi hittat värdet i trädet. 
        /// Är det sökta värdet större än nodens värde kan värdet finnas i nodens högra barn och om värdet är mindre 
        /// än nodens värde kan värdet finnas i nodens vänstra barn. Om något av de följande barnen är 'null' så finns 
        /// inte värdet i trädet. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// Metoden letar efter ett värde i trädet, om värdet hittas returneras noden som innehåller detta värde. 
        /// Samtidigt så returneras nodens förälder genom parameter 'ref TreeNode parent'. Hittas inte värdet returneras 'null'. 
        /// Om den sökta noden är roten är föräldern null. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
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
        /// Metoden letar efter och returnerar den vänstraste noden i ett subträd. Subträdet börjar på det högra barnet till 
        /// den noden som ska tas bort ('nodeToDelete'). Samtidigt så returneras nodens förälder genom 'ref parent'. 
        /// Den här metoden kommer att användas i nästkommande 'Delete' metod. Då vi tar hänsyn till tre olika fall när vi ska 
        /// ta bort en nod kommer ett av fallen att använda sig av den här metoden. Fallet är när en nod har två barn
        /// </summary>
        /// <param name="nodeToDelete"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Delete(int value)
        {
            TreeNode nodeToDelete = Find(value, ref root);
            
            if(nodeToDelete == null)
            {
                Console.WriteLine("The value wasn't in tree.");
                return;
            }

            if (parentNode == null)
            {
                root = null;
                return;
            }
            //fall 1
            //Noden som ska tas bort har inga barn, 
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

            //fall 2
            //Noden som ska tas bort har ett barn
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

            //fall 3
            //noden som ska tas bort har två barn
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
        /// 
        /// </summary>
        public void InorderTraversal()
        {
            InorderTraversal(root);
            Console.WriteLine();
        }

        /// <summary>
        /// Print the binary tree in ascending order of size
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
        /// 
        /// </summary>
        /// <returns></returns>
        public string DrawTree()
        {
            return DrawNode(root); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
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
