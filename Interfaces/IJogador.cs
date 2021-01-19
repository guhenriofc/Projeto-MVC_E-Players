using System.Collections.Generic;
using Projeto_MVC_E_Players.Models;

namespace Projeto_MVC_E_Players.Interfaces
{
    public interface IJogador
    {
        void Create(Jogador j);
        List<Jogador> ReadAll();
        void Update(Jogador j);
        void Delete(int id);
    }
}