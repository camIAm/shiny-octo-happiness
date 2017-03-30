using System.Collections.Generic;
using System;
using CSharpTree;

namespace ConsoleApplication
{
    public class PathComposition
    {
        private int pathCount;
        public Queue<string> PathQueue { get; set; }
        public int PathCount
        {
            get
            {
                return PathQueue.Count;
            } 
            set
            {
                pathCount = value;
            }
        }

        public PathComposition(Queue<string> pathQueue)
        {
            PathQueue = pathQueue;
            //pathCount = pathQueue.Count;
            //PathBuilder();
        }
        public TreeNode<string> PathBuilder()
        {
            //try{
                string valueFromQueue = PathQueue.Dequeue();
                if(valueFromQueue.Equals(null))
                {
                    System.Console.WriteLine("No Value from queue");
                }
                TreeNode<string> root = new TreeNode<string>(valueFromQueue);
                int originalPathCount = PathCount + 1;
                //return root;
                 
               // for(int i = 0; i < orginalPathCount; i++)
               // {
                    if(originalPathCount == 1)
                    {
                        valueFromQueue = PathQueue.Dequeue();
                        
                        root = new TreeNode<string>(valueFromQueue);
                        return root;
                    }
                    
                    if(originalPathCount == 2)
                    {
                        string secondValueFromQueue = PathQueue.Dequeue();
                        TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                        return root;
                    }
                    if(originalPathCount == 3)
                    {
                        string secondValueFromQueue = PathQueue.Dequeue();
                        TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                        {                            
                            string thirdValueFromQueue = PathQueue.Dequeue();
                            TreeNode<string> node1 = root.AddChild(thirdValueFromQueue);
                        }                        
                        return root;
                    }
                    if(originalPathCount == 4)
                    {
                        string secondValueFromQueue = PathQueue.Dequeue();
                        TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                        {
                            string thirdValueFromQueue = PathQueue.Dequeue();
                            TreeNode<string> node1 = root.AddChild(thirdValueFromQueue);
                            {
                                string fourthValueFromQueue = PathQueue.Dequeue();
                                TreeNode<string> node2 = root.AddChild(fourthValueFromQueue);   
                            }
                        }                        
                        return root;
                    }                
                    if(originalPathCount == 5)
                    {
                        string secondValueFromQueue = PathQueue.Dequeue();
                        TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                        {
                            string thirdValueFromQueue = PathQueue.Dequeue();
                            TreeNode<string> node1 = root.AddChild(thirdValueFromQueue);
                                {
                                    string fourthValueFromQueue = PathQueue.Dequeue();
                                    TreeNode<string> node2 = root.AddChild(fourthValueFromQueue);   
                                    {
                                        string fifthValueFromQueue = PathQueue.Dequeue();
                                        TreeNode<string> node3 = root.AddChild(fifthValueFromQueue);   
                                    }
                                }
                            }                            
                            return root;
                        }
                    
                    if(originalPathCount == 6)
                    {
                        string secondValueFromQueue = PathQueue.Dequeue();
                        TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                        {
                                string thirdValueFromQueue = PathQueue.Dequeue();
                                TreeNode<string> node1 = node0.AddChild(thirdValueFromQueue);
                                {
                                    string fourthValueFromQueue = PathQueue.Dequeue();
                                    TreeNode<string> node2 = node1.AddChild(fourthValueFromQueue);   
                                    {
                                        string fifthValueFromQueue = PathQueue.Dequeue();
                                        TreeNode<string> node3 = node2.AddChild(fifthValueFromQueue);   
                                        {
                                            string sixthValueFromQueue = PathQueue.Dequeue();
                                            TreeNode<string> node4 = node3.AddChild(sixthValueFromQueue);   
                                        }
                                    }
                                }
                            }                            
                            return root;
                        }
                    if(originalPathCount == 7)
                    {
                        string secondValueFromQueue = PathQueue.Dequeue();
                        TreeNode<string> node0 = root.AddChild(secondValueFromQueue);
                        {
                            string thirdValueFromQueue = PathQueue.Dequeue();
                            TreeNode<string> node1 = node0.AddChild(thirdValueFromQueue);
                            {
                                string fourthValueFromQueue = PathQueue.Dequeue();
                                TreeNode<string> node2 = node1.AddChild(fourthValueFromQueue);   
                                {
                                    string fifthValueFromQueue = PathQueue.Dequeue();
                                    TreeNode<string> node3 = node2.AddChild(fifthValueFromQueue);   
                                    {
                                        string sixthValueFromQueue = PathQueue.Dequeue();
                                        TreeNode<string> node4 = node3.AddChild(sixthValueFromQueue);
                                        {
                                            string seventhValueFromQueue = PathQueue.Dequeue();
                                            TreeNode<string> node5 = node4.AddChild(seventhValueFromQueue);   
                                        }   
                                    }                                        
                                }
                            }
                        }                        
                        return root;
                    }
                    return root;                    
           }
           /* 
           catch(Exception e)
           {
               System.Console.WriteLine("PathCount does not exist, no loop executed");
               System.Console.WriteLine($"Exception {e.Message}");
           }
        }         
           */
    }     
}
