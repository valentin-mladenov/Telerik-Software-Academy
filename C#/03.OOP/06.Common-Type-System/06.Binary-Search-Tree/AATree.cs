using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Binary_Search_Tree
{
//  I all most made it on my own
//    class Node<T1, T2> : IComparable<Node<T1, T2>>
//            where T1 : IComparable<T1>
//    {
//        // Node internal data
//        internal int level;
//        internal Node<T1, T2> left;
//        internal Node<T1, T2> right;

//        //user data
//        internal T1 key;
//        internal T2 value;

//        //consructor for the center node
//        internal Node()
//        {
//            this.level = 0;
//            this.left = this;
//            this.right = this;
//        }

//        //constructor other nodes
//        internal Node(T1 key, T2 value, Node<T1, T2> center)
//        {
//            this.level = 1;
//            this.left = center;
//            this.right = center;
//            this.key = key;
//            this.value = value;
//        }

//        public override string ToString()
//        {
//            return string.Format("Key: {0}; Value: {1}", this.key, this.value);
//        }

//        public override int GetHashCode()
//        {
//            return this.key.GetHashCode() ^ this.value.GetHashCode();
//        }

//        public int CompareTo(Node<T1, T2> other)
//        {
//            return (object)other == null ? 1 : this.key.CompareTo(other.key);
//        }

//        public override bool Equals(object obj)
//        {
//            return obj == null ? false : this.CompareTo((Node<T1, T2>)obj) == 0;
//        }

//        public static bool operator ==(Node<T1, T2> a, Node<T1, T2> b)
//        {
//            if (((object)a == null) && ((object)b == null))
//            {
//                return true;
//            }
//            else if (((object)a == null) || ((object)b == null))
//            {
//                return false;
//            }
//            else
//            {
//                return a.Equals(b);
//            }
//        }

//        public static bool operator !=(Node<T1, T2> a, Node<T1, T2> b)
//        {
//            return !(a == b);
//        }
//    }

//    public class AATree<T1, T2> : IEnumerable<KeyValuePair<T1, T2>>, ICloneable
//        where T1 : IComparable<T1>
//    {
//        Node<T1, T2> root;
//        readonly Node<T1, T2> center;
//        Node<T1, T2> delete;

//        public AATree()
//        {
//            center = new Node<T1, T2>();
//            root = center;
//            delete = null;
//        }

//        public T2 this[T1 key]
//        {
//            get
//            {
//                Node<T1, T2> node = Search(root, key);
//                return node == null ? default(T2) : node.value;
//            }
//            set
//            {
//                Node<T1, T2> node = Search(root, key);
//                if (node == null)
//                {
//                    Add(key, value);
//                }
//                else
//                {
//                    node.value = value;
//                }
//            }
//        }

//        private void Curve(ref Node<T1, T2> node)
//        {
//            if (node.level == node.left.level)
//            {
//                //rotate right
//                Node<T1, T2> temp = node.left;
//                node.left = temp.right;
//                temp.right = node;
//                node = temp;
//            }
//        }

//        private void Split(ref Node<T1, T2> node)
//        {
//            if (node.level == node.right.right.level)
//            {
//                //rotate right
//                Node<T1, T2> temp = node.right;
//                node.right = temp.left;
//                temp.left = node;
//                node = temp;
//                node.level++;
//            }
//        }

//        private bool Insert(ref Node<T1, T2> node, T1 key, T2 value)
//        {
//            if (node == center)
//            {
//                node = new Node<T1, T2>(key, value, center);
//                return true;
//            }

//            int compare = key.CompareTo(node.key);
//            if (compare < 0)
//            {
//                if (!Insert(ref node.left, key, value))
//                {
//                    return false;
//                }
//            }
//            else if (compare > 0)
//            {
//                if (!Insert(ref node.right, key, value))
//                {
//                    return false;
//                }
//            }
//            else { return false; }

//            Curve(ref node);
//            Split(ref node);
//            return true;
//        }

//        private bool Delete(ref Node<T1, T2> node, T1 key)
//        {
//            if (node == center)
//            {
//                return (delete != null);
//            }

//            int compare = key.CompareTo(node.key);
//            if (compare < 0)
//            {
//                if (!Delete(ref node.left, key))
//                {
//                    return false;
//                }
//            }
//            else
//            {
//                if (compare == 0)
//                {
//                    delete = node;
//                }
//                if (!Delete(ref node.right, key))
//                {
//                    return false;
//                }

//            }

//            if (delete != null)
//            {
//                delete.key = node.key;
//                delete.value = node.value;
//                delete = null;
//                node = node.right;
//            }
//            else if (node.left.level < node.level - 1
//                  || node.right.level < node.level - 1)
//            {
//                node.level--;
//                if (node.right.level > node.level)
//                {
//                    node.right.level = node.level;
//                }
//                Curve(ref node);
//                Curve(ref node.right);
//                Curve(ref node.right.right);
//                Split(ref node);
//                Split(ref node.right);
//            }
//            return true;
//        }

//        private Node<T1, T2> Search(Node<T1, T2> node, T1 key)
//        {
//            if (node == center)
//            {
//                return null;
//            }

//            int compare = key.CompareTo(node.key);
//            if (compare < 0)
//            {
//                return Search(node.left, key);
//            }
//            else if (compare > 0)
//            {
//                return Search(node.right, key);
//            }
//            else
//            {
//                return node;
//            }
//        }

//        public bool Add(T1 key, T2 value)
//        {
//            return Insert(ref root, key, value);
//        }

//        public bool Remove(T1 key)
//        {
//            return Delete(ref root, key);
//        }

//        private void Traverse(Node<T1, T2> node, List<KeyValuePair<T1, T2>> list)
//        {
//            if (node == null)
//            {
//                return;
//            }

//            this.Traverse(node.left, list);
//            list.Add(new KeyValuePair<T1, T2>(node.key, node.value));
//            this.Traverse(node.right, list);
//        }

//        public override string ToString()
//        {
//            StringBuilder str = new StringBuilder();
//            foreach (var node in this)
//            {
//                str.AppendFormat(node.ToString());
//            }

//            if (str.Length > 0)
//            {
//                str.Length -= Environment.NewLine.Length;
//            }

//            return str.ToString();
//        }

//        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
//        {
//            List<KeyValuePair<T1, T2>> elems = new List<KeyValuePair<T1, T2>>();

//            this.Traverse(this.root, elems);
//            foreach (var elem in elems)
//            {
//                yield return elem;
//            }
//        }

//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//        {
//            return this.GetEnumerator();
//        }

//        public object Clone()
//        {
//            AATree<T1, T2> clone = new AATree<T1, T2>();
//            bool deepCopyKey = typeof(ICloneable).IsAssignableFrom(typeof(T1));
//            bool deepCopyValue = typeof(ICloneable).IsAssignableFrom(typeof(T2));
//            T1 key;
//            T2 value;

//            foreach (var item in this)
//            {
//                key = deepCopyKey ? (T1)(item.Key as ICloneable).Clone() : item.Key;
//                value = deepCopyValue ? (T2)(item.Value as ICloneable).Clone() : item.Value;
//                clone.Add(key, value);
//            }
//            return (object)clone;
//        }

//        public override int GetHashCode()
//        }
//            return this.
//        }
 
//        public override bool Equals(object obj)
//        {
//            AATree<T1, T2> otherTree;
//            IEnumerator<KeyValuePair<T1, T2>> myEnumerator;
//            IEnumerator<KeyValuePair<T1, T2>> otherEnumerator;
 
//            if (obj == null)
//            {
//                return false;
//            }

//            otherTree = obj as AATree<T1, T2>;
 
//            if (((object)otherTree == null) || (this.Count != otherTree.Count))
//            {
//                return false;
//            }
 
//            myEnumerator = this.GetEnumerator();
//            otherEnumerator = otherTree.GetEnumerator();
 
//            while (myEnumerator.MoveNext() && otherEnumerator.MoveNext())
//            {
//                if (myEnumerator.Current.Key.CompareTo(otherEnumerator.Current.Key) != 0)
//                {
//                    return false;
//                }
//            }
 
//            return true;
//        }

//        public static bool operator ==(AATree<T1, T2> a, AATree<T1, T2> b)
//        {
//            if (((object)a == null) && ((object)b == null))
//            {
//                return true;
//            }
//            else if (((object)a == null) || ((object)b == null))
//            {
//                return false;
//            }
//            else
//            {
//                return a.Equals(b);
//            }
//        }

//        public static bool operator !=(AATree<T1, T2> a, AATree<T1, T2> b)
//        {
//            return !(a == b);
//        }
//    }

    public class BSTree<TKey, TValue> : IEnumerable<Node<TKey, TValue>> 
        where TKey : IComparable<TKey>
    {
        private Node<TKey, TValue> root;

        public BSTree()
        {
            this.root = null;
        }

        public TValue this[TKey key]
        {
            set
            {
                this.Insert(key, value);
            }
            get
            {
                TValue result;
                if (!this.TryGetValue(key, out result))
                {
                    throw new KeyNotFoundException();
                }
                return result;
            }
        }

        public bool TryGetValue(TKey key, out TValue result)
        {
            Node<TKey, TValue> current = root;
            while (current != null)
            {
                if (current.Key.CompareTo(key) == -1)
                {
                    current = current.RightChild;
                }
                else if (current.Key.CompareTo(key) == 1)
                {
                    current = current.LeftChild;
                }
                else
                {
                    result = current.Value;
                    return true;
                }
            }
            result = default(TValue);
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            TValue tmp;
            return this.TryGetValue(key, out tmp);
        }

        public void Insert(TKey key, TValue value)
        {
            //If the tree is empty, set the root to be the new node.
            if (this.root == null)
            {
                this.root = new Node<TKey, TValue>(key, value);
            }
            else
            {
                Node<TKey, TValue> currentNode = root;
                while (currentNode != null)
                {
                    if (currentNode.Key.CompareTo(key) == -1)
                    {
                        if (currentNode.RightChild == null)
                        {
                            currentNode.RightChild = new Node<TKey, TValue>(key, value, currentNode);
                            /*
                            * Since we insert the node in the right child of the current node, the height of the
                            * right subtree increases, so the difference
                            * height(left-subtree) - height(right-subtree) decreases by 1.
                            */

                            InsertBalanceTree(currentNode, -1);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.RightChild;
                        }
                    }
                    else if (currentNode.Key.CompareTo(key) == 1)
                    {
                        if (currentNode.LeftChild == null)
                        {
                            currentNode.LeftChild = new Node<TKey, TValue>(key, value, currentNode);
                            /*
                            * Since we insert the node in the left child of the current node, the height of the
                            * left subtree increases, so the difference
                            * height(left-subtree) - height(right-subtree) increases by 1.
                            */
                            InsertBalanceTree(currentNode, 1);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.LeftChild;
                        }
                    }
                    else
                    {
                        currentNode.Value = value;
                        break;
                    }
                }
            }
        }

        public void Clear()
        {
            this.root = null;
        }


        private void InsertBalanceTree(Node<TKey, TValue> node, int addBalance)
        {
            while (node != null)
            {
                //Add the new balance value to the current node balance.
                node.Balance += addBalance;

                /*
                * If the balance was -1 or +1, the tree is still balanced so
                * we don't have to balanced it further
                */
                if (node.Balance == 0)
                {
                    break;
                }
                //If the height(left-subtree) - height(right-subtree) == 2
                else if (node.Balance == 2)
                {
                    if (node.LeftChild.Balance == 1)
                    {
                        RotateLeftLeft(node);
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }
                    break;
                }

                //If the height(left-subtree) - height(right-subtree) == -2
                else if (node.Balance == -2)
                {
                    if (node.RightChild.Balance == -1)
                    {
                        RotateRightRight(node);
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }
                    break;
                }

                if (node.Parent != null)
                {
                    /*
                    * If the current node is the left child of the parent node
                    * we need to increase the height of the parent node.
                    * */
                    if (node.Parent.LeftChild == node)
                    {
                        addBalance = 1;
                    }
                    /*
                    * If it is the right child,
                    * we decrease the height of the parent node
                    * */
                    else
                    {
                        addBalance = -1;
                    }
                }
                node = node.Parent;
            }
        }

        private void RotateRightRight(Node<TKey, TValue> node)
        {
            Node<TKey, TValue> rightChild = node.RightChild;
            Node<TKey, TValue> rightLeftChild = null;
            Node<TKey, TValue> parent = node.Parent;

            if (rightChild != null)
            {
                rightLeftChild = rightChild.LeftChild;
                rightChild.Parent = parent;
                rightChild.LeftChild = node;
                rightChild.Balance++;
                node.Balance = -rightChild.Balance;
            }

            node.RightChild = rightLeftChild;
            node.Parent = rightChild;

            if (rightLeftChild != null)
            {
                rightLeftChild.Parent = node;
            }
            if (node == this.root)
            {
                this.root = rightChild;
            }
            else if (parent.RightChild == node)
            {
                parent.RightChild = rightChild;
            }
            else
            {
                parent.LeftChild = rightChild;
            }
        }

        private void RotateLeftLeft(Node<TKey, TValue> node)
        {
            Node<TKey, TValue> leftChild = node.LeftChild;
            Node<TKey, TValue> leftRightChild = null;
            Node<TKey, TValue> parent = node.Parent;

            if (leftChild != null)
            {
                leftRightChild = leftChild.RightChild;
                leftChild.Parent = parent;
                leftChild.RightChild = node;
                leftChild.Balance--;
                node.Balance = -leftChild.Balance;
            }

            node.Parent = leftChild;
            node.LeftChild = leftRightChild;

            if (leftRightChild != null)
            {
                leftRightChild.Parent = node;
            }

            if (node == this.root)
            {
                this.root = leftChild;
            }
            else if (parent.LeftChild == node)
            {
                parent.LeftChild = leftChild;
            }
            else
            {
                parent.RightChild = leftChild;
            }

        }

        private void RotateRightLeft(Node<TKey, TValue> node)
        {
            Node<TKey, TValue> rightChild = node.RightChild;
            Node<TKey, TValue> rightLeftChild = null;
            Node<TKey, TValue> rightLeftRightChild = null;

            if (rightChild != null)
            {
                rightLeftChild = rightChild.LeftChild;
            }
            if (rightLeftChild != null)
            {
                rightLeftRightChild = rightLeftChild.RightChild;
            }

            node.RightChild = rightLeftChild;

            if (rightLeftChild != null)
            {
                rightLeftChild.Parent = node;
                rightLeftChild.RightChild = rightChild;
                rightLeftChild.Balance--;
            }

            if (rightChild != null)
            {
                rightChild.Parent = rightLeftChild;
                rightChild.LeftChild = rightLeftRightChild;
                rightChild.Balance--;
            }

            if (rightLeftRightChild != null)
            {
                rightLeftRightChild.Parent = rightChild;
            }

            RotateRightRight(node);
        }

        private void RotateLeftRight(Node<TKey, TValue> node)
        {
            Node<TKey, TValue> leftChild = node.LeftChild;
            Node<TKey, TValue> leftRightChild = leftChild.RightChild;
            Node<TKey, TValue> leftRightLeftChild = null;
            if (leftRightChild != null)
            {
                leftRightLeftChild = leftRightChild.LeftChild;
            }

            node.LeftChild = leftRightChild;

            if (leftRightChild != null)
            {
                leftRightChild.Parent = node;
                leftRightChild.LeftChild = leftChild;
                leftRightChild.Balance++;
            }

            if (leftChild != null)
            {
                leftChild.Parent = leftRightChild;
                leftChild.RightChild = leftRightLeftChild;
                leftChild.Balance++;
            }

            if (leftRightLeftChild != null)
            {
                leftRightLeftChild.Parent = leftChild;
            }


            RotateLeftLeft(node);
        }

        public void Delete(TKey key)
        {
            Node<TKey, TValue> current = this.root;
            while (current != null)
            {
                if (current.Key.CompareTo(key) == -1)
                {
                    current = current.RightChild;
                }
                else if (current.Key.CompareTo(key) == 1)
                {
                    current = current.LeftChild;
                }
                else //Found the key.
                {
                    if (current.LeftChild == null && current.RightChild == null)
                    {
                        if (current == root)
                        {
                            root = null;
                        }
                        else if (current.Parent.RightChild == current)
                        {
                            current.Parent.RightChild = null;
                            DeleteBalanceTree(current.Parent, 1);
                        }
                        else
                        {
                            current.Parent.LeftChild = null;
                            DeleteBalanceTree(current.Parent, -1);
                        }
                    }
                    else if (current.LeftChild != null) //Get the biggest node from the left subtree.
                    {
                        Node<TKey, TValue> rightMost = current.LeftChild;
                        while (rightMost.RightChild != null)
                        {
                            rightMost = rightMost.RightChild;
                        }


                        ReplaceNodes(current, rightMost);
                        DeleteBalanceTree(rightMost.Parent, 1);
                    }
                    else //Get the smallest node from the right subtree.
                    {
                        Node<TKey, TValue> leftMost = current.RightChild;
                        while (leftMost.LeftChild != null)
                        {
                            leftMost = leftMost.LeftChild;
                        }

                        ReplaceNodes(current, leftMost);
                        DeleteBalanceTree(leftMost.Parent, -1);
                    }
                    break;
                }
            }
        }

        private void ReplaceNodes(Node<TKey, TValue> sourceNode, Node<TKey, TValue> subtreeNode)
        {
            sourceNode.Key = subtreeNode.Key;
            sourceNode.Value = subtreeNode.Value;

            if (subtreeNode.Parent != null)
            {
                if (subtreeNode.LeftChild != null)
                {
                    subtreeNode.LeftChild.Parent = subtreeNode.Parent;
                    if (subtreeNode.Parent.LeftChild == subtreeNode)
                    {
                        subtreeNode.Parent.LeftChild = subtreeNode.LeftChild;
                    }
                    else
                    {
                        subtreeNode.Parent.RightChild = subtreeNode.LeftChild;
                    }
                }
                else if (subtreeNode.RightChild != null)
                {
                    subtreeNode.RightChild.Parent = subtreeNode.Parent;
                    if (subtreeNode.Parent.LeftChild == subtreeNode)
                    {
                        subtreeNode.Parent.LeftChild = subtreeNode.RightChild;
                    }
                    else
                    {
                        subtreeNode.Parent.RightChild = subtreeNode.RightChild;
                    }
                }
                else
                {
                    if (subtreeNode.Parent.LeftChild == subtreeNode)
                    {
                        subtreeNode.Parent.LeftChild = null;
                    }
                    else
                    {
                        subtreeNode.Parent.RightChild = null;
                    }
                }
            }
        }

        private void DeleteBalanceTree(Node<TKey, TValue> node, int addBalance)
        {
            while (node != null)
            {
                node.Balance += addBalance;
                addBalance = node.Balance;

                if (node.Balance == 2)
                {
                    if (node.LeftChild != null && node.LeftChild.Balance >= 0)
                    {
                        RotateLeftLeft(node);

                        if (node.Balance == -1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }
                }
                else if (node.Balance == -2)
                {
                    if (node.RightChild != null && node.RightChild.Balance <= 0)
                    {
                        RotateRightRight(node);

                        if (node.Balance == 1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }
                }
                else if (node.Balance != 0)
                {
                    return;
                }

                Node<TKey, TValue> parent = node.Parent;

                if (parent != null)
                {
                    if (parent.LeftChild == node)
                    {
                        addBalance = -1;
                    }
                    else
                    {
                        addBalance = 1;
                    }
                }
                node = parent;
            }
        }

        public static bool operator ==(BSTree<TKey, TValue> a, BSTree<TKey, TValue> b)
        {
            return BSTree<TKey, TValue>.Equals(a, b);
        }

        public static bool operator !=(BSTree<TKey, TValue> a, BSTree<TKey, TValue> b)
        {
            return !BSTree<TKey, TValue>.Equals(a, b);
        }

        //Traverses the tree in pre-order.
        public IEnumerator<Node<TKey, TValue>> GetEnumerator()
        {
            Queue<Node<TKey, TValue>> queue = new Queue<Node<TKey, TValue>>();
            queue.Enqueue(this.root);

            Node<TKey, TValue> tmp;
            while (queue.Count > 0)
            {
                tmp = queue.Dequeue();

                if (tmp.LeftChild != null)
                {
                    queue.Enqueue(tmp.LeftChild);
                }
                if (tmp.RightChild != null)
                {
                    queue.Enqueue(tmp.RightChild);
                }

                yield return tmp;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");

            Stack<Node<TKey, TValue>> stack = new Stack<Node<TKey, TValue>>();
            if (this.root != null)
            {
                stack.Push(root);
                Node<TKey, TValue> tmpNode;
                while (stack.Count > 0)
                {
                    tmpNode = stack.Pop();

                    if (tmpNode.Parent == null)
                    {
                        result.AppendLine(tmpNode + " is root.");
                    }
                    else if (tmpNode.Parent.RightChild == tmpNode)
                    {
                        result.AppendLine(tmpNode.Parent + " has right child: " + tmpNode);
                    }
                    else
                    {
                        result.AppendLine(tmpNode.Parent + " has left child: " + tmpNode);
                    }

                    if (tmpNode.RightChild != null)
                    {
                        stack.Push(tmpNode.RightChild);
                    }
                    if (tmpNode.LeftChild != null)
                    {
                        stack.Push(tmpNode.LeftChild);
                    }
                }
            }
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            BSTree<TKey, TValue> tree = obj as BSTree<TKey, TValue>;
            if (tree == null)
            {
                return false;
            }
            else
            {
                Queue<Tuple<Node<TKey, TValue>, Node<TKey, TValue>>> queue =
                    new Queue<Tuple<Node<TKey, TValue>, Node<TKey, TValue>>>();

                Node<TKey, TValue> item1, item2;

                queue.Enqueue(Tuple.Create(this.root, tree.root));
                while (queue.Count > 0)
                {
                    item1 = queue.Peek().Item1;
                    item2 = queue.Peek().Item2;
                    queue.Dequeue();

                    if (!item1.Equals(item2))
                    {
                        return false;
                    }
                    else if (item1.LeftChild == null && item2.LeftChild != null)
                    {
                        return false;
                    }
                    else if (item1.LeftChild != null && item2.LeftChild == null)
                    {
                        return false;
                    }
                    else if (item1.RightChild == null && item2.RightChild != null)
                    {
                        return false;
                    }
                    else if (item1.RightChild != null && item2.RightChild == null)
                    {
                        return false;
                    }
                    if (item1.LeftChild != null && item2.LeftChild != null)
                    {
                        queue.Enqueue(Tuple.Create(item1.LeftChild, item2.LeftChild));
                    }
                    if (item1.RightChild != null && item2.RightChild != null)
                    {
                        queue.Enqueue(Tuple.Create(item1.RightChild, item2.RightChild));
                    }
                }
                return true;
            }
        }

        public override int GetHashCode()
        {
            int treeHashCode = 0;
            Queue<Node<TKey, TValue>> queue = new Queue<Node<TKey, TValue>>();

            Node<TKey, TValue> tmp;

            queue.Enqueue(this.root);
            while (queue.Count > 0)
            {
                tmp = queue.Dequeue();
                treeHashCode ^= tmp.GetHashCode();

                if (tmp.LeftChild != null)
                {
                    queue.Enqueue(tmp.LeftChild);
                }
                if (tmp.RightChild != null)
                {
                    queue.Enqueue(tmp.RightChild);
                }
            }
            return treeHashCode;
        }
    }
}
