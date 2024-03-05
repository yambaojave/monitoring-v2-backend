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
        B2WORKGROUP GetLatestWorkGroupByLine(string line);
        B2ITEMMASTER GetItemDescription(string item);
        List<B2BOM> GetAllBomRelation(string partnumber);
        List<B2WORKGROUPDETAIL> GetWgDetails(int wgId);
    }
}
