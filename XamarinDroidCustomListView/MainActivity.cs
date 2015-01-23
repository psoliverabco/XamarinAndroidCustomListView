using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace XamarinDroidCustomListView
{
    [Activity(Label = "Xamarin Droid Custom ListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected ListView MyServiceListView;
        protected List<ServiceItem> MyServiceItems;
        protected ServiceItemsAdapter MyServiceItemsAdapter;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);
            MyServiceListView = FindViewById<ListView>(Resource.Id.service_list);

            //Create an empty list of Service List
            MyServiceItems = new List<ServiceItem>();
            MyServiceItemsAdapter = new ServiceItemsAdapter(this, MyServiceItems);

            MyServiceListView.Adapter = MyServiceItemsAdapter;
            var emptyText = FindViewById<TextView>(Resource.Id.service_list_empty);
            MyServiceListView.EmptyView = emptyText;

        }

        protected override void OnResume()
        {
            base.OnResume();
            LoadData();
        }

        private void LoadData()
        {
            //First clear the adapter of any Services it has 
           // MyServiceItemsAdapter.NotifyDataSetInvalidated();

            Log.Info("LoadData", "Creating Service Instance");
            var service1 = new ServiceItem
            {
                Name = "Baby Sitting Service",
                Description = "Caring baby sitting service",
                Price = 75,
                Category = "Domestic"
                
            };
            MyServiceItemsAdapter.Add(service1);

            var service2 = new ServiceItem
            {
                Name = "House painting",
                Description = "Great looking paint service",
                Price = 150,
                Category = "Labor"

            };
           MyServiceItemsAdapter.Add(service2);
        }
    }

    
}

