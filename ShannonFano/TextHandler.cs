using System.Collections;
using System.Collections.Generic;

namespace ShannonFano
{
    public class TextHandler
    {
        public List<Symbol> GetSymbols(string text)
        {
            var tree = CreateCharTree(text);

            var symbols = tree.GetItems();

            return symbols;
        }

        public string GetEncodedText(string text, List<Symbol> symbols)
        {
            var tree = CreateCharTree(symbols);

            var code = "";

            for (int i = 0; i < text.Length; i++)
            {
                var symbol = tree.Find(text[i]);

                code += symbol.Code;
            }

            return code;
        }

        public AVLTree<string, Symbol> CreatePrefixTree(List<Symbol> symbols)
        {
            IComparer comparer = new StrComparer();

            var tree = new AVLTree<string, Symbol>(comparer);

            foreach (var symbol in symbols)
            {
                AddSymbol(symbol, tree);
            }

            return tree;
        }

        public AVLTree<char, Symbol> CreateCharTree(List<Symbol> symbols)
        {
            IComparer comparer = new CharComparer();
            
            var tree = new AVLTree<char,Symbol>(comparer);

            foreach (var symbol in symbols)
            {
                AddSymbol(symbol,tree);
            }

            return tree;
        }

        private AVLTree<char,Symbol> CreateCharTree(string text)
        {
            IComparer comparer = new CharComparer();

            var tree = new AVLTree<char, Symbol>(comparer);

            foreach (var symbol in text)
            {
                AddSymbol(symbol, tree);
            }

            return tree;
        }

        private void AddSymbol(Symbol symbol, AVLTree<char, Symbol> tree)
        {
            try
            {
                tree.Find(symbol.Value);
            }
            catch
            {
                tree.Insert(symbol.Value,symbol);
            }
        }


        private void AddSymbol(Symbol symbol, AVLTree<string, Symbol> tree)
        {
            try
            {
                tree.Find(symbol.Code);
            }
            catch
            {
                tree.Insert(symbol.Code, symbol);
            }
        }


        private void AddSymbol(char symbolChar, AVLTree<char, Symbol> tree)
        {
            try
            {
                var symbol = tree.Find(symbolChar);

                symbol.Count++;
            }
            catch
            {
                var symbol = new Symbol {Count = 1, Value = symbolChar};

                tree.Insert(symbolChar, symbol);
            }
        }
    }
}