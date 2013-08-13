﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Tavis.IANA
{
    public class AllowHint : Hint
    {
        private readonly JArray _Methods = new JArray();

        public AllowHint()
        {
            Name = "allow";
            Content = _Methods;

        }
        public void AddMethod(HttpMethod method)
        {
            _Methods.Add(new JValue(method.Method));
        }

    }

    public class FormatsHint : Hint
    {
        public FormatsHint()
        {
            Name = "format";
        }
    }

    public class LinksHint : Hint
    {
        public LinksHint()
        {
            Name = "links";
        }
    }

    public class AcceptPostHint : Hint
    {
        public AcceptPostHint()
        {
            Name = "accept-post";
        }
    }

    public class AcceptPatchHint :  Hint
    {
        public AcceptPatchHint()
        {
            Name = "accept-patch";
        }
    }

    public class AcceptRanges : Hint
    {
        public AcceptRanges()
        {
            Name = "accept-ranges";
        }
    }

    public class AcceptPreferHint : Hint
    {
        public AcceptPreferHint()
        {
            Name = "accept-prefer";
        }
    }

    public class PreconditionReqHint : Hint
    {
        public PreconditionReqHint()
        {
            Name = "precondition-req";
        }
    }

    public class AuthSchemesHint : Hint
    {
        public AuthSchemesHint()
        {
            Name = "auth-schemes";
        }
    }

    public enum StatusHintValues
    {
        Deprecated,
        Gone
    }

    public class StatusHint : Hint
    {
     
        public StatusHint()
        {
            Name = "status";
            
        }

        public StatusHintValues Status
        {
            get
            {
                var value = Content as JValue;

                if ((string)value.Value == "gone") { return StatusHintValues.Gone;}
                
                return StatusHintValues.Deprecated;
            }
            set {
                switch (value)
                {
                    case StatusHintValues.Gone :
                        Content = new JValue("gone");
                        break;
                    case StatusHintValues.Deprecated:
                        Content = new JValue("deprecated");
                        break;

                }
            }
        }
    }
}
