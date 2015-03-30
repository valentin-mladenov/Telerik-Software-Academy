namespace _01.Working_With_Tree_Basics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T>
    {
        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }

            this.Root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.Root.AddChild(child.Root);
            }
        }

        public TreeNode<T> Root { get; set; }

        private void TraverseDFS(TreeNode<T> root, string spaces)
        {
            Console.WriteLine(spaces + root.Data);

            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChildAt(i);
                this.TraverseDFS(child, spaces + "   ");
            }
        }

        public void TraverseDFS()
        {
            if (this.Root == null)
            {
                throw new ArgumentNullException("The tree has no root");
            }

            this.TraverseDFS(this.Root, string.Empty);
        }

        public void TraverseBFS()
        {
            if (this.Root == null)
            {
                throw new ArgumentNullException("The tree has no root");
            }

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();
             //   Console.Write("{0} ", currentNode.Data);
                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChildAt(i);
                    queue.Enqueue(childNode);
                }
            }
        }

        public void TraverseDFSWithStack()
        {
            if (this.Root == null)
            {
                throw new ArgumentNullException("The tree has no root");
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(this.Root);
            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();
           //     Console.Write("{0} ", currentNode.Data);
                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChildAt(i);
                    stack.Push(childNode);
                }
            }
        }

        public Stack<T> FindAllLeaves()
        {
            if (this.Root == null)
            {
                throw new ArgumentNullException("The tree has no root");
            }

            Stack<T> leaveStack = new Stack<T>();
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            stack.Push(this.Root);
            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();
                if (currentNode.ChildrenCount==0)
                {
                    leaveStack.Push(currentNode.Data);
                }

                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChildAt(i);
                    stack.Push(childNode);
                }
            }

            return leaveStack;
        }

        public Stack<T> FindAllMiddleNodes()
        {
            if (this.Root == null)
            {
                throw new ArgumentNullException("The tree has no root");
            }

            Stack<T> leaveStack = new Stack<T>();
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            stack.Push(this.Root);
            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();
                if (currentNode.ChildrenCount != 0 && currentNode.HasParent)
                {
                    leaveStack.Push(currentNode.Data);
                }

                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChildAt(i);
                    stack.Push(childNode);
                }
            }

            return leaveStack;
        }

        public int FindLongestPath()
        {
            if (this.Root == null)
            {
                throw new ArgumentNullException("The tree has no root");
            }

            return this.LongestPath(this.Root);
        }

        private int LongestPath(TreeNode<T> start)
        {
            if (start == null)
            {
                return -1;
            }

            int currentLongestPath = 0;
            for (int i = 0; i < start.ChildrenCount; i++)
            {
                currentLongestPath = Math.Max(currentLongestPath, LongestPath(start.GetChildAt(i)));
            }

            return currentLongestPath + 1;
        }

        public List<TreeNode<T>> GetAllNodes()
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            this.GetAllTreeNodes(this.Root, nodes);
            return nodes;
        }

        private void GetAllTreeNodes(TreeNode<T> start, List<TreeNode<T>> nodes)
        {
            if (start == null)
            {
                return;
            }
            nodes.Add(start);
            for (int i = 0; i < start.ChildrenCount; i++)
            {
                GetAllTreeNodes(start.GetChildAt(i), nodes);
            }
        }

        public List<List<TreeNode<T>>> FindPathsWithSum(T sum)
        {
            List<List<TreeNode<T>>> paths = new List<List<TreeNode<T>>>();
            List<TreeNode<T>> treeNodes = GetAllNodes();
            foreach (var node in treeNodes)
            {
                Queue<List<TreeNode<T>>> mainQueue = new Queue<List<TreeNode<T>>>();
                List<TreeNode<T>> path = new List<TreeNode<T>>() { node };
                mainQueue.Enqueue(path);
                while (mainQueue.Count > 0)
                {
                    List<TreeNode<T>> currentPath = mainQueue.Dequeue();
                    dynamic currentSum = Sum(currentPath);
                    if (currentSum == sum)
                    {
                        paths.Add(currentPath);
                    }
                    if (currentSum > sum)
                    {
                        continue;
                    }

                    TreeNode<T> last = currentPath.Last();
                    for (int i = 0; i < last.ChildrenCount; i++)
                    {
                        mainQueue.Enqueue(new List<TreeNode<T>>(currentPath)
                        {
                            last.GetChildAt(i)
                        });
                    }
                }
            }
            return paths;
        }
        private dynamic Sum(List<TreeNode<T>> list)
        {
            dynamic sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i].Data;
            }
            return sum;
        }
    }
}
