using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using Android.Content;

namespace BackgroundNotificationTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView mtv;
        Button mbt,mbt1;
        PriceReceiver receiver;
        PriceService priceService;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

           

            initView();
            initListener();
        }

        private void initListener()
        {
            mbt.Click += Mbt_Click;
            mbt1.Click += Mbt1_Click;
        }

        private void Mbt1_Click(object sender, EventArgs e)
        {
            //Here I use button click to increase the price.
            Intent priceIntent = new Intent("com.xamarin.example.TEST");
            priceIntent.PutExtra("price", 1 + "");
            this.SendBroadcast(priceIntent);
        }

        private void Mbt_Click(object sender, EventArgs e)
        {
            //register the BroadCast Receiver
            receiver = new PriceReceiver();
            RegisterReceiver(receiver, new IntentFilter("com.xamarin.example.TEST"));

            //start a service, the service will improve your app's priority, so that your app
            //can't be killed easily.
            Intent intent = new Intent(this,typeof( PriceService));
            StartService(intent);


        }

        private void initView()
        {
            mtv = FindViewById<TextView>(Resource.Id.tv);
            mbt = FindViewById<Button>(Resource.Id.pric_bt);
            mbt1= FindViewById<Button>(Resource.Id.inc_bt);

            
        }

        protected override void OnDestroy()
        {
            UnregisterReceiver(receiver);
            base.OnDestroy();
        }


    }
}

