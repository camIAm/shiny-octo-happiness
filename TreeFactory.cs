
namespace ConsoleApplication
{
    public class TreeFactory
    {
        ITreeImpl returnTreeKind;
        public TreeFactory()
        {
        }
        /* 
        public TreeFactory(ITreeImpl _returnTreeKind)
        {
            returnTreeKind = _returnTreeKind;
        }
        */
        public ITreeImpl GetTreeKind(int pathCount)
        {
            PathEnum pathEnum = (PathEnum)pathCount;
            switch(pathEnum)
            {
                case PathEnum.Root:
                    returnTreeKind = new RootNode();
                    break;
                case PathEnum.One:
                    returnTreeKind = new OneChildNode();
                    break;
                case PathEnum.Two:
                    returnTreeKind = new TwoChildNode();
                    break;
                case PathEnum.Three:
                    returnTreeKind = new ThreeChildNode();
                    break;
                case PathEnum.Four:
                    returnTreeKind = new FourChildNode();
                    break;
                case PathEnum.Five:
                    returnTreeKind = new FiveChildNode();
                    break;
                case PathEnum.Six:
                    returnTreeKind = new SixChildNode();
                    break;
                case PathEnum.Seven:
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