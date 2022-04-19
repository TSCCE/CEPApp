using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crm.CEP.CreateSegment
{
    public enum Segattri
    {

        [Display(Name = "DOB")]
        dob = 0,

        nat = 1,

        [Display(Name = "Gender")]
        gen = 2,

        [Display(Name = "Marital Status")]
        ms = 3,
        [Display(Name = "Date of Joining")]
        doj = 4,
        [Display(Name = "Purchase Date")]
        pd = 5
    }
}
