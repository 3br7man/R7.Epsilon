# About R7.Epsilon

[![BCH compliance](https://bettercodehub.com/edge/badge/roman-yagodin/R7.Epsilon)](https://bettercodehub.com/)
[![Join the chat at https://gitter.im/roman-yagodin/R7.Epsilon](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/roman-yagodin/R7.Epsilon?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

*R7.Epsilon* is an opensource responsive skin (theme) for DNN Platform based on Bootstrap 3.
See it in action at http://www.volgau.com!

# Features

- Admins can define website-specific configuration options via <del>XML</del> YAML file.
- Users can switch between a11y and normal theme. In the a11y mode DNN modal popups are blocked (if they are enabled).
- Variety of containers, including DNN-style messages, Bootstrap alerts, panels, thumbnails, callouts, etc.
- Home, Edit, Admin + Universal skin variants, reusable through all host portals.
- Social group icons (including a11y versions) for Facebook, Twitter, Google+, YouTube, VK.com, Instagram, Linkedin.
- Social share buttons for Facebook, Twitter, Google+, VK.com.
- Completely localizable parts (full Russian translation included).
- Website and host admins can customize and website-wide and host-wide content using language editor.
- Devs can define styles using <del>Less</del> SCSS.
- Devs can use [Paletton.com](http://paletton.com) to create and customize palettes.
- Integration with feedback forms including passing user-selected content.
- Google Adsense adaptive banners support for different screen sizes with automatic loading on window resize.
- Optional [cnt.sputnik.ru](https://cnt.sputnik.ru/) analytics support.

## Custom pane layouts feature (WIP)

Admins can create and modify custom pane layouts using *LayoutManager* module, then apply them to the page 
using new *Select Layout* command from *Edit Page* menu in the control panel. Selected layout name and kind (host or portal)
are stored in the page settings. Additional layout can be set to use in a11y mode.

This feature currently available only if *Custom* skin is selected for a page.

## Some planned features:

- BlueImp gallery support (at least for Home skin).
- Integration of Bootstrap into skin build process.

# Install

- Install [LazyAds javascript library](https://github.com/roman-yagodin/R7.Dnn.JavaScriptLibraries/releases/tag/lazyads-v1.1.10) dependency.
- Install [Rangy javascript library](https://github.com/roman-yagodin/R7.Dnn.JavaScriptLibraries/releases/tag/rangy-v1.3.0) dependency.
- Install latest *R7.Epsilon* version from [releases](https://github.com/roman-yagodin/R7.Epsilon/releases).

Optionally replace `Global.asax` file in the application root folder with one shipped alongside skin install package
(this will enable more advanced `VaryByCustom` cache options for skin controls - by PortalId, by UserRoles).

## Banner skinobject support for DNN 8/9

Please see [this wiki page](https://github.com/roman-yagodin/R7.Epsilon/wiki/Install:-Banner-skinobject-support-for-DNN-8-and-9)

# Acknowledgements

Project code originates from Chris Hammond's [HammerFlex](https://github.com/ChrisHammond/HammerFlex) skin 
and utilizes some ideas from [Tidy](http://tidy.codeplex.com/) skin. You should really try them too!

# License

[![AGPLv3](https://www.gnu.org/graphics/agplv3-155x51.png)](https://www.gnu.org/licenses/agpl-3.0.html)

The *R7.Epsilon* is free software: you can redistribute it and/or modify it under the terms of 
the GNU Affero General Public License as published by the Free Software Foundation, either version 3 of the License, 
or (at your option) any later version.

## License for assets

Social icons based on Stephen Hutchings's [Typicons](https://github.com/stephenhutchings/typicons.font), 
published under the terms of [CC BY-CA](http://creativecommons.org/licenses/by-sa/3.0/) license.

Google translate and A11y icons based on Xaviju's [Inkscape Open Symbols](https://github.com/Xaviju/inkscape-open-symbols),
the source of which is published under [GPLv2](http://opensource.org/licenses/GPL-2.0) license.

# Customization

As you should already know, any website skin is more like a template which should be customized (sometimes very heavily)
before using it in production. The *R7.Epsilon* skin developed with per-DNN-portal reuse, configuration and customization in mind,
so (hopefully) you can configure and customize it for your website pretty fast.

Some links to allow you to get started:

- The section about customization in the [project wiki](https://github.com/roman-yagodin/R7.Epsilon/wiki/Customization)
- Example of customization project: [volgau/R7.Epsilon.Customizations](https://github.com/volgau/R7.Epsilon.Customizations)
