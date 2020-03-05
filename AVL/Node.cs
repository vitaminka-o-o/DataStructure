using System;
using System.Collections.Generic;
using System.Text;

namespace AVL
{
    public class Node<T> : IComparable<T> where T : IComparable<T>
    {
        Tree<T> _tree;
        Node<T> _left;
        Node<T> _right;
        public T Value { get; private set; }
        public Node<T> Parent { get; internal set; }
        public int Key { get; private set; }

        public Node<T> Left
        {
            get { return _left; }
            internal set
            {
                _left = value;
                if (_left != null)
                    _left.Parent = this;
            }
        }

        public Node<T> Right
        {
            get { return _right; }
            internal set
            {
                _right = value;
                if (_right != null)
                    _right.Parent = this;
            }
        }

        public Node(T value, Node<T> parent, Tree<T> tree)
        {
            if (value != null)
                Value = value;
            Parent = parent;
            _tree = tree;
            if (parent == null)
                Key = 0;
            else
                Key = parent.Key++;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }

        enum TreeState
        {
            Balanced,
            LeftHeavy,
            RightHeavy
        }

        private TreeState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                    return TreeState.LeftHeavy;
                if (RightHeight - LeftHeight > 1)
                    return TreeState.RightHeavy;
                return TreeState.Balanced;
            }
        }

        private int MaxChildHeight(Node<T> node)
        {
            if (node != null)
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            return 0;
        }

        private int LeftHeight
        {
            get { return MaxChildHeight(Left); }
        }

        private int RightHeight
        {
            get { return MaxChildHeight(Right); }
        }

        private int BalanceFactor
        {
            get { return RightHeight - LeftHeight; }
        }

        private void LeftRotation()
        {
            Node<T> newRoot = Right;
            ReplaceRoot(newRoot);
            Right = newRoot.Left;
            newRoot.Left = this;
        }

        private void RightRotation()
        {
            Node<T> newRoot = Left;
            ReplaceRoot(newRoot);
            Left = newRoot.Right;
            newRoot.Right = this;
        }

        private void ReplaceRoot(Node<T> newRoot)
        {
            if (this.Parent != null)
            {
                if (this.Parent.Left == this)
                    this.Parent.Left = newRoot;
                else if (this.Parent.Right == this)
                    this.Parent.Right = newRoot;
            }
            else
            {
                _tree.Head = newRoot;
            }
            newRoot.Parent = this.Parent;
            this.Parent = newRoot;
        }

        public bool Balance()
        {

            if (State == TreeState.RightHeavy)
            {
                if (Right != null && Right.BalanceFactor < 0)
                {
                    RightLeftRotation();
                    return true;
                }
                else
                {
                    LeftRotation();
                    return true;
                }
            }
            else if (State == TreeState.LeftHeavy)
            {
                if (Left != null && Left.BalanceFactor > 0)
                {
                    LeftRightRotation();
                    return true;
                }
                else
                {
                    RightRotation();
                    return true;
                }
            }
            else if (State == TreeState.Balanced)
                return true;
            else
                return false;
        }

        private void RightLeftRotation()
        {
            Right.RightRotation();
            this.LeftRotation();
        }

        private void LeftRightRotation()
        {
            Left.LeftRotation();
            this.RightRotation();
        }
    }
}
