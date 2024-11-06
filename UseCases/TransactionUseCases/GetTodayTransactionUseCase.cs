using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.TransactionUseCases
{
	public class GetTodayTransactionUseCase : IGetTodayTransactionUseCase
	{
		private readonly ITransactionRepository transactionRepository;

		public GetTodayTransactionUseCase(ITransactionRepository transactionRepository)
		{
			this.transactionRepository = transactionRepository;
		}
		public IEnumerable<Transaction> Execute(string cashierName)
		{
			return transactionRepository.GetByDayAndCashier(cashierName, DateTime.Now);
		}
	}
}
