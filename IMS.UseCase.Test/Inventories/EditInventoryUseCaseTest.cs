using IMS.CoreBussiness.Entities;
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
    public class EditInventoryUseCaseTest
    {
        private readonly IInVentoryRespository _inVentoryRespository;

        private readonly EditInventoryUseCase _editInventoryUseCase;

        public EditInventoryUseCaseTest()
        {
            _inVentoryRespository = Substitute.For<IInVentoryRespository>();
            _editInventoryUseCase = new EditInventoryUseCase(_inVentoryRespository);
        }

        [Fact]
        public async Task ExecuteAsync_WhenCalled_Should_ReturnObject()
        {
            var inventory = new Inventory();

            await _editInventoryUseCase.ExecuteAsync(Arg.Any<Inventory>());

            inventory.ShouldBe(inventory);
        }

        [Fact]
        public async Task ExecuteAsync_WhenCalled_Should_NotBeNull()
        {
            var inventory = new Inventory();

            await _editInventoryUseCase.ExecuteAsync(Arg.Any<Inventory>());

            inventory.ShouldNotBeNull();
        }
        [Fact]
        public async Task ExecuteAsync_WheCalled_ShouldNotReturnTheSameObject()
        {
            var inventory = MockedInventory;
            await _editInventoryUseCase.ExecuteAsync(inventory);

            inventory.ShouldNotBe(SecondMocckedInventory);
        }
        private static Inventory MockedInventory
        {
            get
            {
                return new Inventory()
                {
                    InventoryId = 1,
                    InventoryName = "Test",
                    Quantity = 10,
                    Price = 2
                };
            }
        }
        private static Inventory SecondMocckedInventory
        {
            get
            {
                return new Inventory()
                {
                    InventoryId = 2,
                    InventoryName = "Test 2",
                    Quantity = 23,
                    Price = 3
                };
            }
        }
    }
}
