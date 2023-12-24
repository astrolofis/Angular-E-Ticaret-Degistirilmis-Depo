using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Dtos;
using API.Helpers;
using API.Infrastructure.DataContext;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        /*
        private readonly StoreContext _context;

        private readonly IProductRepostitory _productRepository;
        */
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;

        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository,
            IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository,IMapper mapper)
        {
            _productRepository= productRepository;
            _productBrandRepository= productBrandRepository;
            _productTypeRepository= productTypeRepository;
            _mapper= mapper;
            //_context = context;
        }
        


        /// <summary>
        /// Database'deki verileri çekme.
        /// </summary>
        /// <returns></returns>
        [HttpGet]//http verbs -> get post delete put
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(productSpecParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);

            var totalItems = await _productRepository.CountAsync(countSpec);

            var products = await _productRepository.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);            
            //return Ok(data);
            //return data.Select(pro => new ProductToReturnDto
            //{
            //    Id = pro.Id,
            //    Name = pro.Name,
            //    Description = pro.Description,
            //    PictureUrl = pro.PictureUrl,
            //    Price = pro.Price,
            //    ProductBrand = pro.ProductBrand != null ? pro.ProductBrand.Name : string.Empty,
            //    ProductType = pro.ProductType != null ? pro.ProductType.Name : string.Empty
            //}).ToList();
            return Ok(new Pagination<ProductToReturnDto>(productSpecParams.PageIndex, productSpecParams.PageSize, totalItems, data));

        }

        /// <summary>
        /// Database'deki belirli bir veriyi çekme.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(id);

            //return await _productRepository.GetEntityWithSpec(spec);

            var product = await _productRepository.GetEntityWithSpec(spec);

            /*return new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductBrand = product.ProductBrand != null ? product.ProductBrand.Name : string.Empty,
                ProductType = product.ProductType != null ? product.ProductType.Name : string.Empty

                
            };*/
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        /// <summary>
        /// Database'den brand değerlerini çekme
        /// </summary>
        /// <returns></returns>
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok( await _productBrandRepository.ListAllAsync());
        }

        /// <summary>
        /// Database'deki type değerlerini çekme
        /// </summary>
        /// <returns></returns>
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }
    }
}