using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindfulNote.Models
{
    internal class About
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://github.com/beaabrahamsson/DT071G-Projekt-beaab2100";
        public string Message => "Appen MindfulNote är en applikation skapad för kursen Programmering i C#.NET. Syftet med applikationen är att användaren ska kunna skapa och spara anteckningar. Appen är skapad med XAML och C# med .NET MAUI. För mer information samt källkod, se länk nedan.";
    }
}
