using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contacts_lib.models.DTO
{
    public class UserDTO
    {

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Password { get; set; } = null!;


    }
}