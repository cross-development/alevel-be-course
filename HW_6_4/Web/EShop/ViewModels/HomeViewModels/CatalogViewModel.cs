﻿using Microsoft.AspNetCore.Mvc.Rendering;
using EShop.Models;
using EShop.ViewModels.CommonViewModels;

namespace EShop.ViewModels.HomeViewModels;

public class CatalogViewModel
{
    public IEnumerable<CatalogItem> CatalogItems { get; set; }
    
    public int? BrandId { get; set; }
    
    public IEnumerable<SelectListItem> Brands { get; set; }
    
    public int? TypeId { get; set; }

    public IEnumerable<SelectListItem> Types { get; set; }
    
    public PaginationViewModel PaginationViewModel { get; set; }
}