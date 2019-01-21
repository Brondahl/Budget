using System;
using FluentAssertions;
using NUnit.Framework;
using static Budgetting.Helpers.SimpleHasher;

namespace Budgetting.Tests
{
  [TestFixture]
  public class HasherTests
  {
    [TestCase]
    public void OutputLength()
    {
      Hash("inputString").Should().HaveLength(32);
    }

    [TestCase]
    public void HanldesNullables()
    {
      Hash((int?)32).Should().HaveLength(32);
    }

    [TestCase]
    public void HanldesNulls()
    {
      Hash((string)null).Should().HaveLength(32);
    }

    [TestCase]
    public void HashingNothingWorks()
    {
      Hash().Should().HaveLength(32);
    }

    [TestCase]
    public void HashOfNullDifferentFromEmpytHash()
    {
      Hash((string)null).Should().NotBe(Hash());
    }

    [TestCase]
    public void NullsHaveAnEffect()
    {
      Hash((string)null, "input").Should().NotBe(Hash("input"));
      Hash((string)null, "input", null, 3).Should().NotBe(Hash("input", 3));
      Hash("input", null, 3).Should().NotBe(Hash("input"));
    }

    [TestCase]
    public void CaseSensitive()
    {
      Hash("inputString").Should().NotBe(Hash("Inputstring"));
    }

    [TestCase]
    public void RepeatableOutput()
    {
      Hash("inputString").Should().Be(Hash("inputString"));
    }

    [TestCase]
    public void NonCollidingOutput()
    {
      Hash("inputString").Should().NotBe(Hash("differentString"));
    }

    [TestCase]
    public void MultiHasherShouldIgnoreTypeCasts()
    {
      Hash("inputString").Should().Be(Hash((object)"inputString"));
    }

    [TestCase]
    public void MultiHasherShouldGiveDifferentResultsFromConcatenation()
    {
      Hash("inputString").Should().NotBe(Hash("input", "String"));
      Hash("input", "String").Should().NotBe(Hash("in", "putString"));
    }

    [TestCase]
    public void HashingDifferentTypesWorks()
    {
      Hash(1, "inputString", 2).Should().HaveLength(32);
    }

    [TestCase]
    public void ComplexHashingStillRepeatable()
    {
      Hash(1, "inputString", 2, BitConverter.GetBytes(43524256345645)).Should().Be(
        Hash(1, "inputString", 2, BitConverter.GetBytes(43524256345645))
      );
    }

    [TestCase]
    public void OrderingOfNumbersIsSignificant()
    {
      Hash(1, 2).Should().NotBe(Hash(2, 1));
    }
  }
}
