// Decompiled with JetBrains decompiler
// Type: UnrealIccupBruteforcer.Properties.Settings
// Assembly: UnrealIccupBruteforcer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6E7BBA8-DFA2-4C69-A36D-873EA3E30432
// Assembly location: C:\Users\Karaulov\AppData\Roaming\Skype\My Skype Received Files\Brute[goshanvartanov].exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace UnrealIccupBruteforcer.Properties
{
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    [CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        public static Settings defaultInstance;

        public static Settings Default
        {
            get
            {
                return Settings.defaultInstance;
            }
        }

        public Settings()
        {

        }

        static Settings()
        {

            // ISSUE: reference to a compiler-generated field
            // ISSUE: object of a compiler-generated type is created
            Settings.defaultInstance = (Settings)SettingsBase.Synchronized((SettingsBase)new Settings());
        }
    }
}
