﻿//
//  Permalink.ascx.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015 Roman M. Yagodin
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
using System.Web.UI.WebControls;
using System.Web.Security;
using DotNetNuke.Entities.Portals;
using DotNetNuke.UI.WebControls;
using DotNetNuke.Entities.Users;
using DotNetNuke.Common;
using R7.Epsilon.Components;

namespace R7.Epsilon
{
    public class Permalink : EpsilonSkinObjectBase
    {
        /// <summary>
        /// Gets page permalink
        /// </summary>
        /// <value>The page permalink.</value>
        protected string PagePermalink
        {
            get
            {
                return Globals.AddHTTP (PortalSettings.Current.PortalAlias.HTTPAlias + 
                    string.Format (Localizer.SafeGetString ("Permalink.Format", "/Default.aspx?TabId={0}"), 
                    PortalSettings.ActiveTab.TabID));
            }
        }
    }
}
