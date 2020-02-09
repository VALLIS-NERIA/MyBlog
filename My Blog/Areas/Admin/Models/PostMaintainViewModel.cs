using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Blog.Areas.Admin.Models {
    public class PostMaintainViewModel {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}