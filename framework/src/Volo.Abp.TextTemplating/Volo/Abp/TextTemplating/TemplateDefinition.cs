﻿using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Volo.Abp.TextTemplating
{
    public class TemplateDefinition
    {
        [NotNull]
        public string Name { get; }

        public bool IsLayout { get; }

        [CanBeNull]
        public string Layout { get; set; }

        [CanBeNull]
        public Type LocalizationResource { get; set; }

        public bool IsInlineLocalized { get; internal set; }

        [CanBeNull]
        public string DefaultCultureName { get; }

        /// <summary>
        /// Gets/sets a key-value on the <see cref="Properties"/>.
        /// </summary>
        /// <param name="name">Name of the property</param>
        /// <returns>
        /// Returns the value in the <see cref="Properties"/> dictionary by given <see cref="name"/>.
        /// Returns null if given <see cref="name"/> is not present in the <see cref="Properties"/> dictionary.
        /// </returns>
        [CanBeNull]
        public object this[string name]
        {
            get => Properties.GetOrDefault(name);
            set => Properties[name] = value;
        }

        /// <summary>
        /// Can be used to get/set custom properties for this feature.
        /// </summary>
        [NotNull]
        public Dictionary<string, object> Properties { get; }

        public TemplateDefinition(
            [NotNull] string name, 
            [CanBeNull] Type localizationResource = null, 
            bool isLayout = false,
            string layout = null, 
            string defaultCultureName = null)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            LocalizationResource = localizationResource;
            IsLayout = isLayout;
            Layout = layout;
            DefaultCultureName = defaultCultureName;
            Properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Sets a property in the <see cref="Properties"/> dictionary.
        /// This is a shortcut for nested calls on this object.
        /// </summary>
        public virtual TemplateDefinition WithProperty(string key, object value)
        {
            Properties[key] = value;
            return this;
        }
    }
}