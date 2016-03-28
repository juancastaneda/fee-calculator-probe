namespace SolidFeeCalculator
{
	using System;
	
	public class AdDiscountConfiguration
	{
		private readonly int companyDiscount;
		private readonly int beforeExpiryDateDiscount;
		
		private AdDiscountConfiguration(
			int companyDiscount,
			int beforeExpiryDateDiscount)
		{
			
			if (companyDiscount<0){
				throw new ArgumentException("company discount cannot be negative", "companyDiscount");
			}
			
			if (companyDiscount<0){
				throw new ArgumentException("discount for soon expire cannot be negative", "beforeExpiryDateDiscount");
			}
			
			this.companyDiscount=companyDiscount;
			this.beforeExpiryDateDiscount=beforeExpiryDateDiscount;
			
		}

		public int BeforeExpiryDateDiscount {
			get {
				return beforeExpiryDateDiscount;
			}
		}
		public int CompanyDiscount {
			get {
				return companyDiscount;
			}
		}
		public static Builder New(){
			return new Builder();
		}
		
		public sealed class Builder
		{
			private int companyDiscount;
			public Builder CompanyDiscount(int value){
				companyDiscount=value;
				return this;
			}
			
			private int beforeExpiryDateDiscount;
			public Builder BeforeExpiryDateDiscount(int value){
				beforeExpiryDateDiscount=value;
				return this;
			}
			
			public AdDiscountConfiguration Build()
			{
				return new AdDiscountConfiguration(
					companyDiscount,
					beforeExpiryDateDiscount);
			}
		}
	}
}
