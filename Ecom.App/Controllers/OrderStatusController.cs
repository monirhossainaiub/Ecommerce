using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Ecom.App.Controllers.Resources.DTOs;
using Ecom.App.Models;
using Ecom.App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Ecom.App.Controllers
{
    public class OrderStatusController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrderStatusRepository orderStatusRepository;
        private readonly IMapper mapper;

        public OrderStatusController(IUnitOfWork unitOfWork,IOrderStatusRepository orderStatusRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.orderStatusRepository = orderStatusRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderStatus = await orderStatusRepository.GetAllAsync();
            return Ok(orderStatus);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var orderStatus = await orderStatusRepository.GetAsync(id,false);
            return Ok(orderStatus);
        }

        private async Task<bool> isNameExist(string name)
        {
            var Names = await orderStatusRepository.Names();
            if (Names.Count == 0)
                return false;

            else
            {
                for (int i = 0; i < Names.Count; i++)
                {
                    if(name == Names[i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderStatus orderStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await isNameExist(orderStatus.Name))
            {
                ModelState.AddModelError("Exist", "This Order Status already exist.");
                return BadRequest(ModelState);
            }
                
            orderStatusRepository.Add(orderStatus);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetAsync", new { id = orderStatus.Id }, orderStatus);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] OrderStatus orderStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderStatusDb = await orderStatusRepository.GetAsync(id);
            if (orderStatusDb == null)
                return NotFound();

            orderStatusDb.Name = orderStatus.Name;
            await unitOfWork.SaveChangesAsync();

            return Ok(orderStatusDb);
        }

        public async Task<IActionResult> Delete(OrderStatus orderStatus)
        {
            if (orderStatus == null)
                return BadRequest();

            orderStatusRepository.Remove(orderStatus);
            await unitOfWork.SaveChangesAsync();

            return Ok(orderStatus);
        }
        
    }
}
