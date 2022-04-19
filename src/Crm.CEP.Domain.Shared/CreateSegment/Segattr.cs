using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crm.CEP.CreateSegment
{
    public enum Segattr
    {

        [Description("Invoice Value")]
        inv = 0,

        [Description("Item")]
        itm = 1,

        [Description("ATV")]
        atv = 2,

        [Description("UPT")]
        upt = 3
    }
}
