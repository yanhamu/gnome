﻿using System.Collections.Generic;

namespace Gnome.Core.Service.Categories
{
    public class CategoryTree
    {
        private Dictionary<int, CategoryNode> Categories = new Dictionary<int, CategoryNode>();
        public CategoryNode Root { get; private set; }
        public CategoryTree(Dictionary<int, CategoryNode> categories, CategoryNode root)
        {
            this.Root = root;
            this.Categories = categories;
        }
    }
}