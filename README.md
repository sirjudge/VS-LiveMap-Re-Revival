[![MIT License](https://img.shields.io/github/license/mja00/VS-LiveMap-Revival?&logo=github&color)](https://github.com/mja00/VS-LiveMap-Revival/blob/master/LICENSE)
# LiveMap Re-Revival
## Overview
***
**This is a fork of the fork of the original by Billy**
LiveMap, is a Google Maps-like map for Vintage Story that can be viewed in a browser. Easy to set up when making use of LiveMap's integrated webserver which works out-of-the-box, while also available to be integrated into existing websites running on Apache and the like.

**Note:** Anything in this repository readme should be considered possibly out of date at this given time (October 2nd, 2026) due to me (SirJudge) still working on this to bring everything up to better standards. As refactors and fixes are put in this will drift and at some point be fully updated. Please bear with me through this transition and open a PR or issue if something has gone awry.

** Additional Note:** At this point in time translations are broken. I'm aware of this and hope to fix in a future patch.
## AI policy
The original version of this mod which was forked and rebuilt enough using AI was eventually hit with a disruption due to .NET updates and depreciated API calls. This is a revival to the original revival and was done so without the use of generative AI and will remain free of generative AI written code from here forward. This refactor and all new additional logic will be artisanal hand written, just like ye' olden days as a reminder that they cannot come for human ingenuity.
## Features
* **Integrated Web Server**: Out-of-the-box web hosting for the map, with no external dependencies required.
* **Real-time Updates**: The map updates automatically as players explore and modify the world.
* **Built-in Layers**:
    * **Players**: Track the location and health of online players.
    * **Traders**: Automatically mark discovered traders on the map.
    * **Translocators**: Keep track of discovered translocators for easy navigation.
    * **Spawn**: Highlights the world's default spawn point.
* **Rendering Styles**: Choose between multiple map styles, including **Basic** and **Sepia**.
* **High Performance**: Asynchronous rendering and task management ensure minimal impact on server performance.
* **Extensive API**: Easy for other mod developers to add custom layers, markers, and more.
* **Customizable UI**: Fully configurable logo, title, and attribution settings.

## Downloads and Releases

All releases can be downloaded from the VintageStory ModDB site at:

### New URL:
*WIP - Check back later*

### Legacy URL:
[https://mods.vintagestory.at/vslivemaprevival](https://mods.vintagestory.at/vslivemaprevival)

<!-- TODO: Figure out what to do with this section, this is the old version and also someone else's stuff -->
<!-- ## Demo -->
<!-- A live demo of LiveMap can be accessed at: -->
<!-- - https://vslivemap.mart.fyi/ -->
<!-- ![Screenshot of markers on map](https://raw.githubusercontent.com/mja00/VS-LiveMap-Revival/master/.github/images/og5.webp) -->

## For Developers
There is an extensive API that allows you to automate adding/updating your own layers and markers on the map.

### Documentation
Documentation is automatically generated and hosted on GitHub Pages. You can find it at:

[https://mja00.dev/VS-LiveMap-Revival/](https://mja00.dev/VS-LiveMap-Revival/)

To build the documentation locally, ensure you have [Doxygen](https://www.doxygen.nl/download.html) installed and run:

```powershell
.\build-docs.ps1
```

The generated documentation will be located in `docs/html`.

## Building from Source

Prerequisites:
* [.NET SDK 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
* [npm](https://www.npmjs.com/)
* [Node.js](https://nodejs.org/en)
* [ReSharper Extension](https://www.jetbrains.com/resharper/vscode/) (optional but highly recommended)

To build the project run the following command:

```
dotnet build
```

And the final zip will be located at `bin/mods/livemap.zip` if there were no errors.

## Running Tests
To run the automated test suite:

### Web Tests
```bash
cd web
npm test
```

### C# Tests
```bash
dotnet test
```

## Special Thanks
<div align="center">
  <table>
    <tr>
      <td align="center" width="33%">
        <a href="https://www.vintagestory.at/">
          <img width="200" src="https://content.invisioncic.com/r268468/monthly_2018_02/gamelogo-vintagestory-banner.thumb.png.5748739b983e8b748e7bcf976e74c4c2.png">
        </a>
      </td>
      <td align="center" width="33%">
        <a href="https://leafletjs.com/">
          <img width="200" src="https://leafletjs.com/docs/images/logo.png">
        </a>
      </td>
      <td align="center" width="34%">
        <a href="https://jetbrains.com/">
          <img width="200" src="https://resources.jetbrains.com/storage/products/company/brand/logos/jetbrains.png">
        </a>
      </td>
    </tr>
  </table>
  <table>
    <tr>
      <td align="center" width="33%">
        <a href="https://github.com/">
          <img width="200" src="https://github.githubassets.com/assets/GitHub-Logo-ee398b662d42.png">
        </a>
      </td>
      <td align="center" width="34%">
        <a href="https://www.jenkins.io/">
          <img width="200" src="https://mirror.xmission.com/jenkins/art/jenkins-logo/48x48/logo+title.png">
        </a>
      </td>
      <td align="center" width="33%">
        <a href="https://www.nuget.org/">
          <img width="200" src="https://www.nuget.org/Content/gallery/img/logo-header.svg">
        </a>
      </td>
    </tr>
  </table>
</div>
