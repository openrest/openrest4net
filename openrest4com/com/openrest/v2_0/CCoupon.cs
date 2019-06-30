﻿using System;
using System.Runtime.InteropServices;

namespace com.openrest.v2_0
{
    [ComVisible(true)]
    public class CCoupon : ICoupon
    {
        public CCoupon(Coupon coupon)
        {
            this.coupon = coupon;
        }

        public string GetCouponType()
        {
            return coupon.type;
        }

        /*
        public string GetTitle()
        {
            return coupon.title;
        }

        public string GetDescription()
        {
            return coupon.description;
        }
        */

        public int GetMaxNumAllowed()
        {
            return coupon.maxNumAllowed.Value;
        }

        public bool GetOthersAllowed()
        {
            return coupon.othersAllowed.Value;
        }

        private readonly Coupon coupon;
    }
}
