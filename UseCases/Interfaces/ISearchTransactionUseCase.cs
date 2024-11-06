using CoreBusiness;

namespace UseCases.TransactionUseCases
{
	public interface ISearchTransactionUseCase
	{
		IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
	}
}