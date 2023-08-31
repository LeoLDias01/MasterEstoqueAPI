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
    public class ProductCountController : ControllerBase
    {
        #region ..:: Instances and Variables ::..
        private readonly ProductCountValidation _validation = new ProductCountValidation();
        private readonly IMasterEstoqueAPIService _service;
        #endregion

        #region ..:: Constructor ::..
        public ProductCountController(IMasterEstoqueAPIService service) => _service = service;
        #endregion

        #region ..:: Requests and Responses ::..
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Method to insert a new product count ")]
        public IActionResult CreateProductCount([FromBody] ProductCount productCount)
        {
            try
            {
                // Fields validation and start create routine
                if (_validation.InsertValidation(productCount)) return Created("InsertProductCount", _service.InsertProductCount(productCount));
                else return BadRequest("Campos Inválidos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Description("Method to get only one specific product count")]
        public IActionResult GetProductCount(int id)
        {
            try
            {
                // Id validation and start search routine 
                if (id > 0) return Ok(_service.GetProductCount(id));
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
        [Description("Method to get all products count")]
        public IActionResult GetProducts()
        {
            try
            {
                //Search routine 
                return Ok(_service.GetProductsCount());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}
