using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController<int,Role, RoleRepository>
    {
        public RoleController(RoleRepository repository) : base(repository)
        {

        }
    }
   /* public class RoleController : ControllerBase
    {
        private readonly RoleRepository repository;
        public RoleController(RoleRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Role entity)
        {
            try
            {
                var result = await repository.Insert(entity);
                if (result == 0)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Data failed to save"
                    });

                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Saved Successfully"
                    });

                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong !",
                });

            }
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var results = await repository.GetAll();
            if (results is null)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Blank Data!",
                    Data = results
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data Available",
                    Data = results
                });
            }

        }
        [HttpPut]//Update Data
        public async Task<ActionResult> Update(Role entity)
        {
            try
            {
                var result = await repository.Update(entity);
                if (result == 0)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Data Failed to Update"
                    });

                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Successfully Updated"
                    });

                }
            }
            catch
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong !",
                });
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                var result = await repository.Delete(Id);
                if (result == 0)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Failed to Delete Data"
                    });

                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Deleted Successfully"
                    });

                }
            }
            catch
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong !",
                });

            }
        }
    }*/
}
