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
    public class PaymentMethodController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPaymentMethodRepository paymentMethodRepository;
        private readonly IMapper mapper;

        public PaymentMethodController(IUnitOfWork unitOfWork,IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paymentMethodRepository = paymentMethodRepository;
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
            var paymentMethod = await paymentMethodRepository.GetAllAsync();
            return Ok(paymentMethod);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var paymentMethod = await paymentMethodRepository.GetAsync(id,false);
            return Ok(paymentMethod);
        }

        private async Task<bool> isNameExist(string name)
        {
            var Names = await paymentMethodRepository.Names();
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
        public async Task<IActionResult> Create([FromBody] PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await isNameExist(paymentMethod.Name))
            {
                ModelState.AddModelError("Exist", "This Order Status already exist.");
                return BadRequest(ModelState);
            }
                
            paymentMethodRepository.Add(paymentMethod);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetAsync", new { id = paymentMethod.Id }, paymentMethod);
           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderStatusDb = await paymentMethodRepository.GetAsync(id);
            if (orderStatusDb == null)
                return NotFound();

            orderStatusDb.Name = paymentMethod.Name;
            await unitOfWork.SaveChangesAsync();

            return Ok(orderStatusDb);
        }

        public async Task<IActionResult> Delete(PaymentMethod paymentMethod)
        {
            if (paymentMethod == null)
                return BadRequest();

            paymentMethodRepository.Remove(paymentMethod);
            await unitOfWork.SaveChangesAsync();

            return Ok(paymentMethod);
        }
        
    }
}
