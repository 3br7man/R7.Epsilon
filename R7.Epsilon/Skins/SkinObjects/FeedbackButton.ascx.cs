﻿//
//  FeedbackButton.ascx.cs
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
using System.Linq;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using R7.Epsilon.Components;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class FeedbackButton : EpsilonSkinObjectBase
    {
        #region Controls

        protected HyperLink linkFeedback;

        #endregion

        #region Properties

        public string CssClass { get; set; }

        #endregion

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            // find feedback module
            var feedbackModule = ModuleController.Instance.GetModulesByDefinition (PortalSettings.PortalId, "Feedback")
                                                 .Cast<ModuleInfo> ()
                                                 .FirstOrDefault (m => m.TabID == Config.FeedbackTabId);
            
            if (feedbackModule != null) {
                var feedbackUrl = Globals.NavigateURL (feedbackModule.TabID, "", "mid", feedbackModule.ModuleID.ToString ());
                if (PortalSettings.Current.EnablePopUps && !A11yHelper.GetA11y (Request)) {
                    feedbackUrl = UrlUtils.PopUpUrl (feedbackUrl, this, PortalSettings.Current, false, false, 550, 950, false, "");
                }
                else
                {
                    // popups disabled, open feedback in new window
                    linkFeedback.Target = "_blank";
                }
 
                linkFeedback.CssClass = "unselectable " + CssClass;
                linkFeedback.ToolTip = Localizer.GetString ("FeedBackButton.Tooltip");
                linkFeedback.Text = Localizer.GetString  ("FeedBackButton.Text");
                linkFeedback.Attributes.Add ("data-feedback-url", feedbackUrl);
                linkFeedback.Attributes.Add ("onclick", string.Format ("javascript:return skin_setup_feedback_url(this,{0})",
                                                                       feedbackModule.ModuleID));
            }
            else {
                // no feedback module found, hide the button
                linkFeedback.Visible = false;
            }
        }
    }
}
