using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.TransactionUseCases;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
	[Authorize]
	public class TransactionsController : Controller
	{
		private readonly ISearchTransactionUseCase searchTransactionUseCase;

		public TransactionsController(ISearchTransactionUseCase searchTransactionUseCase) 
		{
			this.searchTransactionUseCase = searchTransactionUseCase;
		}
		public IActionResult Index()
		{
		
			TransactionViewModel model =new TransactionViewModel();
			return View(model);
		}
		public IActionResult Search(TransactionViewModel transactionViewModel)
		{
			var model = searchTransactionUseCase.Execute(
				transactionViewModel.CashierName??string.Empty,
				transactionViewModel.StartDate,
				transactionViewModel.EndDate
				);
			transactionViewModel.Transactions = model;
			return View("Index",transactionViewModel);
		}

	}
}
