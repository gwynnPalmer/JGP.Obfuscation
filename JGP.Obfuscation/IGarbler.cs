// ***********************************************************************
// Assembly         : JGP.Obfuscation
// Author           : Joshua Gwynn-Palmer
// Created          : 06-17-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 06-17-2022
// ***********************************************************************
// <copyright file="IGarbler.cs" company="JGP.Obfuscation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Obfuscation;

/// <summary>
///     Interface IGarbler
/// </summary>
public interface IGarbler
{
    /// <summary>
    ///     Obfuscates the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>System.Nullable&lt;System.String&gt;.</returns>
    string? Garble(string? value);

    /// <summary>
    ///     Obfuscates the date time.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
    DateTime? Garble(DateTime? value);

    /// <summary>
    ///     Obfuscates the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>System.Int32.</returns>
    int Garble(int value);

    /// <summary>
    ///     Obfuscates the email.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="prefix">Adds a prefix to the obfuscated email address.</param>
    /// <returns>System.Nullable&lt;System.String&gt;.</returns>
    string? GarbleEmail(string? value, string prefix = "");

    /// <summary>
    ///     Obfuscates the postal code.
    /// </summary>
    /// <param name="postalCode">The postal code.</param>
    /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
    string? GarblePostalCode(string? postalCode);

    /// <summary>
    ///     Obfuscates the telephone number.
    /// </summary>
    /// <param name="telephoneNumber">The telephone number.</param>
    /// <returns>System.Nullable&lt;System.String&gt;.</returns>
    string? GarbleTelephoneNumber(string? telephoneNumber);
}