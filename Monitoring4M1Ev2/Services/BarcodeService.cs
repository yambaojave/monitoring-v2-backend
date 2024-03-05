using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.Barcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Services
{
    public class BarcodeService : IBarcodeService
    {
        private readonly BarcodeDbContext _db;

        public BarcodeService(BarcodeDbContext db)
        {
            _db = db;
        }

        public B2WORKGROUP GetWorkGroup(int id)
        {
            return _db.B2WORKGROUP.FirstOrDefault(e => e.id == id);
        }

        public WorkgroupDetail GetWholeWorkGroupDetails(int id)
        {
            string[] operators = GetWorkGroupOperators(id);
            string[] machinesAndTemplates = GetWorkGroupMachineTemplate(id);
            var group = GetWorkGroup(id);

            var newGrouping = new WorkgroupDetail
            {
                id = group.id,
                line = group.lines,
                additionalCode = group.additionalCode,
                ShiftCode = group.wgShiftcode,
                ShiftHours = group.wgShiftHours,
                ShiftHeadcount = group.wgShiftHeadcount,
                ShiftPlannedOutput = group.wgShiftPlannedOutput,
                Operators = operators,
                MachinesAndTemplates = machinesAndTemplates
            };

            return newGrouping;
        }

        public string[] GetWorkGroupOperators(int id)
        {
            string[] operators = _db.B2WORKGROUPDETAIL.Where(e => e.workgroupId == id)
                .Select(e => e.operatorCode)
                .Distinct()
                .ToArray();
            return operators;

            //  Return an array of operators with distinct value
        }

        public string[] GetWorkGroupMachineTemplate(int id)
        {
            string[] machineList = _db.B2WORKGROUPDETAIL.Where(e => e.workgroupId == id)
                .Select(e => e.machineCode)
                .Distinct()
                .ToArray();
            string[] templateList = _db.B2WORKGROUPDETAIL.Where(e => e.workgroupId == id)
                .Select(e => e.operatorRole)
                .Distinct()
                .ToArray();

            string[] result = machineList.Concat(templateList).ToArray();
            // Removing "" from the array
            string[] newArray = result.Where(a => a != "").ToArray();

            return newArray;
        }

        public B2WORKGROUP GetLatestWorkGroupByLine(string line)
        {
            return _db.B2WORKGROUP.Where(e => e.lines == line).OrderByDescending(e => e.id).FirstOrDefault();
        }


        
        public List<B2BOM> GetBomMaterialList(string bom)
        {
            // Material BOM
            return _db.B2BOM.AsNoTracking().Where(e => e.BOMCode == bom && e.EndEffective == null).ToList();
        }

        public B2ITEMMASTER GetItemDescription(string item)
        {
            return _db.B2ITEMMASTER.Where(e => e.ITEMNO == item).FirstOrDefault();
        }

        public List<B2BOM> GetAllBomRelation(string partnumber)
        {
            return _db.B2BOM.AsNoTracking().Where(e => e.BOMCode == partnumber && e.EndEffective == null).ToList();
        }

        public List<B2WORKGROUPDETAIL> GetWgDetails(int wgId)
        {
            return _db.B2WORKGROUPDETAIL.Where(e => e.workgroupId == wgId).ToList();
        }
    }
}
