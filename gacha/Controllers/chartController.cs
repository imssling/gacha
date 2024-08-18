using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gacha.Models;
using gacha.DTO;

namespace gacha.Controllers
{
    public class chartController : Controller
    {
        private readonly gachaContext _context;

        public chartController(gachaContext context)
        {
            _context = context;
        }
        // GET: chart/Index
        public async Task<IActionResult> Index()
        {
            //性別圓餅圖
            ViewBag.boy = _context.userInfo.Where(b => b.gender == "男").Count();
            ViewBag.girl = _context.userInfo.Where(b => b.gender == "女").Count();

            // 獲取當前時間
            ViewBag.CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            return View();
        }


        //追蹤清單長條圖
        //GET:chart/machineData
        [HttpGet]
        public async Task<IEnumerable<machineData_DTO>> machineData(int id)
        {
            var machineTrackingData = await (from t in _context.trackingList
                                             join g in _context.gachaMachine
                                             on t.gachaMachineId equals g.id
                                             join gt in _context.gachaTheme
                                             on g.themeId equals gt.id
                                             where gt.id == id
                                             group t by new { t.gachaMachineId, g.machineName } into groupedData
                                             select new machineData_DTO
                                             {
                                                 MachineId = groupedData.Key.gachaMachineId,
                                                 MachineName = groupedData.Key.machineName,
                                                 TrackCount = groupedData.Count()
                                             }).ToListAsync();
            return machineTrackingData;
        }

        //追蹤清單長條圖 全部主題分類
        //GET:chart/getThemeName
        [HttpGet]
        public async Task<IEnumerable<gachaTheme_DTO>> getThemeName()
        {
            var gachaTheme = await _context.gachaTheme.Select(t => new gachaTheme_DTO
            {
                id = t.id,
                themeName = t.themeName,
            }).ToListAsync();

            return gachaTheme;
        }

        //追蹤清單長條圖 各主題分類
        //GET:chart/getThemeNamebyId
        [HttpGet]
        public async Task<IEnumerable<gachaTheme_DTO>> getThemeNamebyId(int id)
        {
            var gachaTheme = await _context.gachaTheme.Where(s => s.id == id).Select(t => new gachaTheme_DTO
            {
                id = t.id,
                themeName = t.themeName,
            }).ToListAsync();

            return gachaTheme;
        }

        //儲值月份折線圖
        //GET:chart/GetMonthlyRevenue
        [HttpGet]
        public async Task<IEnumerable<monthlyRevenue_DTO>> GetMonthlyRevenue(int year)
        {
            var monthlyRevenue = from r in _context.rechargeList
                                 where r.rechargeDate.HasValue && r.rechargeDate.Value.Year == year
                                 group r by new { r.rechargeDate.Value.Month } into grouped
                                 select new monthlyRevenue_DTO
                                 {
                                     Month = grouped.Key.Month,
                                     TotalAmount = grouped.Sum(r => r.amount)
                                 };

            return await monthlyRevenue.OrderBy(mr => mr.Month).ToListAsync();
        }

    }
}
