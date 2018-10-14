using System;
using System.Collections.Generic;
using System.Linq;
using RealmExample.Model;
using Realms;
using Xamarin.Forms;

namespace RealmExample.View
{
    public partial class CadastroPage : ContentPage
    {
        public CadastroPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            if (!String.IsNullOrEmpty(xEmail.Text) && !String.IsNullOrEmpty(xNome.Text))
            {

                var realm = Realm.GetInstance();

                var countCliente = realm.All<Cliente>().Where(c => c.Id != 0).Count();

                Cliente cliente = new Cliente();
                cliente.Id = countCliente + 1;
                cliente.Nome = xNome.Text;
                cliente.Email = xEmail.Text;
                cliente.Idade = (int)xAge.Value;

                realm.Write(() => realm.Add(cliente, update: true));

                // informa que foi gravado com sucesso
                await DisplayAlert("Atenção", cliente.Nome + " foi salvo com sucesso.", "OK");
                this.ClickReturn();

            }
            else
            { // preencha corretamanete os dados
                await DisplayAlert("Atenção", "Por favor, informe um Nome e E-mail válidos.", "OK");
            }

        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            this.ClickReturn();
        }

        private void ClickReturn()
        {
            // retorna para Lista de Clientes
            Application.Current.MainPage = new ListaClientePage();
        }
    }
}
