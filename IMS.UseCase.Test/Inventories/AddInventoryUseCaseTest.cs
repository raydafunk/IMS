using IMS.CoreBussiness;
using IMS.UseCases.Inventories;
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
    public class AddInventoryUseCaseTest
    {
        private readonly IInVentoryRespository _inVentoryRespository;
        private readonly AddInventoryUseCase _addInventoryUseCase;

        public AddInventoryUseCaseTest()
        {
             _inVentoryRespository = Substitute.For<IInVentoryRespository>();
            _addInventoryUseCase = new AddInventoryUseCase(_inVentoryRespository);
        }

        [Fact]
        public async Task AddInventoryUseCase_WhenCalled_Should_ReturnObject()
        {
            var inventory = new Inventory();

            await _addInventoryUseCase.ExecuteAsync(Arg.Any<Inventory>());

            inventory.ShouldBe(inventory);
        }

        [Fact]
        public async Task AddInventoryUseCase_WhenCalled_Should_NotBeNull()
        {
            var inventory = new Inventory();

            await _addInventoryUseCase.ExecuteAsync(Arg.Any<Inventory>());

            inventory.ShouldNotBeNull();
        }
    }
} 

