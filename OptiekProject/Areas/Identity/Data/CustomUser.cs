using Project_Optiek.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Optiek.Areas.Identity.Data
{
    public class CustomUser: IdentityUser
    {
        [PersonalData]
        public Gebruiker Gebruiker { get; set; }
    }
}
