using AutoMapper;
using B2B.API.Dtos.CategoryDtos;
using B2B.API.Dtos.ProductCategoryDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using System.Collections.Generic;

namespace B2B.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryService _categoryService;

        public AllProductController(IMapper mapper, IProductCategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpPost("FilterCategory")]
        public IActionResult FilterCategory([FromBody] FilterDto filter)
        {
            List<ProductCategory> products = new List<ProductCategory>();

            for (int i = 0; i < filter.ParentCategoryId.Count; i++)
            {
                int categoryId = filter.ParentCategoryId[i];

                // Seçilen kategori için tüm boyutları döngü ile işle
                foreach (var sizeId in filter.SizesId)
                {
                    // Kategori ve boyuta göre filtreleme işlemi gerçekleştir
                    var filteredProducts = _categoryService.TGetAllCategoriesInclude()
                        .Where(x => x.ParentSubCategoryID == categoryId && x.productPrice.dimensions.Boy == sizeId)
                        .ToList();

                    // Filtrelenmiş ürünleri genel listeye ekle, ancak benzersizlik kontrolü yap
                    foreach (var product in filteredProducts)
                    {
                        // Ürün listede yoksa ekle
                        if (!products.Any(p => p.ProductID == product.ProductID))
                        {
                            products.Add(product);
                        }
                    }
                }
            }


            return Ok(_mapper.Map<List<ResultProductCategoryDto>>(products));
        }


    }
}
