﻿<%@ Control Language="C#" AutoEventWireup="false" Inherits="R7.Epsilon.Containers.EpsilonContainerBase" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="cnt-blank dnnClear">
    <% if (IsEditable) { %>
    <h4><dnn:TITLE ID="dnnTITLE" runat="server" CssClass="h4" /></h4>
    <% } %>
    <div id="ContentPane" runat="server"></div>
</div>