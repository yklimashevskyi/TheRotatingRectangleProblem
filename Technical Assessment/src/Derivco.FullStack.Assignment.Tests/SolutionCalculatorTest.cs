// ----------------------------------------------------------------------------
// <copyright file="SolutionCalculatorTest.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Tests
{
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using FluentAssertions;
  using NUnit.Framework;

  [TestFixture]
  [ExcludeFromCodeCoverage]
  [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Test methods.")]
  public class SolutionCalculatorTest
  {
		[Test]
		public void Calculate_GivenRectangles_ShouldCalculateCorrectSolutionForThreeRectangles()
		{
			// Arrange
			var calculator = new SolutionCalculator();
			var inputRectangles = new List<Rectangle>
			{
				new Rectangle(8, 21),
				new Rectangle(1, 23, 8),
				new Rectangle(3, 8, 9)
			};
			var expectedRectangles = new List<Rectangle>
			{
				new Rectangle(1, 2, 8, 21),
				new Rectangle(9, 13, 0, 8),
				new Rectangle(12, 8)
			};
			var expectedRectanglesCount = 3;

			// Act
			Solution solution = calculator.Calculate(inputRectangles);

			// Assert
			solution.InputRectangles.ShouldAllBeEquivalentTo(inputRectangles);
			solution.OutputRectangles.Count.Should().Be(expectedRectanglesCount);
			for (int i = 0; i < expectedRectanglesCount; i++)
			{
				solution.OutputRectangles[i].ShouldBeEquivalentTo(expectedRectangles[i]);
			}
		}
		
		[Test]
		public void Calculate_GivenRectangles_ShouldCalculateCorrectSolutionForFourRectangles()
		{
			// Arrange
			var calculator = new SolutionCalculator();
			var inputRectangles = new List<Rectangle>
			{
				new Rectangle(2, 16),
				new Rectangle(7, 10, 2),
				new Rectangle(3, 16, 9),
				new Rectangle(3, 12, 12)
			};
			var expectedRectangles = new List<Rectangle>
			{
				new Rectangle(2, 6, 0, 10),
				new Rectangle(3, 4, 9, 12),
				new Rectangle(6, 2, 9, 10),
				new Rectangle(15, 10)
			};
			var expectedRectanglesCount = 4;

			// Act
			Solution solution = calculator.Calculate(inputRectangles);

			// Assert
			solution.InputRectangles.ShouldAllBeEquivalentTo(inputRectangles);
			solution.OutputRectangles.Count.Should().Be(expectedRectanglesCount);
			for (int i = 0; i < expectedRectanglesCount; i++)
			{
				solution.OutputRectangles[i].ShouldBeEquivalentTo(expectedRectangles[i]);
			}
		}

		[Test]
		public void Calculate_GivenRectangles_ShouldCalculateCorrectSolutionForFiveRectangles()
		{
			// Arrange
			var calculator = new SolutionCalculator();
			var inputRectangles = new List<Rectangle>
			{
				new Rectangle(5, 6),
				new Rectangle(10, 16, 5),
				new Rectangle(3, 8, 15),
				new Rectangle(1, 1, 18),
				new Rectangle(4, 3, 19)
			};
			var expectedRectangles = new List<Rectangle>
			{
				new Rectangle(4, 2, 19, 1),
				new Rectangle(10, 8, 5, 8),
				new Rectangle(13, 2, 5, 6),
				new Rectangle(18, 5, 0, 1),
				new Rectangle(23, 1)
			};
			var expectedRectanglesCount = 5;

			// Act
			Solution solution = calculator.Calculate(inputRectangles);

			// Assert
			solution.InputRectangles.ShouldAllBeEquivalentTo(inputRectangles);
			solution.OutputRectangles.Count.Should().Be(expectedRectanglesCount);
			for (int i = 0; i < expectedRectanglesCount; i++)
			{
				solution.OutputRectangles[i].ShouldBeEquivalentTo(expectedRectangles[i]);
			}
		}

		[Test]
		public void Calculate_GivenRectangles_ShouldCalculateCorrectSolutionForSixteenRectangles()
		{
			// Arrange
			var calculator = new SolutionCalculator();
			var inputRectangles = new List<Rectangle>
			{
				new Rectangle(2, 6),
				new Rectangle(4, 8, 2),
				new Rectangle(2, 14, 6),
				new Rectangle(2, 12, 8),
				new Rectangle(6, 10, 10),
				new Rectangle(4, 12, 16),
				new Rectangle(2, 4, 20),
				new Rectangle(12, 8, 22),
				new Rectangle(6, 10, 34),
				new Rectangle(2, 2, 40),
				new Rectangle(4, 6, 42),
				new Rectangle(4, 16, 46),
				new Rectangle(2, 10, 50),
				new Rectangle(6, 4, 52),
				new Rectangle(2, 12, 58),
				new Rectangle(8, 2, 60)
			};
			var expectedRectangles = new List<Rectangle>
			{
				new Rectangle(2, 2, 6, 12),
				new Rectangle(2, 8, 58, 4),
				new Rectangle(4, 2, 6, 10),
				new Rectangle(4, 2, 16, 10),
				new Rectangle(4, 6, 46, 10),
				new Rectangle(6, 2, 34, 8),
				new Rectangle(6, 4, 46, 6),
				new Rectangle(10, 2, 42, 4),
				new Rectangle(14, 2, 6, 8),
				new Rectangle(18, 2, 2, 6),
				new Rectangle(18, 4, 22, 4),
				new Rectangle(18, 2, 42, 2),
				new Rectangle(20, 2, 0, 4),
				new Rectangle(40, 2, 0, 2),
				new Rectangle(68, 2)
			};
			var expectedRectanglesCount = 15;

			// Act
			Solution solution = calculator.Calculate(inputRectangles);

			// Assert
			solution.InputRectangles.ShouldAllBeEquivalentTo(inputRectangles);
			solution.OutputRectangles.Count.Should().Be(expectedRectanglesCount);
			for (int i = 0; i < expectedRectanglesCount; i++)
			{
				solution.OutputRectangles[i].ShouldBeEquivalentTo(expectedRectangles[i]);
			}
		}
	}
}