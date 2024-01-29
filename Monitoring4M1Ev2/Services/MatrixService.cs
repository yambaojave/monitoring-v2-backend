using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model;
using Monitoring4M1Ev2.Model.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Services
{
    public class MatrixService : IMatrixService
    {
        private readonly ApplicationDbContext _db;

        public MatrixService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ProductionModel> GetProductionModels()
        {
            return _db.ProductionModels
                .Include(e => e.WIMatrices)
                    .ThenInclude(e => e.OperationProcesses)
                .ToList();
        }


        public ProductionModel PostProductionModel(ProductionModelDto dto)
        {
            var newModel = new ProductionModel
            {
                ModelName = dto.ModelName,
                ModelDescription = dto.ModelDescription,
                ModelHeadCount = dto.ModelHeadCount
            };

            _db.ProductionModels.Add(newModel);
            _db.SaveChanges();

            return newModel;
        }

        

        public void UpdateProductionModel(ProductionModelDto dto, int id, string updateType)
        {
            var model = _db.ProductionModels.Find(id);

            switch (updateType)
            {
                case "active":
                    model.IsActive = !model.IsActive;
                    model.DateUpdated = DateTime.Now;
                    _db.SaveChanges();
                    break;
                default:
                    model.ModelName = dto.ModelName;
                    model.ModelDescription = dto.ModelDescription;
                    model.DateAdded = DateTime.Now;
                    _db.SaveChanges();
                    break;
            }
            
        }


        public WIMatrix PostWIMatrix(WIMatrixDto dto)
        {
            var newWI = new WIMatrix
            {
                ProcessNumber = dto.ProcessNumber,
                ControlNumber = dto.ControlNumber,
                PModelId = dto.PModelId
            };

            _db.WIMatrices.Add(newWI);
            _db.SaveChanges();

            ModelTimeUpdate(dto.PModelId);

            return newWI;
        }

        public void UpdateWIMatrix(WIMatrixDto dto, int id, string updateType)
        {
            var wi = _db.WIMatrices.Find(id);

            switch (updateType)
            {
                case "active":
                    wi.IsActive = !wi.IsActive;
                    wi.DateUpdated = DateTime.Now;
                    _db.SaveChanges();
                    break;
                default:
                    wi.ProcessNumber = dto.ProcessNumber;
                    wi.ControlNumber = dto.ControlNumber;
                    wi.DateUpdated = DateTime.Now;
                    _db.SaveChanges();
                    break;
            }

            
        }

        public OperationProcess PostOperationProcess(OperationProcessDto dto)
        {
            var newOperation = new OperationProcess
            {
                OperationName = dto.OperationName,
                WIId = dto.WIId
            };

            var wi = _db.WIMatrices.Find(dto.WIId);
            var model = _db.ProductionModels.Find(wi.PModelId);
            

            _db.OperationProcesses.Add(newOperation);
            _db.SaveChanges();

            ModelTimeUpdate(model.PModelId);

            return newOperation;
        }

        public void UpdateOperationProcess(OperationProcessDto dto, int id, string updateType)
        {
            var operation = _db.OperationProcesses.Find(id);

            switch (updateType)
            {
                case "active":
                    operation.IsActive = !operation.IsActive;
                    operation.DateUpdated = DateTime.Now;
                    _db.SaveChanges();
                    break;
                default:
                    operation.OperationName = dto.OperationName;
                    operation.DateUpdated = DateTime.Now;
                    _db.SaveChanges();
                    break;
            }
        }

        public bool DuplicateInputChecking(object obj, string table)
        {
            if (obj == null)
            {
                return true;
            }

            switch (table)
            {
                case "MODELS":
                    string modelName = obj.GetType().GetProperty("ModelName").GetValue(obj)?.ToString();
                    bool m_exists = _db.ProductionModels.Any(e => e.ModelName == modelName);
                    return m_exists;
                case "WI":
                    string controlNumber = obj.GetType().GetProperty("ControlNumber").GetValue(obj)?.ToString();
                    bool wi_exists = _db.WIMatrices.Any(e => e.ControlNumber == controlNumber);
                    return wi_exists;
                case "PROCESS":
                    string operationName = obj.GetType().GetProperty("OperationName").GetValue(obj)?.ToString();
                    bool p_exists = _db.OperationProcesses.Any(e => e.OperationName == operationName);
                    return p_exists;
            }

            return false;
        }

        private void ModelTimeUpdate(int id)
        {
            var model = _db.ProductionModels.Find(id);

            model.DateUpdated = DateTime.Now;
            _db.SaveChanges();
        }


        public Dictionary<string, string[]> GetModelProcessOperation(string model)
        {
            int modelId = _db.ProductionModels.Where(e => e.ModelName == model).Select(e => e.PModelId).FirstOrDefault();
            var items = _db.WIMatrices.Where(e => e.PModelId == modelId).OrderBy(e => e.ProcessNumber).ToList();
            var operations = _db.OperationProcesses.ToList();

            var myDictionary = new Dictionary<string, string[]>();

            foreach (var item in items)
            {
                string[] opArray = operations.Where(e => e.WIId == item.WIId && e.IsActive == true).Select(e => e.OperationName).ToArray();
                myDictionary.Add(item.ProcessNumber, opArray);//new string[] { opArray });
            }

            return myDictionary;
        }


        // Samples
        public List<T> ModelProcessOperation<T>(string model) where T : class
        {
            int modelId = _db.ProductionModels.Where(e => e.ModelName == model).Select(e => e.PModelId).FirstOrDefault();
            var items = _db.WIMatrices.Where(e => e.PModelId == modelId).ToList();

            //List<T> myList = new List<T> { (T)(object)items };
            //List<T> myList = new List<T> { items as T };

            List<T> myList = items.Cast<T>().ToList();

            return myList;

        }

        public bool ModelExisting(string model)
        {
            return _db.ProductionModels.Any(e => e.ModelName == model && e.IsActive == true);
        }

        public ProductionModel GetProductionModelByName(string model)
        {
            return _db.ProductionModels.Include(e => e.WIMatrices).ThenInclude(e => e.OperationProcesses).FirstOrDefault(e => e.ModelName == model);
        }
    }
}
