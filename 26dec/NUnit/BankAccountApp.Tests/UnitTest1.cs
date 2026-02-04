<<<<<<< HEAD
﻿using NUnit.Framework;
using System;

namespace BankAccountTests
{
    // Required attribute for NUnit test class
    [TestFixture]
    public class UnitTest
    {
        // Test for valid deposit amount
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            // Arrange
            Program account = new Program(1000m);

            // Act
            account.Deposit(500m);

            // Assert
            Assert.AreEqual(1500m, account.Balance);
        }

        // Test for negative deposit amount
        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            // Arrange
            Program account = new Program(1000m);

            // Act & Assert
            Assert.AreEqual(
                "Deposit amount cannot be negative",
                Assert.Throws<Exception>(() => account.Deposit(-200m)).Message
            );
        }

        // Test for valid withdrawal amount
        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            // Arrange
            Program account = new Program(1000m);

            // Act
            account.Withdraw(300m);

            // Assert
            Assert.AreEqual(700m, account.Balance);
        }

        // Test for withdrawal with insufficient funds
        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            // Arrange
            Program account = new Program(500m);

            // Act & Assert
            Assert.AreEqual(
                "Insufficient funds.",
                Assert.Throws<Exception>(() => account.Withdraw(800m)).Message
            );
=======
using NUnit.Framework;
using BankAccountApp;
using System;

namespace BankAccountApp.Tests
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            Program acc = new Program(1000);
            acc.Deposit(500);

            Assert.That(acc.Balance, Is.EqualTo(1500));
        }

        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            Program acc = new Program(1000);

            var ex = Assert.Throws<Exception>(() => acc.Deposit(-100));
            Assert.That(ex.Message, Is.EqualTo("Deposit amount cannot be negative"));
        }

        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            Program acc = new Program(1000);
            acc.Withdraw(400);

            Assert.That(acc.Balance, Is.EqualTo(600));
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            Program acc = new Program(500);

            var ex = Assert.Throws<Exception>(() => acc.Withdraw(800));
            Assert.That(ex.Message, Is.EqualTo("Insufficient funds."));
>>>>>>> 24bce4b44ccd71310f565fa4191c55b51973994a
        }
    }
}
