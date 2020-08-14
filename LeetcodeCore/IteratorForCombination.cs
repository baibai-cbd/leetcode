using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class CombinationIterator
    {
        // 1286. Iterator for Combination

        private readonly string _characters;
        private readonly int _comboLength;
        private readonly bool[] _flags;

        public CombinationIterator(string characters, int combinationLength)
        {
            _characters = characters;
            _comboLength = combinationLength;
            _flags = new bool[characters.Length];
            for (int i = 0; i < _comboLength; i++)
            {
                _flags[i] = true;
            }
        }

        public string Next()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _flags.Length; i++)
            {
                if (_flags[i])
                    sb.Append(_characters[i]);
            }

            int countTail = 0;
            for (int i = _flags.Length-1; i >= 0; i--)
            {
                if (!_flags[i]) continue;
                if (_flags[i])
                {
                    if (i+1 < _flags.Length)
                    {
                        if (_flags[i+1])
                        {
                            countTail++;
                            continue;
                        }
                        else
                        {
                            _flags[i + 1] = true;
                            _flags[i] = false;
                            for (int j = 1; j <= countTail; j++)
                            {
                                _flags[^j] = false;
                            }
                            for (int j = 1; j <= countTail; j++)
                            {
                                _flags[i + 1 + j] = true;
                            }
                            break;
                        }
                    }
                    else
                    {
                        countTail++;
                        continue;
                    }
                }
            }
            if (countTail == _comboLength)
            {
                for (int i = 0; i < _flags.Length; i++)
                    _flags[i] = false;
            }
            return sb.ToString();
        }

        public bool HasNext()
        {
            return _flags.Any(f => f == true);
        }
    }
}
