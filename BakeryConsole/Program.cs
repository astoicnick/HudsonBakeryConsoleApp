using BakeryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryConsole
{
    class Program
    {
        static void Main()
        {
            BakeryRepository.Repository repo = new BakeryRepository.Repository();
            ProgramUI programUI = new ProgramUI(repo);
            repo.AddInitialContent();
            programUI.Run();
        }
    }
}
