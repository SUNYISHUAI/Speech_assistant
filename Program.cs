using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NPinyin;
using HtmlAgilityPack;
using Microsoft.Win32;
using System.Diagnostics;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }


        class InnerFunc
        {
            /**static void Main(string[] args)
            {
                //Program.getFromReg();
                Program.getWeather();
                Console.ReadKey();

            }*/
            public static string getWeather()
            {
            var Thecity = "北京";
            var city = NPinyin.Pinyin.GetPinyin(Thecity).Replace(" ", "");
            Console.WriteLine(city);
            var url = "http://www.tianqi.com/" + city + '/';
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var weather = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"weather\")]/span/b/text()").InnerText;
            var temperature = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"weather\")]/span/text()").InnerText;
            var present_temp = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"now\")]/b/text()").InnerText + "℃";
            var shidu = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"shidu\")]/b/text()").InnerText;
            var wind = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"shidu\")]/b[2]/text()").InnerText;
            var airquality = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"kongqi\")]/h5/text()").InnerText;
            var pm25 = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"kongqi\")]/h6/text()").InnerText;
            string result=Thecity + "今日天气：" + weather+'\n' + "今日温度：" + temperature.Replace("-","零下")+'\n'+"当前：" + present_temp+'\n' + shidu+'\n' + wind+'\n'+ airquality+'\n'+"PM 2.5: " + pm25.Replace("PM:","");
            return result;
        }


            public static void getFromReg()
            {
                RegistryKey subrk;
                Object objresult;
                string softwarepath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\";
                Console.WriteLine("input name:");
                string softwarename = Console.ReadLine();
                RegistryKey rk = Registry.LocalMachine;
                try
                {
                    subrk = rk.OpenSubKey(softwarepath + softwarename + ".exe");
                    objresult = subrk.GetValue(@"");
                    Process.Start(objresult.ToString());   //Start process without wait
                    Console.Write(objresult.ToString());
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Cannot find this App");
                }
            }

        }
    
}
