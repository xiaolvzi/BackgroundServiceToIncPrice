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
    [Service]
    class PriceService : Service
    {

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            Log.Error("lv", "StartCommandResult");
            // in the service, you can dectect the change of price, and then call the piceInc method to send Broadcast
            //piceInc(1);
            return StartCommandResult.Sticky;
        }

        public void piceInc(int price)
        {
            Intent priceIntent = new Intent("com.xamarin.example.TEST");
            priceIntent.PutExtra("price", 1 + "");
            this.SendBroadcast(priceIntent);
        }
    }
}