using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using SportzMagazine.Models;

namespace SportzMagazine.Persistency
{
    class ObjectClean
    {
        private ObservableCollection<Subscription> listCustomers;
        private static string filenameInd= "Individual.txt";
        private static string filenameCorp = "Corporate.txt";

        public async void SaveIndividual(ObservableCollection<Subscription> subscriptions)
         {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync(filenameInd, CreationCollisionOption.ReplaceExisting);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof (ObservableCollection<Subscription>));

            using (Stream stream = await file.OpenStreamForWriteAsync() )
            {
                xmlSerializer.Serialize(stream, subscriptions);
            }
        }
        public async Task<ObservableCollection<Subscription>> LoadIndividual()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.GetFileAsync(filenameInd);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Subscription>));

            using (Stream stream = await file.OpenStreamForReadAsync())
            {
               listCustomers =  xmlSerializer.Deserialize(stream) as ObservableCollection<Subscription>;
            }
            return listCustomers;
        }

        public async void SaveCorporate(ObservableCollection<Subscription> subscriptions)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync(filenameCorp, CreationCollisionOption.ReplaceExisting);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Subscription>));

            using (Stream stream = await file.OpenStreamForWriteAsync())
            {
                xmlSerializer.Serialize(stream, subscriptions);
            }
        }
        public async Task<ObservableCollection<Subscription>> LoadCorporate()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.GetFileAsync(filenameCorp);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Subscription>));

            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                listCustomers = xmlSerializer.Deserialize(stream) as ObservableCollection<Subscription>;
            }
            return listCustomers;
        }

    }
}

