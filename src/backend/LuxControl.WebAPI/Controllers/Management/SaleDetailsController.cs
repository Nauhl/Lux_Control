using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using LuxControl.Core.Models.Management;
using LuxControl.Infrastructure.Data;

namespace LuxControl.WebAPI.Controllers.Management
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailsController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public SaleDetailsController(LuxControlContext context)
        {
            _context = context;
        }

        // GET api/saledetails
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<SaleDetail>>> GetSaleDetails()
        {
            return await _context.SaleDetails.ToListAsync();
        }

        // GET api/saledetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDetail>> GetSaleDetailById(int id)
        {
            var SaleDetailId = await _context.SaleDetails.FindAsync(id);
            if (SaleDetailId == null) return NotFound();
            return SaleDetailId;
        }

        // POST api/saledetails
        [HttpPost]
        public async Task<IActionResult> PostSaleDetail(SaleDetail saleDetail)
        {
            _context.SaleDetails.Add(saleDetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSaleDetailById), new {id = saleDetail.Id}, saleDetail);
        }

        // PUT api/saledetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleDetail(int id, SaleDetail saleDetail)
        {
            if (id != saleDetail.Id) return BadRequest();
            _context.Entry(saleDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // [HttpPatch("{id}")]
        // public async Task<ActionResult> PatchSaleDetail(int id, [FromBody] JsonPatchDocument<SaleDetail> patchDoc)
        // {
        //     if (patchDoc == null)
        //     {
        //         return BadRequest();
        //     }

        //     var autorDeLaDB = await _context.SaleDetails.FirstOrDefaultAsync(x => x.Id == id);

        //     if (autorDeLaDB == null)
        //     {
        //         return NotFound();
        //     }

        //     patchDoc.ApplyTo(autorDeLaDB, ModelState);

        //     var isValid = TryValidateModel(autorDeLaDB);

        //     if (!isValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }


        // DELETE api/saledetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleDetailById(int id)
        {
            var SaleDetailId = await _context.SaleDetails.FindAsync(id);

            if(SaleDetailId == null) return NotFound();

            _context.SaleDetails.Remove(SaleDetailId);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}