using Microsoft.AspNetCore.Mvc;
using SistemaCadastroContatoMVC.Models;
using SistemaCadastroContatoMVC.Repository;

namespace SistemaCadastroContatoMVC.Controllers;

public class ContatoController : Controller

{
    private readonly IContatoRepository _contatoRepository;
    public ContatoController(IContatoRepository repository)
    {
        _contatoRepository = repository;
    }

    public IActionResult Index()
    {
        var contatos = _contatoRepository.ListarContatos();
        return View(contatos);
    }
    public IActionResult CriarContato()
    {
        return View();
    }

    public IActionResult EditarContato()
    {
        return View();
    }
    public IActionResult DeletarContato()
    {
        return View();
    }



    [HttpPost]
    public IActionResult CriarContato(ContatoModel contato)
    {
        _contatoRepository.CriarContato(contato);

        return RedirectToAction("Index");
    }

    [HttpPost("/{id}")]
    public IActionResult EditarContato(int id, ContatoModel contato)
    {
        try
        {
            var contatoEditado = _contatoRepository.EditorContato(id, contato);
            return RedirectToAction("Index");
        }
        catch (Exception erro)
        {
            return BadRequest(new { msg = "Houve um erro na edição do contato" });
        }
    }
}