# Nostalgia
Nostalgia is a compatibility layer that enables you to use Garry's Mod addons with S&box.

## Project status
At the moment, this project is nothing more than a little proof of concept.  
All it can do now is to load addons which only use `print()`, `Msg()` and such. Everything else is not implemented.

## Requirements
.NET 5.0 SDK is required to install the addon with Nake.

## How to use
1. At the moment, we have not completely get rid of reflection usage in MoonSharp, so you'll need to edit your access groups (whitelist of symbols that S&Box addons can use).
   Open `(S&box root)/config/accessgroups/baseaccess.txt` and add an asterisk (\*) on a new line at any point of the file.
   > **This completely disables S&box security measures and allows malicious addons to do all kinds of nasty things on your computer, so refrain from joining untrusted servers and playing untrusted gamemodes with this.**
2. [Create a new local S&box addon](https://wiki.facepunch.com/sbox/Making_Gamemode) (they're called "Gamemodes" as there is no support for standalone Garry's Mod-esque addons in S&box yet) and name its folder "nostalgia".
3. Download the source code of [a special version of MoonSharp](https://github.com/javabird25/moonsharp) and extract it to `(S&box root)/addons/nostalgia/code/moonsharp`.
4. Clone or download Nostalgia's repository at S&box root (not to the addons folder, but next to it).
5. Open a terminal at this repository root and run `dotnet tool restore` to install [Nake](https://github.com/yevhen/Nake) locally.
6. Run `dotnet nake install` to copy Nostalgia's source code to the addon you created in step 1.
7. Place your Garry's Mod addons to `(S&box root)/data/local/nostalgia/addons`.
