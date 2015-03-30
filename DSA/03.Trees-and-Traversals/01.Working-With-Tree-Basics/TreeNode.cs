namespace _01.Working_With_Tree_Basics
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        private IList<TreeNode<T>> children;

        public TreeNode(T data)
        {
            this.Data = data;
            this.children = new List<TreeNode<T>>();
        }

        public bool HasParent { get; set; }

        public T Data { get; set; }

        public void AddChild (TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            if (child.HasParent)
            {
                throw new ArgumentException(
                    "This is tree, not graph. Only one perant allowed");
            }

            child.HasParent = true;
            this.children.Add(child);
        }

        public TreeNode<T> GetChildAt(int index)
        {
            return this.children[index];
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }
    }
}