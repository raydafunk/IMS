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
    public class ViewInventoriesByNameUserCaseTest
    {
        private readonly IInVentoryRespository _inVentoryRespository;
        private readonly ViewInventoriesByNameUserCase _viewInventoriesbyNameCase;

        public ViewInventoriesByNameUserCaseTest()
        {
            _inVentoryRespository = Substitute.For<IInVentoryRespository>();
            _viewInventoriesbyNameCase = new ViewInventoriesByNameUserCase(_inVentoryRespository);


        }

        [Fact]
        public async Task GetInvetoriesByNameAsync_WhenCalled_Should_ReturnObject()
        {
            var inventory = new Inventory() { InventoryName =" Bike Body"};

            await _viewInventoriesbyNameCase.ExecuteAsync("Bike Body");

            inventory.ShouldBe(inventory);
        }

        [Fact]
        public async Task AddInventoryUseCase_WhenCalled_Should_NotBeNull()
        {
            var inventory = new Inventory();

            await _viewInventoriesbyNameCase.ExecuteAsync("Bike Body");

            inventory.ShouldNotBeNull();
        }
    }
}
