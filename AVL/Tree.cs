﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AVL
{
    public class Tree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public Node<T> Head { get; internal set; }

        public int Count { get; private set; }

        public Tree() { }

        public Tree(T value)
        {
            Add(value);
        }

        public Tree(T[] array)
        {
            foreach (T item in array)
            {
                Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        public IEnumerator<T> InOrderTraversal()
        {
            if (Head != null)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();
                Node<T> current = Head;

                bool goLeftNext = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                        yield return current.Value;
                        if (current.Right != null)
                        {
                            current = current.Right;
                            goLeftNext = true;
                        }
                        else
                        {
                            current = stack.Pop();
                            goLeftNext = false;
                        }
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Add(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value, null, this);
                Count = 1;
                return true;
            }
            else
                return AddTo(Head, value);
        }

        public bool Add(T[] array)
        {
            bool success = false;
            foreach (T item in array)
            {
                success = AddTo(Head, item);
            }
            return success;
        }

        private bool AddTo(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                    node.Left = new Node<T>(value, node, this);
                else
                    AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new Node<T>(value, node, this);
                else
                    AddTo(node.Right, value);
            }
            Count++;
            return node.Balance();
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        private Node<T> Find(T value)
        {
            Node<T> current = Head;
            while (current != null)
            {
                int result = current.CompareTo(value);
                if (result > 0)
                    current = current.Left;
                else if (result < 0)
                    current = current.Right;
                else
                    break;
            }
            return current;
        }

        public bool Remove(T value)
        {
            if (value == null)
                return false;
            Node<T> current;
            current = Find(value);
            if (current == null)
                return false;
            Node<T> treeToBalance = current.Parent;
            Count--;

            if (current.Right == null)
            {
                if (current.Parent == null)
                {
                    Head = current.Left;
                    if (Head != null)
                        Head.Parent = null;
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Value);
                    if (result > 0)
                        current.Parent.Left = current.Left;
                    else if (result < 0)
                        current.Parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (current.Parent == null)
                {
                    Head = current.Right;
                    if (Head != null)
                        Head.Parent = null;
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Value);
                    if (result > 0)
                        current.Parent.Left = current.Right;
                    else if (result < 0)
                        current.Parent.Right = current.Right;
                }
            }
            else
            {
                Node<T> leftmost = current.Right.Left;
                while (leftmost.Left != null)
                {
                    leftmost = leftmost.Left;
                }
                leftmost.Parent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if (current.Parent == null)
                {
                    Head = leftmost;
                    if (Head != null)
                        Head.Parent = null;
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Value);
                    if (result > 0)
                        current.Parent.Left = leftmost;
                    else if (result < 0)
                        current.Parent.Right = leftmost;
                }
            }
            if (treeToBalance != null)
                treeToBalance.Balance();
            else
            {
                if (Head != null)
                    Head.Balance();
            }
            return true;


        }

        public Node<T> FindMin()
        {
            Node<T> current = Head;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }

        public Node<T> FindMax()
        {
            Node<T> current = Head;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current;
        }
    }
}
