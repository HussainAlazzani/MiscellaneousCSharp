using System;

namespace Miscellaneous
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkList = new SinglyLinkList();
            linkList.AddToTail(5);
            linkList.AddToTail(4);
            linkList.AddToHead(7);
            linkList.AddToHead(8);
            linkList.AddToTail(10);
            linkList.AddToTail(3);
            linkList.AddToHead(2);
            linkList.Reverse();
            linkList.Print();
        }
    }
}
