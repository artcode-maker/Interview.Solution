using System.ComponentModel;
using System.Runtime.CompilerServices;
using Interview.Models;
using Interview.Commands;
using System.Collections.ObjectModel;
using System.Windows;

namespace Interview.ViewModels
{
    public class MainWindowViewModel :INotifyPropertyChanged
    {
        private ObservableCollection<Client> clients;
        private RelayCommand serializeCommand;
        private RelayCommand deserializeCommand;

        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }


        public RelayCommand SerializeCommand
        {
            get
            {
                return serializeCommand ??
                  (serializeCommand = new RelayCommand(() => 
                  {
                      Client.SerializeClients(Clients);
                      MessageBox.Show("Data has been serialized");
                  }));
            }
        }
        public RelayCommand DeserializeCommand
        {
            get
            {
                return deserializeCommand ??
                  (deserializeCommand = new RelayCommand(() =>
                  {
                      Clients = Client.DeserializeClients(Clients);
                      MessageBox.Show("Data has been deserialized");
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public MainWindowViewModel()
        {
            Clients = new ObservableCollection<Client>
            {
                new Client { ClientId = 0, FirstName = "Ivan", FamilyName = "Ivanov", Address = "г.Минск, ул.Первая, д.1", Email = "ivanov@mail.com", Issue = "Problems with computer"},
                new Client { ClientId = 1, FirstName = "Peter", FamilyName = "Petrov", Address = "г.Минск, ул.Вторая, д.2", Email = "petrov@mail.com", Issue = "Problems with phone"}
            };
        }
    }
}
