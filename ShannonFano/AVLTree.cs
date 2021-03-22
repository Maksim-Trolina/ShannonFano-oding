using System;
using System.Collections;
using System.Collections.Generic;

namespace ShannonFano
{
    public class AVLTree<T, V>
    {
        private Node<T, V> root;

        private IComparer comparer;

        public int Count { get; private set; }

        public AVLTree(IComparer comparer)
        {
            this.comparer = comparer;
        }


        public List<V> GetItems()
        {
            var items = new List<V>();

            AddItem(root, items);

            return items;
        }

        public V Find(T key)
        {
            return Find(root, key);
        }


        public void Insert(T key, V value)
        {
            root = Insert<T, V>(root, key, value);

            Count++;
        }


        private void AddItem(Node<T, V> node, List<V> items)
        {
            if (node == null)
            {
                return;
            }

            AddItem(node.Left, items);

            items.Add(node.Item);

            AddItem(node.Right, items);
        }

        private int Height<T, V>(Node<T, V> node)
        {
            return node?.Height ?? 0;
        }

        private int BFactor<T, V>(Node<T, V> node)
        {
            return Height(node.Right) - Height(node.Left);
        }

        private void FixHeight<T, V>(Node<T, V> node)
        {
            var heightLeft = Height(node.Left);
            var heightRight = Height(node.Right);
            node.Height = (heightLeft > heightRight ? heightLeft : heightRight) + 1;
        }

        private Node<T, V> RotateRight<T, V>(Node<T, V> node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;
            FixHeight(node);
            FixHeight(left);
            return left;
        }

        private Node<T, V> RotateLeft<T, V>(Node<T, V> node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;
            FixHeight(node);
            FixHeight(right);
            return right;
        }

        private Node<T, V> Balance<T, V>(Node<T, V> node)
        {
            FixHeight(node);
            if (BFactor(node) == 2)
            {
                if (BFactor(node.Right) < 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                return RotateLeft(node);
            }

            if (BFactor(node) == -2)
            {
                if (BFactor(node.Left) > 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                return RotateRight(node);
            }

            return node;
        }

        private Node<T, V> Insert<T, V>(Node<T, V> node, T key, V value)
        {
            if (node == null)
            {
                return new Node<T, V>(key, value);
            }

            if (comparer.Compare(key, node.Key) == (int) ComparisonResult.Less)
            {
                node.Left = Insert(node.Left, key, value);
            }
            else
            {
                node.Right = Insert(node.Right, key, value);
            }

            return Balance(node);
        }

        private V Find<T, V>(Node<T, V> node, T key)
        {
            if (node == null)
            {
                throw new Exception("Not found item with same key");
            }

            return comparer.Compare(key, node.Key) switch
            {
                (int) ComparisonResult.Less => Find(node.Left, key),
                (int) ComparisonResult.More => Find(node.Right, key),
                _ => node.Item
            };
        }
    }
}