﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Import Namespace="DotNetNuke.Security" %>
<% if (PortalSecurity.IsInRole ("Administrators")) { %>
    <div class="skin-admin-page-info alert alert-info alert-dismissible"></div>
<% } %>