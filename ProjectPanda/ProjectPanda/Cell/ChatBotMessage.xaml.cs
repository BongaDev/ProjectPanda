﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectPanda.Cell
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatBotMessage : ViewCell
	{
		public ChatBotMessage ()
		{
			InitializeComponent ();
		}

        public bool IsUser { get; internal set; }
    }
}