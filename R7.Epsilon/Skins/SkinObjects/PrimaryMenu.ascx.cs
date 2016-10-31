﻿//
//  PrimaryMenu.ascx.cs
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
using DDRMenu = DotNetNuke.Web.DDRMenu;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class PrimaryMenu: EpsilonMenuBase
    {
        #region Controls

        protected DDRMenu.SkinObject menuPrimary;

        #endregion

        protected override void OnInit (EventArgs e)
        {
            Menu = menuPrimary;
            Menu.NodeSelector = Config.PrimaryMenu.NodeSelector;
            Menu.IncludeNodes = Config.PrimaryMenu.IncludeNodes;

            base.OnInit (e);
        }
    }
}
