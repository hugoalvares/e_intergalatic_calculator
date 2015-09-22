using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalaticCalculator
{
    class Material
    {
        // material names
        public const string constStSilver = "Silver";
        public const string constStGold = "Gold";
        public const string constStIron = "Iron";

        // credit value for materials
        public const double constDoSilverValue = 17;
        public const double constDoGoldValue = 14450;
        public const double constDoIronValue = 195.5;

        // this function converts the intergalatic number to roman number
        public static double getMaterialValue(double doMaterialAmmount, string stMaterialType)
        {
            double doMaterialValue = 0;
            if (stMaterialType == constStSilver) {
                doMaterialValue = doMaterialAmmount * constDoSilverValue;
            } else if (stMaterialType == constStGold) {
                doMaterialValue = doMaterialAmmount * constDoGoldValue;
            } else if (stMaterialType == constStIron) {
                doMaterialValue = doMaterialAmmount * constDoIronValue;
            }
            return doMaterialValue;
        }
    }
}
