using System;
using System.Collections.Generic;
using System.Text;

namespace Bokhandel.EntityHelperClasses
{
    public static class EntityAdder
    {
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
                Pris = Decimal.Parse(userInputBokInfo[1]),
                Språk = userInputBokInfo[2],
                Titel = userInputBokInfo[3],
                Utgivningsdatum = DateTime.Parse(userInputBokInfo[4])
            };
        }
    }
}
