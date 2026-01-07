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
        try
        {
            if (!ModelState.IsValid) return View(contato);

            TempData["MensagemSucesso"] = $"Contato {contato.Nome} criado com sucesso!";
            _contatoRepository.CriarContato(contato);

            return RedirectToAction("Index");
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Ops, não foi possivel criado o contato! erro: {erro.Message}";

            return RedirectToAction("Index");

        }
    }

    [HttpPost]
    public IActionResult EditarContato(ContatoModel contato)
    {
        if (!ModelState.IsValid) return View(contato);

        try
        {
            TempData["MensagemSucesso"] = $"Contato {contato.Nome} atualizado com sucesso!";

            _contatoRepository.EditorContato(contato);
            return RedirectToAction("Index");
        }

        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Ops,ouve um erro de atualizar o contato!, error : {erro.Message}";
            return View("Index");

        }

    }

    public IActionResult ConfirmacaoDeletarContato(int id)
    {
        var deletado = _contatoRepository.DeletarContato(id);

        if (deletado)
        {
            TempData["MensagemSucesso"] = "Contato deletado com sucesso!";
        }
        else
        {
            TempData["MensagemErro"] = "Ops, não foi possível deletar o contato!";
        }

        return RedirectToAction("Index");
    }
}