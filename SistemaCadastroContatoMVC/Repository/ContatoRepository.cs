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

    public void EditorContato(int id, ContatoModel contato)
    {
        var contatoBuscado = ListarContatoPorId(id);

        contato.Nome = contato.Nome;
        contato.Email = contato.Email;

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
}
