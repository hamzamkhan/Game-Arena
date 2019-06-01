using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Game_Arena.Models;

namespace Game_Arena.ViewModels
{
    public class CustomerFormViewModel
    {
        //We only need to iterate so didn't use List
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}