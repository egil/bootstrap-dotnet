﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egil.RazorComponents.Bootstrap.Base;
using Egil.RazorComponents.Bootstrap.Extensions;
using Microsoft.AspNetCore.Components.RenderTree;

namespace Egil.RazorComponents.Bootstrap.Components.Html
{
    public sealed class Header : BootstrapHtmlElementComponentBase
    {
        public Header()
        {
            DefaultElementName = HtmlTags.HEADER;
        }
    }

    public sealed class Footer : BootstrapHtmlElementComponentBase
    {

        public Footer()
        {
            DefaultElementName = HtmlTags.FOOTER;
        }
    }
}
