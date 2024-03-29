﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCHome.Context;
using MVCHome.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MVCHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _context.UsuarioDb.Include(z => z.Rol).ToListAsync();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> IndexCopy()
        {
            var response = await _context.UsuarioDb.Include(z => z.Rol).ToListAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.RolesVb = _context.RolDb.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRol.ToString()
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Usuario request)
        {
            if(request != null)
            {
                Usuario usuario=new Usuario();
                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.UsuarioDb.Add(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        // FUNCIONES PARA EDITAR
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _context.UsuarioDb.Find(id);
            if(usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> EditarUsuario(Usuario response)
        {
            Usuario usuario = new Usuario();
            usuario = _context.UsuarioDb.Find(response.PkUser);

            if (usuario != null)
            {
                usuario.Nombre = response.Nombre;
                usuario.User = response.User;
                usuario.Password = response.Password;
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        //FUNCIONES PARA ELIMINAR
        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _context.UsuarioDb.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarUsuario(Usuario response)
        {
            Usuario usuario = new Usuario();
            usuario.PkUser = response.PkUser;

            _context.UsuarioDb.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
