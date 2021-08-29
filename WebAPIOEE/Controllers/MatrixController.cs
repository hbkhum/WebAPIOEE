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
    [Route("api/Matrix")]
    [EnableCors("CorsPolicy")]
    public class MatrixController : Controller
    {
        private readonly IDataServices _dataServices;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public MatrixController(IDataServices dataServices,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _dataServices = dataServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        // GET: api/Matrixs
        // GET: api/Matrixs/pageSize?/pageNumber?/orderby(optional)/wherevalue/type
        [HttpGet]
        [Route("{pageSize:int?}/{pageNumber:int?}/{orderby:alpha?}/{wherevalue:alpha?}/{type:alpha?}")]
        public async Task<IActionResult> Get(int pageSize = 5000, int pageNumber = 1, string whereValue = "", string orderBy = "", string type = "json")
        {
            whereValue = whereValue ?? "";
            var result = await _dataServices.MatrixService.GetAllMatrixs(whereValue, orderBy);
            var data = result as IList<Matrix> ?? result.ToList();
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

        // GET api/Matrix/5
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id, string type = "json")
        {
            var result = await _dataServices.MatrixService.GetMatrixById(id);
            if (type == "json")
            {
                return Ok(result);
            }
            return null;
        }
        //[Route("")]
        [HttpPost]
        public async Task<Guid?> Post([FromBody] Matrix matrix)
        {
            var result = await _dataServices.MatrixService.CreateMatrix(matrix);
            if (!result) return null;
            //SignalR Methods Add Element
            //await _hub.Matrixs.All.AddMatrix(Matrix);
            var task = Task.Run(() => matrix.MatrixId);
            return await task;
        }




        // PUT api/Matrix/5
        [HttpPut("{id:Guid}")]
        //[Route("{id:Guid}")]
        public async Task<bool> Put(Guid id, [FromBody] Matrix matrix)
        {
            var result = await _dataServices.MatrixService.UpdateMatrix(matrix);
            if (!result) return await Task.Run(() => false);
            //SignalR Methods Update
            //await _hub.Matrixs.All.UpdateMatrix(Matrix);
            var task = Task.Run(() => true);
            return await task;

        }

        // DELETE api/Matrix/5
        [HttpDelete("{id:Guid}")]
        public async Task<bool> Delete(Guid id)
        {
            var matrix = await _dataServices.MatrixService.GetMatrixById(id);
            var result = await _dataServices.MatrixService.DeleteMatrix(id);
            if (!result) return await Task.Run(() => false);
            //SignalR Methods Delete
            //await _hub.Matrixs.All.DeleteMatrix(Matrix);
            var task = Task.Run(() => true);
            return await task;

        }
    }
}