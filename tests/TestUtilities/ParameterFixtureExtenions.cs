﻿using Egil.RazorComponents.Bootstrap.Base.CssClassValues;
using Egil.RazorComponents.Bootstrap.Options;
using Egil.RazorComponents.Bootstrap.Options.CommonOptions;
using Shouldly;
using System.Linq;

namespace Egil.RazorComponents.Bootstrap.Tests.TestUtilities
{
    public static class ParameterFixtureExtenions
    {
        public static void ShouldContainOptionsWithPrefix(this CssClassProviderBase parameter, string prefix, int number)
        {
            parameter.ShouldContainOptionsWithPrefix(prefix, (Number)number);
        }

        public static void ShouldContainOptionsWithPrefix(this CssClassProviderBase parameter, string prefix, IOption option)
        {
            parameter.Single().ShouldBe($"{prefix}{Option.OptionSeparator}{option.Value}");
            parameter.Count.ShouldBe(1);
        }

        public static void ShouldContainOptionsWithPrefix(this CssClassProviderBase parameter, string prefix, IOptionSet<IOption> set)
        {
            var setWithPrefix = set.Select(option => $"{prefix}{Option.OptionSeparator}{option.Value}");
            parameter.ShouldBe(setWithPrefix);
            parameter.Count.ShouldBe(set.Count);
        }
    }
}