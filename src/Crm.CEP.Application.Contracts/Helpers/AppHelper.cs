using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.CEP.Helpers
{
    public static class AppHelper
    {

        public static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
                return $"id";

            return sorting;
        }
    }
}
