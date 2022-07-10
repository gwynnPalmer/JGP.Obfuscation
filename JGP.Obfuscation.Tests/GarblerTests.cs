// ***********************************************************************
// Assembly         : JGP.Packages.Tests
// Author           : Joshua Gwynn-Palmer
// Created          : 06-26-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 06-26-2022
// ***********************************************************************
// <copyright file="GarblerTests.cs" company="Joshua Gwynn-Palmer">
//     Joshua Gwynn-Palmer
// </copyright>
// <summary></summary>
// ***********************************************************************

using Bogus;
using FluentAssertions;
using FluentAssertions.Execution;
using JGP.Extensions.Strings;
using JGP.Obfuscation;
using NUnit.Framework;

namespace JGP.Packages.Tests.Obfuscation;

/// <summary>
///     Class GarblerTests.
/// </summary>
public class GarblerTests
{
    /// <summary>
    ///     Defines the test method GarbleDateTime.
    /// </summary>
    [Test]
    public void GarbleDateTime()
    {
        var dateTime = DateTime.UtcNow;
        var garbled = Garbling.Garble(dateTime);

        using (new AssertionScope())
        {
            garbled.Should().NotBeNull();
            garbled.Should().NotBe(dateTime);
            garbled.Should().HaveValue();
        }
    }

    /// <summary>
    ///     Defines the test method GarbleEmail.
    /// </summary>
    [Test]
    public void GarbleEmail()
    {
        var email = new Faker().Person.Email;

        var emailIsEmail = email.IsEmailAddress();
        var garbled = Garbling.GarbleEmail(email);
        var garbledIsEmail = garbled!.IsEmailAddress();

        using (new AssertionScope())
        {
            emailIsEmail.Should().BeTrue();
            garbled.Should().NotBeNullOrWhiteSpace();
            garbledIsEmail.Should().BeTrue();
            garbled.Should().NotBe(email);
        }
    }

    /// <summary>
    ///     Defines the test method GarbleInt.
    /// </summary>
    [Test]
    public void GarbleInt()
    {
        var baseRandom = new Random();
        var random = new Random(baseRandom.Next(0, 1000000));
        var value = random.Next(0, 1000000);
        var garbled = Garbling.Garble(value);

        using (new AssertionScope())
        {
            garbled.Should().BeOfType(typeof(int));
            garbled.Should().NotBe(value);
            garbled.Should().BeInRange(0, value);
        }
    }

    /// <summary>
    ///     Defines the test method GarblePostalCode.
    /// </summary>
    [Test]
    public void GarblePostalCode()
    {
        var postalCode = new Faker("en_GB").Address
            .ZipCode("??## #??");

        var garbled = Garbling.GarblePostalCode(postalCode);

        using (new AssertionScope())
        {
            garbled.Should().NotBeNullOrWhiteSpace();
            garbled!.Length.Should().Be(postalCode.Length);
            garbled.Should().NotBe(postalCode);
        }
    }

    /// <summary>
    ///     Defines the test method GarbleString.
    /// </summary>
    [Test]
    public void GarbleString()
    {
        var value = StringExtensions.GenerateRandomString(20);
        var garbled = Garbling.Garble(value);

        using (new AssertionScope())
        {
            garbled.Should().NotBeNullOrWhiteSpace();
            garbled.Should().NotBe(value);
            garbled!.Length.Should().Be(value.Length);
        }
    }

    /// <summary>
    ///     Defines the test method GarbleTelephoneNUmber.
    /// </summary>
    [Test]
    public void GarbleTelephoneNUmber()
    {
        var telephone = new Faker("en_GB").Person.Phone;

        var garbled = Garbling.GarbleTelephoneNumber(telephone);

        using (new AssertionScope())
        {
            garbled.Should().NotBeNullOrWhiteSpace();
            garbled.Should().NotBe(telephone);
        }
    }
}