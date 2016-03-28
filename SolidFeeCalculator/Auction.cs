namespace SolidFeeCalculator
{
	using System;

	/// <summary>
	/// The auction advertisement type.
	/// </summary>
	public sealed class Auction:IAd
	{
		private readonly int price;
		private readonly DateTime expiryDate;

		private Auction(int price, DateTime expiryDate)
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
			
			public Auction EndsOn(DateTime expiryDate){
				return new Auction(price,expiryDate);
			}
			
			public Auction EndsOn5Days(){
				return EndsOn(DateTime.Now.AddDays(5));
			}
		}
	}
}
