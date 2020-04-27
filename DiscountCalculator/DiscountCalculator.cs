using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCalculator
{
	public class BookStore
	{
		const double BASEPRICE = 8.0;	
		public double GetDiscount(List<int> bookList)//change casing
		{
			double total = 0;
			while (bookList.Count != 0)//checking till discount of all set of books are calculated
			{
				int max = bookList.Count;// assigning count of book sets				
				int leastValue = bookList.Min();
				for (int i = 0; i < max; i++)
				{
					bookList[i] = bookList[i] - leastValue;
				}		
				total += leastValue * ((BASEPRICE * max ) - CalculateDiscountFactor(max)); //calculating discount for each set		
				bookList.RemoveAll(x => x == 0);				
			}
			return total;
		}
		public double CalculateDiscountFactor(int setCount)
		{			
			double discountFactor = 0;
			switch (setCount)
			{
				case 1: discountFactor = 0;
					break;
				case 2:
					discountFactor = .05;
					break;
				case 3:
					discountFactor = .1;
					break;
				case 4:
					discountFactor = .2;
					break;
				case 5:
					discountFactor = .25;
					break;
			}
			return (setCount * BASEPRICE )* discountFactor;
		}
		static void Main(string[] args)
		{
			BookStore bookStore = new BookStore();
			List<int> userInputList = new List<int>();
			for (int i = 1; i <= 5; i++)
			{
				Console.WriteLine("Enter Count of Type" + i + ": ");
				//if (Convert.ToInt32(Console.ReadLine()) > 0)
				userInputList.Add(Convert.ToInt32(Console.ReadLine()));				
			}
			Console.WriteLine("Result: "+bookStore.GetDiscount(userInputList));
			Console.ReadLine();
		}		
	}	
}
