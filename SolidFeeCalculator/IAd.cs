namespace SolidFeeCalculator
{
	using System;

	public interface IAd
	{
		DateTime ExpiryDate { get; }
		int Price{ get; }
		T Accept<T>(IAdVisitor<T> visitor);
	}
}
