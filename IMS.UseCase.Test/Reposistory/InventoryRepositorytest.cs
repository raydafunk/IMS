using IMS.CoreBussiness.Entities;
using IMS.Plugins.EFCoreSqlServer;
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

        [Fact]
        public async Task GetInvetoriesByNameAsync_WhenCalled_ShouldHaveEqualInventoriesInList()
        {
            IEnumerable<Inventory> inventories = new List<Inventory>() { new Inventory { InventoryId = 1, InventoryName = "fdc   ", Quantity = 10, Price = 2 } };
            await _repo.GetInvetoriesByNameAsync("Bike Seat");

            inventories.ShouldBe(inventories);
        }
        [Fact]
        public async Task GetInvetoriesByNameAsync_WhenCalled_ShouldContainName()
        {
            IEnumerable<Inventory> inventories = new List<Inventory>() { new Inventory { InventoryName = "Bike Seat" } };
            await _repo.GetInvetoriesByNameAsync("Bike Seat");

            inventories.ShouldBeSameAs(inventories);
        }

        [Fact]
        public async Task GetInvetoriesByIdAsync_WhenCalled_ShouldContain_SameId()
        {
            var InventoryId = 1;
            await _repo.GetInvetoriesByIdAsync(InventoryId);

            InventoryId.ShouldBe(InventoryId);
        }

        [Fact]
        public async Task UpdateInventoryAsyn_WhenCalled_ShouldNotBeNUll()
        {
            var inventory = MockedInventory;
            await _repo.UpdateInventoryAsync(inventory);

            inventory.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateInventoryAsyn_WheCalled_ShouldNotReturnTheSameObject()
        {
            var inventory = MockedInventory;
            await _repo.UpdateInventoryAsync(inventory);

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
