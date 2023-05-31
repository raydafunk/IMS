﻿using IMS.CoreBussiness.Entities;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        Task ProduceProductAsync(string productionNumber, Product product, int quantity, string doneby);
    }
}