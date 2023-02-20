using IMS.CoreBussiness;
using IMS.Plugins.InMemory;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IMS.UseCase.Test.Inventories
{
    public class InventoryRepositorytest
    {
        private readonly InventoryRepository _repo;

        public InventoryRepositorytest()
        {
            _repo = new InventoryRepository();
        }


        [Fact]
        public async Task AddInventoryAsync_WhenCalled_ShouldNotBeNUll()
        {
            var inventory = MockedInventory;

            await _repo.AddInventoryAsync(inventory);
            inventory.ShouldNotBeNull();

        }

        [Fact]
        public async Task AddInventoryAsync_WHenCalled_ShouldBeInventoryObject()
        {
            var inventory = MockedInventory;
            await _repo.AddInventoryAsync(inventory);

            inventory.ShouldBe(inventory);
        }

        [Fact]
        public async Task AddIventoryAsync_WhenCalled_ThesecodOBjectisEqual()
        {
            var inventory = SecondMocckedInventory;
            await _repo.AddInventoryAsync(inventory);

            inventory.ShouldBe(inventory);
        }
        [Fact]
        public async Task AddIventoryAsync_WhenCalled_ThesecodOBjectIsNotNull()
        {
            var inventory = SecondMocckedInventory;
            await _repo.AddInventoryAsync(inventory);

            inventory.ShouldBe(inventory);
        }
        [Fact]
        public async Task GetInvetoriesByNameAsync_WhenCalled_ShouldNot_NameObjectIsNotNull()
        {
            IEnumerable<Inventory> inventories= new List<Inventory>() { new Inventory { InventoryId = 1, InventoryName = "fdc   ", Quantity = 10, Price = 2 } };
            await _repo.GetInvetoriesByNameAsync("Bike Seat");

            inventories.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetInvetoriesByNameAsync_WhenCalled_ShouldHaveInventoriesInEnumerable()
        {
            IEnumerable<Inventory> inventories = new List<Inventory>() { new Inventory { InventoryId = 1, InventoryName = "fdc   ", Quantity = 10, Price = 2 } };
            await _repo.GetInvetoriesByNameAsync("Bike Seat");

            inventories.ShouldHaveSingleItem();
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
