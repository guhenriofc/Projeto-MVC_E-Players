using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_MVC_E_Players.Models;

namespace Projeto_MVC_E_Players.Controllers
{
    //http://localhost:5001/Equipe
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
        //Criando um objeto equipe, instanciando a classe, equipe com a estrutura Equipe

        //http://localhost:5001/Equipe/Listar
        [Route("Listar")]
        public IActionResult Index()
        //Metodo Listar, mostrar a tela de equipes na tela do usuario
        {
            //Listando todas as equipes e enviando para a View através da ViewBag.Equipes
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        //http://localhost:5001/Equipe/Cadastrar
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        //Cadastrando os dados que o usuario enviou, para o form -> formulario
        {
            //Criamos uma nova instancia de Equipe
            //e armazenamos os dados enviados pelo usuario
            //atraves do formulario
            //e salvamos no objeto novaEquipe
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome     = form["Nome"];
            novaEquipe.Imagem   = form["Imagem"];

            //Chamando o metodo Create para salvar
            //a novaEquipe no CSV
            equipeModel.Create(novaEquipe);
            //Listar e armazer na ViewBag
            ViewBag.Equipes = equipeModel.ReadAll();


            return LocalRedirect("~/Equipe/Listar");
        }

    }
}