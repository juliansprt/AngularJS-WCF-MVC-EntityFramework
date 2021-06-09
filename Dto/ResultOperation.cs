using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    [DataContract]
    public class ResultOperation<t>
    {
        public ResultOperation(OperationTypes type, string msj)
        {
            Status = type;
            Message = msj;
        }

        public ResultOperation(OperationTypes type)
        {
            Status = type;
        }

        public ResultOperation(t data)
        {
            Status = OperationTypes.Success;
            Data = data;
        }
        public ResultOperation()
        {
        }

        public t Data { get; set; }
        public OperationTypes Status { get; set; }

        public string Message { get; set; }
    }

    public enum OperationTypes
    {
        Success = 1,
        Error = 2
    }
}
