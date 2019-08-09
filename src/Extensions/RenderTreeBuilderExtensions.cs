﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

namespace Egil.RazorComponents.Bootstrap.Extensions
{
    public static class RenderTreeBuilderExtensions
    {
        private const int DEFAULT_SEQUENCE = -1;

        public static void OpenElement(this RenderTreeBuilder builder, string elementName, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.OpenElement(sequence, elementName);
        }

        public static void OpenComponent<TComponent>(this RenderTreeBuilder builder, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE) where TComponent : IComponent
        {
            builder.OpenComponent<TComponent>(sequence);
        }

        public static void AddElementReferenceCapture(this RenderTreeBuilder builder, Action<ElementRef>? elementReferenceCaptureAction, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            if (elementReferenceCaptureAction is null) return;
            builder.AddElementReferenceCapture(sequence, elementReferenceCaptureAction);
        }

        public static void AddAttribute(this RenderTreeBuilder builder, string name, string? value, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            if (string.IsNullOrEmpty(value)) return;

            builder.AddAttribute(sequence, name, value);
        }

        public static void AddEventListener<T>(this RenderTreeBuilder builder, string eventName, EventCallback<T> callback, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            if (string.IsNullOrEmpty(eventName)) return;

            builder.AddAttribute(sequence, eventName, callback);
        }

        public static void AddEventListener<T>(this RenderTreeBuilder builder, string eventName, EventCallback<T>? callback, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            if (callback is null) return;
            if (string.IsNullOrEmpty(eventName)) return;

            builder.AddAttribute(sequence, eventName, callback);
        }

        public static void AddAttribute(this RenderTreeBuilder builder, string name, bool value, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.AddAttribute(sequence, name, value);
        }

        public static void AddAttribute(this RenderTreeBuilder builder, string name, MulticastDelegate value, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.AddAttribute(sequence, name, value);
        }

        public static void AddAttribute(this RenderTreeBuilder builder, string name, object? value, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            if (value is null) return;

            builder.AddAttribute(sequence, name, value);
        }

        /// <summary>
        /// Adds multiple attributes to the target.
        /// <para>
        /// NOTE: If this call appears after a specific <see cref="AddAttribute"/> call but 
        /// the attributes dictionary contains an attribute with the same name, then the 
        /// previously added attribute will be used.
        /// </para>
        /// </summary>
        public static void AddMultipleAttributes(this RenderTreeBuilder builder, IEnumerable<KeyValuePair<string, object>>? attributes, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            if (attributes is null) return;

            builder.AddMultipleAttributes(sequence, attributes);
        }

        public static void AddContent(this RenderTreeBuilder builder, string textContent, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.AddContent(sequence, textContent);
        }

        public static void AddContent(this RenderTreeBuilder builder, RenderFragment fragment, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.AddContent(sequence, fragment);
        }

        public static void AddMarkupContent(this RenderTreeBuilder builder, string markupContent, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.AddMarkupContent(sequence, markupContent);
        }

        public static void AddIdAttribute(this RenderTreeBuilder builder, string? value, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            if (string.IsNullOrEmpty(value)) return;
            builder.AddAttribute(sequence, "id", value);
        }

        public static void AddClassAttribute(this RenderTreeBuilder builder, string? value, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            if (string.IsNullOrEmpty(value)) return;
            builder.AddAttribute(sequence, "class", value);
        }

        public static void AddRoleAttribute(this RenderTreeBuilder builder, string? value, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            if (string.IsNullOrEmpty(value)) return;
            builder.AddAttribute(sequence, "role", value);
        }

        public static void AddAriaLabelAttribute(this RenderTreeBuilder builder, string? value, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            if (string.IsNullOrEmpty(value)) return;
            builder.AddAttribute(sequence, "aria-label", value);
        }

        public static void AddAriaHiddenAttribute(this RenderTreeBuilder builder, bool value = true, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.AddAttribute(sequence, "aria-hidden", value.ToLowerCaseString());
        }

        public static void AddTabIndex(this RenderTreeBuilder builder, int index = 0, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.AddAttribute(sequence, "tabindex", index);
        }

        public static void AddChildContentFragment(this RenderTreeBuilder builder, RenderFragment renderFragment, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.AddAttribute(sequence, RenderTreeBuilder.ChildContent, renderFragment);
        }

        public static void AddChildMarkupContent(this RenderTreeBuilder builder, string markupContent, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.AddAttribute(sequence, RenderTreeBuilder.ChildContent, (RenderFragment)(nestedBuilder => nestedBuilder.AddMarkupContent(markupContent)));
        }

        public static void AddDisableParentOverridesAttribute(this RenderTreeBuilder builder, bool value = true, [CallerLineNumber] int sequence = DEFAULT_SEQUENCE)
        {
            builder.AddAttribute(sequence, "DisableParentOverrides", value);
        }
    }
}