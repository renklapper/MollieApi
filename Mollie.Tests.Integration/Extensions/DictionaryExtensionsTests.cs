﻿using System.Collections.Generic;
using System.Linq;
using Mollie.Api.Extensions;
using NUnit.Framework;

namespace Mollie.Tests.Integration.Extensions
{
    [TestFixture]
    public class DictionaryExtensionsTests
    {

        [Test]
        public void CanCreateUrlQueryFromDictionary()
        {
            // Arrange
            var parameters = new Dictionary<string, string>()
            {
                {"include", "issuers"},
                {"testmode", "true"}
            };
            var expected = "?include=issuers&testmode=true";

            // Act
            var result = parameters.ToQueryString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CanCreateUrlQueryFromEmptyDictionary()
        {
            // Arrange
            var parameters = new Dictionary<string, string>();
            string expected = string.Empty;

            // Act
            var result = parameters.ToQueryString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CanAddParameterToDictionaryIfNotEmptyDictionary()
        {
            // Arrange
            var parameters = new Dictionary<string, string>();
            var parameterName = "include";
            var parameterValue = "issuers";

            // Act
            parameters.AddValueIfNotNullOrEmpty(parameterName, parameterValue);

            // Assert
            Assert.IsTrue(parameters.Any());
            Assert.AreEqual(parameterValue, parameters[parameterName]);
        }

        [Test]
        public void CannotAddParameterToDictionaryIfEmptyDictionary()
        {
            // Arrange
            var parameters = new Dictionary<string, string>();

            // Act
            parameters.AddValueIfNotNullOrEmpty("include", "");

            // Assert
            Assert.IsFalse(parameters.Any());
        }
    }
}
