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

    [HttpGet]
    public IActionResult EditarContato(int id)
    {
        ContatoModel contato = _contatoRepository.ListarContatoPorId(id);
        return View(contato);
    }

    [HttpGet]
    public IActionResult DeletarContato(int id)
    {
        ContatoModel contato = _contatoRepository.ListarContatoPorId(id);

        return View(contato);
    }



    [HttpPost]
    public IActionResult CriarContato(ContatoModel contato)
    {
        _contatoRepository.CriarContato(contato);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult EditarContato(ContatoModel contato)
    {
        try
        {
            Console.WriteLine(contato.Id);
            _contatoRepository.EditorContato(contato);
            return RedirectToAction("Index");
        }

        catch (Exception erro)
        {
            return BadRequest(new { msg = "Houve um erro na edição do contato" });
        }

    }

    public IActionResult ConfirmacaoDeletarContato(int id)
    {
        _contatoRepository.DeletarContato(id);

        return RedirectToAction("Index");
    }
}