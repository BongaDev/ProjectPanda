﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProjectPanda.Models;

namespace ProjectPanda.ViewModels
{
    public class PrescribedMedicationListView
    {

        public ObservableCollection<PrescribedMedication> _prescribedMedication { get; set; }
        public object Selected { get; set; }

        public PrescribedMedicationListView()
        {
            GeneratePrecribedList();
        }

        public void GeneratePrecribedList()
        {

            _prescribedMedication = new ObservableCollection<PrescribedMedication>
            {
             
            };

        }


    }
}
