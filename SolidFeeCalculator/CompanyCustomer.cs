namespace SolidFeeCalculator
{
	using System;
	
	/// <summary>
	/// Description of CompanyCustomer.
	/// </summary>
	public class CompanyCustomer:ICustomer
	{
		/// <summary>
		/// Use when an instance of company customer is
		/// needed but not which customer in particular
		/// </summary>
		public static readonly CompanyCustomer Null=new CompanyCustomer();
		
		private CompanyCustomer()
		{}

		public T Accept<T>(ICustomerVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
