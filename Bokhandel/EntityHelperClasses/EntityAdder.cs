using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bokhandel.EntityHelperClasses
{
    public static class EntityAdder
    {
        public static Regex ISBNConstraint => new Regex("([0-9]){13}"); 

        public static FörfattareBöckerFörlag AddNyFörfattareBöckerFörlag(string[] userInputBok, Förlag inputFörlag, Författare nyFörfattare)
        {
            return new FörfattareBöckerFörlag()
            {
                Isbn = userInputBok[0],
                FörfattareId = nyFörfattare.FörfattareId,
                FörlagsId = inputFörlag.FörlagsId
            };
        }

        public static Författare AddNyFörfattare(string[] userInputFörfattareInfo)
        {
            return new Författare()
            {
                Förnamn = userInputFörfattareInfo[0],
                Efternamn = userInputFörfattareInfo[1],
                Födelsedatum = DateTime.Parse(userInputFörfattareInfo[2])
            };
        }


        public static Böcker AddNyBok(string[] userInputBokInfo)
        {
            return new Böcker()
            {
                Isbn = userInputBokInfo[0],
                Titel = userInputBokInfo[1],
                Språk = userInputBokInfo[2],
                Pris = Decimal.Parse(userInputBokInfo[3]),
                Utgivningsdatum = DateTime.Parse(userInputBokInfo[4])
            };
        }

        public static bool IsISBNUnique(string currentISBN, List<string> ISBNList)
        {
            foreach (var isbn in ISBNList)
            {
                if (currentISBN == isbn)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
