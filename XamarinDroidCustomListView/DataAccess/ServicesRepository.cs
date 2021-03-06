﻿using System;
using System.Collections.Generic;
using System.IO;

namespace XamarinDroidCustomListView.DataAccess
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

			//instantiate the database
			_db = new ServicesDatabase(DbLocation);
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

		public static ServiceItem GetServiceItem(int id)
		{
			return Me._db.GetItem<ServiceItem>(id);
		}

		public static IEnumerable<ServiceItem> GetServiceItems()
		{
			return Me._db.GetItems<ServiceItem>();
		}

		public static int SaveServiceItem(ServiceItem item)
		{
			return Me._db.SaveItem(item);
		}

		public static int DeleteServiceItem(int id)
		{
			return Me._db.DeleteItem<ServiceItem>(id);
		}
	}
}

