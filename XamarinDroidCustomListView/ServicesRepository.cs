using System;
using System.Collections.Generic;
using System.IO;

namespace XamarinDroidCustomListView
{
	public class ServicesRepository
	{
	    private ServicesDatabase _db = null;
	    protected static string DbLocation;
	    protected static ServicesRepository Me;

	    static ServicesRepository()
	    {
            Me = new ServicesRepository();
	    }

	    protected ServicesRepository()
	    {
            //set the db location;
            DbLocation = DatabaseFilePath;
	    }


        public static string DatabaseFilePath
        {
            get
            {
                const string sqliteFilename = "ServicesDB.db3";
                var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var path = Path.Combine(libraryPath, sqliteFilename);
                return path;
            }
        }


        // CRUD (Create, Read, Update and Delete) methods

        public static ServiceItem GetClient(int id)
        {
            return Me._db.GetItem<ServiceItem>(id);
        }

        public static IEnumerable<ServiceItem> GetClients()
        {
            return Me._db.GetItems<ServiceItem>();
        }

        public static int SaveClient(ServiceItem client)
        {
            return Me._db.SaveItem(client);
        }

        public static int DeleteClient(int id)
        {
            return Me._db.DeleteItem<ServiceItem>(id);
        }
	}
}

