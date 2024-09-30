using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClientesControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public ClientesControllers(Context context,
                                   IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        #region Get
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await context.Clientes.ToListAsync();
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
                context.Clientes.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
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
            var pepe = await context.Clientes.Where(e => e.Id == id).FirstOrDefaultAsync();

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
                context.Clientes.Update(pepe);
                await context.SaveChangesAsync();
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
            var existe = await context.Clientes.AnyAsync(x => x.Id == id);
            if (!existe) 
            {
                return NotFound($"El Cliente {id} no existe.");
            }
            Cliente EntidadABorrar = new Cliente();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}
