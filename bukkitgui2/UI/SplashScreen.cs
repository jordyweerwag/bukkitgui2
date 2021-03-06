﻿// SplashScreen.cs in bukkitgui2/bukkitgui2
// Created 2014/08/18
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System.Windows.Forms;
using MetroFramework.Forms;

namespace Net.Bertware.Bukkitgui2.UI
{
    public partial class SplashScreen : MetroForm
    {
        public static SplashScreen Reference;

        public SplashScreen()
        {
            Reference = this;
            InitializeComponent();
        }

        public void SafeFormClose()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) SafeFormClose);
            }
            else
            {
                Close();
            }
        }
    }
}