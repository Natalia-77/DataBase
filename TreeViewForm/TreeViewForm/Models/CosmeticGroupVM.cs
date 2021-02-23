using System.Collections.Generic;


namespace TreeViewForm.Models
{
    public class CosmeticGroupVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Image { get; set; }
        public int? ParentId { get; set; }
        public List<CosmeticGroupVM> Children { get; set; }
    }
}
