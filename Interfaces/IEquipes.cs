using System.Collections.Generic;
using Projeto_MVC_E_Players.Models;

namespace Projeto_MVC_E_Players.Interfaces
{
    public interface IEquipes
    {
        //CRUD
        // Create Read Update Delete

        void Create(Equipe e);
        //Metodo para criar equipe
        List<Equipe> ReadAll();
        //Metodo para ler e listar as equipes criadas
        void Update(Equipe e);
        //Metodo para alterar as equipes criadas
        void Delete(int id);
        //Metodo para deletar a equipe pelo ID-Identificador dela

    }
}