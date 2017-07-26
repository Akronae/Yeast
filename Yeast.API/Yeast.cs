using System;

namespace Yeast
{
    /// <summary>
    /// Handle Encoding, Decoding, and random Generation of keys.
    /// </summary>
    public static class Yeast
    {
        private static char[] _Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_".ToCharArray();
        private static string _PreviousKey = String.Empty;
        private static int _Seed;

        /// <summary>
        /// Return a string representing the given number.
        /// </summary>
        /// <param name="number">The long you want to be converted into string.</param>
        /// <returns>The corresponding string.</returns>
        public static string Encode (long number)
        {
            var encoded = String.Empty;

            do
            {
                encoded = _Alphabet[number % _Alphabet.Length] + encoded;
                number = (long) Math.Floor( (double) number / _Alphabet.Length);
            }
            while (number > 0);

            return encoded;
        }

        /// <summary>
        /// Return an long representing the given string.
        /// </summary>
        /// <param name="value">The string you want to be converted into long.</param>
        /// <returns>The corresponding long.</returns>
        public static long Decode (string value)
        {
            long decoded = 0;

            for (var i = 0; i < value.Length; i++)
                decoded = decoded * _Alphabet.Length + Array.IndexOf(_Alphabet, value[i]);

            return decoded;
        }

        /// <summary>
        /// Return a string corresponding to the milliseconds ellapsed since 1/1/1970.
        /// </summary>
        /// <returns>The encoded string.</returns>
        public static string GenerateKey ()
        {
            long now = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            string key = Encode(now);

            if (key != _PreviousKey)
            {
                _Seed = 0;
                _PreviousKey = key;
                return key;
            }
            else return $"{key}.{Encode(_Seed++)}";
        }
    }
}
