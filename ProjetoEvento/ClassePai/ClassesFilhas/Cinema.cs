using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Cinema : Evento
    {
        public DateTime[] Sessoes { get; set; }
        public string Genero { get; set; }

        public Cinema()
        {
            
        }

        
        public Cinema(string Titulo, string Local,
         int Lotacao,string Duracao, 
         int Classificacao, DateTime Data,
          DateTime[] Sessoes, string Genero)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;
            this.Sessoes = Sessoes;
            this.Genero = Genero;
        }

        public override bool Cadastrar(){
            bool efetuado = false;
            StreamWriter arquivo = null;
            try{
                string sessoes = "";

                foreach (var item in this.Sessoes){
                    sessoes += item + "-";
                }

                arquivo = new StreamWriter("cinema.csv",true);
                arquivo.WriteLine(
                    Titulo+";"+
                    Local+";"+
                    Duracao+";"+
                    Data+";"+
                    sessoes.Substring(0, sessoes.Length - 1)+";"+
                    Genero+";"+
                    Lotacao+";"+
                    Classificacao
                );
                efetuado = true;
            }
            catch(Exception ex){
                throw new Exception("Erro ao tentar gravar o arquivo "+ex.Message);
            }
            finally{
                arquivo.Close();
            }
            return efetuado;
        }
        public override string Pesquisar(string Titulo){
            string resultado = "Evento não encontrado";
            StreamReader ler = null;
            try{
                ler = new StreamReader("cinema.csv",Encoding.Default);
                string linha = "";
                while((linha=ler.ReadLine())!=null){
                    string[] dados = linha.Split(';');
                    if(dados[0]==Titulo){
                        resultado = linha;
                        break;
                    }
                }                
            }
            catch(Exception ex){
                resultado = "Erro ao tentar ler o arquivo. "+ex.Message;
            }
            finally{
                ler.Close();
            }
            return resultado;
        }
        public override string Pesquisar(DateTime Data){
            string resultado = "Não existem eventos para a data";
            StreamReader ler = null;
            try{
                ler = new StreamReader("cinema.csv",Encoding.Default);
                string linha = "";
                while((linha=ler.ReadLine())!=null){
                    string[] dados = linha.Split(';');
                    if(dados[3]==Data.ToString()){
                        resultado = linha;
                        break;
                    }

                }
                
            }
            catch(Exception ex){
                resultado = "Erro ao tentar ler o arquivo. "+ex.Message;
            }
            finally{
                ler.Close();
            }
            return resultado;
        }
    }
}