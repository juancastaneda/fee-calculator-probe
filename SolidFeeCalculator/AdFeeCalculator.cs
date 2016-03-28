namespace SolidFeeCalculator
{
	using System;

	public class AdFeeCalculator
	{
		private readonly IAdVisitor<int> fixCostsCalculator;
		private readonly ConfigAdDiscountCalculator discountCalculator;
		
		public AdFeeCalculator(
			AdDiscountConfiguration discountConfig,
			AdFixCostsConfiguration fixCostsConfig)
		{			
			fixCostsCalculator=new ConfigFixCostsCalculator(fixCostsConfig);
			discountCalculator=new ConfigAdDiscountCalculator(discountConfig);
		}

		public int CalculateFee(FeeCalculationParameters parameters)
		{
			if (parameters == null) {
				throw new ArgumentNullException("parameters");
			}
			
			if (parameters.Ad==null){
				throw new ArgumentException("missing adtype","parameters");
			}
			
			var discount=discountCalculator.GetDiscount(parameters);			
			var adFixCost=parameters.Ad.Accept<int>(fixCostsCalculator);
			return parameters.Ad.Price+adFixCost-discount;
		}
	}
}