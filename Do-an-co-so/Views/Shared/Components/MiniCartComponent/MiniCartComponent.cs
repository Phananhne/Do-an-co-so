﻿using Do_an_co_so.Intefaces;
using Do_an_co_so.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Globalization;
using System.Net.NetworkInformation;

namespace Do_an_co_so.Views.Shared.Components.MiniCartComponent
{
    public class MiniCartComponent : ViewComponent
    {
        readonly CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        private readonly ICartRepository _cartRepo;
        public MiniCartComponent(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public double TotalMoney()
        {
            double totalMoney = 0;
            List<Item> listCart = _cartRepo.Get(HttpContext.Session);
            if (listCart != null)
            {
                totalMoney = listCart.Sum(x => x.Quantity * (x.Product.ProductPrice - (x.Product.ProductPrice * x.Product.ProductDiscount / 100)));
            }
            return totalMoney;
        }
        public IViewComponentResult Invoke()
        {
            var cart = _cartRepo.Get(HttpContext.Session);
            ViewData["TotalMoney"] = TotalMoney().ToString("#,###", cul.NumberFormat);
            ViewData["Count"] = cart.Count();
            return View(cart);
        }
    }
}
