using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Teatro : Evento
    {
        public string[] Elenco { get; set; }
        public string Diretor { get; set; }

        public Teatro()
        {
            
        }
        public Teatro(string Titulo, string Local,
         int Lotacao,string Duracao, 
         int Classificacao, DateTime Data,
          string[] Elenco, string Diretor)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;
            this.Elenco = Elenco;
            this.Diretor = Diretor;
        }

        public override bool Cadastrar(){
            bool efetuado = false;
            StreamWriter arquivo = null;
            try{
                string elenco = "";

                foreach (var item in this.Elenco){
                    elenco += item + "-";
                }

                arquivo = new StreamWriter("teatro.csv",true);
                arquivo.WriteLine(
                    Titulo+";"+
                    Local+";"+
                    Duracao+";"+
                    Data+";"+
                    elenco.Substring(0, elenco.Length - 1)+";"+
                    Diretor+";"+
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
                ler = new StreamReader("teatro.csv",Encoding.Default);
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
                ler = new StreamReader("teatro.csv",Encoding.Default);
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