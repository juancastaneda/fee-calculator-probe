namespace SolidFeeCalculator
{
	using System;

	/// <summary>
	/// Describes what an advertisement for
	/// fee calculation is
	/// </summary>
	public class FeeCalculationParameters
	{
		private readonly		IAd ad;
		private readonly		ICustomer customer;
		private readonly DateTime toStartShowingOn;
		
		public FeeCalculationParameters(
			IAd ad,
			DateTime toStartShowingOn,
			ICustomer customer)
		{
			if (ad == null) {
				throw new ArgumentNullException("ad");
			}
			if (customer == null) {
				throw new ArgumentNullException("customer");
			}
			
			if (toStartShowingOn==new DateTime()){
				throw new ArgumentException("Please provide a date. Default cannot be used");
			}
			
			this.ad = ad;
			this.customer = customer;
			this.toStartShowingOn=toStartShowingOn;
		}

		public ICustomer Customer {
			get {
				return customer;
			}
		}

		public DateTime ToStartShowingOn {
			get {
				return toStartShowingOn;
			}
		}

		public IAd Ad {
			get {
				return ad;
			}
		}
		public static Builder OfType(IAd ad)
		{
			return new Builder(ad);
		}
		
		public sealed class Builder
		{
			private readonly IAd ad;
			private DateTime adEndsOn;
			public Builder(IAd ad)
			{
				this.ad = ad;
			}
			
			public Builder ToStartShowing(DateTime value){
				adEndsOn=value;
				return this;
			}
			
			public Builder ToStartShowingToday(){
				return ToStartShowing(DateTime.Now);
			}
			
			public FeeCalculationParameters ForPrivateCustomer()
			{
				return new FeeCalculationParameters(ad, adEndsOn,PrivateCustomer.Null);
			}
			
			public FeeCalculationParameters ForCompanyCustomer()
			{
				return new FeeCalculationParameters(ad,adEndsOn, CompanyCustomer.Null);
			}
		}
	}
}
