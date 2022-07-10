// ***********************************************************************
// Assembly         : JGP.Obfuscation
// Author           : Joshua Gwynn-Palmer
// Created          : 06-17-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 06-17-2022
// ***********************************************************************
// <copyright file="Garbling.cs" company="JGP.Obfuscation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Obfuscation
{
    /// <summary>
    ///     Class Garbling.
    /// </summary>
    public static class Garbling
    {
        /// <summary>
        ///     The obfuscator
        /// </summary>
        private static readonly IGarbler Garbler = new Garbler();

        /// <summary>
        ///     Obfuscates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;System.String&gt;.</returns>
        public static string? Garble(string? value)
        {
            return Garbler.Garble(value);
        }

        /// <summary>
        ///     Obfuscates the date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public static DateTime? Garble(DateTime? value)
        {
            return Garbler.Garble(value);
        }

        /// <summary>
        ///     Obfuscates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public static int Garble(int value)
        {
            return Garbler.Garble(value);
        }

        /// <summary>
        ///     Obfuscates the email.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="prefix">Adds a prefix to the obfuscated email address.</param>
        /// <returns>System.Nullable&lt;System.String&gt;.</returns>
        public static string? GarbleEmail(string? value, string prefix = "")
        {
            return Garbler.GarbleEmail(value, prefix);
        }

        /// <summary>
        ///     Obfuscates the postal code.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public static string? GarblePostalCode(string? postalCode)
        {
            return Garbler.GarblePostalCode(postalCode);
        }

        /// <summary>
        ///     Obfuscates the telephone number.
        /// </summary>
        /// <param name="telephoneNumber">The telephone number.</param>
        /// <returns>System.Nullable&lt;System.String&gt;.</returns>
        public static string? GarbleTelephoneNumber(string? telephoneNumber)
        {
            return Garbler.GarbleTelephoneNumber(telephoneNumber);
        }
    }
}