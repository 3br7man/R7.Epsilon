﻿//
//  Layout.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;

namespace R7.Epsilon.Components
{
    public class Layout
    {
        public List<DockInfo> Docks { get; set; }
    }

    public class DockInfo
    {
        public string Dock { get; set; }

        public List<PaneInfo> Panes { get; set; }
    }

    public class PaneInfo
    {
        public string Pane { get; set; }

        public string Class { get; set; }

        public string ContainerType { get; set; }

        public string ContainerName { get; set; }

        public string ContainerSrc { get; set; }
    }
}
