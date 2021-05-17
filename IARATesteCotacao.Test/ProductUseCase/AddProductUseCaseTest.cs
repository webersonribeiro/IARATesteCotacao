using IARATesteCotacao.Business.ProductsArea.UseCases.AddProduct;
using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IARATesteCotacao.Test.ProductUseCase
{
    public class AddProductUseCaseTest
    {
        [Fact]
        public async void Create_New_Product_All_Fields()
        {
            var productRepo = new Mock<IProductRepository>();
            var productTest = new Product("Manga Palmer", true);
            productRepo.Setup(x => x.AddAsync(It.IsAny<Product>())).Returns(Task.FromResult(productTest));
            var handler = new AddProductHandler(productRepo.Object);
            var result = (ApiResult<Product>)await handler.Handle(new AddProductCommand { Name = "Manga Palmer", Status = true }, It.IsAny<CancellationToken>());

            Assert.Equal(productTest.Name, result.Data.Name);
            Assert.Equal(productTest.Status, result.Data.Status);
        }

        [Fact]
        public async void Create_New_Product_Fields_Empty()
        {
            var productRepo = new Mock<IProductRepository>();            
            var handler = new AddProductHandler(productRepo.Object);
            var result = await handler.Handle(new AddProductCommand { Name = string.Empty, Status = true }, It.IsAny<CancellationToken>());
            Assert.False(result.IsSuccess);            
        }
    }
}
