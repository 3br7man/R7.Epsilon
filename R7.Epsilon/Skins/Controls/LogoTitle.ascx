﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.LogoTitle" %>

<a class="skin-logo-title" href="/<%= CultureInfo.CurrentCulture.Name.ToLowerInvariant() %>" hreflang="<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>"><%= SafeLocalizeString (string.Format("LogoTitle_{0}.Text", PortalSettings.PortalId), PortalSettings.PortalName) %></a>
<div class="skin-logo-title-motto">
    <%= LocalizeString (string.Format("LogoTitle_{0}.Motto", PortalSettings.PortalId), "LogoTitle_Default.Motto") %>
</div>