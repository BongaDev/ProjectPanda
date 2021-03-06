﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lottie.Forms.iOS.Renderers;
using Foundation;
using UIKit;
using System.IO;

namespace ProjectPanda.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{

            // This MobileServiceClient has been configured to communicate with the Azure Mobile App and
            // Azure Gateway using the application url. You're all set to start working with your Mobile App!
            Microsoft.WindowsAzure.MobileServices.MobileServiceClient ProjectPandaClient = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(
            "https://projectpanda.azurewebsites.net");
            global::Xamarin.Forms.Forms.Init ();

            //Calenderview code
            XamForms.Controls.iOS.Calendar.Init();

            //Inicializa o Zxing no iOS
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();


            //the lottie code for Ios



            #region SqLite local databse for ios

            string dbName = "travel_db.sqlite";
            string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library");
            string fullPath = Path.Combine(folderPath, dbName);

            #endregion

            LoadApplication(new ProjectPanda.App (fullPath));

        
            return base.FinishedLaunching (app, options);



        }
	}
}
