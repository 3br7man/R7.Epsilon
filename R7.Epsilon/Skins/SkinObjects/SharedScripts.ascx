﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ OutputCache Duration="1200" VaryByParam="TabId;Language" %>
<%
var vk = Config.SocialNetworks.FirstOrDefault (n => n.Name == "VKontakte" && n.ShareEnabled);
var fb = Config.SocialNetworks.FirstOrDefault (n => n.Name == "Facebook" && n.ShareEnabled);
var tw = Config.SocialNetworks.FirstOrDefault (n => n.Name == "Twitter" && n.ShareEnabled);
var gp = Config.SocialNetworks.FirstOrDefault (n => n.Name == "GooglePlus" && n.ShareEnabled);
%>
<%-- Facebook Like --%><% if (fb != null) { %>
<script>(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    <% if (!string.IsNullOrWhiteSpace (fb.ApiId)) { %>
    js.src = "//connect.facebook.net/<%= CultureInfo.CurrentCulture.Name.Replace ("-", "_") %>/sdk.js#xfbml=1&version=v2.8&appId=<%: fb.ApiId %>";
    <% } else { %>
    js.src = "//connect.facebook.net/<%= CultureInfo.CurrentCulture.Name.Replace ("-", "_") %>/sdk.js#xfbml=1&version=v2.8";
    <% } %>
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));
</script><% } %>
<%-- Tweet Button --%><% if (tw != null) { %><script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');</script><% } %>
<%-- Google +1 --%><% if (gp != null) { %><script type="text/javascript">
window.___gcfg = {
    lang: '<%= CultureInfo.CurrentCulture.TwoLetterISOLanguageName %>', 
    parsetags: 'onload'
};
(function() {
    var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
    po.src = 'https://apis.google.com/js/platform.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
})();
</script><% } %>
<%-- VK.com Widget--%><% if (vk != null) { %><script type="text/javascript">
window.vkAsyncInit = function() {
    VK.init({apiId: <%= vk.ApiId %>, onlyWidgets: true});
    VK.Widgets.Like("vk_like", {type: "mini", height: 20});
};
setTimeout(function() {
    var el = document.createElement("script");
    el.type = "text/javascript";
    el.src = "https://vk.com/js/api/openapi.js?143";
    el.async = true;
    document.getElementById("vk_api_transport").appendChild(el);
},0);
</script><% } %>
<% if (Config.Analytics.UseSputnik) { %>
<script type="text/javascript">
  (function(d, t, p) {
    var j = d.createElement(t); j.async = true; j.type = "text/javascript";
    j.src = ("https:" == p ? "https:" : "http:") + "//stat.sputnik.ru/cnt.js";
    var s = d.getElementsByTagName(t)[0]; s.parentNode.insertBefore(j, s);
  })(document, "script", document.location.protocol);
</script><% } %>
