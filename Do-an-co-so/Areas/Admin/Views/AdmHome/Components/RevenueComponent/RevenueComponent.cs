﻿using Do_an_co_so.Models;
using Do_an_co_so.Intefaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Do_an_co_so.Data;


namespace Do_an_co_so.Areas.Admin.Views.AdmHome.Components.RevenueComponent
{
    public class RevenueComponent : ViewComponent
    {
        private Do_an_co_soContext _context;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        public RevenueComponent(Do_an_co_soContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(string revenueOrder)
        {
            double objRevenue = 0;
            double objLastRevenue = 0;
            switch (revenueOrder)
            {
                case "today":
                    var lastDate = DateTime.Now.Date.AddDays(-1);
                    objRevenue = _context.Orders.Where(
                        x => x.DayOrder.Date == DateTime.Now.Date
                        ).Sum(x => x.TotalMoney);
                    objLastRevenue = _context.Orders.Where(
                        x => x.DayOrder.Date == lastDate
                        ).Sum(x => x.TotalMoney);

                    ViewBag.RevenueDay = "Hôm nay";
                    break;
                case "thisMonth":
                    var lastMonthDate = DateTime.Now.Date.AddMonths(-1);
                    objRevenue = _context.Orders.Where(
                        x => x.DayOrder.Year == DateTime.Now.Year
                        && x.DayOrder.Month == DateTime.Now.Month
                        ).Sum(x => x.TotalMoney);
                    objLastRevenue = _context.Orders.Where(
                        x => x.DayOrder.Year == lastMonthDate.Year
                        && x.DayOrder.Month == lastMonthDate.Month
                        ).Sum(x => x.TotalMoney);
                    ViewBag.RevenueDay = "Tháng này";
                    break;
                case "thisYear":
                    var lastYearDate = DateTime.Now.Date.AddYears(-1);
                    objRevenue = _context.Orders.Where(x => x.DayOrder.Year == DateTime.Now.Year).Sum(x => x.TotalMoney);
                    objLastRevenue = _context.Orders.Where(x => x.DayOrder.Year == lastYearDate.Year).Sum(x => x.TotalMoney);
                    ViewBag.RevenueDay = "Năm này";
                    break;
            }
            ViewBag.RevenuePercent = (objLastRevenue > 0) ? Math.Round((objRevenue - objLastRevenue) * 100, 2) : objRevenue * 100;
            ViewBag.RevenueColor = (objRevenue == objLastRevenue) ? "text-muted" : (objRevenue >= objLastRevenue) ? "text-success" : "text-danger";
            ViewBag.RevenueStatus = (objRevenue == objLastRevenue) ? "" : (objRevenue >= objLastRevenue) ? "tăng" : "giảm";
            ViewBag.RevenueNumbers = (objRevenue == 0) ? "0" : objRevenue.ToString("#,###", cul.NumberFormat);
            return View();
        }
    }
}
