﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repositorio
{
    public class FilmeRepositorio
    {
        string CadeiaConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\65979\Documents\ExemploBancoDados02.mdf;Integrated Security=True;Connect Timeout=30";

        // Metodo que irá retornar os dados dos filmes (List<Filme>) da tabela de filmes 

        public List<Filme> ObterTodos()
        {
        
        // Cria conexao com o bando de dados e abre a conexão.

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = CadeiaConexao;
            conexao.Open();
        
        // Cria o comando para ser executado no banco de dados e diz para este comando qual a conexao que está aberta. 

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT * FROM filmes";
        
        // Cria uma tabela em memória para poder obter os dados que são retornados do banco de dados executando o comando no banco de dados.

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

        // Cria uma lista para adicionar os filmes do banco de dados
            List<Filme> filmes = new List<Filme>();
        
        // Percorre todos os registros lidos no banco de dados. 
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                // Cria um objeto com as informações obtidas do banco de dados.
                Filme filme = new Filme();
                filme.Id = Convert.ToInt32(linha["id"]);
                filme.Nome = linha["nome"].ToString();
                filme.Avaliacao = Convert.ToDecimal(linha["avaliacao"]);
                filme.Duracao = Convert.ToDateTime(linha["duracao"]);
                filme.Curtiu = Convert.ToBoolean(linha["curtiu"]);
                filme.Categoria = linha["categoria"].ToString();
                filme.TemSequencia = Convert.ToBoolean(linha["tem_sequencia"]);
                // Adiciona o objeto que foi criado a lista de filmes
                filmes.Add(filme);
            }

            // Fecha a conexao do bd
            conexao.Close();
            // retorno a lista de filmes 
            return filmes;
        }  
    }
}