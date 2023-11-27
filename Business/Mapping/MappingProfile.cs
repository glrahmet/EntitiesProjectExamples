using AutoMapper;
using Business.Features._Product.CreateProduct;
using Business.Features._Product.RemoveProduct;
using Business.Features._Product.UpdateProduct;
using Business.Features.Categories.CreateCategories;
using Business.Features.Categories.UpdateCategories;
using Business.Models;
using EntitiesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, ProductModel>();
            CreateMap<UpdateProductCommand, ProductModel>();

            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        }
    }
}
