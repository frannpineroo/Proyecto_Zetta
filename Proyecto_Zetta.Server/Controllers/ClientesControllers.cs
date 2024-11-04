using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Proyecto_Zetta.DB.Data;
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
        private readonly IMapper mapper;

        public ClientesControllers(IClienteRepositorio repositorio,
                                   IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
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
            var existe = await repositorio.Existe(id);
            return existe;
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearClienteDTO entidadDTO)
        {
            try
            {
                //Cliente entidad = new Cliente();
                //entidad.Codigo = entidadDTO.Codigo;
                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Apellido = entidadDTO.Apellido;
                //entidad.Direccion = entidadDTO.Direccion;
                //entidad.Localidad = entidadDTO.Localidad;
                //entidad.Telefono = entidadDTO.Telefono;

                Cliente entidad = mapper.Map <Cliente>(entidadDTO);
                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                
                return BadRequest(e.InnerException?.Message);
            }
        }
        #endregion

        #region Put
        [HttpPut("{id:int}")] //api/Clientes/2
        public async Task<ActionResult> Put(int id, Cliente entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var pepe = await repositorio.SelectById(id);

            if (pepe == null)
            {
                return NotFound("No existe el cliente mencionado.");
            }

            pepe.Nombre = entidad.Nombre;
            pepe.Apellido = entidad.Apellido;
            pepe.Direccion = entidad.Direccion;
            pepe.Localidad = entidad.Localidad;
            pepe.Telefono = entidad.Telefono;
            pepe.Mail = entidad.Mail;
            pepe.Descripcion = entidad.Descripcion;

            try
            {
                await repositorio.Update(id, pepe);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.InnerException?.Message);
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
