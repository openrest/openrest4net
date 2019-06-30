﻿using System;
using System.Runtime.InteropServices;

namespace com.openrest.v2_0
{
    [ComVisible(true)]
    public class CCategory : ICategory
    {
        public CCategory(Category category)
        {
            this.category = category;
        }

        public string GetId()
        {
            return category.id;
        }

        public string GetRestaurantId()
        {
            return category.restaurantId;
        }

        public IStringMap GetTitle()
        {
            return new CStringMap(category.title);
        }

        public IStringMap GetDescription()
        {
            return new CStringMap(category.description);
        }

        public string GetParentCategoryId()
        {
            return category.parentCategoryId;
        }

        public string[] GetItemIds()
        {
            string[] arr = new string[category.itemIds.Count];
            category.itemIds.CopyTo(arr, 0);
            return arr;
        }

        public double GetPriority()
        {
            return category.priority.Value;
        }

        private readonly Category category;
   }
}
