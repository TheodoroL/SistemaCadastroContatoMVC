using SistemaCadastroContatoMVC.Data;
using SistemaCadastroContatoMVC.Models;

namespace SistemaCadastroContatoMVC.Repository;


public class ContatoRepository : IContatoRepository
{
    private BancoContext _bancoContext;
    public ContatoRepository(BancoContext context)

    {
        _bancoContext = context;
    }

    public ContatoModel CriarContato(ContatoModel contato)
    {
        _bancoContext.Contatos.Add(contato);
        _bancoContext.SaveChanges();

        return contato;
    }


    public List<ContatoModel> ListarContatos()
    {
        return _bancoContext.Contatos.ToList();
    }

    public void EditorContato(ContatoModel contato)
    {
        var contatoBuscado = ListarContatoPorId(contato.Id);

        contatoBuscado.Nome = contato.Nome;
        contatoBuscado.Email = contato.Email;
        contatoBuscado.Telefone = contato.Telefone;

        _bancoContext.Contatos.Update(contatoBuscado);
        _bancoContext.SaveChanges();

    }

    public ContatoModel ListarContatoPorId(int id)
    {

        var contatoBuscado = _bancoContext.Contatos.FirstOrDefault(c => c.Id == id);

        if (contatoBuscado == null)
        {
            throw new Exception("Houve um erro na edição do contato");
        }

        return contatoBuscado;
    }

    public bool DeletarContato(int id)
    {
        var contatoBuscado = ListarContatoPorId(id);
        if (contatoBuscado == null) return false;

        _bancoContext.Contatos.Remove(contatoBuscado);
        _bancoContext.SaveChanges();

        return true;
    }
}
