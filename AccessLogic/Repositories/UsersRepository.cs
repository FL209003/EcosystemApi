using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Utility;

namespace AccessLogic.Repositories
{
    public class UsersRepository : IRepositoryUsers
    {
        public EcosystemContext Context { get; set; }

        public UsersRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(User u)
        {
            try
            {
                if (u != null)
                {
                    u.Validate();
                    Context.Users.Add(u);
                    Context.SaveChanges();
                }
                else throw new InvalidOperationException("Error al crear usuario, intente nuevamente.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> FindAll()
        {
            return Context.Users;
        }

        public User FindById(int id)
        {
            User? user = Context.Users.Find(id);
            if (user != null)
            {
                return user;
            }
            throw new InvalidOperationException("No se encontró un usuario con ese id.");
        }

        public User FindByName(string username)
        {
            User? user = Context.Users.Where(us => us.Username == username).SingleOrDefault();
            if (user != null)
            {
                return user;
            }
            throw new InvalidOperationException("No se encontró un usuario con ese nombre de usuario.");
        }

        public void Remove(User u)
        {
            if (u != null)
            {
                Context.Users.Remove(u);
                Context.SaveChanges();
            }
            throw new InvalidOperationException("El usuario que intenta eliminar no existe.");
        }

        public void Update(User u)
        {
            if (u != null)
            {
                Context.Users.Update(u);
                Context.SaveChanges();
            }
            throw new InvalidOperationException("El usuario que intenta actualizar no existe.");
        }
    }
}
