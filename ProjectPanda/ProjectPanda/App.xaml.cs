﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectPanda.Views;
using ProjectPanda.Pages;
using ProjectPanda.Views.DeliveryViews;
using Xamarin.Forms;
using ProjectPanda.ViewModels.UserViewModels;

namespace ProjectPanda
{
	public partial class App : Application
	{
        public bool IsLoggedIn;
		public App ()
		{
            IsLoggedIn = false;
			InitializeComponent();

            SerapisInit(); 
            //MainPage = new NavigationPage(new LoginPage());
            // MainPage = new NavigationPage(new MainPage());

          

        }

        private void SerapisInit()
        {
            if (IsLoggedIn)
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }

            
        }

        protected override void OnStart ()
		{
            base.OnStart();
            /*First ask for location
             * if [user declines ]
             *      run app normally
             * else
             *  Return location

             */
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
