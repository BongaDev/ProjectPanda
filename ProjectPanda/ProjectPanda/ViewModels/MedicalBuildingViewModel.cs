﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts;

using ProjectPanda.Services;
using ProjectPanda.Models;
using ProjectPanda.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjectPanda.Views;

namespace ProjectPanda.ViewModels
{
    public class MedicalBuildingViewModel : BaseViewModel
    {
       // readonly static string connectionString = "mongodb://localhost:27017";//for local development
        readonly static string connectionString = "mongodb+srv://Bonga:langelihle@cluster0-bkjo1.mongodb.net/test?retryWrites=true";
        MongoDBResp mongoDB = new MongoDBResp(connectionString);
        public ObservableCollection<MedicalBuildingModel> Practices { get; set; }//MockData
        List<MedicalBuildingModel> Practice = new List<MedicalBuildingModel>();
        public string medicalbuilding;
        public string FieldsSpecilized;

        public MedicalBuildingViewModel()
        {
            GenerateMedicalBuildingModel();
            //LoadMedicalBuildingAsync();
        }

        private async Task<List<MedicalBuildingModel>> LoadMedicalBuildingAsync()
        {
            var ConnectedToDB = mongoDB.CheckConnection();
            if(ConnectedToDB !=false)
                try
                {
                    IsBusy = true;//Starts ActivityIndicator

                    int NumOfPractices = 0;
                    //need to implement the itemtapped
                    //must get values from MessagingCenter
                    var practices = await mongoDB.GetUsersBySpecialization(medicalbuilding,FieldsSpecilized);
                    while (NumOfPractices < practices.Count)
                    {
                        Practice.AddRange(practices);
                        NumOfPractices++;
                    }
                    
                }
                catch(Exception e)
                {
                    //e.debug.writeline();
                }
                finally
                {
                    IsBusy = false;
                }
            return Practice;
        }

        public ICommand NavigateToDoctorList { get; set; }

        private async Task GoToDoctorList()
        {
            await App.Current.MainPage.Navigation.PushAsync(new DoctorListView());
        }

        #region MockData: ListViewData
        private void GenerateMedicalBuildingModel()
        {
            Practices = new ObservableCollection<MedicalBuildingModel>
            {
                new MedicalBuildingModel{Distance=7.8, MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "Grey's Hospital",ChartData = Chart1, PatientsCurrentlyAtPractice=5},
                new MedicalBuildingModel{Distance=7.0, MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "CromptomHospital",ChartData = Chart2, PatientsCurrentlyAtPractice=3},
                new MedicalBuildingModel{Distance=6.0, MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "GrooteSchuurHospital",ChartData = Chart3, PatientsCurrentlyAtPractice=12},
                new MedicalBuildingModel{Distance=12.5,MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "PinetownClinic",ChartData = Chart4, PatientsCurrentlyAtPractice=20},
                new MedicalBuildingModel{Distance=8.0, MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "WestvilleHospital",ChartData = Chart5, PatientsCurrentlyAtPractice=8},
                new MedicalBuildingModel{Distance=5.5, MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "Medicross:Pinetown",ChartData = Chart6, PatientsCurrentlyAtPractice=11},
                new MedicalBuildingModel{Distance=2.5, MedicalBuildingImage ="GreysHospital.jpg",PracticeName = "Grey's Hospital",ChartData = Chart7, PatientsCurrentlyAtPractice=15},
            };

            
        }

        public Chart Chart1 => new LineChart()
        {
            Entries = new[]
            {
                new Entry(60) { Label = "8am",ValueLabel = "", Color = SKColor.Parse("#FFFF00")},
                new Entry(40)//then less value of the first Entry out of 100
                {
                    Label = "10am",
                    ValueLabel = "",
                     Color = SKColor.Parse("#D3D3D3")//Grey Color
                },
                new Entry(74) //Indicates how busy it is
                {
                    Label = "12pm",
                    Color = SKColor.Parse("#FF4500"),
                },
                new Entry(24) //Indicates how busy it is
                {
                    Label = "2pm",
                    Color = SKColor.Parse("#FF4500"),
                },
            },
           BackgroundColor = SKColors.Transparent,
           LabelTextSize = 18, 
           LineSize = 7,
            MinValue = 0,
            MaxValue = 100
        };

