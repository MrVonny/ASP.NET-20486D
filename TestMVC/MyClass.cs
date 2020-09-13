using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVC
{
    public class MyService : IMyService
    {
        public string Text { get; set; } = "Text1";
        public MyService()
        {
            
        }

        public string Write()
        {
            string temp = Text;
            Text += "_O_";
            return Text;
        }
    }
    public interface IMyService
    {
        string Write();      
    }
}
