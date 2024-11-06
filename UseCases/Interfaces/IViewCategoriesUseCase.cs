using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}