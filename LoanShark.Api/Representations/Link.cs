using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanShark.Api.Representations
{
    public class Link
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public static class StandardName
        {
            public const string Self = "self";
        }
    }
}