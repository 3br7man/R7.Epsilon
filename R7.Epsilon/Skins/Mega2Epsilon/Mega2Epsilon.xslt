<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ddr="urn:ddrmenu">
	<xsl:output method="html"/>
	<xsl:param name="ControlID" />
	<xsl:param name="Options" />
    <xsl:param name="hamburgerMenu">0</xsl:param>
    <xsl:param name="urlType">0</xsl:param>
	<xsl:param name="subMenuColumns">3</xsl:param>
	<xsl:param name="pointer"></xsl:param>
	<xsl:param name="startUl"><![CDATA[<ul>]]></xsl:param>
	<xsl:param name="endUl"><![CDATA[</ul>]]></xsl:param>
    <xsl:template match="/*">
		<xsl:apply-templates select="root" />
	</xsl:template>
	<xsl:template match="root">
		<script type="text/javascript">
			jQuery(document).ready(function() {
				splitSubMenu(&quot;<xsl:value-of select="$ControlID" />&quot;, <xsl:value-of select="$subMenuColumns"/>);
			});
		</script>
		<ul class="megamenu">
            <xsl:attribute name="id"><xsl:value-of select="$ControlID" /></xsl:attribute>
            <xsl:apply-templates select="node">
				<xsl:with-param name="level" select="0"/>
			</xsl:apply-templates>
		</ul>
	</xsl:template>
	<xsl:template match="node">
		<xsl:param name="level" />
		<xsl:choose>
			<xsl:when test="$level=0">
				<li>
					<xsl:attribute name="class">level0<xsl:if test="@breadcrumb = 1"> current</xsl:if></xsl:attribute>
                    <a>
						<xsl:attribute name="class"><xsl:if test="@breadcrumb = 1">current</xsl:if></xsl:attribute>
                        <xsl:call-template name="menuLink"/>
                        <xsl:choose>
                            <xsl:when test="$hamburgerMenu = 1">
                                <span class="sr-only"><xsl:value-of select="ddr:GetString('ToggleNavigation.Text','Portals/_default/Skins/R7.Epsilon/App_LocalResources/SharedResources.resx')" /></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:value-of select="@text" />
						        <xsl:if test="node">
							        <xsl:value-of select="$pointer" disable-output-escaping="yes"/>
						        </xsl:if>
                            </xsl:otherwise>
                        </xsl:choose>
					</a>
					<xsl:if test="node">
						<div class="sub">
							<xsl:apply-templates select="node">
								<xsl:with-param name="level" select="$level + 1" />
							</xsl:apply-templates>
						</div>
					</xsl:if>
				</li>
			</xsl:when>
			<xsl:when test="$level=1">
                <ul>
                    <li>
                        <a>
                            <xsl:call-template name="menuLink"/>
                            <xsl:value-of select="@text"/>
                        </a>
                    </li>
					<xsl:if test="node">
						<xsl:apply-templates select="node">
							<xsl:with-param name="level" select="$level + 1"/>
						</xsl:apply-templates>
					</xsl:if>
				</ul>
			</xsl:when>
			<xsl:otherwise>
                <li>
                    <a>
                        <xsl:call-template name="menuLink"/>
                        <xsl:value-of select="@text"/>
                    </a>
                </li>
				<xsl:if test="node">
					<xsl:apply-templates select="node">
						<xsl:with-param name="level" select="$level + 1"/>
					</xsl:apply-templates>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
    <xsl:template name="menuLink">
        <xsl:choose>
            <xsl:when test="@enabled = 1">
                <xsl:choose>
                    <xsl:when test="$urlType = 1">
                        <xsl:attribute name="href">/Default.aspx?TabId=<xsl:value-of select="@id"/></xsl:attribute>
                    </xsl:when>
                    <xsl:when test="$urlType = 2">
                        <xsl:attribute name="href">/<xsl:value-of select="@id"/></xsl:attribute>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:attribute name="href"><xsl:value-of select="@url"/></xsl:attribute>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:when>
            <xsl:otherwise>
                <xsl:attribute name="href">#</xsl:attribute>
                <xsl:attribute name="onclick">return false</xsl:attribute>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>