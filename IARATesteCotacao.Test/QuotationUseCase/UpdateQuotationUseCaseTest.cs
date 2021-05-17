using IARATesteCotacao.Business.QuotationsArea.UseCases.AddQuotation;
using IARATesteCotacao.Business.QuotationsArea.UseCases.UpdateQuotation;
using IARATesteCotacao.Business.Services.Locality;
using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IARATesteCotacao.Test.QuotationUseCase
{
    public class UpdateQuotationUseCaseTest
    {
        [Fact]
        public async void Update_Quotation_All_Fields()
        {
            var localityService = new Mock<ILocalityService>();
            var quotationRepo = new Mock<IQuotationRepository>();
            var quotatioTest = new Quotation("04568321000189",
                "07123456000316",
                DateTime.Now,
                DateTime.Now.AddDays(5),
                "66789000",
                "Av Filadelfia",
                string.Empty,
                "Centro",
                "MA",
                string.Empty, new List<ItensQuotation>() { new ItensQuotation(1, 10, 123, 0, 10, "BLAZ", "UND") });

            //localityService.Setup(x => x.GetByCep(It.IsAny<string>())).Returns(Task.FromResult(new LocalityAddress()));
            quotationRepo.Setup(x => x.GetByIdAsync(It.IsAny<long>())).Returns(Task.FromResult(quotatioTest));
            quotationRepo.Setup(x => x.UpdateAsync(It.IsAny<Quotation>())).Returns(Task.FromResult(quotatioTest));
            var handler = new UpdateQuotationHandler(quotationRepo.Object, localityService.Object);
            var result = (ApiResult<Quotation>)await handler.Handle(new UpdateQuotationCommand
            {
                Id = 999,
                CnpjClient = "04568321000189",
                CnpjSeller = "07123456000316",
                DateStart = DateTime.Now,
                DateLimit = DateTime.Now.AddDays(5),
                Address = "Av Filadelfia",
                ComplementAddress = string.Empty,
                Comments = string.Empty,
                District = "Areias",
                State = "MA",
                ZipCode = "66789000",
                ItensQuotation = new List<ItemQuotationCommand>() { new ItemQuotationCommand{ ItemNumber = 1,
                    QuotationId = 10,
                    ProductId = 123,
                    Price = 0,
                    Quantity = 10,
                    Manufacturer = "BLAZ",
                    Unit = "UND" } }
            }, It.IsAny<CancellationToken>());

            Assert.Equal(quotatioTest.CnpjSeller, result.Data.CnpjSeller);
            Assert.Equal(quotatioTest.CnpjClient, result.Data.CnpjClient);
            Assert.Equal(quotatioTest.DateStart, result.Data.DateStart);
            Assert.Equal(quotatioTest.DateLimit, result.Data.DateLimit);
            Assert.Equal(quotatioTest.Address, result.Data.Address);
            Assert.Equal(quotatioTest.ComplementAddress, result.Data.ComplementAddress);
            Assert.Equal(quotatioTest.Comments, result.Data.Comments);
            Assert.Equal(quotatioTest.District, result.Data.District);
            Assert.Equal(quotatioTest.State, result.Data.State);
            Assert.Equal(quotatioTest.ZipCode, result.Data.ZipCode);
            Assert.Equal(quotatioTest.ItensQuotation.Count, result.Data.ItensQuotation.Count);

        }
    }
}