        public Chart Chart2 => new LineChart()
        {
            Entries = new[]
            {
                new Entry(74) //Indicates how busy it is
                {
                    Label = "8am",
                     Color = SKColor.Parse("#FF4500"),  
                },
                  new Entry(26)
                  {
                     Color = SKColor.Parse("#D3D3D3")//Grey Color
                  },
            },
            BackgroundColor = SKColors.Transparent,
            LabelTextSize = 18,
            LineSize = 7,
            MinValue = 0,
            MaxValue = 100
        };

        public Chart Chart3 => new LineChart()
        {
            Entries = new[]
           {
                new Entry(85) //Indicates how busy it is
                {
                    Label = "8am",
                     Color = SKColor.Parse("#FFFF00")
                },
                new Entry(15)
                {
                    Label = "8am",
                     Color = SKColor.Parse("#D3D3D3")//Grey Color
                },
                new Entry(94) //Indicates how busy it is
                {
                    Label = "10am",
                     Color = SKColor.Parse("#ff0000")
                },
                 new Entry(6)
                {
                     Color = SKColor.Parse("#D3D3D3")//Grey Color
                },
            },
            BackgroundColor = SKColors.Transparent,
            LabelTextSize = 18,
            LineSize = 7,
            MinValue = 0,
            MaxValue = 100
        };
        public Chart Chart4 => new LineChart()
        {
            Entries = new[]
           {
                new Entry(85) //Indicates how busy it is
                {
                    Label = "8am",
                     Color = SKColor.Parse("#FFFF00")
                },
                new Entry(15)
                {
                    Label = "10am",
                     Color = SKColor.Parse("#D3D3D3")//Grey Color
                },
                new Entry(74) //Indicates how busy it is
                {
                    Label = "12pm",
                    Color = SKColor.Parse("#FF4500"),
                },
                new Entry(24) //Indicates how busy it is
                {
                    Label = "2pm",
                    Color = SKColor.Parse("#FF4500"),
                },
            },
            BackgroundColor = SKColors.Transparent,
            LabelTextSize = 18,
            LineSize = 7,
            MinValue = 0,
            MaxValue = 100
        };
        public Chart Chart5 => new LineChart()
        {
            Entries = new[]
          {
                new Entry(80)
                {
                    Label = "8am",
                     Color = SKColor.Parse("#ff0000")
                },
                new Entry(20)
                {
                    Label = "10am",
                     Color = SKColor.Parse("#D3D3D3")//Grey Color
                },
                new Entry(85) //Indicates how busy it is
                {
                     Label = "12pm",
                     Color = SKColor.Parse("#FFFF00")
                },
                new Entry(15)
                {
                     Label = "2pm",
                     Color = SKColor.Parse("#D3D3D3")//Grey Color
                },
            },
            BackgroundColor = SKColors.Transparent,
            LabelTextSize = 18,
            LineSize = 7,
            MinValue = 0,
            MaxValue = 100
        };
        public Chart Chart6 => new LineChart()
        {
            Entries = new[]
            {
                new Entry(40)
                {
                    Label = "8am",
                     Color = SKColor.Parse("#00ff00")
                },
                new Entry(60)
                {
                    Label = "10am",
                     Color = SKColor.Parse("#D3D3D3")//Grey Color
                },
                new Entry(85) //Indicates how busy it is
                {
                     Label = "12pm",
                     Color = SKColor.Parse("#FFFF00")
                },
                new Entry(15)
                {
                     Label = "2pm",
                     Color = SKColor.Parse("#D3D3D3")//Grey Color
                },
            },
            BackgroundColor = SKColors.Transparent,
            LabelTextSize = 18,
            LineSize = 7,
            MinValue = 0,
            MaxValue = 100
        };
        public Chart Chart7 => new LineChart()
        {
            Entries = new[]
            {
                new Entry(25)
                {
                    Label = "8am",
                     Color = SKColor.Parse("#00ff00")
                },
                new Entry(75)
                {
                    Label = "10am",
                     Color = SKColor.Parse("#D3D3D3")//Grey Color
                },
                 new Entry(85) //Indicates how busy it is
                {
                     Color = SKColor.Parse("#FFFF00")
                },
                new Entry(15)
                {
                    Color = SKColor.Parse("#D3D3D3")//Grey Color
                },
            },
            BackgroundColor = SKColors.Transparent,
            LabelTextSize = 18,
            LineSize = 7,
            MinValue = 0,
            MaxValue = 100
        };
        #endregion

    }
    
}
