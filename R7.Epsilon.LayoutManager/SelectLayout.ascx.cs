﻿//
// EditR7.Epsilon.LayoutManager.ascx.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2016 Roman M. Yagodin
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.Skins;
using DotNetNuke.UI.Skins.Controls;
using R7.Epsilon.LayoutManager.Components;
using System.Collections;
using R7.Epsilon.LayoutManager.Models;
using System.Linq;
using DotNetNuke.Services.Localization;

namespace R7.Epsilon.LayoutManager
{
    public partial class SelectLayout : PortalModuleBase
    {
        #region Handlers

        /// <summary>
        /// Handles Init event for a control.
        /// </summary>
        /// <param name="e">Event args.</param>
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            linkCancel.NavigateUrl = GetReturnUrl ();
        }

        /// <summary>
        /// Handles Load event for a control.
        /// </summary>
        /// <param name="e">Event args.</param>
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);

            try {
                if (!IsPostBack) {

                    if (string.IsNullOrEmpty (Request.QueryString ["returntabid"])) {
                        // TODO: Log error
                        Response.Redirect (Globals.NavigateURL (), true);
                        return;
                    }

                    BindLayouts (PortalId);

                    // select existing value
                    var tabSettings = TabController.Instance.GetTabSettings (int.Parse (Request.QueryString ["returntabid"]));
                    var layoutName = (string) tabSettings ["r7_Epsilon_Layout"];

                    if (layoutName != null) {
                        comboLayout.SelectedValue = layoutName;
                    }
                }
            } 
            catch (Exception ex) {
                Exceptions.ProcessModuleLoadException (this, ex);
            }
        }

        /// <summary>
        /// Handles Click event for Select button
        /// </summary>
        /// <param name='sender'>
        /// Sender.
        /// </param>
        /// <param name='e'>
        /// Event args.
        /// </param>
        protected void buttonSelect_Click (object sender, EventArgs e)
        {
            try {
                
                if (comboLayout.SelectedIndex > 0) {
                    // update tab setting
                    TabController.Instance.UpdateTabSetting (int.Parse (Request.QueryString ["returntabid"]), "r7_Epsilon_Layout", comboLayout.SelectedValue);
                } 
                else {
                    // delete tab setting
                    TabController.Instance.DeleteTabSetting (int.Parse (Request.QueryString ["returntabid"]), "r7_Epsilon_Layout");
                }

                Response.Redirect (GetReturnUrl (), true);
            } 
            catch (Exception ex) {
                Exceptions.ProcessModuleLoadException (this, ex);
            }
        }

        #endregion

        protected void BindLayouts (int portalId)
        {
            comboLayout.DataSource = LayoutController.GetLayouts (portalId)
                .Concat (LayoutController.GetLayouts (Const.HOST_PORTAL_ID))
                .Distinct (new LayoutEqualityComparer ())
                .OrderBy (L => L.Name);
            
            comboLayout.DataBind ();

            // insert default item
            comboLayout.Items.Insert (0, new ListItem (LocalizeString ("NotSelected.Text"), int.MinValue.ToString ()));
        }

        protected string GetReturnUrl ()
        {
            var returnTabIdStr = Request.QueryString ["returntabid"];
            if (!string.IsNullOrEmpty (returnTabIdStr)) {
                return Globals.NavigateURL (int.Parse (returnTabIdStr));
            }

            return Globals.NavigateURL ();
        }

        protected void ErrorMessage (string messageResource)
        {
            Skin.AddModuleMessage (this, LocalizeString (messageResource), ModuleMessage.ModuleMessageType.RedError);
        }
    }
}

