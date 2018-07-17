// ----------------------------------------------------------------------------
// <copyright file="SolutionCalculator.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment
{
	using System.Collections.Generic;
	using System.Linq;

	public class SolutionCalculator : ISolutionCalculator
	{
		#region ISolutionCalculator implementation

		public Solution Calculate(IList<Rectangle> inputRectangles)
		{
			return new Solution
			{
				InputRectangles = inputRectangles,
				OutputRectangles = CalculateSolution(inputRectangles)
			};
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Calculate solution for the Rotating Rectangle Problem
		/// </summary>
		/// <param name="inputRectangles">List of input rectangles</param>
		/// <returns>Rotated list of rectangles</returns>
		private IList<Rectangle> CalculateSolution(IList<Rectangle> inputRectangles)
		{
			List<Rectangle> outputRectangles = new List<Rectangle>();
			List<Rectangle> inputRectanglesCopy = GetInputRectanglesCopy(inputRectangles);

			while (inputRectanglesCopy.Count > 0)
			{
				List<Rectangle> neighborRectanglesCombination = GetFirstNeighborRectanglesCombination(inputRectanglesCopy);
				Rectangle solutionRectangle = GetCommonRectangleFromCombination(neighborRectanglesCombination);
				outputRectangles.Add(solutionRectangle);
				RemoveSolutionRectangleArea(solutionRectangle, inputRectanglesCopy);
			}

			return outputRectangles.OrderBy(r => r.Width).ToList();
		}

		/// <summary>
		/// Get copy of input rectangles
		/// </summary>
		/// <param name="inputRectangles">List of input rectangles</param>
		/// <returns>Copy of input rectangles</returns>
		private List<Rectangle> GetInputRectanglesCopy(IList<Rectangle> inputRectangles)
		{
			return inputRectangles.Select(r => new Rectangle(r.Width, r.Height, r.Left, r.Bottom)).ToList();
		}

		/// <summary>
		/// Get first neighbor rectangles combination from the start
		/// </summary>
		/// <param name="rectangles">List of rectangles</param>
		/// <returns>First neighbor rectangles combination from the start</returns>
		private List<Rectangle> GetFirstNeighborRectanglesCombination(IList<Rectangle> rectangles)
		{
			List<Rectangle> neighborRectanglesCombination = new List<Rectangle> { rectangles[0] };
			for (int i = 0; i < rectangles.Count - 1; i++)
			{
				Rectangle next = rectangles[i + 1];
				Rectangle current = rectangles[i];
				if (next.Left != current.Left + current.Width)
				{
					break;
				}
				neighborRectanglesCombination.Add(next);
			}
			return neighborRectanglesCombination;
		}

		/// <summary>
		/// Get common rectangle from neighbors combination
		/// </summary>
		/// <param name="rectanglesCombination">Neighbor rectangles combination</param>
		/// <returns>Solution rectangle</returns>
		private Rectangle GetCommonRectangleFromCombination(IList<Rectangle> rectanglesCombination)
		{
			Rectangle first = rectanglesCombination[0];
			int combinationWidthSum = rectanglesCombination.Sum(r => r.Width);
			int combinationMinHeight = rectanglesCombination
				.OrderBy(r => r.Height)
				.Select(r => r.Height)
				.FirstOrDefault();
			return new Rectangle(combinationWidthSum, combinationMinHeight, first.Left, first.Bottom);
		}

		/// <summary>
		/// Remove solution rectangle area from rectangles list
		/// </summary>
		/// <param name="solutionRectangle">Solution rectangle</param>
		/// <param name="rectangles">List of rectangles</param>
		private void RemoveSolutionRectangleArea(Rectangle solutionRectangle, List<Rectangle> rectangles)
		{
			foreach (Rectangle rectangle in rectangles)
			{
				if (IsCoveredBySolutionRectangle(rectangle, solutionRectangle))
				{
					DecreaseRectangleBySolutionArea(rectangle, solutionRectangle);
				}
			}
			RemoveAllZeroHeightRectangles(rectangles);
		}

		/// <summary>
		/// Check is rectangle covered by solution rectangle
		/// </summary>
		/// <param name="rectangle">Rectangle</param>
		/// <param name="solutionRectangle">Solution rectangle</param>
		/// <returns>Result of check</returns>
		private bool IsCoveredBySolutionRectangle(Rectangle rectangle, Rectangle solutionRectangle)
		{
			return solutionRectangle.Height <= rectangle.Height
				&& rectangle.Left >= solutionRectangle.Left
				&& rectangle.Left < solutionRectangle.Left + solutionRectangle.Width;
		}

		/// <summary>
		/// Decrease rectangle by solution rectangle area
		/// </summary>
		/// <param name="rectangle">Rectangle</param>
		/// <param name="solutionRectangle">Solution rectangle</param>
		private void DecreaseRectangleBySolutionArea(Rectangle rectangle, Rectangle solutionRectangle) {
			rectangle.Height -= solutionRectangle.Height;
			rectangle.Bottom += solutionRectangle.Height;
		}

		/// <summary>
		/// Remove all rectangles with zero height
		/// </summary>
		/// <param name="rectangles">List of rectangles</param>
		private void RemoveAllZeroHeightRectangles(List<Rectangle> rectangles)
		{
			rectangles.RemoveAll(r => r.Height == 0);
		}

		#endregion

  }
}