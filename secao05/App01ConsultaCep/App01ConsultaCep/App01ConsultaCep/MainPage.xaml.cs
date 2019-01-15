using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01ConsultaCep.Servico.Modelo;
using App01ConsultaCep.Servico;

namespace App01ConsultaCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCep;            
        }

        private void BuscarCep (object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();

            if (isValidCep (cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço:{0},{1},{2},{3},{4},{5}", end.complemento, end.logradouro, end.bairro, end.localidade, end.uf, end.cep);
                    }
                    else
                    {
                        DisplayAlert("ERRO Na Busca", "Não foi encontrado nenhum endereço para o CEP informado!", "OK");
                    }                    
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }                
            }            
        }

        private bool isValidCep(string cep)
        {
            int novoCep = 0;

            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("ERRO", "CEP Invalido! O CEP deve ser composto apenas por numeros", "OK");
                return false;
            }

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Invalido! O CEP deve conter 8 caracteres.", "OK");
                return false;
            }
            return true;
        }
    }
}
