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
            if (tree == null)
            {
                tree = node;
            }
            else if (node.Value < tree.Value)
            {
                Add(node, ref tree.left);
            }
            else
            {
                Add(node, ref tree.right);
            }
            return;
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
                return FindParent(value, ref root);

            else
                return null;
        }

        /// <summary>
        /// Metoden letar efter ett värde i trädet, om värdet hittas returneras noden som innehåller detta värde. 
        /// Samtidigt så returneras nodens förälder genom parameter 'ref TreeNode parent'. Hittas inte värdet returneras 'null'. 
        /// Om den sökta noden är roten är föräldern null. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private TreeNode FindParent(int value, ref TreeNode parent)
        {
            if (parent == null)
            {
                return null;
            }

            else if (parent.Value == value)
            {
                return parent;
            }

            else if (parent.Value < value)
            {
                return FindParent(value, ref parent.left);
            }

            else if (parent.Value > value)
            {
                return FindParent(value, ref parent.right);
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
            //Det är nåt knas med koden vi fått i den här funktionen, kolla över noga
            parent = nodeToDelete;
            nodeToDelete = nodeToDelete.Right;
            while (nodeToDelete.Left != null)
            {

            }
            parent = nodeToDelete;
            nodeToDelete = nodeToDelete.Left;
            return nodeToDelete;
        }

        public void Delete(int value)
        {
            //fall 1
            //Noden som ska tas bort har inga barn

            //fall 2
            //Noden som ska tas bort har ett barn

            //fall 3
            //noden som ska tas bort har två barn
            //
            //TreeNode successor = LeftMostNodeOnRight(nodeToDelete, ref parent);
            //TreeNode temp = new TreeNode(successor.Value);
            //if (parent.Left == successor)
            //{
            //    parent.Left = successor.Right;
            //}
            //else
            //{
                //parent.Right = successor.Right;
            //}
            //nodeToDelete.Value = temp.Value
        }

        /// <summary>
        /// Print the binary tree in ascending order of size
        /// </summary>
        /// <param name="node"></param>
        public void InorderTraversal(TreeNode node)
        {
            BinaryTree bTree = new BinaryTree();
            bTree.Insert(5);
            bTree.Insert(88);
            bTree.Insert(2);
            bTree.Insert(33);
            bTree.Insert(123);
            //bTree.InorderTraversal();
        }
    }
}
