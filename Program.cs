﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Win_dog
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();//fuck
            Application.SetCompatibleTextRenderingDefault(false); //shabi
            Application.Run(new Form1());
        }
    }
}
