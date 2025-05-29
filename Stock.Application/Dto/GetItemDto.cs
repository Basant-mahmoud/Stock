using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Stock.Stock.Application.Dto
{
    public class GetItemDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
    }
}
