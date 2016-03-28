namespace SolidFeeCalculator
{
	using System;

	/// <summary>
	/// Description of AdDiscountCalculator.
	/// </summary>
	public class ConfigAdDiscountCalculator
	{
		private readonly ICustomerVisitor<int> customerDiscountCalculator;
		private readonly AdDiscountConfiguration config;
		
		public ConfigAdDiscountCalculator(AdDiscountConfiguration config)
		{
			if (config==null){
				throw new ArgumentNullException("config");
			}
			this.config=config;
			customerDiscountCalculator=new ConfigCustomerDiscountCalculator(config);
		}
		
		public int GetDiscount(FeeCalculationParameters feeParameters){
			if (feeParameters==null){
				throw new ArgumentNullException("feeParameters");
			}if (feeParameters.Customer==null){
				throw new ArgumentException("requires a customer");
			}
			
			var discount=feeParameters.Customer.Accept( customerDiscountCalculator);
			if (feeParameters.ToStartShowingOn.Date==feeParameters.Ad.ExpiryDate.Date){
				discount+=config.BeforeExpiryDateDiscount;
			}
			
			return discount;
		}
	}
}
