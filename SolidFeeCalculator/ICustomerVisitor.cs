namespace SolidFeeCalculator
{
	public interface ICustomerVisitor<T>
	{
		T Visit(PrivateCustomer customer);
		T Visit(CompanyCustomer customer);
	}
}
