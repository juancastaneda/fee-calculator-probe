
using System;

namespace SolidFeeCalculator
{
	/// <summary>
	/// Description of PrivateCustomer.
	/// </summary>
	public class PrivateCustomer:ICustomer
	{
		/// <summary>
		/// Use when an instance of private customer is
		/// needed but not which customer in particular
		/// </summary>
		public static readonly PrivateCustomer Null=new PrivateCustomer();
		
		private PrivateCustomer()
		{
		}

		public T Accept<T>(ICustomerVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
