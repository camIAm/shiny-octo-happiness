using System.Collections.Generic;
using CSharpTree;

namespace ConsoleApplication
{
    public class TreeFactory
    {
        ITreeImpl returnTreeKind;
        public TreeFactory(ITreeImpl _returnTreeKind)
        {
            returnTreeKind = _returnTreeKind;
        }
        public TreeFactory()
        {
        }
        public ITreeImpl GetTreeKind(int pathCount)
        {
            switch(pathCount)
            {
                case 0:
                    returnTreeKind = new RootNode();
                    break;
                case 1:
                    returnTreeKind = new OneChildNode();
                    break;
                case 2:
                    returnTreeKind = new TwoChildNode();
                    break;
                case 3:
                    returnTreeKind = new ThreeChildNode();
                    break;
                case 4:
                    returnTreeKind = new FourChildNode();
                    break;
                case 5:
                    returnTreeKind = new FiveChildNode();
                    break;
                case 6:
                    returnTreeKind = new SixChildNode();
                    break;
                case 7:
                    returnTreeKind = new SeventhChildNode();
                    break;
                default:
                    System.Console.WriteLine("path count > or < than pathCount");
                    break;
            }
            return returnTreeKind;
        }
    }
}