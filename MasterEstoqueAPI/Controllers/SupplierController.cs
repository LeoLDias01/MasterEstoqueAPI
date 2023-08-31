using MasterEstoqueAPI.Business.Services;
using MasterEstoqueAPI.Business.Validators;
using MasterEstoqueAPI.Domain.Infra;
using MasterEstoqueAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Slapper.AutoMapper;

namespace MasterEstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        #region ..:: Instances and Variables ::..
        private readonly SupplierValidation _validation = new SupplierValidation();
        private readonly IMasterEstoqueAPIService _service;
        #endregion

        #region ..:: Constructor ::..
        public SupplierController(IMasterEstoqueAPIService service)
        {
            _service = service;
        }
        #endregion

        #region ..:: Requests and Responses ::..
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] Supplier supplier)
        {
            try
            {
                if(_validation.InsertValidation(supplier)) return Created("InsertSupplier", _service.InsertSupplier(supplier));
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
        public IActionResult Update([FromBody] Supplier supplier)
        {
            try
            {
                if (_validation.AlterValidation(supplier) && supplier.Id > 0) return Ok(_service.UpdateSupplier(supplier));
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
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _service.DeleteSupplier(id);
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
        public IActionResult GetSupplier(int id)
        {
            try
            {
                if (id > 0) return Ok(_service.GetSupplier(id));
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
        public IActionResult GetSuppliers()
        {
            try
            {
                return Ok(_service.GetSuppliers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}
