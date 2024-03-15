using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HRManager
{
   public interface IPhoneBookItem // Best Practivces: All interfaceclasses shouls start with the letter I
    {
        // Intercafes are always abstract classes
        string GetContactSummary();
    }
}
