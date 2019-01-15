using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01ConsultaCep.Servico.Modelo;
using Newtonsoft.Json;

namespace App01ConsultaCep.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP (string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;           
            return end;
        }

    }
}
