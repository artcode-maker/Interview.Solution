using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Interview.Models
{
    /// <summary>
    /// Represents client's class
    /// </summary>
    [Serializable]
    public class Client : INotifyPropertyChanged
    {
        #region Constructors
        /// <summary>
        /// Constructor returns new instance of Client without arguments
        /// </summary>
        public Client() { }

        /// <summary>
        /// Constructor returns new instance of Client with entire arguments
        /// </summary>
        /// <param name="firstName">Client's first name</param>
        /// <param name="familyName">Client's second name</param>
        /// <param name="password">Password for client dashboard</param>
        /// <param name="email">Email address for client's identity</param>
        /// <param name="address">Client's address</param>
        /// <param name="issue">Technical issue of client</param>
        public Client(
            string firstName, 
            string familyName,
            string email,
            string address,
            string issue)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Email = email;
            Address = address;
            Issue = issue;
        }
        #endregion

        #region Fields
        private long clientId;
        private string firstName;
        private string familyName;
        private string email;
        private string address;
        private string issue;
        #endregion

        #region Properties
        /// <summary>
        /// Identifier for clients's entries
        /// </summary>
        public long ClientId 
        {
            get => clientId;

            set
            {
                if (value >= 0)
                {
                    clientId = value;
                    OnPropertyChanged(nameof(ClientId));
                }
                else
                {
                    clientId = 0;
                    //throw new ArgumentException("Invalid ID");
                }
            }
        }

        /// <summary>
        /// Client's first name
        /// </summary>
        [Required(ErrorMessage = "Please enter first name")]
        [DisplayName("Имя")]
        public string FirstName
        {
            get => firstName;

            set
            {
                if (value.Length <= 20 && value.Length >= 2)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
                else
                {
                    firstName = "Invalid Data";
                    //throw new ArgumentException("Invalid First Name. Length from 2 to 20 characters");
                }
            }
        }

        /// <summary>
        /// Client's second name
        /// </summary>
        [Required(ErrorMessage = "Please enter family name")]
        [DisplayName("Фамилия")]
        public string FamilyName
        {
            get => familyName;

            set
            {
                if (value.Length <= 20 && value.Length >= 2)
                {
                    familyName = value;
                    OnPropertyChanged(nameof(FamilyName));
                }
                else
                {
                    familyName = "Invalid Data";
                    //throw new ArgumentException("Invalid Family Name. Length from 2 to 20 characters");
                }
            }
        }

        /// <summary>
        /// Email address for client's identity
        /// </summary>
        [Required(ErrorMessage = "Please enter email")]
        [DisplayName("Электронная почта")]
        public string Email
        {
            get => email;

            set
            {
                string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
                else
                {
                    email = "Invalid Data";
                    //throw new ArgumentException("Invalid Email");
                }
            }
        }

        /// <summary>
        /// Client's address
        /// </summary>
        [DisplayName("Адрес")]
        public string Address
        {
            get => address;

            set
            {
                if (value.Length <= 30 && value.Length >= 10)
                {
                    address = value;
                    OnPropertyChanged(nameof(Address));
                }
                else
                {
                    address = "Invalid Data";
                    //throw new ArgumentException("Invalid Address. Length from 10 to 30 characters");
                }
            }
        }

        /// <summary>
        /// Technical issue of client
        /// </summary>
        [Required(ErrorMessage = "Please discribe your issue")]
        [DisplayName("Техническая проблема")]
        public string Issue
        {
            get => issue;

            set
            {
                if (value.Length <= 100 && value.Length >= 10)
                {
                    issue = value;
                    OnPropertyChanged(nameof(Issue));
                }
                else
                {
                    issue = "Invalid Data";
                    //throw new ArgumentException("Invalid Address. Length from 10 to 30 characters");
                }
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Serializer of Client object
        /// </summary>
        /// <returns>void</returns>
        public static void SerializeClients(ObservableCollection<Client> Clients)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы (xml)|*.xml|Все файлы|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Client>));
                using (Stream fStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    xml.Serialize(fStream, Clients);
                }
            }
        }
        /// <summary>
        /// Static deserializer of Client's objects
        /// </summary>
        /// <returns>ObservableCollection of Clients</returns>
        public static ObservableCollection<Client> DeserializeClients(ObservableCollection<Client> Clients)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы (xml)|*.xml|Все файлы|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Client>));
                using (Stream fStream = File.OpenRead(openFileDialog.FileName))
                {
                    Clients = xml.Deserialize(fStream) as ObservableCollection<Client>;
                    return Clients;
                }
            }
            else return Clients;
        }

        public override string ToString()
            => $"Client: Id = {ClientId}, First Name = {FirstName}, Family Name = {FamilyName}, Email = {Email}";

        #endregion
    }
}
