using Monitoring4M1Ev2.Model.Barcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Interfaces
{
    public interface IBarcodeService
    {
        B2WORKGROUP GetWorkGroup(int id);
        WorkgroupDetail GetWholeWorkGroupDetails(int id);
        string[] GetWorkGroupOperators(int id);
        string[] GetWorkGroupMachineTemplate(int id);
        int GetLatestWorkGroupByLine(string line);
    }
}
