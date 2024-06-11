using CommunityToolkit.Mvvm.ComponentModel;
using ExemploHTTP.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ExemploHTTP.ViewModels
{
    public partial class PostagemViewModel : ObservableObject
    {
        private readonly RestService _restService;

        [ObservableProperty]
        private ObservableCollection<Postagem> _postagens = new ObservableCollection<Postagem>();

        public PostagemViewModel()
        {
            _restService = new RestService();
            GetPostagensAsyncCommand = new Command(async () => await GetPostagensAsync());
        }

        public ICommand GetPostagensAsyncCommand { get; }

        public async Task GetPostagensAsync()
        {
            Postagens = await _restService.GetPostagensAsync();
        }
    }
}
