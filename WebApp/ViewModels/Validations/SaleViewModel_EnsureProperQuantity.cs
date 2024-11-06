using System.ComponentModel.DataAnnotations;
using UseCases.ProductsUseCases;

namespace WebApp.ViewModels.Validations
{
	public class SaleViewModel_EnsureProperQuantity:ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var saleViewModel=validationContext.ObjectInstance as SaleViewModel;
			if (saleViewModel != null)
			{
				if (saleViewModel.QuantityToSell <= 0)
				{
					return new ValidationResult($"The quantity to sell must be greater than 0.");
				}
				else
				{
					var getProductByIdUseCase=validationContext.GetService(typeof(IViewSelectedProductUseCase)) as IViewSelectedProductUseCase;
					if(getProductByIdUseCase != null)
					{
						var product= getProductByIdUseCase.Execute(saleViewModel.SelectedProductId);
						if (product != null)
						{
							if(product.Quantity < saleViewModel.QuantityToSell) 
							{
								return new ValidationResult($"{product.Name} have only {product.Quantity} left.");
							}
						}
						else
						{
							return new ValidationResult("Selected Product doesnt exist");
						}
					}
				}
			}
			return ValidationResult.Success;
		}
	}
}
