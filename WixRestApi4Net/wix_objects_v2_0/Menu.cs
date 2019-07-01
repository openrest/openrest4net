﻿using System;
using System.Collections.Generic;
using wixrest.v2_0;

namespace wixrest.v2_0
{
    public class Menu
    {
        public Menu(IList<Item> items, IList<Tag> tags, IList<Category> categories)
        {
            this.items = items;
            this.tags = tags;
            this.categories = categories;
        }

        /** Empty constructor required for initialization from JSON-encoded string. */
        public Menu() { }

        public IList<Item> items = new List<Item>();

        public IList<Tag> tags = new List<Tag>();

        public IList<Category> categories = new List<Category>();
    }
}
