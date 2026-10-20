[![MIT License](https://img.shields.io/github/license/mja00/VS-LiveMap-Revival?&logo=github&color)](https://github.com/mja00/VS-LiveMap-Revival/blob/master/LICENSE)
# LiveMap Re-Revival
## Overview
***
**This is a fork of the fork of the original by Billy**
LiveMap, is a Google Maps-like map for Vintage Story that can be viewed in a browser. Easy to set up when making use of LiveMap's integrated web server which works out-of-the-box, while also available to be integrated into existing websites running on Apache and the like.

**Note (October 2nd, 2026) :** Anything in this repository `README.md` should be considered possibly out-of-date at this given time due to me (SirJudge) still working on this to bring everything up to better standards. As refactors and fixes are put in this will drift and at some point be fully updated. Please bear with me through this transition and open a PR or issue if something has gone awry.

**Additional Note:** At this point in time translations are broken. I'm aware of this and hope to fix in a future patch.
## Currently Broken Features or Important Notes
- Security Audit. This needs to be done decently soonish. I can't really audit until I'm done with fixes and updates which will just take some more time. In theory from what I've read so far, it's spawning a standalone endpoint that uses protobuf and protobuf accessories for serializing data between front and back. While this should protect against malicious payloads it's also a potential opening. Some kind of scan + manual review combo should be done to mitigate any potential pitfalls from those who came before me or code that has since become a vulnerability.
## AI Policy
The original version of this mod which was forked and rebuilt enough using AI was eventually hit with a disruption due to .NET updates and depreciated API calls. This is a revival to the original revival and was done so without AI directly writing to this codebase from this commit (INSERT COMMIT HERE LATER) onwards. LLMs can and will be used for consultation - As my good friend said "Let the pattern machine find the pattern" - but will not be allowed to directly write any code.

I want this repository to remain free of generative AI written code from here forward. This refactor and all new additional logic will be artisnal hand written, just like ye' olden days as a reminder that they cannot come for human ingenuity.
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
Re-Re-Revival link
[https://mods.vintagestory.at/edit/mod/?assetid=72693](https://mods.vintagestory.at/edit/mod/?assetid=72693)

### Legacy URL:
Previous iteration of Re-Revival, this mod's predecessor
[https://mods.vintagestory.at/vslivemaprevival](https://mods.vintagestory.at/vslivemaprevival)
## For Developers
There is an extensive API that allows you to automate adding/updating your own layers and markers on the map.

### Documentation
Documentation used to be hosted through the old developer's site but I don't own that and at this moment don't have any plans to self host it so will leave that up to the developer to build locally. There's a lot of missing documentation I'll be working on adding as I work on various sections of the codebase to improve functionality.

To build the documentation locally, ensure you have [Doxygen](https://www.doxygen.nl/download.html) installed and run:

```
make docs
```

The generated documentation will be located in `docs/html`.

## Building from Source
Prerequisites:
* [.NET SDK 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
* [npm](https://www.npmjs.com/)
* [Node.js](https://nodejs.org/en)
* [ReSharper Extension](https://www.jetbrains.com/resharper/vscode/) (optional but highly recommended)

To build the project run the following commands:
```
# Removes build artifacts within the repository folder
make clean

# call build script in release mode
make build-prod

# call build script in debug mode
make build-debug

```

And the final zip will be located at `bin/mods/livemap.zip` if there were no errors.

## Running Tests
To run the automated test suite:

### Run All Tests
```bash
make tests
```

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
    </tr>
  </table>
</div>
