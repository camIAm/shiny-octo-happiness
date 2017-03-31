using CSharpTree;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class RootNode: ITreeImpl
    {
        public TreeNode<string> GetTreeImple(Queue<string> pathQueue)
        {
            string valueFromQueue = pathQueue.Dequeue();
            if(valueFromQueue.Equals(null))
            {
                System.Console.WriteLine("No Value from queue");
            }
            TreeNode<string> root = new TreeNode<string>(valueFromQueue);
            return root;
        }
    }
    public class OneChildNode: ITreeImpl
    {
        public TreeNode<string> GetTreeImple(Queue<string> pathQueue)
        {
            string valueFromQueue = pathQueue.Dequeue();
            if(valueFromQueue.Equals(null))
            {
                System.Console.WriteLine("No Value from queue");
            }
            TreeNode<string> root = new TreeNode<string>(valueFromQueue);
            return root;
        }
    }
    public class TwoChildNode: ITreeImpl
    {
        public TreeNode<string> GetTreeImple(Queue<string> pathQueue)
        {
            string valueFromQueue = pathQueue.Dequeue();
            if(valueFromQueue.Equals(null))
            {
                System.Console.WriteLine("No Value from queue");
            }
            TreeNode<string> root = new TreeNode<string>(valueFromQueue);
            {
                string secondValueFromQueue = pathQueue.Dequeue();
                TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                return root;
            }
        }
    }
    public class ThreeChildNode: ITreeImpl
    {
        public TreeNode<string> GetTreeImple(Queue<string> pathQueue)
        {
            string valueFromQueue = pathQueue.Dequeue();
            if(valueFromQueue.Equals(null))
            {
                System.Console.WriteLine("No Value from queue");
            }
            TreeNode<string> root = new TreeNode<string>(valueFromQueue);
            {
                string secondValueFromQueue = pathQueue.Dequeue();
                TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                {                            
                    string thirdValueFromQueue = pathQueue.Dequeue();
                    TreeNode<string> node1 = node0.AddChild(thirdValueFromQueue);// dont need to create last object in all these case
                                                                            // i.e. node1 in this case, TODO: Remove
                }                        
                return root;
            }        
        }
    }
    public class FourChildNode: ITreeImpl
    {
        public TreeNode<string> GetTreeImple(Queue<string> pathQueue)
        {
            string valueFromQueue = pathQueue.Dequeue();
            if(valueFromQueue.Equals(null))
            {
                System.Console.WriteLine("No Value from queue");
            }
            TreeNode<string> root = new TreeNode<string>(valueFromQueue);
            {
                string secondValueFromQueue = pathQueue.Dequeue();
                TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                {
                    string thirdValueFromQueue = pathQueue.Dequeue();
                    TreeNode<string> node1 = root.AddChild(thirdValueFromQueue);
                    {
                        string fourthValueFromQueue = pathQueue.Dequeue();
                        TreeNode<string> node2 = node1.AddChild(fourthValueFromQueue);   
                    }
                }          
            }
            return root;
        }
    }
    public class FiveChildNode: ITreeImpl
    {
        public TreeNode<string> GetTreeImple(Queue<string> pathQueue)
        {
            string valueFromQueue = pathQueue.Dequeue();
            if(valueFromQueue.Equals(null))
            {
                System.Console.WriteLine("No Value from queue");
            }
            TreeNode<string> root = new TreeNode<string>(valueFromQueue);
            {
                string secondValueFromQueue = pathQueue.Dequeue();
                TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                {
                    string thirdValueFromQueue = pathQueue.Dequeue();
                    TreeNode<string> node1 = node0.AddChild(thirdValueFromQueue);
                    {
                        string fourthValueFromQueue = pathQueue.Dequeue();
                        TreeNode<string> node2 = node1.AddChild(fourthValueFromQueue);   
                        {
                            string fifthValueFromQueue = pathQueue.Dequeue();
                            TreeNode<string> node3 = node2.AddChild(fifthValueFromQueue);   
                        }
                    }
                }        
            }
            return root;
        }
    }
    public class SixChildNode: ITreeImpl
    {
        public TreeNode<string> GetTreeImple(Queue<string> pathQueue)
        {
            string valueFromQueue = pathQueue.Dequeue();
            if(valueFromQueue.Equals(null))
            {
                System.Console.WriteLine("No Value from queue");
            }
            TreeNode<string> root = new TreeNode<string>(valueFromQueue);
            {
                string secondValueFromQueue = pathQueue.Dequeue();
                TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                {
                    string thirdValueFromQueue = pathQueue.Dequeue();
                    TreeNode<string> node1 = node0.AddChild(thirdValueFromQueue);
                    {
                        string fourthValueFromQueue = pathQueue.Dequeue();
                        TreeNode<string> node2 = node1.AddChild(fourthValueFromQueue);   
                        {
                            string fifthValueFromQueue = pathQueue.Dequeue();
                            TreeNode<string> node3 = node2.AddChild(fifthValueFromQueue);   
                            {
                                string sixthValueFromQueue = pathQueue.Dequeue();
                                TreeNode<string> node4 = node3.AddChild(sixthValueFromQueue);   
                            }
                        }
                    }
                }        
            }
            return root;
        }
    }
        public class SeventhChildNode: ITreeImpl
    {
        public TreeNode<string> GetTreeImple(Queue<string> pathQueue)
        {
            string valueFromQueue = pathQueue.Dequeue();
            if(valueFromQueue.Equals(null))
            {
                System.Console.WriteLine("No Value from queue");
            }
            TreeNode<string> root = new TreeNode<string>(valueFromQueue);
            {
                string secondValueFromQueue = pathQueue.Dequeue();
                TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                {
                    string thirdValueFromQueue = pathQueue.Dequeue();
                    TreeNode<string> node1 = node0.AddChild(thirdValueFromQueue);
                    {
                        string fourthValueFromQueue = pathQueue.Dequeue();
                        TreeNode<string> node2 = node1.AddChild(fourthValueFromQueue);   
                        {
                            string fifthValueFromQueue = pathQueue.Dequeue();
                            TreeNode<string> node3 = node2.AddChild(fifthValueFromQueue);   
                            {
                                string sixthValueFromQueue = pathQueue.Dequeue();
                                TreeNode<string> node4 = node3.AddChild(sixthValueFromQueue); 
                                {
                                    string seventhValueFromQueue = pathQueue.Dequeue();
                                    TreeNode<string> node5 = node4.AddChild(seventhValueFromQueue);
                                }  
                            }
                        }
                    }
                }        
            }
            return root;
        }
    }
}