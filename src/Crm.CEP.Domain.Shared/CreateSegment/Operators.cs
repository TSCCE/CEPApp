using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crm.CEP.CreateSegment
{

    public enum Operators
    {
        [Display(Name = "Equal To")]
        eq=0,

        [Display(Name = "Greater Than/Equal To")]
        gt =1,

        [Display(Name =" Less Than/Equal To")]
        lt =2,

        [Display(Name = "Between")]
        bt =3

            


    }
}
