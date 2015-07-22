using System;

namespace Places
{
    public static class Helper
    {
        // Use spherical law of cosines to calculate distance from two points
        public static double CalculateDistance(double uLat, double uLong, double latitude, double longitude)
        {
            int radius = 6371;
            var dLatitude = (latitude - uLat) * Math.PI / 180;
            var dLongitude = (longitude - uLong) * Math.PI / 180;
            var a = Math.Sin(dLatitude / 2) * Math.Sin(dLatitude / 2) + Math.Cos(uLat) * Math.Cos(latitude) * Math.Sin(dLongitude / 2) * Math.Sin(dLongitude / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return radius * c;
        }

        // Get Direction to latitude & longitude point from user latitude & longitude
        public static string GetDirection(double uLat, double uLong, double latitude, double longitude)
        {
            var y = Math.Sin(longitude - uLong) * Math.Cos(latitude);
            var x = Math.Cos(uLat) * Math.Sin(latitude) - Math.Sin(uLat) * Math.Cos(latitude) * Math.Cos(longitude - uLong);
            var b = Math.Atan2(y, x) * (180 / Math.PI);
            var bearings = new string[] { "N", "NW", "W", "SW", "S", "SE", "E", "NE" };
            int idx = (int)((b + 360) % 360);
            return bearings[idx / 45];
        }
    }
}