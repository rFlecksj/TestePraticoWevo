using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Models;
using UsuarioAPI.Services;

namespace UsuarioAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase{
        private readonly UsuarioServices _usuarioService;

        public UsuarioController(UsuarioServices usuarioServices)
        {
            _usuarioService = usuarioServices;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            return _usuarioService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(string id)
        {
            var usuario = _usuarioService.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> Create(Usuario usuario)
        {
            _usuarioService.Create(usuario);

            return CreatedAtRoute("GetUsuario", new { id = usuario.Id.ToString() }, usuario);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Usuario usuarioIn)
        {
            var usuario = _usuarioService.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioService.Update(id, usuarioIn);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var usuario = _usuarioService.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioService.Remove(usuario.Id);

            return Ok();
        }
    }
}