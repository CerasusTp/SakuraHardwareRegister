using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakuraHardwareRegister.Common
{
    public class CheckErrorItem
    {
        private readonly List<string> ErrorMsg;
        public CheckErrorItem() { ErrorMsg = []; }
        public void AddError(string msg) { ErrorMsg.Add(msg); }
        public bool HasError() { return ErrorMsg.Count != 0; }
        public string GetError() { return string.Join("\n", ErrorMsg); }
        public void ClearError() { ErrorMsg.Clear(); }
    }
}
