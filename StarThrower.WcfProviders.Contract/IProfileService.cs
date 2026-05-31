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
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.Web.Profile;
using System.Web.Security;
using System.Text;

namespace StarThrower.WcfProviders.Contract
{
    [ServiceContract]
    public interface IProfileService
    {
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        [WebInvoke(UriTemplate = "/deleteinactiveprofiles", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        [WebInvoke(UriTemplate = "/deleteprofilesbyusername", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        int DeleteProfilesByUserName(string[] userNames);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        [WebInvoke(UriTemplate = "/deleteprofilesbyprofile", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        int DeleteProfilesByProfile(ProfileInfoCollection profiles);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        [WebInvoke(UriTemplate = "/findinactiveprofilesbyusername", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        GetProfilesResult FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string userNameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        [WebInvoke(UriTemplate = "/findprofilesbyusername", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        GetProfilesResult FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string userNameToMatch, int pageIndex, int pageSize);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        [WebInvoke(UriTemplate = "/getallinactiveprofiles", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        GetProfilesResult GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        [WebInvoke(UriTemplate = "/getallprofiles", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        GetProfilesResult GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        [WebInvoke(UriTemplate = "/getnumberofinactiveprofiles", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        [WebInvoke(UriTemplate = "/getpropertyvalues", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        Collection<ProfileItem> GetPropertyValues(SettingsContext context, Collection<ProfileItem> collection);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        [WebInvoke(UriTemplate = "/setpropertyvalues", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        void SetPropertyValues(SettingsContext context, Collection<ProfileItem> collection);
    }
}
