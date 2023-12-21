using Monitoring4M1Ev2.Model.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Interfaces
{
    public interface IMatrixService
    {
        /*
         *  GET
         */
        List<ProductionModel> GetProductionModels();

        /*
         *  CREATION 
         */
        ProductionModel PostProductionModel(ProductionModelDto dto);
        WIMatrix PostWIMatrix(WIMatrixDto dto);
        OperationProcess PostOperationProcess(OperationProcessDto dto);

        /*
         *  UPDATE 
         */
        void UpdateProductionModel(ProductionModelDto dto, int id, string updateType);
        void UpdateWIMatrix(WIMatrixDto dto, int id, string updateType);
        void UpdateOperationProcess(OperationProcessDto dto, int id, string updateType);

        /*
         *  CHECKING
         */
        bool DuplicateInputChecking(object obj, string table);

    }
}
