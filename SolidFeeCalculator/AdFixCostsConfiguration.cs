namespace SolidFeeCalculator
{
	using System;

	public class AdFixCostsConfiguration
	{
		private readonly int auctionFixCost;
		private readonly int buyNowfixCost;

		public AdFixCostsConfiguration(
			
			int auctionFixCost,
			int buyNowfixCost)
		{
			
			if (auctionFixCost < 0) {
				throw new ArgumentException("auction fix cost cannot be negative", "auctionFixCost");
			}
			
			if (buyNowfixCost<0){
				throw new ArgumentException("buy now fix cost cannot be negative", "buyNowfixCost");
			}
		
			this.auctionFixCost = auctionFixCost;
			this.buyNowfixCost=buyNowfixCost;
		}

		public int BuyNowfixCost {
			get {
				return buyNowfixCost;
			}
		}
		
		public int AuctionFixCost {
			get{ return auctionFixCost; }
		}
		
		public static Builder New(){
			return new Builder();
		}
		
		
		public sealed class Builder
		{
			private int auctionFixCost;
			public Builder AuctionFixCost(int value)
			{
				auctionFixCost = value;
				return this;
			}
			
			private int buyNowfixCost;
			public Builder BuyNowfixCost(int value){
				buyNowfixCost=value;
				return this;
			}
			
			public AdFixCostsConfiguration Build()
			{
				return new AdFixCostsConfiguration(
					auctionFixCost,
					buyNowfixCost);
			}
		}
	}
}
