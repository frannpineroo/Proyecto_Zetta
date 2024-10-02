using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class ClienteRepositorio : Repositorio<Cliente> , IClienteRepositorio
    {
        public ClienteRepositorio(Context context) : base(context)
        {
            
        }
    }
}
