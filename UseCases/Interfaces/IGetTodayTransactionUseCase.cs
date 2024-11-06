using CoreBusiness;

namespace UseCases.TransactionUseCases
{
	public interface IGetTodayTransactionUseCase
	{
		IEnumerable<Transaction> Execute(string cashierName);
	}
}