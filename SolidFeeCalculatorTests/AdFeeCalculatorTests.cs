namespace SolidFeeCalculator
{
	using System;
	using NUnit.Framework;

	[TestFixture]
	public class AdFeeCalculatorTests
	{
		[TestCase(100)]
		[TestCase(250)]
		[TestCase(30)]
		public void Can_get_price_of_auction_without_discount_for_private(int adValue)
		{
			var auction = Auction.WithPrice(adValue).EndsOn5Days();
			var fixture = new Fixture()
				.SetupAuctionFixCost(0);
			var sut = fixture.CreateSUT();
			
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(auction).ToStartShowingToday().ForPrivateCustomer());
			
			Assert.AreEqual(adValue,actual,"calculated fee");
		}
		
		[TestCase(30)]
		[TestCase(60)]
		[TestCase(130)]
		public void Can_get_price_of_auction_with_fix_cost_for_private(int fixCost)
		{
			const int auctionCost=10;
			var auction = Auction.WithPrice(auctionCost).EndsOn5Days();
			var fixture = new Fixture()
				.SetupAuctionFixCost(fixCost);
			var sut = fixture.CreateSUT();
			
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(auction).ToStartShowingToday().ForPrivateCustomer());
			
			var expected=auctionCost+fixCost;
			Assert.AreEqual(expected,actual,"calculated fee");
		}
		
		[TestCase(100,20)]
		[TestCase(250,100)]
		[TestCase(30,10)]
		public void Can_get_price_of_auction_for_company_customers(int adValue,int companyDiscount)
		{
			var auction = Auction.WithPrice(adValue).EndsOn5Days();
			var fixture = new Fixture()
				.SetupAuctionFixCost(0)
				.SetupCompanyDiscount(companyDiscount);
			var sut = fixture.CreateSUT();
			
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(auction).ToStartShowingToday().ForCompanyCustomer());
			
			var expected=adValue-companyDiscount;
			Assert.AreEqual(expected,actual,"calculated fee");
		}
		
		[TestCase(30)]
		[TestCase(60)]
		[TestCase(130)]
		public void Can_get_price_of_auction_with_fix_cost_for_company(int fixCost)
		{
			const int auctionCost=100;
			const int discount=40;
			var auction = Auction.WithPrice(auctionCost).EndsOn5Days();
			var fixture = new Fixture()
				.SetupAuctionFixCost(fixCost)
				.SetupCompanyDiscount(discount);
			var sut = fixture.CreateSUT();
			
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(auction).ToStartShowingToday().ForCompanyCustomer());
			
			var expected=auctionCost+fixCost-discount;
			Assert.AreEqual(expected,actual,"calculated fee");
		}
		
		[TestCase(2)]
		[TestCase(4)]
		[TestCase(10)]
		public void Can_get_discount_on_auction_for_private_when_auction_ends_before(int expiryDay)
		{
			var expiryDate=new DateTime(2010,01,expiryDay);
			const int auctionPrice=10;
			const int expiryBeforeDiscount=5;
			var auction=Auction.WithPrice(auctionPrice).EndsOn(expiryDate);
			var fixture=new Fixture()
				.SetupAuctionFixCost(0)
				.SetupDiscountOnBeforeExpiryDate(expiryBeforeDiscount);
			var sut=fixture.CreateSUT();
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(auction).ToStartShowing(expiryDate).ForPrivateCustomer());
			
			var expected=auctionPrice-expiryBeforeDiscount;
			Assert.AreEqual(expected,actual,"calculated fee");
		}
		
		[TestCase(2)]
		[TestCase(4)]
		[TestCase(10)]
		public void Can_get_discount_on_auction_for_company_when_auction_ends_before(int expiryDay)
		{
			var expiryDate=new DateTime(2010,01,expiryDay);
			const int auctionPrice=10;
			const int expiryBeforeDiscount=5;
			const int companyDiscount=2;
			var auction=Auction.WithPrice(auctionPrice).EndsOn(expiryDate);
			var fixture=new Fixture()
				.SetupDiscountOnBeforeExpiryDate(expiryBeforeDiscount)
				.SetupCompanyDiscount(companyDiscount)
				.SetupAuctionFixCost(0)				;
			var sut=fixture.CreateSUT();
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(auction).ToStartShowing(expiryDate).ForCompanyCustomer());
			
			var expected=auctionPrice-expiryBeforeDiscount-companyDiscount;
			Assert.AreEqual(expected,actual,"calculated fee");
		}

		[TestCase(100)]
		[TestCase(250)]
		[TestCase(30)]
		public void Can_get_price_of_buynow_without_discount_for_private(int adValue)
		{
			var buyNow = BuyNow.WithPrice(adValue).EndsOn3Days();
			var fixture = new Fixture()
				.SetupBuyNowFixCost(0);
			var sut = fixture.CreateSUT();
			
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(buyNow).ToStartShowingToday().ForPrivateCustomer());
			
			Assert.AreEqual(adValue,actual,"calculated fee");
		}
		
		[TestCase(30)]
		[TestCase(60)]
		[TestCase(130)]
		public void Can_get_price_of_buynow_with_fix_cost_for_private(int fixCost)
		{
			const int buyNowCost=10;
			var buyNow = BuyNow.WithPrice(buyNowCost).EndsOn3Days();
			var fixture = new Fixture()
				.SetupBuyNowFixCost(fixCost);
			var sut = fixture.CreateSUT();
			
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(buyNow).ToStartShowingToday().ForPrivateCustomer());
			
			var expected=buyNowCost+fixCost;
			Assert.AreEqual(expected,actual,"calculated fee");
		}
		
		[TestCase(100,20)]
		[TestCase(250,100)]
		[TestCase(30,10)]
		public void Can_get_price_of_buynow_for_company_customers(int adValue,int companyDiscount)
		{
			var buyNow = BuyNow.WithPrice(adValue).EndsOn3Days();
			var fixture = new Fixture()
				.SetupBuyNowFixCost(0)
				.SetupCompanyDiscount(companyDiscount);
			var sut = fixture.CreateSUT();
			
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(buyNow).ToStartShowingToday().ForCompanyCustomer());
			
			var expected=adValue-companyDiscount;
			Assert.AreEqual(expected,actual,"calculated fee");
		}
		
		[TestCase(30)]
		[TestCase(60)]
		[TestCase(130)]
		public void Can_get_price_of_buynow_with_fix_cost_for_company(int fixCost)
		{
			const int buyNowCost=100;
			const int discount=40;
			var buyNow = BuyNow.WithPrice(buyNowCost).EndsOn3Days();
			var fixture = new Fixture()
				.SetupBuyNowFixCost(fixCost)
				.SetupCompanyDiscount(discount);
			var sut = fixture.CreateSUT();
			
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(buyNow).ToStartShowingToday().ForCompanyCustomer());
			
			var expected=buyNowCost+fixCost-discount;
			Assert.AreEqual(expected,actual,"calculated fee");
		}
		
		[TestCase(2)]
		[TestCase(4)]
		[TestCase(10)]
		public void Can_get_discount_on_buyNow_on_for_private_when_buyNow_ends_before(int expiryDay)
		{
			var expiryDate=new DateTime(2010,01,expiryDay);
			const int buyNowPrice=10;
			const int buyNowFixCost=20;
			const int expiryBeforeDiscount=5;
			var buyNow=BuyNow.WithPrice(buyNowPrice).EndsOn(expiryDate);
			var fixture=new Fixture()
				.SetupBuyNowFixCost(buyNowFixCost)
				.SetupDiscountOnBeforeExpiryDate(expiryBeforeDiscount);
			var sut=fixture.CreateSUT();
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(buyNow).ToStartShowing(expiryDate).ForPrivateCustomer());
			
			const int expected = buyNowFixCost + buyNowPrice - expiryBeforeDiscount;
			Assert.AreEqual(expected,actual,"calculated fee");
		}
		
		[TestCase(2)]
		[TestCase(4)]
		[TestCase(10)]
		public void Can_get_discount_on_buynow_for_company_when_buynow_ends_before(int expiryDay)
		{
			var expiryDate=new DateTime(2010,01,expiryDay);
			const int buyNowPrice=10;
			const int buyNowFixCost=20;
			const int expiryBeforeDiscount=5;
			const int companyDiscount=2;
			var buyNow=BuyNow.WithPrice(buyNowPrice).EndsOn(expiryDate);
			var fixture=new Fixture()
				.SetupDiscountOnBeforeExpiryDate(expiryBeforeDiscount)
				.SetupCompanyDiscount(companyDiscount)
				.SetupBuyNowFixCost(buyNowFixCost)				;
			var sut=fixture.CreateSUT();
			var actual = sut.CalculateFee(
				FeeCalculationParameters.OfType(buyNow).ToStartShowing(expiryDate).ForCompanyCustomer());
			
			const int expected = buyNowFixCost + buyNowPrice - expiryBeforeDiscount - companyDiscount;
			Assert.AreEqual(expected,actual,"calculated fee");
		}		
		
		
		private sealed class Fixture
		{
			private int auctionCost=1;
			private int companyDiscount=2;
			private int beforeExpiryDateDiscount=3;
			private int buyNowCost=4;
			
			public Fixture SetupCompanyDiscount(int value){
				companyDiscount=value;
				return this;
			}
			
			public Fixture SetupAuctionFixCost(int value){
				auctionCost=value;
				return this;
			}
			
			public Fixture SetupDiscountOnBeforeExpiryDate(int value){
				beforeExpiryDateDiscount=value;
				return this;
			}
			
			public Fixture SetupBuyNowFixCost(int value){
				buyNowCost=value;
				return this;
			}
			
			public AdFeeCalculator CreateSUT()
			{
				var discountConfig=AdDiscountConfiguration.New()
					.CompanyDiscount(companyDiscount)
					.BeforeExpiryDateDiscount(beforeExpiryDateDiscount)
					.Build();
				
				var fixCostConfig=AdFixCostsConfiguration.New()
					.AuctionFixCost(auctionCost)
					.BuyNowfixCost(buyNowCost)
					.Build();
				return new AdFeeCalculator(discountConfig,fixCostConfig);
			}
		}
	}
}
