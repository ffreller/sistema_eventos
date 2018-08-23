using System;
using ProjetoEvento.ClassePai.ClassesFilhas;

namespace ProjetoEventoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = "";

            do{
                Console.WriteLine("Digite a Opção desejada");
                Console.WriteLine("1 - Shows");
                Console.WriteLine("2 - Teatro");
                Console.WriteLine("3 - Cinema");
                Console.WriteLine("9 - Sair");
                
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        OpcaoShow();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }

            }while(opcao != "9");
        }

        static void OpcaoShow(){
            
            string opcao = "";
            do{
                Console.WriteLine("Digite a opção desejada");
                Console.WriteLine("1 - Cadastrar Show");
                Console.WriteLine("2 - Pesquisar Show pelo Titulo");
                Console.WriteLine("3 - Pesquisar Show pela Data");
                Console.WriteLine("9 - Voltar");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        {
                            Console.WriteLine("Digite o titulo do Show");
                            string titulo = Console.ReadLine();
                            Console.WriteLine("Digite o local");
                            string local = Console.ReadLine();
                            Console.WriteLine("Digite a lotação");
                            int lotacao = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Digite a duração");
                            string duracao = Console.ReadLine();
                            Console.WriteLine("Digite a data");
                            DateTime datashow = Convert.ToDateTime( Console.ReadLine());
                            Console.WriteLine("Digite a classificação");
                            int classificacao = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Digite o Artista");
                            string artista = Console.ReadLine();
                            Console.WriteLine("Digite o genero musical");
                            string generomusical = Console.ReadLine();

                            Show show = new Show(titulo,local,lotacao,duracao,
                                                classificacao,datashow,artista,generomusical);
                            bool cadastrosucesso = show.Cadastrar();
                            
                            if(cadastrosucesso)
                                Console.WriteLine("Show Cadastrado");
                            else
                                Console.WriteLine("Ocorreu um ero, contacte o administrador do sistema");

                            break;
                        }
                    case "2":{
                            Console.WriteLine("Digite o titulo do show");
                            string titulo = Console.ReadLine();
                            Show show = new Show();
                            string resultado = show.Pesquisar(titulo);
                            Console.WriteLine(resultado);
                            break;
                        }
                    case "3":{
                        Console.WriteLine("Digite a data do show");
                        DateTime datashow = Convert.ToDateTime(Console.ReadLine());
                        Show show = new Show();
                        string resultado = show.Pesquisar(datashow);
                        Console.WriteLine(resultado); 
                        break;
                    }
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            }while(opcao != "9");

        }
    }
}
