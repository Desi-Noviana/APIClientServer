using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<string, Employee, EmployeeRepository>
    {
        public EmployeeController(EmployeeRepository repository) : base(repository)
        {

        }
    }
    /*public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository repository;

        public EmployeeController(EmployeeRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Employee entity)
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
        [HttpPut] //Update Data
        public async Task<ActionResult> Update(Employee entity)
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
        [HttpDelete] // Delete Data
        public async Task<ActionResult> Delete(string NIK)
        {
            try
            {
                var result = await repository.Delete(NIK);
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
        [HttpGet]
        [Route("{key}")]
        public async Task<ActionResult> GetById(string NIK)
        {
            var results = await repository.GetById(NIK);
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

    }*/
}
