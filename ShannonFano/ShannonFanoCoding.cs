using System.Collections.Generic;

namespace ShannonFano
{
    public class ShannonFanoCoding
    {
        private AVLTree<string, Symbol> tree;

        public List<Symbol> Coding(string text)
        {
            var textHandler = new TextHandler();

            var symbols = textHandler.GetSymbols(text);

            Sort(symbols, 0, symbols.Count - 1);

            var sum = GetSum(symbols);

            Rec(symbols, sum, "");

            this.tree = textHandler.CreatePrefixTree(symbols);

            return symbols;
        }

        public string Decoding(string code)
        {
            var prefix = "";

            var text = "";

            for (int i = 0; i < code.Length; i++)
            {
                prefix += code[i];

                try
                {
                    var symbol = tree.Find(prefix);

                    text += symbol.Value;

                    prefix = "";
                }
                catch
                {
                }
            }

            return text;
        }

        private void Rec(List<Symbol> symbols, int sum, string code)
        {
            if (symbols.Count == 1)
            {
                symbols[0].Code = code;

                return;
            }

            var leftList = new List<Symbol>();

            var rightList = new List<Symbol>();

            var curSum = 0;

            for (int i = 0; i < symbols.Count; i++)
            {
                if (curSum + symbols[i].Count <= sum / 2)
                {
                    leftList.Add(symbols[i]);

                    curSum += symbols[i].Count;
                }
                else
                {
                    rightList.Add(symbols[i]);
                }
            }

            Rec(leftList, curSum, code + "0");

            Rec(rightList, sum - curSum, code + "1");
        }


        private int GetSum(List<Symbol> symbols)
        {
            int sum = 0;

            foreach (var symbol in symbols)
            {
                sum += symbol.Count;
            }

            return sum;
        }

        private int Partition(List<Symbol> symbols, int start, int end)
        {
            Symbol temp;

            var marker = start;

            for (var i = start; i < end; i++)
            {
                if (symbols[i].Count > symbols[end].Count)
                {
                    temp = symbols[marker];
                    symbols[marker] = symbols[i];
                    symbols[i] = temp;
                    marker++;
                }
            }

            temp = symbols[marker];
            symbols[marker] = symbols[end];
            symbols[end] = temp;
            return marker;
        }

        private void Sort(List<Symbol> symbols, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = Partition(symbols, start, end);
            Sort(symbols, start, pivot - 1);
            Sort(symbols, pivot + 1, end);
        }
    }
}