using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SportzMagazine.Models;
using Windows.Storage;

namespace SportzMagazine.Persistency
{
    public class Facade
    {
        private string xlmFileName = "SportzMagazine.txt";

        public void SaveSubscriptionAsXaml(ObservableCollection<Subscription> subscription)
        {
            XmlSerializer xlmSerializer =new XmlSerializer(subscription.GetType());
            StringWriter textwriter=new StringWriter();
            xlmSerializer.Serialize(textwriter,subscription);
            SerializeSubscritionFile(textwriter.ToString(),xlmFileName);
        }

        public async void SerializeSubscritionFile(string subscriptionString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(localFile, subscriptionString);
        }

        internal void SaveSubscriptionAsXaml(ObservableCollection<Models.Subscription> listInd)
        {
            throw new NotImplementedException();
        }
    }
}
