using Microsoft.VisualBasic;
using PPM.DAL.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PPM.DAL
{
    public class RoleDal
    {
        public void InsertIntoRoleTable(int roleId, string roleName)
        {
            try
            {
                using (var context = new ProlificsProjectManagement())
                {
                    Role role = new Role();
                    {
                        role.RoleId = roleId;
                        role.RoleName = roleName;
                    };
                    context.Roles.Add(role);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops an error occured " + e);
            }
        }

        public IEnumerable<Role> ReadData()
        {
            try
            {
                using (var context = new ProlificsProjectManagement())
                {
                    var roles = context.Roles.ToList();
                    if (roles.Count > 0)
                    {
                        return roles;
                    }
                    context.SaveChanges();
                    return Enumerable.Empty<Role>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops an error occured " + e);
                return null;
            }
        }


    }
}