using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntergalaticCalculator
{
    class Query
    {
        // query possibilities
        private const string constStIntergalaticToDecimalText = "how much is";
        private const string constStGetMaterialValueText = "how many Credits is";

        // query types
        public const string constStBadQuery = "I have no idea what you are talking about";
        public const string constStIntergalaticToDecimal = "intergalaticToDecimal";
        public const string constStGetMaterialValue = "getMaterialVelue";

        // this function gets the query type from the query string
        public static string getQueryType(string stQuery)
        {
            string stQueryType = constStBadQuery;
            // validating the query size to prevend c# error in the substring
            if (stQuery.Length > 10) {
                if (stQuery.Substring(0, 11) == constStIntergalaticToDecimalText)
                {
                    stQueryType = constStIntergalaticToDecimal;
                }
                else if (stQuery.Substring(0, 19) == constStGetMaterialValueText)
                {
                    stQueryType = constStGetMaterialValue;
                }
            }
            
            return stQueryType;
        }

        // this function gets the material type from the query string
        public static string getMaterialType(string stQuery)
        {
            string stMaterialType = "";
            string[] arQueryWords = stQuery.Split(' ');
            foreach (string stWord in arQueryWords)
            {
                if (stWord == Material.constStSilver) {
                    stMaterialType = Material.constStSilver;
                } else if (stWord == Material.constStGold) {
                    stMaterialType = Material.constStGold;
                } else if (stWord == Material.constStIron) {
                    stMaterialType = Material.constStIron;
                }
            }
            return stMaterialType;
        }

        // this function gets the intergalatic number from the query string
        public static string getNumber(string stQuery)
        {
            // get the intergalatic number from the query string
            string[] arQuery = stQuery.Split(' ');

            // build the number
            string stIntergalaticNumber = "";
            foreach (string stNumber in arQuery)
            {
                if (stNumber == Numeral.constGlob) {
                    stIntergalaticNumber += Numeral.constGlob + " ";
                } else if (stNumber == Numeral.constProk) {
                    stIntergalaticNumber += Numeral.constProk + " ";
                } else if (stNumber == Numeral.constPish) {
                    stIntergalaticNumber += Numeral.constPish + " ";
                } else if (stNumber == Numeral.constTegj) {
                    stIntergalaticNumber += Numeral.constTegj + " ";
                }
            }
            return stIntergalaticNumber;
        }

        // main function!
        public static List<string> run(string[] arQueryLines)
        {
            List<String> arOutput = new List<String>();
            foreach (string stQuery in arQueryLines)
            {
                // find out what kind of query it is
                string stQueryType = getQueryType(stQuery);

                // --------------------------------------------------------- 
                // QUERY TYPE 1 = convert intergalatic to decimal
                // --------------------------------------------------------- 

                if (stQueryType == constStIntergalaticToDecimal) {

                    // get intergalatic number from query
                    string stIntergalaticNumber = getNumber(stQuery);

                    // convert the intergalatic number into decimals
                    double doCredits = Convertion.intergalaticToDecimals(stIntergalaticNumber);

                    // response
                    arOutput.Add(doCredits.ToString());

                // --------------------------------------------------------- 
                // QUERY TYPE 2 = get material value
                // --------------------------------------------------------- 

                } else if (stQueryType == constStGetMaterialValue) {

                    // get material type from query
                    string stMaterialType = getMaterialType(stQuery);

                    // get intergalatic number from query
                    string stIntergalaticNumber = getNumber(stQuery);

                    // convert the intergalatic number into decimals
                    double doMaterialAmmount = Convertion.intergalaticToDecimals(stIntergalaticNumber);

                    // multiply the ammount of materials with their value
                    double doCredits = Material.getMaterialValue(doMaterialAmmount, stMaterialType);

                    // response
                    arOutput.Add(doCredits.ToString());

                // --------------------------------------------------------- 
                // QUERY TYPE NOT FOUND = query unidentified
                // --------------------------------------------------------- 

                } else {
                    arOutput.Add(constStBadQuery);
                }
            }
            return arOutput;
        }
    }
}
