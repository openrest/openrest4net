﻿using System;

namespace com.openrest.v1_1
{
    public class GetOrganizationFullRequest : Request
    {
        public const string TYPE = "get_organization_full";

        public string organizationId;

        /** Empty constructor required for initialization from JSON-encoded string. */
        public GetOrganizationFullRequest()
            : base(TYPE)
        {
        }

        public GetOrganizationFullRequest(string organizationId)
            : base(TYPE)
        {
            this.organizationId = organizationId;
        }
    }
}
