using System;
using System.Linq;

namespace _06.Binary_Search_Tree
{
    //Almost!!!
    //public class Node
    //{
    //    // Node internal data
    //    internal int level;
    //    internal Node left;
    //    internal Node right;

    //    //user data
    //    internal T1 key;
    //    internal T2 value;

    //    //consructor for the center node
    //    internal Node()
    //    {
    //        this.level = 0;
    //        this.left = this;
    //        this.right = this;
    //    }

    //    //constructor other nodes
    //    internal Node(T1 key, T2 value, Node center)
    //    {
    //        this.level = 1;
    //        this.left = center;
    //        this.right = center;
    //        this.key = key;
    //        this.value = value;
    //    }
    //}

    public class Node<TKey, TValue>
    {
        public Node(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
            this.LeftChild = null;
            this.RightChild = null;
            this.Parent = null;
            this.Balance = 0;
        }

        public Node(TKey key, TValue value, Node<TKey, TValue> parent)
            : this(key, value)
        {
            this.Parent = parent;
        }

        public Node(Node<TKey, TValue> node)
            : this(node.Key, node.Value, node.Parent)
        {
            this.LeftChild = node.LeftChild;
            this.RightChild = node.RightChild;
        }

        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public Node<TKey, TValue> Parent { get; set; }
        public Node<TKey, TValue> LeftChild { get; set; }
        public Node<TKey, TValue> RightChild { get; set; }
        public int Balance { get; set; }


        public override int GetHashCode()
        {
            return (this.Key.GetHashCode() << 16) | (this.Value.GetHashCode() & 0xFFFF);
        }

        public override bool Equals(object obj)
        {
            Node<TKey, TValue> node = obj as Node<TKey, TValue>;
            if (node == null)
            {
                return false;
            }
            else
            {
                if (this.Key.Equals(node.Key) && this.Value.Equals(node.Value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", this.Key, this.Value);
        }
    }
}
