using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAssignment
{
    class MainMenu
    {
        BinaryTree binaryTree = new BinaryTree();

        public MainMenu()
        {
            Menu();
        }

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
                            }

                            else
                            {
                                Console.WriteLine("Invalid value, please try again!");
                            }
                            break;

                        case 2:
                            Console.Write("Enter value to remove: ");
                            break;

                        case 3:
                            Console.Write("Enter value to find: ");
                            int findValue = Convert.ToInt32(Console.ReadLine());
                            if (binaryTree.FindValue(findValue) != null)
                                Console.WriteLine("Value " + findValue.ToString() + " is found");
                            else
                                Console.WriteLine(findValue + " wasn't found");
                            break;

                        case 4:
                            Console.WriteLine("Print tree...");
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
