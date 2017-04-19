![logo](https://raw.githubusercontent.com/ennerperez/hudplugin/master/src/.editoricon.png)

# Hud Plugin

Cross platform plugin to display HUD's dialog through a single API from Xamarin.iOS and Xamarin.Android.

[![Build status](https://ci.appveyor.com/api/projects/status/wjtnc7oeo14f162l?svg=true)](https://ci.appveyor.com/project/ennerperez/hudplugin)
[![NuGet](https://img.shields.io/nuget/v/Xam.Plugin.Hud.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugin.Hud/)

---------------------------------------

See the [changelog](CHANGELOG.md) for changes.

## Featuring

**Platform Support**

|Platform|Version|
| ------------------- | :------------------: |
|Xamarin.iOS|iOS 6+|
|Xamarin.Android|API 10+|

## Roadmap
- [x] Initial CrossHUD implementation
- [ ] iOS timer autoDismiss (WIP)
- [ ] CrossShowImage
- [ ] Other platforms

## Table of contents

* [Implementing](#implementing)
* [Bugs and feature requests](#bugs-and-feature-requests)
* [Documentation](#documentation)
* [License](#license)

### Implementing

**Add the library to your project**
* Install into your PCL project and Client projects.
 
Add the [NuGet Package](https://www.nuget.org/packages/Xam.Plugin.Hud/). Right click on your project and click 'Manage NuGet Packages...'. Search for 'Hud' and click on install. Once installed the library will be included in your project references. (Or install it through the package manager console: PM> Install-Package Xam.Plugin.Hud)

**Build Status**
* CI NuGet Feed: https://ci.appveyor.com/nuget/hudplugin

### Bugs and feature requests

Have a bug or a feature request? Please first search for existing and closed issues. If your problem or idea is not addressed yet, [please open a new issue](https://github.com/ennerperez/hudplugin/issues/new).

**Setup**
* Available on NuGet: http://www.nuget.org/packages/Xam.Plugin.Hud 

### Documentation

**API Usage**

Call **CrossHud.Current** from any project or PCL to gain access to APIs.

### License

Code released under [The MIT License](LICENSE)
