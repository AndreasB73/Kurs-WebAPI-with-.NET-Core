﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; }
    }
}
