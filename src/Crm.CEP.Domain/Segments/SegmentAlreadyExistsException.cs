using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Crm.CEP.Segments
{
    public class SegmentAlreadyExistsException : BusinessException
    {
        public SegmentAlreadyExistsException(string name) 
            : base(CEPDomainErrorCodes.SegmentAlreadyExists)
        {
            WithData(nameof(name), name);   
        }
    }
}
