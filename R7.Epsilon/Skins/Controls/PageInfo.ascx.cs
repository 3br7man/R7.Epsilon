﻿//
//  PageInfo.ascx.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2016 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Web;
using System.Web.UI;
using DotNetNuke.Entities.Portals;
using System.Web.UI.WebControls;
using System.Web.Security;
using DotNetNuke.UI.WebControls;
using DotNetNuke.Entities.Users;
using R7.Epsilon.Models;
using R7.Epsilon.Components;

namespace R7.Epsilon
{
    public class PageInfo : EpsilonSkinObjectBase
    {
        public bool ShowPageInfo { get; set; }

        protected PageInfo ()
        {
            // set default values
            ShowPageInfo = true;
        }

        protected string PublishedOnDate
        {
            get
            {
                var activeTab = PortalSettings.ActiveTab;
                return ModelHelper.PublishedOnDate (activeTab.CreatedOnDate, activeTab.StartDate)
                    .ToString (Localizer.SafeGetString ("PublishedOnDate.Format", "MM/dd/yyyy")); 
            }
        }

        protected string PublishedByUserName
        {
            get
            {
                var activeTab = PortalSettings.ActiveTab;
                var user = activeTab.CreatedByUser (PortalSettings.PortalId);
                return (user != null)? user.DisplayName : Localizer.SafeGetString ("SystemUser.Text", "System");
            }
        }
    }
}
