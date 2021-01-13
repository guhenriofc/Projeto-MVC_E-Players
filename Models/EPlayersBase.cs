using System.Collections.Generic;
using System.IO;

namespace Projeto_MVC_E_Players.Models
{
    public abstract class EPlayersBase
    {
        public void CreateFolderAndFile(string path)
        {
            //Criando Arquivo
            //Database/Equipe.csv
            string folder = path.Split("/")[0];

            if (!Directory.Exists(folder))
            {
                //Criando a pasta
                //Para criar a pasta deve se usa-la como argumento
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(path))
            {
                //Criando o arquivo
                //Sempre que criar um arquivo deve passar o path inteiro como argumento
                File.Create(path);
            }
        }

        public List<string> ReadAllLinesCSV(string path)
        {
            List<string> linhas = new List<string>();

            //using -> abrir e fechar determinado arquivo ou conexao
            //StreamReader -> Ler as informações do CSV
            using (StreamReader file = new StreamReader(path))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                //Lendo todas as linhas ate chegar na ultima
                {
                    //Adicionar a linha lida na lista linhas
                    linhas.Add(linha);
                }
            }

            return linhas;
        }

        public void RewriteCSV(string path, List<string> linhas)
        {
            //StreamWriter -> Escrita de arquivos
            using (StreamWriter ouput = new StreamWriter(path))
            {
                foreach (var item in linhas)
                {
                    ouput.Write(item + '\n');
                }
            }
        }
    }
}