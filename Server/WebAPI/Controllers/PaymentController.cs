using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectCore.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {

        private readonly IPaymentService _servPayment;

        public PaymentController(IPaymentService servPayment)
        {
            _servPayment = servPayment;
        }

        //Get  api/departments
        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _servPayment.GetAll();
            return Ok(payments);
        }

        //GET api/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var payment = await _servPayment.GetById(id.Value);
            if (payment != null)
            { return Ok(payment); }
            else
            { return NotFound(); }
        }

        //[Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody]PaymentDTO paymentDTO)
        {
            if (paymentDTO == null)
            {
                return BadRequest();
            }
            int result = await _servPayment.Create(paymentDTO);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }



        //[Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdatePaymentById([FromBody]PaymentDTO paymentDTO)
        {


            if (paymentDTO == null)
            {
                return BadRequest();
            }

            int result = await _servPayment.Update(paymentDTO);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }



        //[Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            int result = await _servPayment.DeleteById(id.Value);
            // return RedirectToAction(nameof(Index));
            if (result == 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }









    }
}
