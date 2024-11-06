using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using UseCases.CategoriesUseCases;
using UseCases.CategoriesUseCases.DataStorePluginsInterfaces;
using UseCases.Interfaces;
using UseCases.ProductsUseCases;
using UseCases.TransactionUseCases;
using Microsoft.AspNetCore.Identity;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AccountContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("MarketManagement")); });
builder.Services.AddDbContext<MarketContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("MarketManagement")); });

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();

builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("Inventory", p => p.RequireClaim("Position", "Inventory"));
	options.AddPolicy("Cashier", p => p.RequireClaim("Position", "Cashier"));
});

if (builder.Environment.IsEnvironment("QA"))
{
	builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
	builder.Services.AddSingleton<IProductRepository, ProductsInMemoryRepository>();
	builder.Services.AddSingleton<ITransactionRepository, TransactionInMemoryRepository>();
}
else
{
builder.Services.AddTransient<ICategoryRepository,CategorySQLRepository>();
builder.Services.AddTransient<IProductRepository, ProductSQLRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionSQLRepository>();
}

builder.Services.AddTransient<IViewCategoriesUseCase,ViewCategoriesUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase,AddCategoryUseCase>();
builder.Services.AddTransient<IViewSelectedCategoryUseCase,ViewSelectedCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase,EditCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase,DeleteCategoryUseCase>();

builder.Services.AddTransient<IAddProductUseCase,AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase,EditProductUseCase>();
builder.Services.AddTransient<IDeleteProduct, DeleteProduct>();
builder.Services.AddTransient<IViewProductInCategoryUseCase,ViewProductInCategoryUseCase>();
builder.Services.AddTransient<IViewProductsUseCase,ViewProductsUseCase>();
builder.Services.AddTransient<IViewSelectedProductUseCase,ViewSelectedProductUseCase>();

builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();
builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<ISearchTransactionUseCase, SearchTransactionUseCase>();
builder.Services.AddTransient<IGetTodayTransactionUseCase, GetTodayTransactionUseCase>();



var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    ) ;

app.Run();
