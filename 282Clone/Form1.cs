
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leaf.xNet;

namespace _282Clone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cookie = "c_user=100087839900519;xs=28:x0xY2ZMi3djpqA:2:1669075195:-1:-1;fr=;datr=6hB8Y7idu7x3_1Qvdi8WjnT_";
            var html = login("https://mbasic.facebook.com/", cookie);
            File.WriteAllText("log.html", html);
            Process.Start("log.html");
        }
        public static string login(string url, string cookie = null)
        {
            HttpRequest http = new HttpRequest();
            http.Cookies = new CookieStorage();


            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            http.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
            string html = http.Get(url).ToString();
            return html;
        }
        static void AddCookie(HttpRequest http, string cookie)
        {
            var temp = cookie.Split(';');
            foreach (var item in temp)
            {
                var temp2 = item.Split('=');
                if (temp2.Count() > 1)
                {
                    http.Cookies.Add(temp2[0], temp2[1]);
                }

            }

        }
    }
}
