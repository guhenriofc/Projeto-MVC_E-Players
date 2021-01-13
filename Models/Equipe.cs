using System.Collections.Generic;
using System.IO;
using Projeto_MVC_E_Players.Interfaces;

namespace Projeto_MVC_E_Players.Models
{
    public class Equipe : EPlayersBase , IEquipes
    {
        // ID - Identificadoor
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";
        public Equipe()
        {
            CreateFolderAndFile(PATH);
            //Arquivo para armazenar as equipes
        }

        public string Prepare(Equipe e)
        {
            //Preparando uma equipe
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
        
        public void Create(Equipe e)
        {
            //Criando uma equipe
            string[] linhas = { Prepare(e) };

            //Armazenando as equipes criadas
            File.AppendAllLines(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            //Ler todas as linhas do csv
            string[] linhas = File.ReadAllLines(PATH);

            //Percorrer as linhas e adcionar na lista de equipes cada objeto equipe
            foreach (var item in linhas)
            {
                //Quebrar em um array e passar para uma equipe
                //1;Iphone;Iphone.jpg
                string[] linha = item.Split(";");

                //[0] = 1
                //[1] = Iphone
                //[2] = Iphone.jpg

                //Criamos o objeto equipe
                Equipe equipe = new Equipe();

                //Alimentamos o objeto equipe
                equipe.IdEquipe = int.Parse( linha[0] );
                equipe.Nome     = linha[1];
                equipe.Imagem   = linha[2];

                //Adicionamos a equipe na lista de equipes
                equipes.Add( equipe );
            }


            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            
            //Remover a linha que tenha o codigo a ser alterado
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());

            //Adicionar a linha alterada no final do arquivo
            linhas.Add( Prepare(e) );

            //Reescrever o CSV com as informações
            RewriteCSV(PATH , linhas);
            
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            
            //Remover a linha que tenha o codigo a ser alterado
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            //Reescrever o CSV com as informações
            RewriteCSV(PATH , linhas);
            
        }
    }
}