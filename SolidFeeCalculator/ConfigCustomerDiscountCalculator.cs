namespace SolidFeeCalculator
{
	using System;
	
	/// <summary>
	/// Description of ConfigCustomerDiscountCalculator.
	/// </summary>
	public class ConfigCustomerDiscountCalculator:ICustomerVisitor<int>
	{
		private readonly AdDiscountConfiguration config;
		
		public ConfigCustomerDiscountCalculator(AdDiscountConfiguration config)
		{
			if (config==null){
				throw new ArgumentNullException("config");
			}
			
			this.config=config;
		}

		public int Visit(PrivateCustomer customer)
		{
			return 0;
		}

		public int Visit(CompanyCustomer customer)
		{
			return config.CompanyDiscount;
		}
	}
}
