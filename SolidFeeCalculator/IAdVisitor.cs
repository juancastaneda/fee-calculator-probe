namespace SolidFeeCalculator
{
	public interface IAdVisitor<T>
	{
		T Visit(Auction ad);
		T Visit(BuyNow ad);
	}
}
