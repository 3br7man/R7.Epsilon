﻿<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ViewLayoutManager.ascx.cs" Inherits="R7.Epsilon.LayoutManager.ViewLayoutManager" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<asp:Panel id="panelViewLayoutManager" runat="server" CssClass="dnnForm dnnClear">
    <fieldset>
		<div class="dnnFormItem">
	        <dnn:Label id="labelPortal" runat="server" ControlName="comboPortal" />
	   	    <asp:DropDownList id="comboPortal" runat="server"
			    DataValueField="PortalID" DataTextField="PortalName"
                AutoPostBack="true" OnSelectedIndexChanged="comboPortals_SelectedIndexChanged" />
		</div>	
	    <div class="dnnFormItem">
			<label class="dnnLabel"></label>
    	    <asp:GridView id="gridLayouts" runat="server" AutoGenerateColumns="false"
					CssClass="dnnGrid gridLayouts" GridLines="None">
            	<HeaderStyle CssClass="dnnGridHeader" HorizontalAlign="Left" />
                <RowStyle CssClass="dnnGridItem" HorizontalAlign="Left" />
                <AlternatingRowStyle CssClass="dnnGridAltItem" />
                <EditRowStyle CssClass="dnnFormInput" />
                <SelectedRowStyle CssClass="dnnFormError" />
                <FooterStyle CssClass="dnnGridFooter" />
                <PagerStyle CssClass="dnnGridPager" />
				<EmptyDataRowStyle CssClass="" />
                <Columns>
            		<asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" IconKey="Edit" 
								NavigateUrl='<%# EditUrl ("layoutname", (string) Eval ("Name"), "Edit", "layoutportalid", ((int) Eval ("PortalId")).ToString ()) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:BoundField DataField="Name" HeaderText="LayoutName.Column" />
					<asp:BoundField DataField="IsInUse" HeaderText="LayoutInUse.Column" />
            	</Columns>
				<EmptyDataTemplate>
                    <asp:Label runat="server" CssClass="dnnFormMessage dnnFormInfo" resourcekey="NoLayouts.Info" />
				</EmptyDataTemplate>
            </asp:GridView>
	    </div>
		<div class="dnnFormItem">
            <label class="dnnLabel"></label>
			<asp:HyperLink id="linkAddLayout" runat="server" CssClass="dnnPrimaryAction" resourcekey="AddLayout.Text" />
		</div>
    </fieldset>
</asp:Panel>
