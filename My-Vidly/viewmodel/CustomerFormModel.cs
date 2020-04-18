using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using My_Vidly.Models;

namespace My_Vidly.viewmodel
{
    public class CustomerFormModel
    {
        public List<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}