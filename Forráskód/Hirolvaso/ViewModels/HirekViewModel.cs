using CommunityToolkit.Mvvm.Input;
using Hirolvaso.Models;
using Hirolvaso.Repositories;
using System.Collections.ObjectModel;

namespace Hirolvaso.ViewModels
{
    public class HirekViewModel
    {
        private readonly GenericAPIRepository<List<Hir>> repository;
        public ObservableCollection<Hir> Hirek { get; set; }
        public AsyncRelayCommand<string> OpenLinkCommand { get; set; }

        public HirekViewModel()
        {
            repository = new GenericAPIRepository<List<Hir>>(OldalTipus.Hirek);
            Hirek = new ObservableCollection<Hir>();
            OpenLinkCommand = new AsyncRelayCommand<string>(OpenLink);
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            Hirek.Clear();
            var response = await repository.GetValueAsync();
            foreach (var item in response)
            {
                Hirek.Add(item);
            }
        }

        private async Task OpenLink(string url)
        {
            Uri uri = new Uri(url);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}
