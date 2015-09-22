using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalaticCalculator
{
    class Convertion
    {
        // this function converts the intergalatic number to credits
        public static double intergalaticToDecimals(string stIntergalaticNumber)
        {
            string stRomanNumber = intergalaticToRoman(stIntergalaticNumber);
            return romanToInt(stRomanNumber);
        }

        // this function converts the intergalatic number to roman number
        private static string intergalaticToRoman(string stIntergalaticNumber)
        {
            // split the intergalatic number into an array of separate intergalatic numbers
            string[] arIntergalaticNumbers = stIntergalaticNumber.Split(' ');

            // build the corresponding roman number
            string stRomanNumber = "";
            foreach (string stNumber in arIntergalaticNumbers)
            {
                if (stNumber == Numeral.constGlob) {
                    stRomanNumber += Numeral.constStGlobRoman;
                } else if (stNumber == Numeral.constProk) {
                    stRomanNumber += Numeral.constStProkRoman;
                } else if (stNumber == Numeral.constPish) {
                    stRomanNumber += Numeral.constStPishRoman;
                } else if (stNumber == Numeral.constTegj) {
                    stRomanNumber += Numeral.constStTegjRoman;
                }
            }

            return stRomanNumber;
        }

        // this function converts the roman number to int
        private static int romanToInt(string stRomanNumber)  
        {
            // step one: convert the roman number string to a char array
            char[] arChRomanNumber = stRomanNumber.ToCharArray();

            // step two: convert char array to int array 
            int[] arInRomanNumber = romanCharArrayToIntArray(arChRomanNumber);

            // step three: calculating (had a little help from google, I'm only human)
            int inResponse = 0;
            int inRomanNumberSize = arInRomanNumber.Length;
            int inMultp, inCurrentNumber;

            for (int inIdx = 0; inIdx < inRomanNumberSize; inIdx++)
            {
                inCurrentNumber = arInRomanNumber[inIdx];
                
                // if not last number AND the next number is bigger than the current number
                if ((inIdx + 1 < inRomanNumberSize) && (arInRomanNumber[inIdx + 1] > inCurrentNumber)) {
                    // invert the number
                    inMultp = -1;
                } else {
                    // nothing changes
                    inMultp = 1;
                }

                inResponse += inMultp * inCurrentNumber;
            }
            return inResponse;
        }

        // this function converts the char array (in romans) into an integer array
        // note: due to lack of time, I'm only considering the numbers in the given scenario
        private static int[] romanCharArrayToIntArray(char[] arChRomanNumber)
        {
            List<int> arInList = new List<int>();
            foreach (char chNumber in arChRomanNumber)
            {
                if (chNumber == 'I') {
                    arInList.Add(1);
                } else if (chNumber == 'V') {
                    arInList.Add(5);
                } else if (chNumber == 'X') {
                    arInList.Add(10);
                } else if (chNumber == 'L') {
                    arInList.Add(50);
                }
            }
            return arInList.ToArray();
        }

        internal static int symbolsToCredits(char p)
        {
            throw new NotImplementedException();
        }
    }
}
