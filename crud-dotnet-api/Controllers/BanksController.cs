using crud_dotnet_api.data;
using crud_dotnet_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_api.Controllers
{
    [ApiController]
    [Route("/api/Banks")]
    public class BanksController : Controller
    {
        public string sort_name { get; set; }
        public string full_name { get; set; }
        private readonly FullStackDbcontext _fullStackDbcontext;

        public BanksController(FullStackDbcontext fullStackDbcontext)
        {
            _fullStackDbcontext = fullStackDbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBanks()
        {
          var Banks = await _fullStackDbcontext.Banks.ToListAsync();
            return Ok(Banks);
          
        }
        [HttpPost]
        public async Task<IActionResult> AddBanks([FromBody] Banks bankrequest)
        {

            bankrequest.id = Guid.NewGuid();

             await _fullStackDbcontext.Banks.AddAsync(bankrequest);
            await _fullStackDbcontext.SaveChangesAsync();

            return Ok(bankrequest);

        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBanks([FromRoute]Guid id )
        {
         var Banks =  await _fullStackDbcontext.Banks.FirstOrDefaultAsync(x => x.id == id);
            if(Banks == null)
            {
                return NotFound();
            }
            return Ok(Banks);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBanks([FromRoute] Guid id,Banks updateBanksRequest)
        {
         var Banks =  await _fullStackDbcontext.Banks.FindAsync(id);
            if(Banks == null)
            {
                return NotFound();
            }
           
            Banks.ref_code = updateBanksRequest.ref_code;
            Banks.name = updateBanksRequest.name;
            Banks.updated_at = updateBanksRequest.updated_at;
            Banks.sort_name = updateBanksRequest.sort_name;
           

            await _fullStackDbcontext.SaveChangesAsync(); return Ok(Banks);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBanks([FromRoute] Guid id)
        {
            var banks = await _fullStackDbcontext.Banks.FindAsync(id);
            if(banks == null)
            {
                return NotFound();
            }
            _fullStackDbcontext.Banks.Remove(banks);
            await _fullStackDbcontext.SaveChangesAsync();
            var banksdel = await _fullStackDbcontext.Banks.ToListAsync();
            return Ok(banksdel);

        }


    }
}


