using AspCore_Crud.Models;
using AspCore_Crud.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspCore_Crud.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioDAL _funcionario;

        public FuncionarioController(IFuncionarioDAL funcionario)
        {
            _funcionario = funcionario;  
        }
        public IActionResult Index()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            listaFuncionarios = _funcionario.GetAllFuncionarios().ToList();
            return View(listaFuncionarios);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Funcionario funcionario = _funcionario.GetFuncionario(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _funcionario.AddFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Funcionario funcionario = _funcionario.GetFuncionario(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _funcionario.UpdateFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Funcionario funcionario = _funcionario.GetFuncionario(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            _funcionario.DeleteFuncionario(id);
            return RedirectToAction("Index");
        }
    }
}
