﻿//
//  LayoutManager.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016 Roman M. Yagodin
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
using System.Collections.Concurrent;
using System.IO;
using R7.Epsilon.Models;

namespace R7.Epsilon.Components
{
    /// <summary>
    /// Holds layouts dictionary.
    /// </summary>
    public class LayoutManager
    {
        #region Singleton implementation

        static Lazy<LayoutManager> instance = new Lazy<LayoutManager> ();

        public static LayoutManager Instance
        {
            get { return instance.Value; }
        }

        public static void ResetInstance ()
        {
            instance = new Lazy<LayoutManager> ();
        }

        #endregion

        readonly ConcurrentDictionary<string, Lazy<Layout>> layouts =
            new ConcurrentDictionary<string, Lazy<Layout>> ();

        public Layout GetLayout (int portalId, string layoutName)
        {
            return layouts.GetOrAdd (portalId + ":" + layoutName, key =>
                new Lazy<Layout> (() => GetLayoutByKey (key))
            ).Value;
        }

        Layout GetLayoutByKey (string key)
        {
            var keyParts = key.Split (new [] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            var portalId = int.Parse (keyParts [0]);
            var layoutName = keyParts [1];

            var layoutFile = LayoutHelper.GetLayoutFileName (layoutName, portalId);
            if (File.Exists (layoutFile)) {
                try {
                    return MarkupParser.ParseLayout (File.ReadAllText (layoutFile));
                } catch (Exception ex) {
                    // TODO: Log layout loading error
                    throw new Exception (string.Format ("Cannot find layout file \"{0}.xml\"", Path.GetFileNameWithoutExtension (layoutFile)), ex);
                }
            }

            return null;
        }

        /// <summary>
        /// Removes layout reference from dictionary, so it can be re-added later
        /// </summary>
        /// <param name="portalId">Portal identifier.</param>
        /// <param name="layoutName">Layout name.</param>
        public void ResetLayout (int portalId, string layoutName)
        {
            Lazy<Layout> removedLayout;
            layouts.TryRemove (portalId + ":" + layoutName, out removedLayout);
        }
    }
}
