using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{

     [System.Serializable]
     class ProdutoFisico : Produto, IEstoque
    {

        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
          

        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adcionar entrada no estoque do produto {nome}");
            Console.WriteLine("Digite a Qtd. que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            
                Console.WriteLine($"Adcionar saida no estoque do produto {nome}");
                Console.WriteLine("Digite a Qtd. que você quer dar entrada: ");
                int entrada = int.Parse(Console.ReadLine());
                 estoque -= entrada;
                Console.WriteLine("saida Registrada");
                Console.ReadLine();
            
        }

        public void Exibir()
        {
            Console.WriteLine($"nome:{nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("=============");
        }
    }
}
