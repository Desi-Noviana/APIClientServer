using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
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
                        Message = "Data Gagal Disimpan"
                    });

                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Disimpan"
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
                    Message = "Data Kosong!",
                    Data = results
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data Ada",
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
                        Message = "Data Gagal Di Update"
                    });

                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Di Update"
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
                        Message = "Data Gagal DiHapus"
                    });

                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Dihapus"
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
        public async Task<ActionResult> GetById(int key)
        {
            var results = await repository.GetById(key);
            if (results is null)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data Kosong!",
                    Data = results
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data Ada",
                    Data = results
                });
            }
        }

    }
}
