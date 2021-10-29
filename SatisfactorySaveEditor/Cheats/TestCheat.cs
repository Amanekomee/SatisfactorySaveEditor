using SatisfactorySaveEditor.Model;
using SatisfactorySaveParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySaveEditor.Cheats
{
    class TestCheat : ICheat
    {
        public string Name => "test";

        public bool Apply(SaveObjectModel rootItem, SatisfactorySave saveGame)
        {
            return true;
        }
    }
}
