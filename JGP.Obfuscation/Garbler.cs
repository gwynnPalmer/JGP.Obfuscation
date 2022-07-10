// ***********************************************************************
// Assembly         : JGP.Obfuscation
// Author           : Joshua Gwynn-Palmer
// Created          : 06-17-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 06-17-2022
// ***********************************************************************
// <copyright file="Garbler.cs" company="JGP.Obfuscation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Obfuscation
{
    using System.Text;
    using Extensions.Strings;

    /// <summary>
    ///     Class Garbler.
    /// </summary>
    public class Garbler : IGarbler
    {
        /// <summary>
        ///     The random
        /// </summary>
        private readonly Random _random;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Garbler" /> class.
        /// </summary>
        public Garbler()
        {
            _random = new Random(46821);
        }


        /// <summary>
        ///     Obfuscates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;System.String&gt;.</returns>
        public string? Garble(string? value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            if (value.IsDate())
            {
                DateTime.TryParse(value, out var dateTimeValue);
                return Garble(dateTimeValue)?.ToString("yyyy-MM-dd");
            }

            if (!value.IsInt()) return Encrypt(value);

            int.TryParse(value, out var intValue);
            return Garble(intValue).ToString();
        }

        /// <summary>
        ///     Obfuscates the date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public DateTime? Garble(DateTime? value)
        {
            return value?.AddDays(GetRandom(-31, 31)).Date;
        }

        /// <summary>
        ///     Obfuscates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public int Garble(int value)
        {
            return GetRandom(0, value);
        }

        /// <summary>
        ///     Obfuscates the email.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="prefix">Adds a prefix to the obfuscated email address.</param>
        /// <returns>System.Nullable&lt;System.String&gt;.</returns>
        public string? GarbleEmail(string? value, string prefix = "")
        {
            return string.IsNullOrEmpty(value)
                ? null
                : $"{prefix}{Encrypt(value)}";
        }

        /// <summary>
        ///     Obfuscates the postal code.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public string? GarblePostalCode(string? postalCode)
        {
            if (string.IsNullOrEmpty(postalCode)) return null;

            if (postalCode.IsInt()) return Garble(int.Parse(postalCode)).ToString();

            var postcodeParts = postalCode.Trim().Split(' ');
            return postcodeParts.Length > 1
                ? $"{postcodeParts[0].ToUpper()} {Garble(postcodeParts[1])?.ToUpper()}"
                : Garble(postalCode)?.ToUpper();
        }

        /// <summary>
        ///     Obfuscates the telephone number.
        /// </summary>
        /// <param name="telephoneNumber">The telephone number.</param>
        /// <returns>System.Nullable&lt;System.String&gt;.</returns>
        public string? GarbleTelephoneNumber(string? telephoneNumber)
        {
            if (string.IsNullOrEmpty(telephoneNumber)) return null;

            var length = telephoneNumber.Length;
            var stringBuilder = new StringBuilder();
            while (stringBuilder.Length < length + 1) stringBuilder.Append(GetRandom(0, 9));

            return stringBuilder.ToString();
        }

        #region HELPER METHODS

        /// <summary>
        ///     Ciphers the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.Char.</returns>
        private static char Cipher(char character, int key)
        {
            if (!char.IsLetter(character)) return character;

            var offset = char.IsUpper(character) ? 'A' : 'a';
            return (char)((character + key - offset) % 26 + offset);
        }

        /// <summary>
        ///     Encrypts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        private string Encrypt(string input)
        {
            var output = string.Empty;

            foreach (var character in input)
            {
                var key = GetRandom(1, 25);
                output += Cipher(character, key);
            }

            return output;
        }

        /// <summary>
        ///     Gets the random.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>System.Int32.</returns>
        private int GetRandom(int start, int end)
        {
            return _random.Next(start, end);
        }
        #endregion
    }
}