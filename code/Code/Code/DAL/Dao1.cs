using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Code.DAL
{
    class Dao1
    {
        private readonly DataBase database;
        const string filePath = "store.bin";
        public Dao1(DataBase database)
        {
            this.database = database;
        }
        public void Save()
        {
            using (Stream stream = File.Create(filePath))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, database);
            }
        }


        public void Load()
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                var serializer = new BinaryFormatter();
                DataBase db = (DataBase)serializer.Deserialize(stream);
                Copy(db.tours, database.tours);
                Copy(db.tourists, database.tourists);
                Copy(db.orders, database.orders);
            }

            void Copy<T>(List<T> from, List<T> to)
            {
                to.Clear();
                to.AddRange(from);
            }
        }
    }
}
