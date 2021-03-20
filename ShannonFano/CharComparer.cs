using System.Collections;

namespace ShannonFano
{
    public class CharComparer : IComparer
    {
        public int Compare(object? key1, object? key2)
        {
            var keyChar1 = (char) key1;

            var keyChar2 = (char) key2;

            if (keyChar1 < keyChar2)
            {
                return -1;
            }

            if (keyChar1 > keyChar2)
            {
                return 1;
            }

            return 0;
        }
    }
}