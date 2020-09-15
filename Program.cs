using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceCEP
{
    /*
     * URL do WebService nos correios adicionada nas referências:
     * https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl     
     */

    using ServiceCEP;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o CEP que deseja pesquisar: ");
            string cep = Convert.ToString(Console.ReadLine());

            if (!string.IsNullOrEmpty(cep))
                ConsultarCEP(cep);            
        }

        private static void ConsultarCEP(string cep)
        {
            using (var webservice = new AtendeClienteClient())
            {
                var resposta = webservice.consultaCEP(cep);

                Console.Clear();
                Console.WriteLine(String.Format("CEP:      {0}", resposta.cep));
                Console.WriteLine(String.Format("Endereço: {0}", resposta.end));
                Console.WriteLine(String.Format("Bairro:   {0}", resposta.bairro));
                Console.WriteLine(String.Format("Cidade:   {0}", resposta.cidade));
                Console.WriteLine(String.Format("Estado:   {0}", resposta.uf));

                Console.WriteLine("");
                Console.WriteLine("PRESSIONE QUALQUER TECLA PARA SAIR");

                Console.ReadKey();
            }
                
        }
    }
}
