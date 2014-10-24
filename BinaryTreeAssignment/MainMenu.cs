﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAssignment
{
    /// <summary>
    /// 
    /// </summary>
    class MainMenu
    {
        BinaryTree binaryTree = new BinaryTree();

        /// <summary>
        /// 
        /// </summary>
        public MainMenu()
        {
            Menu();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Menu()
        {
            int choiceInMenu = -1;

            while (choiceInMenu != 0)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("        BINARY TREE           ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("                              ");
                Console.WriteLine("What do you want to do?       ");
                Console.WriteLine("1: Add element                ");
                Console.WriteLine("2: Remove element             ");
                Console.WriteLine("3: Find value                 ");
                Console.WriteLine("4: Print tree                 ");
                Console.WriteLine("5: Print sorted values in tree");
                Console.WriteLine("6: Add predefined values      ");
                Console.WriteLine("0: Exit application           ");
                Console.WriteLine("                              ");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choiceInMenu))
                {
                    switch (choiceInMenu)
                    {
                        case 0:
                            break;

                        case 1:
                            Console.Write("Enter value to add: ");
                            int insertValue;
                            if (int.TryParse(Console.ReadLine(), out insertValue))
                            {
                                binaryTree.Insert(insertValue);
                                Console.WriteLine("The number of elements in tree are " + binaryTree.Count.ToString());
                            }

                            else
                            {
                                Console.WriteLine("Invalid value, please try again!");
                            }
                            break;

                        case 2:
                            Console.Write("Enter value to remove: ");
                            binaryTree.Delete(Convert.ToInt32(Console.ReadLine()));
                            break;

                        case 3:
                            Console.Write("Enter value to find: ");
                            int findValue = Convert.ToInt32(Console.ReadLine());
                            if (binaryTree.FindValue(findValue) != null)
                                Console.WriteLine("Value " + findValue.ToString() + " was found");
                            else
                                Console.WriteLine("Value " + findValue + " wasn't found");
                            break;

                        case 4:
                            Console.WriteLine("Print tree...");
                            Console.WriteLine(binaryTree.DrawTree());
                            break;

                        case 5:
                            binaryTree.InorderTraversal();
                            break;
                        case 6:
                            binaryTree.Insert(5);
                            binaryTree.Insert(7);
                            binaryTree.Insert(3);
                            binaryTree.Insert(4);
                            binaryTree.Insert(2);
                            binaryTree.Insert(6);
                            binaryTree.Insert(8);
                            binaryTree.Insert(10);
                            break;

                        default:
                            Console.WriteLine("Invalid input, please try again!");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Wrong input, please try again");
                    choiceInMenu = -1;
                }
            }
        }
    }
}
