using System;
using System.Collections.Generic;
using DiscountCalculator;
using NUnit.Framework;

namespace DiscountCalculator_Tests
{
	[TestFixture]
	public class Test_DiscountCalculator
	{
		/// <summary>
		///  Calculate Discount Factor - Test
		/// </summary>
		/// <param name="inputValue"></param>
		/// <param name="expectedValue"></param>
		[Test]
		[TestCase(1, 0)]
		[TestCase(2, 0.8)]
		[TestCase(3, 2.4)]
		[TestCase(4, 6.4)]
		[TestCase(5, 10)]
		public void Test_CalculateDiscountFactor(int inputValue, double expectedValue)
		{
			//Arrange
			BookStore bookStore = new BookStore();
			//Act
			double actualResult = bookStore.CalculateDiscountFactor(inputValue);
			//Assert
			Assert.AreEqual(expectedValue, Math.Round(actualResult, 2));
		}

		/// <summary>
		/// Get Discounted Price - Test
		/// </summary>
		/// <param name="inputValue"></param>
		/// <param name="expectedValue"></param>
		[Test]
		[TestCase((new int[] { 2, 2, 2, 1, 1 }), 51.60)]
		[TestCase((new int[] { 1, 1, 2}), 29.60)]

		[TestCase((new int[] { }), 0)]
		[TestCase((new int[] { 1}), 8)]
		[TestCase((new int[] { 1, 1}), 15.2)]
		[TestCase((new int[] { 1, 1 ,1}), 21.6)]
		[TestCase((new int[] { 1, 1, 1 ,1}), 25.6)]
		[TestCase((new int[] { 1, 1, 1, 1 ,1}), 30)]

		[TestCase((new int[] {10}),80)]
		[TestCase((new int[] { 100}), 800)]
		[TestCase((new int[] { 500,100,50,25,15}), 5206)]
		
		public void Test_GetDiscountedPrice(int[] inputValue, double expectedValue)
		{
			//Arrange
			BookStore bookStore = new BookStore();
			//Act
			double actualResult = bookStore.GetDiscountedPrice(new List<int>(inputValue)); 
			//Assert
			Assert.AreEqual(expectedValue, Math.Round(actualResult, 2));
		}		
	}
}
