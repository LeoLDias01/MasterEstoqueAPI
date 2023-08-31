using MasterEstoqueAPI.Business.Services;
using MasterEstoqueAPI.Business.Validators;
using MasterEstoqueAPI.Domain.Infra;
using MasterEstoqueAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MasterEstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupController : ControllerBase
    {
        #region ..:: Instances and Variables ::..
        private readonly ProductGroupValidation _validation = new ProductGroupValidation();
        private readonly IMasterEstoqueAPIService _service;
        #endregion

        #region ..:: Constructor ::..
        public ProductGroupController(IMasterEstoqueAPIService service )
        {
            _service = service;
        }
        #endregion

        #region ..:: Requests and Responses ::..
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateProductGroup([FromBody] ProductGroup productGroup)
        {
            try
            {
                // Fields validation and start create routine
                if (_validation.InsertValidation(productGroup)) return Created("InsertProductGroup", _service.InsertProductGroup(productGroup));
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
        public IActionResult UpdateProductGroup([FromBody] ProductGroup productGroup)
        {
            try
            {
                // Fields validation and start update routine
                if (_validation.AlterValidation(productGroup)) return Ok(_service.UpdateProductGroup(productGroup));
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
        public IActionResult DeleteProductGroup(int id)
        {
            try
            {
                if (id > 0)
                {
                    // Delete routine
                    _service.DeleteProductGroup(id);
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
        public IActionResult GetProductGroup(int id)
        {
            try
            {
                // Id validation and start search routine 
                if (id > 0) return Ok(_service.GetProductGroup(id));
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
        public IActionResult GetProductsGroup()
        {
            try
            {
                //Search routine 
                return Ok(_service.GetProductsGroup());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}
