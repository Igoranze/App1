using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using System.Collections.Generic;
using Android.Content.PM;
using Java.IO;
using Android.Graphics;
using System.Net;
using Android.Media;
using System.Text;
using Java.Net;
using Java.Lang;

namespace PizzaMainApp
{
    [Activity(Label = "PizzaMainApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        int visited = 0;
        Button feelingsIntent;

        public static File _file;
        public static File _dir;
        public static Bitmap bitmap;

        public static readonly int CAPTURE_IMAGE_FULLSIZE_ACTIVITY_REQUEST_CODE = 1777;
        public static readonly int SAVE_IMAGE_FILLSIZE = 144;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            if (visited == 0)
            {

            }

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();
            }

            feelingsIntent = FindViewById<Button>(Resource.Id.Gevoelens);
            feelingsIntent.Click += TakeAPicture;


            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };


        }
        private void CreateDirectoryForPictures()
        {
            MainActivity._dir = new File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "CameraAppDemo");
            if (!MainActivity._dir.Exists())
            {
                MainActivity._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }


        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            MainActivity._file = new File(MainActivity._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(MainActivity._file));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            File file = new File(System.Environment.getExternalStorageDirectory() + File.Separator + "image.jpg");
            Bitmap bitmap = decodeSampledBitmapFromFile(file.getAbsolutePath(), 400, 400);
            MediaStore.Images.Media.InsertImage(getContentResolver(), bitmap, "KikkertSelfie", "KikkertSelfies");
            new UploadTask().Execute(bitmap);

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Android.Net.Uri contentUri = Android.Net.Uri.FromFile(MainActivity._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);


            //MainActivity.bitmap = MainActivity._file.Path.LoadAndResizeBitmap(500, 500);

            try
            {
                //create WebClient object
                WebClient client = new WebClient();
                string myFile = @"C:\file.txt";
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UploadFile(@"http://myweb.com/projects/idl/Draft Results/RK/myFile", "PUT", myFile);
                client.Dispose();
            }
            catch (System.Exception err)
            {
                
            }


            GC.Collect();
        }

        public static Bitmap decodeSampledBitmapFromFile(string path, int reqWidth, int reqHeight)
        { // BEST QUALITY MATCH
            BitmapFactory.Options options = new BitmapFactory.Options();
            options.InJustDecodeBounds = true;
            BitmapFactory.DecodeFile(path, options);

            // Calculate inSampleSize, Raw height and width of image
            int height = options.OutHeight;
            int width = options.OutWidth;
            options.InPreferredConfig = Bitmap.Config.Rgb565;
            int inSampleSize = 1;

            if (height > reqHeight)
            {
                inSampleSize = (int)Java.Lang.Math.Round((float)height / (float)reqHeight);
            }
            int expectedWidth = width / inSampleSize;

            if (expectedWidth > reqWidth)
            {
                //if(Math.round((float)width / (float)reqWidth) > inSampleSize) // If bigger SampSize..
                inSampleSize = (int)Java.Lang.Math.Round((float)width / (float)reqWidth);
            }

            options.InSampleSize = inSampleSize;

            // Decode bitmap with inSampleSize set
            options.InJustDecodeBounds = false;

            return BitmapFactory.DecodeFile(path, options);
        }



        private class UploadTask : AsyncTask<Bitmap, Java.Lang.Void, Java.Lang.Void> {

            HttpURLConnection connection;

            @Override
        protected Java.Lang.Void doInBackground(Bitmap...bitmaps)
        {


            if (bitmaps[0] == null)
                return null;

            Bitmap bitmap = bitmaps[0];
            ByteArrayOutputStream stream = new ByteArrayOutputStream();
            bitmap.compress(Bitmap.CompressFormat.JPEG, 70, stream); // convert Bitmap to ByteArrayOutputStream
            InputStream data = new ByteArrayInputStream(stream.toByteArray()); // convert ByteArrayOutputStream to ByteArrayInputStream

            try
            {
                multipartRequest("http://smulders.techmaus.nl/kikkertapp/public/api/selfies", "test=1", data, "selfie");
            }
            catch (Android.Net.ParseException e)
            {
                e.PrintStackTrace();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }

            return null;
        }

            protected override void RunInBackground(params Bitmap[] @params)
            {
                throw new NotImplementedException();
            }
        }
}









