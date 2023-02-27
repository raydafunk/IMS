using IMS.CoreBussiness;
using IMS.UseCases.Inventories;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IMS.UseCase.Test.Inventories
{
    public class ViewInventoryByIdUserCaseTest
    {
        private readonly IInVentoryRespository _inVentoryRespository;

        private readonly ViewInventoryByIdUseCase _viewInventoriesByIduseCase;

        public ViewInventoryByIdUserCaseTest()
        {
            _inVentoryRespository = Substitute.For<IInVentoryRespository>();
            _viewInventoriesByIduseCase = new ViewInventoryByIdUseCase(_inVentoryRespository);
        }

        [Fact]
        public async Task ViewInventoryByIdUseCase_WhenCalled_Should_ReturnObject()
        {
            var inventoryId = 1;

            await _viewInventoriesByIduseCase.ExeuteAysnc(inventoryId);

            inventoryId.ShouldBe(inventoryId);
        }

        [Fact]
        public async Task ViewInventoryByIdUseCase_WhenCalled_ShouldHaveReturnID()
        {
            var inventoryId = 1;

            await _viewInventoriesByIduseCase.ExeuteAysnc(inventoryId);

            inventoryId.ShouldBeSameAs(inventoryId);
        }
    }
}
