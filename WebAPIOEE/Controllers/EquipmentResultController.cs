using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPIOEE.Infrastructure.Context;
using WebAPIOEE.Infrastructure.Entities;
using WebAPIOEE.Services;

namespace WebAPIOEE.Controllers
{
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/EquipmentResult")]
    [EnableCors("CorsPolicy")]
    public class EquipmentResultController : Controller
    {
        private readonly IDataServices _dataServices;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public EquipmentResultController(IDataServices dataServices,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _dataServices = dataServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        // GET: api/EquipmentResults
        // GET: api/EquipmentResults/pageSize?/pageNumber?/orderby(optional)/wherevalue/type
        [HttpGet]
        [Route("{pageSize:int?}/{pageNumber:int?}/{orderby:alpha?}/{wherevalue:alpha?}/{type:alpha?}")]
        public async Task<IActionResult> Get(int pageSize = 5000, int pageNumber = 1, string whereValue = "", string orderBy = "", string type = "json")
        {
            whereValue = whereValue ?? "";
            var result = await _dataServices.EquipmentResultService.GetAllEquipmentResults(whereValue, orderBy);
            var data = result as IList<EquipmentResult> ?? result.ToList();
            var totalCount = data.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);
            if (type == "json")
            {
                var results = new
                {
                    TotalCount = totalCount,
                    totalPages = Math.Ceiling((double)totalCount / pageSize),
                    result = data
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList()
                };
                return Ok(results);
            }
            return null;
        }

        // GET api/EquipmentResult/5
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id, string type = "json")
        {
            var result = await _dataServices.EquipmentResultService.GetEquipmentResultById(id);
            if (type == "json")
            {
                return Ok(result);
            }
            return null;
        }
        //[Route("")]
        [HttpPost]
        public async Task<Guid?> Post([FromBody] EquipmentResult equipmentResult)
        {
            var result = await _dataServices.EquipmentResultService.CreateEquipmentResult(equipmentResult);
            if (!result) return null;
            //SignalR Methods Add Element
            //await _hub.EquipmentResults.All.AddEquipmentResult(EquipmentResult);
            var task = Task.Run(() => equipmentResult.EquipmentResultId);
            return await task;
        }




        // PUT api/EquipmentResult/5
        [HttpPut("{id:Guid}")]
        //[Route("{id:Guid}")]
        public async Task<bool> Put(Guid id, [FromBody] EquipmentResult equipmentResult)
        {
            var result = await _dataServices.EquipmentResultService.UpdateEquipmentResult(equipmentResult);
            if (!result) return await Task.Run(() => false);
            //SignalR Methods Update
            //await _hub.EquipmentResults.All.UpdateEquipmentResult(EquipmentResult);
            var task = Task.Run(() => true);
            return await task;

        }

        // DELETE api/EquipmentResult/5
        [HttpDelete("{id:Guid}")]
        public async Task<bool> Delete(Guid id)
        {
            var equipmentResult = await _dataServices.EquipmentResultService.GetEquipmentResultById(id);
            var result = await _dataServices.EquipmentResultService.DeleteEquipmentResult(id);
            if (!result) return await Task.Run(() => false);
            //SignalR Methods Delete
            //await _hub.EquipmentResults.All.DeleteEquipmentResult(EquipmentResult);
            var task = Task.Run(() => true);
            return await task;

        }
    }
}