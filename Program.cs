// Decompiled with JetBrains decompiler
// Type: UnrealIccupBruteforcer.Program
// Assembly: UnrealIccupBruteforcer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6E7BBA8-DFA2-4C69-A36D-873EA3E30432
// Assembly location: C:\Users\Karaulov\AppData\Roaming\Skype\My Skype Received Files\Brute[goshanvartanov].exe

using System;
using System.Windows.Forms;

namespace UnrealIccupBruteforcer
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }
            catch
            {
            }
            Application.Run((Form)new AbsolBruter());
        }
    }
}
