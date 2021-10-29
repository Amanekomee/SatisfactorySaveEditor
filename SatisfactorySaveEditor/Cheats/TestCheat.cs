using SatisfactorySaveEditor.Model;
using SatisfactorySaveParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SatisfactorySaveEditor.Cheats
{
    class TestCheat : ICheat
    {
        public string Name => "test";

        public bool Apply(SaveObjectModel rootItem, SatisfactorySave saveGame)
        {
            var window = new TestWindow()
            {
                Owner = Application.Current.MainWindow
            };
            if (!window.ShowDialog().Value)
                return false;

            Console.WriteLine(window.AValue);
            return true;
        }
    }
}
