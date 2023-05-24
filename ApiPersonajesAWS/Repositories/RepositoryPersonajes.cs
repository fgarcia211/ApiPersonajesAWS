using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        private int GetMaxIdPersonaje()
        {
            if (this.context.Personajes.Count() != 0)
            {
                return this.context.Personajes.Max(x => x.IdPersonaje) + 1;
            }

            return 1;
        }
        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        public async Task CreatePersonaje(Personaje personaje)
        {
            personaje.IdPersonaje = this.GetMaxIdPersonaje();
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }
    }
}
