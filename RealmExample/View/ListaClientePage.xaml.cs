using System;
using System.Collections.Generic;
using System.Linq;
using RealmExample.Model;
using Realms;
using Xamarin.Forms;

namespace RealmExample.View
{
    public partial class ListaClientePage : ContentPage
    {
        public ListaClientePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            this.CarregaValuesBd();

        }

        private async void CarregaValuesBd()
        {
            var realm = Realm.GetInstance();

            var list = realm.All<Cliente>().Where(c => c.Id != 0);

            List<Cliente> lista = new List<Cliente>(list);

            ListaCliente.ItemsSource = lista;

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new CadastroPage();
        }

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {

            Cliente cliente = (Cliente)e.SelectedItem;

            if (await DisplayAlert("Atenção", "Deseja excluir realmente o cliente " + cliente.Nome + "?", "Sim", "Não"))
            {
                var realm = Realm.GetInstance();

                using (var trans = realm.BeginWrite())
                {
                    realm.Remove(cliente);
                    trans.Commit();
                }

                // atualiza a lista
                this.CarregaValuesBd();
            }

        }
    }

}

