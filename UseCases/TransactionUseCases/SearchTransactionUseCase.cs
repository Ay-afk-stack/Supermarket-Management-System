using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.TransactionUseCases
{
	public class SearchTransactionUseCase : ISearchTransactionUseCase
	{
		private readonly ITransactionRepository transactionRepository;

		public SearchTransactionUseCase(ITransactionRepository transactionRepository)
		{
			this.transactionRepository = transactionRepository;
		}

		public IEnumerable<Transaction> Execute(
			string cashierName,
			DateTime startDate,
			DateTime endDate
			)
		{
			return transactionRepository.Search(cashierName, startDate, endDate);
		}
	}
}
