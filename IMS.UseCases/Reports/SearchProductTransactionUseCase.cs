using IMS.CoreBussiness.Entities;
using IMS.CoreBussiness.Enums;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Reports.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Reports
{
    public class SearchProductTransactionUseCase : ISearchProductTransactionUseCase
    {
        private readonly IProductTransactionRepository _productTransactionRespository;
        public SearchProductTransactionUseCase(IProductTransactionRepository productTransactionRespository)
        {
            _productTransactionRespository = productTransactionRespository;
        }
        public async Task<IEnumerable<ProductTransaction>> ExeuteAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionTYpe)
        {
            if (dateTo.HasValue) dateTo = dateTo.Value.AddDays(1);
            return await _productTransactionRespository.GetProductTranscationAsync(productName, dateFrom, dateTo, transactionTYpe);
        }
    }
}
