namespace Modelo.Dto
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public int ParentMenuId { get; set; }
        public bool IsParent { get; set; }
        public string? Area { get; set; }
        public string? PageName { get; set; }
        public string? MenuName { get; set; }
        public string? IconName { get; set; }
    }
}