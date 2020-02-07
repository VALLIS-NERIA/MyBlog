﻿using System;

namespace BlogModel {
    public class Post {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime CreateDate { get; set; }
            public DateTime ModifyDate { get; set; }
            public string Author { get; set; }
            public bool IsPublish { get; set; }
            public int ClickCount { get; set; }
        }
    }

