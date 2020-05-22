using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Helpers
{
    public static class Geographic
    {
        /// <summary>
        /// Radius of the Earth
        /// </summary>
        private const double R = 6378;
        private const double kmOfMeridian = 1.0 / 111.0;

        public static double countRangeNS(double valueKm)
        {
            return valueKm * kmOfMeridian;
        }

        public static double countRangeEW(double valueKm, double latitude)
        {
            double radianLatitude = (Math.PI / 180) * latitude;
            return 360 / (2 * Math.PI * R * Math.Cos(radianLatitude));
        }


    }
}
