using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace BackgroundNotificationTest
{
    [BroadcastReceiver]
    [IntentFilter(new[] { "com.xamarin.example.TEST" })]
    public class PriceReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //you can push a notification here.
            Log.Error("lv", "OnReceive");
            string price=intent.GetStringExtra("price");
            Toast.MakeText(context, price, ToastLength.Short).Show();
        }
    }
}