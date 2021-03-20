using application.Catalog.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
