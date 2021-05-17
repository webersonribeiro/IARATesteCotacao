using IARATesteCotacao.Business.ProductsArea.UseCases.UpdateProduct;
using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IARATesteCotacao.Test.ProductUseCase
{
    public class UpdateProductUseCaseTest
    {
        [Fact]
        public async void Update_Product_All_Fields()
        {
            var productRepo = new Mock<IProductRepository>();
            var productTest = new Product("Manga P", true);
            productRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(productTest));
            productRepo.Setup(x => x.UpdateAsync(It.IsAny<Product>())).Returns(Task.FromResult(productTest));
            var handler = new UpdateProductHandler(productRepo.Object);
            var result = (ApiResult<Product>)await handler.Handle(new UpdateProductCommand { Id=1, Name = "Manga P", Status = true }, It.IsAny<CancellationToken>());

            Assert.Equal(productTest.Name, result.Data.Name);
            Assert.Equal(productTest.Status, result.Data.Status);
        }

        [Fact]
        public async void Update_Product_Fields_Empty()
        {
            var productRepo = new Mock<IProductRepository>();            
            var handler = new UpdateProductHandler(productRepo.Object);
            var result = await handler.Handle(new UpdateProductCommand { Id = 1, Name = string.Empty, Status = true }, It.IsAny<CancellationToken>());
            Assert.False(result.IsSuccess);
        }
    }
}
