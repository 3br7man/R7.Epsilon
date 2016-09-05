﻿//
//  JsVariables.ascx.cs
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

using System.Linq;
using System.Text;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Tabs;
using R7.Epsilon.Components;

namespace R7.Epsilon
{
    public class JsVariables: EpsilonSkinObjectBase
    {
        #region Control properties

        private bool breadCrumbsRemoveLastLink = true;
        public bool BreadCrumbsRemoveLastLink
        {
            get { return breadCrumbsRemoveLastLink; }
            set { breadCrumbsRemoveLastLink = value; }
        }

        #endregion

        #region Bindable properties

        protected string JsBreadCrumbsRemoveLastLink
        {
            get { return breadCrumbsRemoveLastLink.ToString ().ToLowerInvariant (); }
        }

        protected string JsBreadCrumbsList
        {
            get 
            {
                return "[" + Utils.FormatList<int> (",", PortalSettings.ActiveTab.BreadCrumbs
                    .ToArray ().Select (b => ((TabInfo) b).TabID)) + "]"; 
            }
        }

        protected string LayoutManagerUrl
        {
            get {
                var layoutManager = ModuleController.Instance.GetModuleByDefinition (PortalSettings.PortalId, "R7.Epsilon.LayoutManager");
                if (layoutManager != null) {
                    return Globals.NavigateURL (layoutManager.TabID, "Select", "mid", layoutManager.ModuleID.ToString ());
                }

                // TODO: Log error: no LayoutManager module found, layout selection feature is disabled
                return null;
            }
        }

        public string LocalizationResources
        {
            get {
                var sb = new StringBuilder ();

                sb.AppendFormat ("selectLayout: '{0}'", Localizer.GetString ("SelectLayout.Text"));

                return sb.ToString ();
            }
        }

        #endregion
    }
}
