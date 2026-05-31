/***********************************************************************************
    StarThrower Utilities / WcfProviders
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Profile;
using StarThrower.WcfProviders.Contract;

namespace StarThrower.WcfProviders
{
    public class WcfProfileProvider : ProfileProvider
    {
        private string _applicationName = "/";

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
        }

        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            return ServiceWrapper.Instance.DeleteInactiveProfiles(authenticationOption, userInactiveSinceDate);
        }

        public override int DeleteProfiles(string[] userNames)
        {
            return ServiceWrapper.Instance.DeleteProfiles(userNames);
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            return ServiceWrapper.Instance.DeleteProfiles(profiles);
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string userNameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            GetProfilesResult result = ServiceWrapper.Instance.FindInactiveProfilesByUserName(authenticationOption, userNameToMatch, userInactiveSinceDate, pageIndex, pageSize);
            totalRecords = result.TotalRecords;
            return result.Profiles;
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string userNameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            GetProfilesResult result = ServiceWrapper.Instance.FindProfilesByUserName(authenticationOption, userNameToMatch, pageIndex, pageSize);
            totalRecords = result.TotalRecords;
            return result.Profiles;
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            GetProfilesResult result = ServiceWrapper.Instance.GetAllInactiveProfiles(authenticationOption, userInactiveSinceDate, pageIndex, pageSize);
            totalRecords = result.TotalRecords;
            return result.Profiles;
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            GetProfilesResult result = ServiceWrapper.Instance.GetAllProfiles(authenticationOption, pageIndex, pageSize);
            totalRecords = result.TotalRecords;
            return result.Profiles;
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            return ServiceWrapper.Instance.GetNumberOfInactiveProfiles(authenticationOption, userInactiveSinceDate);
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            Collection<ProfileItem> l = new Collection<ProfileItem>();
            foreach (SettingsProperty p in collection)
            {
                ProfileItem pi = null;
                switch (p.SerializeAs)
                {
                    case SettingsSerializeAs.Binary:
                        pi = new BinaryProfileItem();
                        break;
                    case SettingsSerializeAs.String:
                    case SettingsSerializeAs.Xml:
                        pi = new TextProfileItem();
                        break;
                    default:
                        throw new NotSupportedException();
                }
                pi.Name = p.Name;
                pi.PropertyType = p.PropertyType.AssemblyQualifiedName;
                pi.DefaultValue = p.DefaultValue;
                pi.SerializeAs = p.SerializeAs;
                l.Add(pi);
            }
            Collection<ProfileItem> profile = ServiceWrapper.Instance.GetPropertyValues(context, l);
            SettingsPropertyValueCollection result = new SettingsPropertyValueCollection();
            foreach (ProfileItem itm in profile)
            {
                SettingsProperty property = new SettingsProperty(itm.Name, Type.GetType(itm.PropertyType), null, false, itm.DefaultValue, itm.SerializeAs, new SettingsAttributeDictionary(), true, true);
                SettingsPropertyValue value = new SettingsPropertyValue(property);
                if (itm is TextProfileItem)
                {
                    value.PropertyValue = ((TextProfileItem)itm).Value;
                }
                else if (itm is BinaryProfileItem)
                {
                    value.PropertyValue = ((BinaryProfileItem)itm).Value;
                }
                result.Add(value);
            }
            return result;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            Collection<ProfileItem> profile = new Collection<ProfileItem>();
            foreach (SettingsPropertyValue value in collection)
            {
                if (value.PropertyValue is String)
                {
                    TextProfileItem itm = new TextProfileItem();
                    itm.Name = value.Name;
                    itm.PropertyType = value.Property.PropertyType.AssemblyQualifiedName;
                    itm.DefaultValue = value.Property.DefaultValue;
                    itm.SerializeAs = value.Property.SerializeAs;
                    itm.Value = (String)(value.PropertyValue);
                    profile.Add(itm);
                }
                else if (value.PropertyValue is Boolean)
                {
                    TextProfileItem itm = new TextProfileItem();
                    itm.Name = value.Name;
                    itm.PropertyType = value.Property.PropertyType.AssemblyQualifiedName;
                    itm.DefaultValue = value.Property.DefaultValue;
                    itm.SerializeAs = value.Property.SerializeAs;
                    itm.Value = value.PropertyValue.ToString();
                    profile.Add(itm);
                }
                else if (value.PropertyValue is DateTime)
                {
                    TextProfileItem itm = new TextProfileItem();
                    itm.Name = value.Name;
                    itm.PropertyType = value.Property.PropertyType.AssemblyQualifiedName;
                    itm.DefaultValue = value.Property.DefaultValue;
                    itm.SerializeAs = value.Property.SerializeAs;
                    itm.Value = value.PropertyValue.ToString();
                    profile.Add(itm);
                }
                else if (value.PropertyValue is Int32)
                {
                    TextProfileItem itm = new TextProfileItem();
                    itm.Name = value.Name;
                    itm.PropertyType = value.Property.PropertyType.AssemblyQualifiedName;
                    itm.DefaultValue = value.Property.DefaultValue;
                    itm.SerializeAs = value.Property.SerializeAs;
                    itm.Value = value.PropertyValue.ToString();
                    profile.Add(itm);
                }
                else if (value.PropertyValue is Guid)
                {
                    TextProfileItem itm = new TextProfileItem();
                    itm.Name = value.Name;
                    itm.PropertyType = value.Property.PropertyType.AssemblyQualifiedName;
                    itm.DefaultValue = value.Property.DefaultValue;
                    itm.SerializeAs = value.Property.SerializeAs;
                    itm.Value = value.PropertyValue.ToString();
                    profile.Add(itm);
                }
                else
                {
                    BinaryProfileItem itm = new BinaryProfileItem();
                    itm.Name = value.Name;
                    itm.PropertyType = value.Property.PropertyType.AssemblyQualifiedName;
                    itm.DefaultValue = value.Property.DefaultValue;
                    itm.SerializeAs = value.Property.SerializeAs;
                    itm.Value = (byte[])(value.PropertyValue);
                    profile.Add(itm);
                }
            }
            ServiceWrapper.Instance.SetPropertyValues(context, profile);
        }
    }
}
