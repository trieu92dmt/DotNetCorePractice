using DotNetCorePractice.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePractice.ViewModels.Catalog.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public bool IsShowOnHome { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }
    }
}
