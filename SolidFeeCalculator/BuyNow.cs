namespace SolidFeeCalculator
{	using System;

	/// <summary>
	/// The buy now advertisement type.
	/// </summary>
	public sealed class BuyNow:IAd
	{
		private readonly int price;
		private readonly DateTime expiryDate;

		private BuyNow(int price, DateTime expiryDate)
		{
			this.price = price;
			this.expiryDate=expiryDate;
		}

		public DateTime ExpiryDate {
			get {
				return expiryDate;
			}
		}
		
		public int Price{ get { return price; } }
		
		public T Accept<T>(IAdVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
		
		public static Builder WithPrice(int value){
			return new Builder(value);
		}
		
		public sealed class Builder{
			private readonly int price;
			public Builder(int price)
			{
				this.price=price;
			}
			
			public BuyNow EndsOn(DateTime expiryDate){
				return new BuyNow(price,expiryDate);
			}
			
			public BuyNow EndsOn3Days(){
				return EndsOn(DateTime.Now.AddDays(3));
			}
		}
	}

}
