using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DOUFizzBuzz
{
    public class FizzBuzzer
    {
        // set default values
        private int _nFizz = 3;
        private int _nBuzz = 5;
        private int _nLowerBound = 1;
        private int _nUpperBound = 100;

        public int NFizz
        {
            get { return _nFizz; }
            set { _nFizz = value; }
        }

        public int NBuzz
        {
            get { return _nBuzz; }
            set { _nBuzz = value; }
        }

        public int NLowerBound
        {
            get { return _nLowerBound; }
            set { _nLowerBound = value; }
        }

        public int NUpperBound
        {
            get { return _nUpperBound; }
            set { _nUpperBound = value; }
        }

        // return a list with all values
        public List<string> GetAll()
        {
            var fizzBuzzList = new List<string>();

            for (var i = _nLowerBound; i <= _nUpperBound; i++)
            {
                string fbResult = GetResult(i);

                if (!string.IsNullOrEmpty(fbResult))
                {
                    fizzBuzzList.Add(fbResult);
                }
            }
            return fizzBuzzList;
        }

        public string GetResult(int currentNumber)
        {
            var sb = new StringBuilder();
            var isMatch = false;

            if ((currentNumber % _nFizz) == 0)
            {
                isMatch = true;
                sb.Append("Fizz");
            }

            if ((currentNumber % _nBuzz) == 0)
            {
                if (isMatch)
                    sb.Append(" ");

                isMatch = true;
                sb.Append("Buzz");
            }

            if (!isMatch)
            {
                sb.Append(currentNumber);
            }

            return sb.ToString();
        }

    }
}
