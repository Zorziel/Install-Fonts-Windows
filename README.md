# Install Fonts (Windows)

A simple program to silently install all the fonts in a folder for all users on Windows 7+.  

Originally created to deploy fonts for all users through SCCM/MEM but can be used standalone or as part of a script or deployment package.  

## Dependencies
 - Windows 7 or above
 - .NET 4.5.2 or above
 - Administrator rights (if running manually)
 
## Instructions

### General Usage
1. Download InstallFonts.exe
2. Create a folder called "Fonts" in the same directory as InstallFonts.exe
3. Add any .otf or .ttf fonts to the Fonts folder (You can also add subdirectories containing font files in the Fonts folder)
4. Execute InstallFonts.exe as Administrator


### Viewing Output
This executable was meant to run silently so that it can be used with SCCM or another deployment system.  However, the executable will return a basic status and error info (if any) for each font that it parses.  In order to view this output, you'll need to launch either PowerShell (as Administrator) or the Command Prompt (as Administrator) and run InstallFonts.exe from there.  

## To-Do
 - Add support for other font file types
