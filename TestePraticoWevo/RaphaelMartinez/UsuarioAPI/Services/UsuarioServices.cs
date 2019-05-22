using System.Collections.Generic;
using System.Linq;
using UsuarioAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace UsuarioAPI.Services
{
    public class UsuarioServices
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioServices(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("testePraticoWevo"));
            var database = client.GetDatabase("testePraticoWevo");
            _usuarios = database.GetCollection<Usuario>("Usuarios");
        }

        public List<Usuario> GetAll()
        {
            return _usuarios.Find(usuario => true).ToList();
        }

        public Usuario Get(string id)
        {
            return _usuarios.Find<Usuario>(usuario => usuario.Id == id).FirstOrDefault();
        }

        public Usuario Create(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            return usuario;
        }

        public void Update(string id, Usuario usuarioIn)
        {
            _usuarios.ReplaceOne(usuario => usuario.Id == id, usuarioIn);
        }

        public void Remove(Usuario usuarioIn)
        {
            _usuarios.DeleteOne(usuario => usuario.Id == usuarioIn.Id);
        }

        public void Remove(string id)
        {
            _usuarios.DeleteOne(usuario => usuario.Id == id);
        }
    }
}