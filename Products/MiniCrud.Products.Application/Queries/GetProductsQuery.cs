using MediatR;
using MiniCrud.Products.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCrud.Products.Application.Queries
{
    public class GetProductsQuery : IRequest<ProductDTO>
    {
    }
}
