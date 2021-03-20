namespace ShannonFano
{
    public class Node<T,V>
    {
        public V Item;
        public T Key;
        public int Height;
        public Node<T,V> Left;
        public Node<T,V> Right;

        public Node(T key,V value)
        {
            Key = key;
            Left = Right = null;
            Height = 1;
            Item = value;
        }
    }
}