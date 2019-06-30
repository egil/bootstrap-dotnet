﻿using Egil.RazorComponents.Bootstrap.Base;
using Egil.RazorComponents.Bootstrap.Base.CssClassValues;
using Egil.RazorComponents.Bootstrap.Components.Badges.Parameters;
using Egil.RazorComponents.Bootstrap.Utilities.Colors;
using Microsoft.AspNetCore.Components;

namespace Egil.RazorComponents.Bootstrap.Components.Badges
{
    public sealed class Badge : BootstrapParentComponentBase
    {
        private const string BadgeCssClass = "badge";
        private const string PillShapedCssClass = "badge-pill";

        [Parameter]
        public ColorParameter<BadgeColor> Color { get; set; } = ColorParameter<BadgeColor>.None;

        [Parameter, CssClassToggleParameter(PillShapedCssClass)]
        public bool PillShaped { get; set; }

        public Badge()
        {
            DefaultCssClass = BadgeCssClass;
        }

        protected override void OnBootstrapParametersSet()
        {
            if (AdditionalAttributes.ContainsKey(HtmlAttrs.HREF))
                DefaultElementName = HtmlTags.A;
            else
                DefaultElementName = HtmlTags.SPAN;
        }
    }
}