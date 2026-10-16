using System;
using System.Collections.Generic;
using System.Text;

namespace CsomagszallitoFutarszolgalatRendszer
{
    public class UzemanyagKalkulator
    {
        public static double BecsultUzemanyagKoltseg(int osszKm)
        {
            return osszKm * 0.08 * 600;
        }
    }
}
