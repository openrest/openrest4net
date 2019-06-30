﻿using System;
using System.Runtime.InteropServices;

namespace com.openrest.v2_0
{
    [ComVisible(true)]
    public class CNullableLong : INullableLong
    {
        private readonly long? l;

        public CNullableLong(long? l)
        {
            this.l = l;
        }

        public bool HasValue()
        {
            return l.HasValue;
        }

        public long GetValue()
        {
            return l.Value;
        }
    }
}
