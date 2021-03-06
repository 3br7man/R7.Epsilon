﻿//
//  EpsilonMenuBase.cs
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
using System.Collections.Generic;
using DotNetNuke.Web.DDRMenu.TemplateEngine;

// aliases
using DDRMenu = DotNetNuke.Web.DDRMenu;

namespace R7.Epsilon.Skins.SkinObjects
{
    public abstract class EpsilonMenuBase: EpsilonSkinObjectBase
    {
        #region Controls

        protected DDRMenu.SkinObject Menu;

        /*
        protected DDRMenu.SkinObject menu;

        public DDRMenu.SkinObject Menu
        {
            get
            {
                if (menu == null)
                {
                    // find menu control
                    foreach (Control control in Controls)
                    {
                        if (control.ID != null && control.ID.StartsWith ("menu", StringComparison.InvariantCultureIgnoreCase))
                        {
                            menu = (DDRMenu.SkinObject) control;
                            break;
                        }
                    }
                }

                return menu;
            }
        }
        */

        #endregion

        #region Properties

        public bool PassDefaultTemplateArgs { get; set; }

        #endregion

        protected EpsilonMenuBase ()
        {
            PassDefaultTemplateArgs = true;
        }
       
        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            if (PassDefaultTemplateArgs)
            {
                // configurable menu template arguments
                var menuTemplateArgs = new List<TemplateArgument> ()
                {
                    new TemplateArgument ("urlType", Config.MenuUrlType.ToString ()) 
                };

                // set menu template arguments
                SetMenuTemplateArguments (Menu, menuTemplateArgs);
            }
        }

        private void SetMenuTemplateArguments (DDRMenu.SkinObject menu, List<TemplateArgument> args)
        {
            // check if menu exists for various skin derivatives
            if (menu != null)
            {
                if (menu.TemplateArguments != null)
                    menu.TemplateArguments.AddRange (args);
                else
                    menu.TemplateArguments = args;
            }
        }
    }
}
