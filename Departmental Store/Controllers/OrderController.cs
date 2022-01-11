using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Departmental_Store.Data;
using Departmental_Store.ViewModels;

namespace Departmental_Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly Departmental_StoreContext _context;

        public OrderController(Departmental_StoreContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {

            var orderModel = new OrderModel();

            int x = 0;
            x = orderModel.Price * orderModel.Quantity;
            ViewBag.total = x;

            return View(await _context.OrderModel.ToListAsync());

        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.OrderModel
                .FirstOrDefaultAsync(m => m.StoreID == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            int x = 0;
            x = orderModel.Price * orderModel.Quantity;
            ViewBag.total = x;

            return View(orderModel);
        }





        // GET: Order/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreID,StoreName,Description,Quantity,Price,Total")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderModel);
        }





        // GET: Order/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
       // {
          //  if (id == null)
       //     {
          //      return NotFound();
    //        }
    //
         //   var orderModel = await _context.OrderModel.FindAsync(id);
      //      if (orderModel == null)
       //    {
        //        return NotFound();
       //     }
           // return View(orderModel);
      //  }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       // [HttpPost]
       // [ValidateAntiForgeryToken]
       // public async Task<IActionResult> Edit(int id, [Bind("StoreID,StoreName,Description,Quantity,Price,Total")] OrderModel orderModel)
       // {
           // if (id != orderModel.StoreID)
         //   {
           //     return NotFound();
          //  }

          //  if (ModelState.IsValid)
          //  {
             //   try
            //    {
                //    _context.Update(orderModel);
                //    await _context.SaveChangesAsync();
             //   }
             //   catch (DbUpdateConcurrencyException)
             //   {
             //       if (!OrderModelExists(orderModel.StoreID))
                //    {
               //         return NotFound();
            //        }
                //    else
                 //   {
                        //throw;
                  //  }
                //}
            //    return RedirectToAction(nameof(Index));
           // }
           // return View(orderModel);
       // }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.OrderModel
                .FirstOrDefaultAsync(m => m.StoreID == id);
            if (orderModel == null)
            {
                return NotFound();
            }
            int x = 0;
            x = orderModel.Price * orderModel.Quantity;
            ViewBag.total = x;

            return View(orderModel);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderModel = await _context.OrderModel.FindAsync(id);
            _context.OrderModel.Remove(orderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderModelExists(int id)
        {
            return _context.OrderModel.Any(e => e.StoreID == id);
        }
    }
}
