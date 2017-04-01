using System.Collections.Generic;
using System;

namespace ConsoleApplication
{
    public class TreeFactory
    {
        Dictionary<PathEnum, Lazy<ITreeImpl>> returnTreeKindDict;
        public TreeFactory()
        {
        }
        
        public TreeFactory(Dictionary<PathEnum, Lazy<ITreeImpl>> _returnTreeKindDict)
        {
            returnTreeKindDict = _returnTreeKindDict;
        }
        
        public ITreeImpl GetTreeKind(int pathCount)
        {
            Lazy<ITreeImpl> treeType;
            PathEnum pathEnum = (PathEnum)pathCount;
            if(!returnTreeKindDict.TryGetValue(pathEnum, out treeType))
            {
                throw new NotImplementedException("here is no implementation of IAccountDiscountCalculatorFactory interface for given Account Status");
            }

            return treeType.Value;
            /* 
            switch(pathEnum)
            {
                case PathEnum.Root:
                    returnTreeKindDict = new RootNode();
                    break;
                case PathEnum.One:
                    returnTreeKindDict = new OneChildNode();
                    break;
                case PathEnum.Two:
                    returnTreeKindDict = new TwoChildNode();
                    break;
                case PathEnum.Three:
                    returnTreeKindDict = new ThreeChildNode();
                    break;
                case PathEnum.Four:
                    returnTreeKindDict = new FourChildNode();
                    break;
                case PathEnum.Five:
                    returnTreeKindDict = new FiveChildNode();
                    break;
                case PathEnum.Six:
                    returnTreeKindDict = new SixChildNode();
                    break;
                case PathEnum.Seven:
                    returnTreeKindDict = new SeventhChildNode();
                    break;
                default:
                    System.Console.WriteLine("path count > or < than pathCount");
                    break;
            }
            return returnTreeKindDict;
            */
        }
    }
}