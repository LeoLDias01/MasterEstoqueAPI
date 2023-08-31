using MasterEstoqueAPI.Business.Validators;
using MasterEstoqueAPI.Domain.Infra;
using MasterEstoqueAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MasterEstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region ..:: Instances and Variables ::..
        private readonly ProductValidation _validation = new ProductValidation();
        private readonly IMasterEstoqueAPIService _service;
        #endregion

        #region ..:: Constructor ::..
        public ProductController(IMasterEstoqueAPIService service) => _service = service;
        #endregion

        #region ..:: Requests and Responses ::..
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Method to insert a new product data")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                // Fields validation and start create routine
                if (_validation.InsertValidation(product)) return Created("InsertProduct", _service.InsertProduct(product));
                else return BadRequest("Campos Inválidos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Method to update product data")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                // Fields validation and start alteration routine
                if (_validation.AlterValidation(product)) return Ok(_service.UpdateProduct(product));
                else return BadRequest("Campos Inválidos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Description("Method to delete product data")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                // Id validation and starting delete routine
                if (id > 0)
                {
                    _service.DeleteProduct(id);
                    return Ok();
                }

                else return NotFound("Id Inválido");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Description("Method to get only one specific product data")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                // Id validation and start search routine 
                if (id > 0) return Ok(_service.GetProduct(id));
                else return NotFound("Id Inválido");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Description("Method to get all products data")]
        public IActionResult GetProducts()
        {
            try
            {
                //Search routine 
                return Ok(_service.GetProducts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}
