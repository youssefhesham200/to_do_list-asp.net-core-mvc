using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace to_do_list.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [Column(TypeName = "nvarchar(50)")] 
    public string FirstName { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; }
}

