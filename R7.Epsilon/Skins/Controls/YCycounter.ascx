﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Components.EpsilonSkinObjectBase" %>
<%@ OutputCache Duration="1200" VaryByParam="Language" VaryByCustom="PortalId" %>
<a href="http://yandex.ru/cy?base=0&amp;host=<%= PortalSettings.PortalAlias.HTTPAlias %>">
    <img src="http://www.yandex.ru/cycounter?<%= PortalSettings.PortalAlias.HTTPAlias %>" 
        alt="<%: Localizer.GetString ("YandexCycounter.Text") %>" aria-label="<%: Localizer.GetString ("YandexCycounter.Text") %>" /></a>