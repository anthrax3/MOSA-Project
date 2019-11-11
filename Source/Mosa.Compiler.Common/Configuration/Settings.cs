﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using System;
using System.Collections.Generic;

namespace Mosa.Compiler.Common.Configuration
{
	public sealed class Settings
	{
		private List<Property> Properties = new List<Property>();
		private Dictionary<string, Property> Lookups = new Dictionary<string, Property>();

		public static Settings Merge(Settings start, Settings updates)
		{
			var settings = new Settings();

			foreach (var property in start.Properties)
			{
				settings.AddProperty(property);
			}

			foreach (var property in updates.Properties)
			{
				settings.MergeProperty(property);
			}

			return settings;
		}

		public Property CreateProperty(string fullname)
		{
			if (!Lookups.TryGetValue(fullname, out Property property))
			{
				property = new Property()
				{
					Name = fullname
				};

				AddProperty(property);
			}

			return property;
		}

		public void UpdateProperty(Property property)
		{
			var remove = GetProperty(property.Name);

			if (remove != null)
			{
				Lookups.Remove(property.Name);
				Properties.Remove(remove);
			}

			AddProperty(property);
		}

		public void MergeProperty(Property property)
		{
			var existing = GetProperty(property.Name);

			if (existing == null)
			{
				AddProperty(property);
				return;
			}

			if (property.Value == "@clear")
			{
				existing.List.Clear();
			}
			else
			{
				existing.Value = property.Value;
			}

			foreach (var item in property.List)
			{
				existing.List.AddIfNew(item);
			}
		}

		private void AddProperty(Property property)
		{
			Properties.Add(property);
			Lookups.Add(property.Name, property);
		}

		public Property GetProperty(string fullname)
		{
			if (Lookups.TryGetValue(fullname, out Property property))
			{
				return property;
			}

			return null;
		}

		public string GetValue(string fullname, string defaultValue, bool defaultIfBlank = false)
		{
			var property = GetProperty(fullname);

			if (property == null)
				return defaultValue;

			if (defaultIfBlank && string.IsNullOrEmpty(property.Value))
				return defaultValue;

			return property.Value;
		}

		public string GetValue(string fullname)
		{
			return GetProperty(fullname).Value;
		}

		public List<string> GetValueList(string fullname)
		{
			return GetProperty(fullname).List;
		}

		public bool IsConfigurationValueTrue(string fullname)
		{
			return GetProperty(fullname).IsValueTrue;
		}

		public bool IsConfigurationValueFalse(string fullname)
		{
			return GetProperty(fullname).IsValueFalse;
		}

		public bool GetValueAsBoolean(string fullname, bool defaultValue)
		{
			var property = GetProperty(fullname);

			if (property == null)
				return defaultValue;

			if (property.IsValueFalse)
				return false;

			if (property.IsValueTrue)
				return true;

			return defaultValue;
		}

		public int GetValueAsInteger(string fullname, int defaultValue)
		{
			var property = GetProperty(fullname);

			if (property == null)
				return defaultValue;

			if (Int32.TryParse(property.Value, out int result))
			{
				return result;
			}

			return defaultValue;
		}

		public List<string> GetList(string fullname)
		{
			var property = GetProperty(fullname);
			return property.List;
		}

		public void SetProperty(string fullname, string value)
		{
			var property = CreateProperty(fullname);
			property.Value = value;
		}

		public void SetProperty(string fullname, bool value)
		{
			var property = CreateProperty(fullname);
			property.Value = value ? "true" : "false";
		}

		public void SetProperty(string fullname, int value)
		{
			var property = CreateProperty(fullname);
			property.Value = value.ToString();
		}

		public void AddPropertyListValue(string fullname, string value)
		{
			if (value == null)
				return;

			var property = CreateProperty(fullname);
			property.List.Add(value);
		}

		public void ClearProperty(string fullname)
		{
			var property = GetProperty(fullname);

			if (property == null)
				return;

			Lookups.Remove(property.Name);
			Properties.Remove(property);
		}
	}
}