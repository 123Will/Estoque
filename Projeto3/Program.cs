using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto3
{
    partial class  Program
   {
        

        static List<IEstoque> produtos = new List<IEstoque>();
        private static object encoder;
        private static int i;

        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (escolheuSair == false)
            {
                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("1-Listar\n2-Adcionar\n3-Remover\n4-Registrar entrada\n5-Registrar saida\n6-Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

                if (opInt > 0 && opInt < 7)
                {
                    Menu escolha = (Menu)opInt;
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adcionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }

                }
                else
                {
                    escolheuSair = true;

                }
                Console.Clear();
            }
        }


        
        static void Listagem()
        {
            Console.WriteLine("Lista de produtos");
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine(); 
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer remover");
            int id = int.Parse(Console.ReadLine());
            if(id>= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar entrada");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar baixa");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produtos");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);
            switch (escolhaInt)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
            

            
        }

        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastro produto fisico: ");
            Console.WriteLine("nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }
        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastro produto fisico: ");
            Console.WriteLine("nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }
        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso: ");
            Console.WriteLine("nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();
        }

        static void Salvar()
        {

            FileStream stream = new FileStream("produto.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            enconder.Serialize(stream, produtos);

            stream.Close();

        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produto.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            try
            {

               produtos = (List<IEstoque>)enconder.Deserialize(stream);


                if (produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch(Exception e)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();
            


        }

    }
}         

  

