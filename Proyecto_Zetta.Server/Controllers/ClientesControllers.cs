using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Server.Repositorio;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Controllers
{
	[ApiController]
    [Route("api/Clientes")]
    public class ClientesControllers : ControllerBase
    {
        private readonly IClienteRepositorio repositorio;

        public ClientesControllers(IClienteRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }


        #region Get
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region GetById
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> Get(int id) 
        {
            Cliente? holanda = await repositorio.SelectById(id);
            if (holanda == null)
            {
                return NotFound();
            }
            return holanda;
        }
        #endregion

        #region Existe
        [HttpGet("existe/{id:int}")] //api/Clientes/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Cliente entidad)
        {
            try
            {
                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Put
        [HttpPut("{id:int}")] //api/Clientes/2
        public async Task<ActionResult> Put(int id, [FromBody] Cliente entidad)
        {
            try
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                var pepe = await repositorio.Update(id, entidad);

                if (!pepe)
                {
                    return BadRequest("No se pudo actualizar el cliente.");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id:int}")] //api/Clientes/2
        public async Task<ActionResult> Delete(int id) 
        {
            var existe = await repositorio.Existe(id);
            if (!existe) 
            {
                return NotFound($"El Cliente {id} no existe.");
            }
            Cliente EntidadABorrar = new Cliente();
            EntidadABorrar.Id = id;
            await repositorio.Delete(id);
            return Ok();
        }
        #endregion
    }
}
