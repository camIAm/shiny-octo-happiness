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
        }
    }
}