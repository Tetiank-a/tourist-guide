using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DAL
{
    class Dao
    {
        private readonly DataBase database;
        public Dao(DataBase database)
        {
            this.database = database;
        }
        public void Save()
        {
            SaveTours();
            SaveTourists();
            SaveOrders();
        }


        public void Load()
        {
            LoadTours();
            LoadTourists();
            LoadOrders();
        }

        private void SaveTours()
        {
            using (var wr = new StreamWriter("tours.txt"))
            {
                if (database.tours.Count != 0)
                    wr.WriteLine(database.tours.Count);
                foreach (var t in database.tours)
                {
                    wr.WriteLine(t.name);
                    wr.WriteLine(t.country);
                    wr.WriteLine(t.city);
                    wr.WriteLine(t.date_begin.D + " " + t.date_begin.M + " " + t.date_begin.Y);
                    wr.WriteLine(t.date_end.D + " " + t.date_end.M + " " + t.date_end.Y);
                    wr.WriteLine(t.price);
                    //wr.WriteLine(t.id);
                }
            }
        }

        private void SaveTourists()
        {
            using (var wr = new StreamWriter("tourists.txt"))
            {
                if (database.tourists.Count != 0)
                    wr.WriteLine(database.tourists.Count);
                foreach (var t in database.tourists)
                {
                    wr.WriteLine(t.login);
                    wr.WriteLine(t.password);
                    //wr.WriteLine(t.id);
                }
            }
        }

        private void SaveOrders()
        {
            using (var wr = new StreamWriter("orders.txt"))
            {
                if (database.orders.Count != 0)
                    wr.WriteLine(database.orders.Count);
                foreach (var o in database.orders)
                {
                    wr.WriteLine(o.tour.id);
                    wr.WriteLine(o.tourist.id);
                }
            }
        }

        private void LoadTours()
        {
            using (var rd = new StreamReader("tours.txt", true))
            {
                int n = Convert.ToInt32(rd.ReadLine());
                // tours.Clear();
                for (int i = 0; i < n; i++)
                {
                    string namex = rd.ReadLine(), countryx = rd.ReadLine(), cityx = rd.ReadLine();
                    string s = rd.ReadLine();
                    string[] tmp = s.Split(' ');
                    int d1 = Convert.ToInt32(tmp[0]);
                    int m1 = Convert.ToInt32(tmp[1]);
                    int y1 = Convert.ToInt32(tmp[2]);

                    s = rd.ReadLine();
                    tmp = s.Split(' ');
                    int d2 = Convert.ToInt32(tmp[0]);
                    int m2 = Convert.ToInt32(tmp[1]);
                    int y2 = Convert.ToInt32(tmp[2]);

                    int pricex = Convert.ToInt32(rd.ReadLine());
                    //int idx = Convert.ToInt32(rd.ReadLine());

                    database.tours.Add(new Tour
                    {
                        name = namex,
                        country = countryx,
                        city = cityx,
                        date_begin = new Date(d1, m1, y1),
                        date_end = new Date(d2, m2, y2),
                        price = pricex,
                        id = database.tours.Count
                    });
                }
            }
        }

        private void LoadTourists()
        {
            using (var rd = new StreamReader("tourists.txt"))
            {
                int n = Convert.ToInt32(rd.ReadLine());
                database.tourists.Clear();
                for (int i = 0; i < n; i++)
                {
                    database.tourists.Add(new Tourist
                    {
                        login = rd.ReadLine(),
                        password = rd.ReadLine(),
                        id = database.tourists.Count
                    });
                }
            }
        }

        private void LoadOrders()
        {
            using (var rd = new StreamReader("orders.txt"))
            {
                int n = Convert.ToInt32(rd.ReadLine());
                database.orders.Clear();
                for (int i = 0; i < n; i++)
                {
                    var tourist = Convert.ToInt32(rd.ReadLine());
                    var tour = Convert.ToInt32(rd.ReadLine());
                    database.orders.Add(new Order(database.tourists[tourist], database.tours[tour], database.orders.Count));
                }
            }
        }
    }
}
