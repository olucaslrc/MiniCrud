using MediatR;
using MiniCrud.Products.Application.DTOs;
using MiniCrud.Products.Domain.Entities;
using MiniCrud.Products.Domain.Interfaces;
using System.Linq;

namespace MiniCrud.Products.Application.Queries.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IUnityOfWork _uow;

        public GetProductsQueryHandler(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new List<ProductDTO>();
                var getProducts = await _uow.ProductRepository.GetAllAsync();

                foreach (var product in getProducts)
                {
                    result.Add(new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Registered = product.Registered,
                    });
                }
                return result;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }
    }
}
