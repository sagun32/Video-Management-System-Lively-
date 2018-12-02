﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lively.Models;

namespace Lively.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public string Title
        {
            get
            {
                if (Customer != null && Customer.ID != 0)
                    return "Edit Customer";
                return "New Customer";
            }
        }
    }
}