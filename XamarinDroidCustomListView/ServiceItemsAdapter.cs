using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinDroidCustomListView
{
    public class ServiceItemsAdapter : BaseAdapter<ServiceItem>
    {
        protected Activity Context = null;
        protected List<ServiceItem> ServiceItems;


        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return ServiceItems.Count; }
        }

        public override ServiceItem this[int position]
        {
            get { return ServiceItems[position]; }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ServiceViewHolder holder = null;
            var view = convertView;

            if (view != null)
            {
                holder = view.Tag as ServiceViewHolder;
            }

            if (holder == null)
            {
                holder = new ServiceViewHolder();
                view = Context.LayoutInflater.Inflate(Resource.Layout.custom_row, null);
                holder.Name = view.FindViewById<TextView>(Resource.Id.tvServiceName);
                holder.Price = view.FindViewById<TextView>(Resource.Id.tvServicePrice);
                holder.Category = view.FindViewById<TextView>(Resource.Id.tvServiceCategory);
                holder.EditButton = view.FindViewById<ImageButton>(Resource.Id.buttonEditService);
                holder.DeleteButton = view.FindViewById<ImageButton>(Resource.Id.buttonDeleteService);
                view.Tag = holder;
            }

            //Now the holder holds reference to our view objects, whether they are 
            //recycled or created new. 
            //Next we need to populate the views

            var tempServiceItem = ServiceItems[position];
            holder.Name = (TextView) tempServiceItem.Name;
            holder.Category = (TextView) tempServiceItem.Category;
            holder.Price = (TextView)String.Format("{0:C}", tempServiceItem.Price);
            return null;
        
             

            
        }



        private class ServiceViewHolder : Java.Lang.Object
        {
            public TextView Name { get; set; }
            public TextView Price { get; set; }
            public TextView Category { get; set; }
            public ImageButton EditButton { get; set; }
            public ImageButton DeleteButton { get; set; }
        }
    }
}