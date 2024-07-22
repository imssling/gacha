﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gacha.Models;
using gacha.ViewModels;

namespace gacha.Controllers
{
    public class rechargeListsController : Controller
    {
        private readonly gachaContext _context;

        public rechargeListsController(gachaContext context)
        {
            _context = context;
        }

        // GET: rechargeLists
        public async Task<IActionResult> Index()
        {
            //var gachaContext = _context.rechargeList.Include(r => r.rechargePlan).Include(r => r.user);
            //return View(await gachaContext.ToListAsync());
            var gachaContext = _context.rechargeList.Include(t => t.rechargePlan).Include(t => t.user)
                .Select(t => new rechargeList_ViewModel
                {
                    id = t.id,
                    quantity = t.quantity,
                    amount = t.amount,
                    paymentMode = t.paymentMode,
                    rechargePlanId = t.rechargePlanId,
                    userId = t.userId

                });
            return View(await gachaContext.ToListAsync());
        }

        // GET: rechargeLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rechargeList = await _context.rechargeList
                .Include(r => r.rechargePlan)
                .Include(r => r.user)
                .FirstOrDefaultAsync(m => m.id == id);

            if (rechargeList == null)
            {
                return NotFound();
            }
            //var gachaContext = _context.rechargeList.Include(t => t.rechargePlan).Include(t => t.user)
            //   .Select(t => new rechargeList_ViewModel
            //   {
            //       id = t.id,
            //       quantity = t.quantity,
            //       amount = t.amount,
            //       paymentMode = t.paymentMode,
            //       rechargePlanId = t.rechargePlanId,
            //       userId = t.userId

            //   });
            //if (rechargeList == null)
            //{
            //    return NotFound();
            //}

            rechargeList_ViewModel rechargeListV = new rechargeList_ViewModel()
            {
                id = rechargeList.id,
                quantity = rechargeList.quantity,
                amount = rechargeList.amount,
                paymentMode = rechargeList.paymentMode,
                rechargePlanId = rechargeList.rechargePlanId,
                //rechargePlan = rechargeList.rechargePlan?.name,
                userId = rechargeList.userId,
                rechargeDate = rechargeList.rechargeDate
                //userName = rechargeList.user?.userName
            };
            ViewBag.rechargeName = rechargeList.rechargePlan.name;
            ViewBag.rechargeTotalPrice = rechargeList.quantity * rechargeList.amount;
            
            return View(rechargeListV);
        }

