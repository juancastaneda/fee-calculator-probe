namespace SolidFeeCalculator
{
	using System;

	/// <summary>
	/// Description of ConfigFixCostsCalculator.
	/// </summary>
	public class ConfigFixCostsCalculator:IAdVisitor<int>
	{
		private readonly AdFixCostsConfiguration config;
		public ConfigFixCostsCalculator(AdFixCostsConfiguration config)
		{
			if (config==null){
				throw new ArgumentNullException("config");
			}
			
			this.config=config;
		}


		public int Visit(Auction ad)
		{
			return config.AuctionFixCost;
		}

		public int Visit(BuyNow ad)
		{
			return config.BuyNowfixCost;
		}
	}
}
