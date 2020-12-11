using System;

namespace Miscellaneous
{
    public class SinglyLinkList
    {
        private SNode head;

        public void AddToTail(int value)
        {
            var newNode = new SNode(value);
            if (head == null)
            {
                head = newNode;
                return;
            }

            SNode current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        public void AddToHead(int value)
        {
            var newNode = new SNode(value);
            if (head == null)
            {
                head = newNode;
                return;
            }

            newNode.Next = head;
            head = newNode;
        }

        public void Print()
        {
            if (head == null) return;

            SNode current = head;
            while (current != null)
            {
                System.Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        public bool Find(int value)
        {
            if (head == null) return false;

            SNode current = head;

            while (current != null)
            {
                if (current.Value == value)
                    return true;
                
                current = current.Next;
            }
            return false;
        }

        public void Remove(int value)
        {
            if(head == null) return;

            // If first node matches value
            if (head.Value == value)
            {
                head = head.Next;
                return;
            }

            SNode current = head;

            while (current.Next != null && current.Next.Next != null)
            {
                if (current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }

            if (current.Next.Value == value)
            {
                current.Next = null;
            }
        }

        public void Clear()
        {
            head = null;
        }

        public void PrintReverse()
        {
            if (head == null) return;
            PrintReverseHelper(head);
        }
        
        private void PrintReverseHelper(SNode node)
        {
            if (node == null) return;

            PrintReverseHelper(node.Next);
            System.Console.WriteLine(node.Value);
        }

        public void Reverse()
        {
            if(head == null) return;

            SNode p = null;
            SNode c = head;
            SNode n = head.Next;

            while (c.Next != null)
            {
                c.Next = p;
                p = c;
                c = n;
                n = n.Next;
            }

            // Reverse last node and make it head.
            c.Next = p;
            head = c;
        }
    }
}