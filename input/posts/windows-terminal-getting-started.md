Title: Fun with Windows Terminal - Getting Started
Lead: Windows terminal is the long overdue replacement enhancement of the terminal experience for Windows. Bringing to what is normally a very boring and often unfriendly experience a rich highly personalizable one.
Published: 4/1/2020
Updated: 9/13/2024
Image: images/christian-wiediger-WkfDrhxDMC8-unsplash.jpg
Author: JJ Bussert
AuthorUrl: https://www.linkedin.com/in/jjbussert/
Keywords: Windows Terminal, VS Code, PowerShell Core, DotNet Core
Tags:
 - Windows Terminal
 - VS Code
 - PowerShell Core
 - DotNet Core
---
For those of you that have yet to hear about the new [Windows Terminal](https://github.com/Microsoft/Terminal) I have to ask "have you been living under a rock?". Joking aside when Microsoft first announced their new open source terminal many of my colleagues were left asking why? Many of them have already found alternatives to the ancient cmd.exe console that's been shipping with windows since the beginning of time and most have already found their preferred alternative applications. Being a Microsoft fanboy these days I was excited by the 

One of the key aspects of Windows Terminal that got me excited was how easy it was to customize and the degree to which I could do it.  Certainly not as much as downloading the code and building my own custom version (which there are very interesting write-ups of people doing exactly for some fascinating results).  The provided profile customizations combined with some custom work the community has already done makes it so simple to do.  But I'm getting ahead of myself, let's take a look at how you can get started with Windows Terminal and how easy it is to make some impressive looking tweaks.  Below is everything you'll need to follow along with the rest of this series, I'm going out of my way to do everything via a CLI even if there is a UI path as well.

If you want to use the same icons and backgrounds as me you can find them in my [terminal github repository](https://github.com/JJBussert/terminal) where I sync my setup to.

1. Go to the Microsoft App Store > search for "[Windows Terminal](https://www.microsoft.com/en-us/p/windows-terminal-preview/9n0dx20hk701)"
    [![Windows Terminal](/images/posts/fun-with-windows-terminal/appstore-winterminal.png "Windows Terminal")](/images/posts/fun-with-windows-terminal/appstore-winterminal.png)    
    
2. Execute the follow powershell commands from an elevated terminal
    ```powershell
    Set-ExecutionPolicy Bypass -Scope Process -Force; `
        [System.Net.ServicePointManager]::SecurityProtocol = `
        [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; `
        iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
  
    choco upgrade dotnetcore-sdk -y
    choco upgrade git -y
  
    dotnet tool update --global PowerShell
  
    Install-PackageProvider -Name NuGet -Force
    Install-Module posh-git -Scope CurrentUser -Force -SkipPublisherCheck
    Install-Module oh-my-posh -Scope CurrentUser -Force -SkipPublisherCheck
    Install-Module PSReadLine -Scope CurrentUser -Force -SkipPublisherCheck
    ```
    
    There's a lot in here so lets break it down
    * [1-4] : [Chocolatey](https://chocolatey.org/) is a package manager for Windows that makes it easy to install apps via the command line
    * [5-7] : Now using choco it easy to install git and the dotnetcore sdk if you don't already have it installed
    * [9] : Once dotnetcore is installed we install powershell core as a dotnet global tool
    * [11-14] : Several PowerShell install commands for some additional pre-reqs needed to customize the appearance of our new terminal

3. Launch Windows Terminal and run `code $settings` > this will bring up VS Code with the Windows Terminal profile.json in it, look for a section with commandline="Windows.Terminal.PowershellCore" 
    ```json
    {
      "$schema": "https://aka.ms/terminal-profiles-schema",

      "defaultProfile": "{61c54bbd-c2c6-5271-96e7-009a87ff44bb}",

      "profiles":
      {
          "defaults":
          {
              "fontFace":"Delugia Nerd Font",
              "acrylicOpacity": 0.8,
              "useAcrylic": true,
              "startingDirectory": "C:\\_"
          },
          "list":
          [
              {
                  "guid": "{61c54bbd-c2c6-5271-96e7-009a87ff44bb}",
                  "name": "E13",
                  "commandline": "pwsh.exe",
                  "hidden": false,
                  "cursorShape": "vintage",
                  "cursorColor": "#00ffff",
                  "icon": "C:\\_\\_terminal\\e13_white.png",
                  "backgroundImage": "C:\\_\\_terminal\\e13_white.png",
                  "backgroundImageOpacity": 0.3,
                  "backgroundImageAlignment": "bottomRight",
                  "backgroundImageStretchMode": "none"
              },
              ...
          ]
      },

      "schemes": [],

      "keybindings": [
          { "command": "copy", "keys": ["ctrl+c"] },
          { "command": "paste", "keys": ["ctrl+v"] }
      ]
    }
    ```

    So lots of code here but the properties themselves are fairly self explanatory, let's look at the important sections:
    * [4] : Terminal supports multiple terminals in a tabbed interface, this is the id of the profile that you would like to be the default tab that opens initially
    * [8-14] : If there are settings that you would like to apply to all profiles, as an example I wanted to use the same font across all of my terminal profiles and always start in the C:\_ directory where I have all of my cloned git repos
    * [18-28] : For my default profile I have customized a pwsh terminal with a fun background image and colors, cursors, etc.
    * [30] : You can have as many profiles as you want, on top of that Terminal will auto-detect many terminals that you may have installed such as WSL terminals
    * [37-38] : In addition the visual modifications you can also define keybindings, by default ctrl+c/v (copy/paste) that I'm used to are not setup in order to avoid conflicts with people coming from Mac/Linux environments where those keys have other default meaning.  But I've been a windows guy for so long that muscle memory is near impossible for me to retrain so I'll keep my old habits.

3. Open Windows Terminal again now that powershellcore is the default terminal and run "code $profile" > this will bring up VS Code to modify the behavior of pwsh
    ```powershell
    $global:DefaultUser = [System.Environment]::UserName
   
    Import-Module posh-git
    Import-Module oh-my-posh
    Set-Theme Paradox
    ```
   
    * [1] : This will make it so the default username@computername does not show up in the powerline.  For my local development needs I don't need that
    * [3-5] : Import the modules that we installed back in step 2 along with setting a theme that will enable powerline

4. Install a Font w/ Powerline Glyphs
    There are several different options, two that I have used:
    * [Cascadia Code PL](https://github.com/microsoft/cascadia-code/releases)
    * [Delugia Code](https://github.com/adam7/delugia-code/releases)

    These aren't the only options and if you want an overload of options check out [Nerd Fonts](https://www.nerdfonts.com/), the options are nearly limitless
    

We've done a lot, at this point your terminal should look something like the screenshot below.  You'll see that this example the yellow powerline shows that this directory is a cloned git repo that has changes to be sync'd.  In a following post I'll go through doing the same for a WSL profile.

<div style="padding-bottom: 200px">

[![Conclusion](/images/posts/fun-with-windows-terminal/conclusion.png "Conclusion")](/images/posts/fun-with-windows-terminal/conclusion.png)  

</div>

So what do you think of Windows Terminal? did you configure powerline? How did you personalize your powershell core terminal? Please share in the comments below.

Special thanks to <a style="background-color:black;color:white;text-decoration:none;padding:4px 6px;font-family:-apple-system, BlinkMacSystemFont, &quot;San Francisco&quot;, &quot;Helvetica Neue&quot;, Helvetica, Ubuntu, Roboto, Noto, &quot;Segoe UI&quot;, Arial, sans-serif;font-size:12px;font-weight:bold;line-height:1.2;display:inline-block;border-radius:3px" href="https://unsplash.com/@christianw?utm_medium=referral&amp;utm_campaign=photographer-credit&amp;utm_content=creditBadge" target="_blank" rel="noopener noreferrer" title="Download free do whatever you want high-resolution photos from Christian Wiediger"><span style="display:inline-block;padding:2px 3px"><svg xmlns="http://www.w3.org/2000/svg" style="height:12px;width:auto;position:relative;vertical-align:middle;top:-2px;fill:white" viewBox="0 0 32 32"><title>unsplash-logo</title><path d="M10 9V0h12v9H10zm12 5h10v18H0V14h10v9h12v-9z"></path></svg></span><span style="display:inline-block;padding:2px 3px">Christian Wiediger</span></a> for the photo used in this post!