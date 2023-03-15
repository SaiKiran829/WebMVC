namespace PPM.UI.Web.Models
{
    public class ProjectDto
    {
        public string projectName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int id { get; set; }

        public ProjectDto(string projectname, string startdate, string enddate, int Id)
        {
            this.projectName = projectname;
            this.startDate = startdate;
            this.endDate = enddate;
            this.id = Id;
        }
        public ProjectDto()
        {

        }
    }
}
