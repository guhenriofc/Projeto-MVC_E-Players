using System.Collections.Generic;
using System.IO;
using Projeto_MVC_E_Players.Interfaces;

namespace Projeto_MVC_E_Players.Models
{
    public class Jogador : EPlayersBase , IJogador
        {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }

        //Login
        public string Email { get; set; }
        public string Senha { get; set; }

        public const string PATH = "Database/Jogador.csv";
        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.Email};{j.Senha}";
        }

        public void Create(Jogador j)
        {
            string[] linhas = { Prepare(j)};
            File.AppendAllLines(PATH, linhas);
        }

        public List<Jogador> ReadAll()
        {
            List<Jogador> jogador = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jogadores = new Jogador();
                jogadores.IdJogador = int.Parse(linha[0]);
                jogadores.Nome = linha[1];
                jogadores.Email = linha[2];
                jogadores.Senha = linha[3];

                jogador.Add( jogadores );

            }

            return jogador;
        }

        public void Update(Jogador j)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add( Prepare(j) );                        
            RewriteCSV(PATH, linhas);    

        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            
            linhas.RemoveAll(x => x.Split(";")[0] == IdJogador.ToString());                        
            RewriteCSV(PATH, linhas);
        }
    }
}