        // GET: rechargeLists/Create
        public IActionResult Create()
        {
            //ViewData["rechargePlanId"] = new SelectList(_context.rechargePlan, "id", "name");
            //ViewData["userId"] = new SelectList(_context.userInfo, "id", "id");
            //ViewData["userName"] = new SelectList(_context.userInfo, "id", "userName");

            ViewBag.rechargePlanId = new SelectList(_context.rechargePlan, "id", "name");
            ViewBag.userId = new SelectList(_context.userInfo, "id", "id");
            //ViewBag.userName = new SelectList(_context.userInfo, "id", "userName");

            //增加rechargePlan paymentMode的select選項
            ViewBag.paymentMode = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "信用卡", Text = "信用卡" },
            }, "Value", "Text");

            //增加rechargePlan amount的select選項
            ViewBag.amount = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "100", Text = "$100" },
                new SelectListItem { Value = "200", Text = "$200" },
                new SelectListItem { Value = "500", Text = "$500" },
                new SelectListItem { Value = "1000", Text = "$1000" },
                new SelectListItem { Value = "2000", Text = "$2000" },
                new SelectListItem { Value = "500", Text = "$5000" }
            }, "Value", "Text");
            //增加rechargePlan的select選項
            ViewBag.rechargePlan = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "正五品方案", Text = "正五品方案" },
                new SelectListItem { Value = "正四品方案", Text = "正四品方案" },
                new SelectListItem { Value = "正三品方案", Text = "正三品方案" },
                new SelectListItem { Value = "正二品方案", Text = "正二品方案" },
                new SelectListItem { Value = "正一品方案", Text = "正一品方案" },
                new SelectListItem { Value = "皇后方案", Text = "皇后方案" }
            }, "Value", "Text");

            return View();
        }

        // POST: rechargeLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("quantity,amount,paymentMode,rechargePlanId, userId")] rechargeList_ViewModel rechargeListVM)
        {

            //增加rechargePlan paymentMode的select選項
            ViewBag.paymentMode = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "信用卡", Text = "信用卡" },
            }, "Value", "Text");

            //增加rechargePlan amount的select選項
            ViewBag.amount = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "100", Text = "$100" },
                new SelectListItem { Value = "200", Text = "$200" },
                new SelectListItem { Value = "500", Text = "$500" },
                new SelectListItem { Value = "1000", Text = "$1000" },
                new SelectListItem { Value = "2000", Text = "$2000" },
                new SelectListItem { Value = "500", Text = "$5000" }
            }, "Value", "Text");
            //增加rechargePlan的select選項
            ViewBag.rechargePlan = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "正五品方案", Text = "正五品方案" },
                new SelectListItem { Value = "正四品方案", Text = "正四品方案" },
                new SelectListItem { Value = "正三品方案", Text = "正三品方案" },
                new SelectListItem { Value = "正二品方案", Text = "正二品方案" },
                new SelectListItem { Value = "正一品方案", Text = "正一品方案" },
                new SelectListItem { Value = "皇后方案", Text = "皇后方案" }
            }, "Value", "Text");

            if (ModelState.IsValid)
            {
                var rechargeList = new rechargeList
                {
                    quantity = rechargeListVM.quantity,
                    amount = rechargeListVM.amount,
                    paymentMode = rechargeListVM.paymentMode,
                    rechargePlanId = rechargeListVM.rechargePlanId,
                    userId = rechargeListVM.userId  
                };

                _context.Add(rechargeList);
                await _context.SaveChangesAsync(); // Ensure this line is present
                return RedirectToAction(nameof(Index));

                
            }

            ViewData["rechargePlanId"] = new SelectList(_context.rechargePlan, "id", "name", rechargeListVM.rechargePlanId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "name", rechargeListVM.userId);

            return View(rechargeListVM);
        }

        // GET: rechargeLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rechargeList = await _context.rechargeList.FindAsync(id);
            if (rechargeList == null)
            {
                return NotFound();
            }
            ViewData["rechargePlanId"] = new SelectList(_context.rechargePlan, "id", "name", rechargeList.rechargePlanId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email", rechargeList.userId);
            //增加rechargePlan paymentMode的select選項
            ViewBag.paymentMode = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "信用卡", Text = "信用卡" },
            }, "Value", "Text");
            //增加rechargePlan amount的select選項
            ViewBag.amount = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "100", Text = "$100" },
                new SelectListItem { Value = "200", Text = "$200" },
                new SelectListItem { Value = "500", Text = "$500" },
                new SelectListItem { Value = "1000", Text = "$1000" },
                new SelectListItem { Value = "2000", Text = "$2000" },
                new SelectListItem { Value = "500", Text = "$5000" }
            }, "Value", "Text");
            //增加rechargePlan的select選項
            ViewBag.rechargePlan = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "正五品方案", Text = "正五品方案" },
                new SelectListItem { Value = "正四品方案", Text = "正四品方案" },
                new SelectListItem { Value = "正三品方案", Text = "正三品方案" },
                new SelectListItem { Value = "正二品方案", Text = "正二品方案" },
                new SelectListItem { Value = "正一品方案", Text = "正一品方案" },
                new SelectListItem { Value = "皇后方案", Text = "皇后方案" }
            }, "Value", "Text");

            var rechargeListVM = new rechargeList_ViewModel
            {
                id = rechargeList.id,
                quantity = rechargeList.quantity,
                amount = rechargeList.amount,
                paymentMode = rechargeList.paymentMode,
                rechargePlanId = rechargeList.rechargePlanId,
                userId = rechargeList.userId
            };




            ViewBag.rechargePlanId = new SelectList(_context.rechargePlan, "id", "name");
            ViewBag.userId = new SelectList(_context.userInfo, "id", "id");
            ViewBag.userName = new SelectList(_context.userInfo, "id", "userName");

            

            return View(rechargeListVM);
        }

        // POST: rechargeLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,quantity,amount,paymentMode,rechargePlanId, rechargePlan,userId, userName")] rechargeList_ViewModel rechargeListVM)
        {
            //增加rechargePlan paymentMode的select選項
            ViewBag.paymentMode = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "信用卡", Text = "信用卡" },
            }, "Value", "Text");
            //增加rechargePlan amount的select選項
            ViewBag.amount = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "100", Text = "$100" },
                new SelectListItem { Value = "200", Text = "$200" },
                new SelectListItem { Value = "500", Text = "$500" },
                new SelectListItem { Value = "1000", Text = "$1000" },
                new SelectListItem { Value = "2000", Text = "$2000" },
                new SelectListItem { Value = "500", Text = "$5000" }
            }, "Value", "Text");
            //增加rechargePlan的select選項
            ViewBag.rechargePlan = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "正五品方案", Text = "正五品方案" },
                new SelectListItem { Value = "正四品方案", Text = "正四品方案" },
                new SelectListItem { Value = "正三品方案", Text = "正三品方案" },
                new SelectListItem { Value = "正二品方案", Text = "正二品方案" },
                new SelectListItem { Value = "正一品方案", Text = "正一品方案" },
                new SelectListItem { Value = "皇后方案", Text = "皇后方案" }
            }, "Value", "Text");


            if (id != rechargeListVM.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var rechargeList = await _context.rechargeList.FindAsync(id);
                    rechargeList.quantity = rechargeListVM.quantity;
                    rechargeList.amount = rechargeListVM.amount;
                    rechargeList.paymentMode = rechargeListVM.paymentMode;
                    rechargeList.rechargePlanId = rechargeListVM.rechargePlanId;
                    rechargeList.userId = rechargeListVM.userId;

                    _context.Update(rechargeList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rechargeListExists(rechargeListVM.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["rechargePlanId"] = new SelectList(_context.rechargePlan, "id", "name", rechargeListVM.rechargePlanId);
            ViewData["userId"] = new SelectList(_context.userInfo, "id", "email", rechargeListVM.userId);
            return View(rechargeListVM);
        }

        // GET: rechargeLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rechargeList = await _context.rechargeList
                .Include(r => r.rechargePlan)
                .Include(r => r.user)
                .FirstOrDefaultAsync(m => m.id == id);
            if (rechargeList == null)
            {
                return NotFound();
            }

            var rechargeListVM = new rechargeList_ViewModel
            {
                id = rechargeList.id,
                quantity = rechargeList.quantity,
                amount = rechargeList.amount,
                paymentMode = rechargeList.paymentMode,
                rechargePlanId = rechargeList.rechargePlanId,
                //rechargePlan = rechargeList.rechargePlan?.name,
                userId = rechargeList.userId
                //userName = rechargeList.user?.userName
            };

            return View(rechargeListVM);
        }

        // POST: rechargeLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rechargeList = await _context.rechargeList.FindAsync(id);
            if (rechargeList != null)
            {
                _context.rechargeList.Remove(rechargeList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rechargeListExists(int id)
        {
            return _context.rechargeList.Any(e => e.id == id);
        }
    }
}