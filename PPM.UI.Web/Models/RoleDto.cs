namespace PPM.UI.Web.Models
{
    public class RoleDto
    {
        public int roleId { get; set; }
        public string roleName { get; set; }

        public RoleDto(int roleId, string roleName)
        {
            this.roleId = roleId;
            this.roleName = roleName;
        }

        public RoleDto()
        {

        }
    }
}
