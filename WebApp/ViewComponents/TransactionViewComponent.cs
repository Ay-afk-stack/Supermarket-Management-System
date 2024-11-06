using Microsoft.AspNetCore.Mvc;
using UseCases.TransactionUseCases;
using WebApp.Models;

namespace WebApp.ViewComponents
{
	[ViewComponent]
	public class TransactionViewComponent:ViewComponent
	{
		private readonly IGetTodayTransactionUseCase getTodayTransactionUseCase;

		public TransactionViewComponent(IGetTodayTransactionUseCase getTodayTransactionUseCase)
		{
			this.getTodayTransactionUseCase = getTodayTransactionUseCase;
		}
		public IViewComponentResult Invoke(string userName)
		{
			var transactions=getTodayTransactionUseCase.Execute(userName);
			return View(transactions);
		}
	}
}
