﻿using System;
using System.Collections.Generic;

namespace wixrest.v2_0
{
    public class Chain : Organization
    {
        public const string TYPE = "chain";

        /** Empty constructor required for initialization from JSON-encoded string. */
        public Chain() : base(TYPE) { }

        /** The distributor in charge of this chain. */
        public string distributorId;
    }
}
