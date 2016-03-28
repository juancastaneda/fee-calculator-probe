
using System;

namespace SolidFeeCalculator
{
	/// <summary>
	/// Description of ICustomer.
	/// </summary>
	public interface ICustomer
	{
		T Accept<T>(ICustomerVisitor<T> visitor);
	}
}
