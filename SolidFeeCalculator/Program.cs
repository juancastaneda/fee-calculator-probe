using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolidFeeCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
        	var costsConfig=AdFixCostsConfiguration.New()
        		.AuctionFixCost(25)
        		.BuyNowfixCost(35)
        		.Build();
        	var discountConfig=AdDiscountConfiguration.New()
        		.BeforeExpiryDateDiscount(10)
        		.CompanyDiscount(5)
        		.Build();
        	var calculator=new AdFeeCalculator(discountConfig,costsConfig);
        	var today=DateTime.Today;
        	var auction=Auction.WithPrice(100).EndsOn(today);
        	var calculationParameters=FeeCalculationParameters
        		.OfType(auction)
        		.ToStartShowingToday()
        		.ForCompanyCustomer();
        	var fee=calculator.CalculateFee(calculationParameters);
        	System.Console.WriteLine(
        		"Företags auktion {0} kostar {1} och slutar {2:d}",
        		auction.Price,
        		fee, 
        		auction.ExpiryDate);
        	var buyNow=BuyNow.WithPrice(100).EndsOn(today);
        	calculationParameters=FeeCalculationParameters
        		.OfType(buyNow)
        		.ToStartShowingToday()
        		.ForCompanyCustomer();
        	fee=calculator.CalculateFee(calculationParameters);
        	System.Console.WriteLine(
        		"Företags köp nu {0} kostar {1} och slutar {2:d}",
        		buyNow.Price,
        		fee, 
        		buyNow.ExpiryDate);
        	Console.ReadKey();
        
        }
    }
}
