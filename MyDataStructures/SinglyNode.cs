using System;

namespace MyDataStructures
{
    public class SNode
    {
        public int Value { get; set; }
        public SNode Next { get; set; }

        public SNode(int value)
        {
            this.Value = value;
        }
    }
}
