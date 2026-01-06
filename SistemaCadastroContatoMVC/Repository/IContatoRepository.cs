using SistemaCadastroContatoMVC.Models;

namespace SistemaCadastroContatoMVC.Repository;

public interface IContatoRepository
{
    ContatoModel CriarContato(ContatoModel contato);
    List<ContatoModel> ListarContatos();

    ContatoModel ListarContatoPorId(int id);
    void EditorContato(ContatoModel contato);

    bool DeletarContato(int id);
}
