using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCalculator
{
	public class BookStore
	{
		const double BASE_PRICE = 8.0;	
		/// <summary>
		/// Calculate discounted price for books
		/// </summary>
		/// <param name="bookList"></param>
		/// <returns></returns>
		public double GetDiscountedPrice(List<int> bookList)
		{
			double total = 0;
			while (bookList.Count != 0)//check if any book sets remaining for discount calculation
			{
				int max = bookList.Count;// assign count of book sets				
				int leastValue = bookList.Min(); // get minimum value out of the set
				for (int i = 0; i < max; i++) 
				{
					bookList[i] = bookList[i] - leastValue; // reduce minimum value from each set
				}		
				total += leastValue * ((BASE_PRICE * max ) - CalculateDiscountFactor(max)); // calculate total value after discount
				bookList.RemoveAll(x => x == 0);	// Remove the 0 values to get the remaining different set of books			
			}
			return total;
		}
		/// <summary>
		/// Calculating discount 
		/// </summary>
		/// <param name="setCount"></param>
		/// <returns></returns>
		public double CalculateDiscountFactor(int setCount)
		{			
			double discountFactor = 0;
			switch (setCount)
			{
				case 1: discountFactor = 0; // no discount
					break;
				case 2:
					discountFactor = .05; // 5% discount
					break;
				case 3:
					discountFactor = .1; // 10% discount
					break;
				case 4:
					discountFactor = .2; // 20% discount
					break;
				case 5:
					discountFactor = .25; // 25% discount
					break;
			}
			return (setCount * BASE_PRICE )* discountFactor;
		}
		static void Main(string[] args)
		{
			List<int> userInputList = new List<int>();
			for (int i = 1; i <= 5; i++) // 5 different type of books
			{
				Console.WriteLine("Enter Count of Type" + i + " : "); // Enter count of books for each type			
				userInputList.Add(Convert.ToInt32(Console.ReadLine()));				
			}
			Console.WriteLine("Result: "+ new BookStore().GetDiscountedPrice(userInputList));
			Console.ReadLine();
		}		
	}	
}
