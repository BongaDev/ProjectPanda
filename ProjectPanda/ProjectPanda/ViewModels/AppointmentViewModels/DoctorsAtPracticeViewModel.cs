﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using ProjectPanda.Models;
using ProjectPanda.Models.AppointmentModels;

namespace ProjectPanda.ViewModels.AppointmentViewModels
{
    public class DoctorsAtPracticeViewModel
    {

        public ObservableCollection<DoctorsAtPractice> _docs { get; set; }

        public DoctorsAtPracticeViewModel()
        {
            GenerateDoctorsAtPractice();
        }

        private void GenerateDoctorsAtPractice()
        {
            _docs = new ObservableCollection<DoctorsAtPractice>
            {
                new DoctorsAtPractice{Name="Dr Zulu", ProfileImageURl="userplaceholder.png"  },
                new DoctorsAtPractice{Name="Dr Buthelezi", ProfileImageURl="userplaceholder.png}" },
                new DoctorsAtPractice{Name="Dr Zuma", ProfileImageURl="userplaceholder.png}" }

            };
        }
    }
}