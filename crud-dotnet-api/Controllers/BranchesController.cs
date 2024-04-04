using crud_dotnet_api.data;
using crud_dotnet_api.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_api.Controllers
{
    [ApiController]
    [Route("/api/branches")]
    public class BranchesController : Controller

    {
        private readonly FullStackDbcontext _fullStackDbcontext;
        public BranchesController (FullStackDbcontext fullStackDbContext)
        {
            _fullStackDbcontext = fullStackDbContext;
                    }
        [HttpGet]
        public async Task<IActionResult> Getbranches()
        {
            var branches = await _fullStackDbcontext.branches.ToListAsync();
            return Ok(branches);
           
        }
        [HttpPost]
        public async Task<IActionResult> Addbranches([FromBody] branches branchesrequest)
        {
            branchesrequest.id = Guid.NewGuid();
            await _fullStackDbcontext.branches.AddAsync(branchesrequest);
            await _fullStackDbcontext.SaveChangesAsync();
            return Ok(branchesrequest);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Getbranches( Guid id)
        {
            var branches = await _fullStackDbcontext.branches.FirstOrDefaultAsync(x => x.id == id);
            
            if(
                branches == null )
            { return NotFound();
            }
            return Ok(branches);

        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBranches([FromRoute] Guid id, branches updateBranchesRequest)
        {
            var branches = await _fullStackDbcontext.branches.FindAsync(id);
            if (branches == null)
            {
                return NotFound();
            }
            branches.name = updateBranchesRequest.name;
            branches.ref_code = updateBranchesRequest.ref_code;
            branches.address = updateBranchesRequest.address;
            branches.ifsc = updateBranchesRequest.ifsc;
            branches.bank_id = updateBranchesRequest.bank_id;
            branches.short_name = updateBranchesRequest.short_name;
            branches.updated_at = updateBranchesRequest.updated_at;
          

            await _fullStackDbcontext.SaveChangesAsync();

            return Ok(branches);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Deletebranches([FromRoute] Guid id)
        {
            var branches = await _fullStackDbcontext.branches.FindAsync(id);
            if (branches == null)
            {
                return NotFound();
            }
            _fullStackDbcontext.branches.Remove(branches);
            await _fullStackDbcontext.SaveChangesAsync();
            var branchesdel = await _fullStackDbcontext.branches.ToListAsync();
            return Ok(branchesdel);

        }

    }
}