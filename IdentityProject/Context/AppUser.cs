using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Context
{
    public class AppUser : IdentityUser<int>
    {
        public int PictureURL { get; set; }
        // against 3nf
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
