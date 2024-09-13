Title: Fun with Windows Terminal - WSL / Ubuntu
Lead: You cannot look at Windows Terminal without delving into WSL, First up Ubuntu
Published: 4/2/2020
Image: images/daniel-josef-AMssSjUaTY4-unsplash.jpg
Author: JJ Bussert
AuthorUrl: https://www.linkedin.com/in/jjbussert/
Keywords: Windows Terminal, Ubuntu, WSL, GitHub, VS Code
Tags:
 - Windows Terminal
 - Ubuntu
 - WSL
 - GitHub
 - VS Code
---
[Previously](xref:windows-terminal-getting-started) I explained how to get started with windows terminal by setting up PowerShell Core as the default profile, but why would you want multiple terminal profiles?  IMO one of the best use cases is [WSL (Windows Subsystem for Linux)](https://en.wikipedia.org/wiki/Windows_Subsystem_for_Linux).  The ability to run a linux distro locally on Windows isn't groundbreaking, [Virtual Machine](https://en.wikipedia.org/wiki/Virtual_machine) tech has been around forever, but what Microsoft did with WSL makes it so convenient and easy to use compared to spinning up a traditional VM.  The setup I'll go through below enables you to interact with a linux distro, in this case Ubuntu, but work against your local C drive from windows just like you would from a traditional cmd or powershell terminal.  Combine that with Windows Terminal's tabbed profiles and you have the ability to bounce between different environments all running on the same system seamlessly.  And even though you could set all of this up by hand... who has time for that!  

If you want to use the same icons and backgrounds as me you can find them in my [terminal github repository](https://github.com/JJBussert/terminal) where I sync my setup to.

1. Go to the Microsoft App Store > Search for "WSL"
    [![WSL](/images/posts/fun-with-windows-terminal/appstore-wsl.png "WSL")](/images/posts/fun-with-windows-terminal/appstore-wsl.png)
    
2. For this walkthrough choose Ubuntu
    [![Linux Distros](/images/posts/fun-with-windows-terminal/appstore-distros.png "Linux Distros")](/images/posts/fun-with-windows-terminal/appstore-distros.png)

3. Install WSL Feature - Execute the following powershell command from an elevated terminal
    
    ```powershell
    Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux
    ```

4. Now that WSL and the Ubuntu distro are installed launch Ubuntu from the start menu
    [![Launch Ubuntu](/images/posts/fun-with-windows-terminal/ubuntu-launch.png "Launch Ubuntu")](/images/posts/fun-with-windows-terminal/ubuntu-launch.png)
    [![Install Ubuntu](/images/posts/fun-with-windows-terminal/ubuntu-install.png "Install Ubuntu")](/images/posts/fun-with-windows-terminal/ubuntu-install.png)
    [![Configure Ubuntu](/images/posts/fun-with-windows-terminal/ubuntu-configure.png "Configure Ubuntu")](/images/posts/fun-with-windows-terminal/ubuntu-configure.png)
    The steps are intuitive, last one being setting up a username for yourself in this distro

5. Launch Windows Terminal and execute `code $settings` > this will bring up VS Code with the Windows Terminal profile.json in it, look for a section with commandline="Windows.Terminal.Wsl" and name="Ubuntu" and update it like below.
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
              ...
              {
                  "guid": "{2c4de342-38b7-51cf-b940-2309a097f518}",
                  "hidden": false,
                  "name": "Ubuntu",
                  "backgroundImage": "C:\\_\\_terminal\\ubuntu-logo.png",
                  "backgroundImageOpacity": 0.3,
                  "backgroundImageAlignment": "bottomRight",
                  "backgroundImageStretchMode": "none",
                  "source": "Windows.Terminal.Wsl",
                  "icon": "C:\\_\\_terminal\\ubuntu-icon.png"
              },
              ...
          ]
      },

      ...
    }
    ```

    Mostly repeated from part 1, let's look at the important sections:
    * [8-14] : For me I wanted to have some settings the same across profiles such as font and starting directory
    * [19-27] : In order to more easily identify the terminal type (but mostly because it's fun) I've updated the profile with and icon and background image.

6. Now in Windows terminal you should see Ubuntu as an option for a new tab and you should see something like this:
    [![Starting Ubuntu Terminal](/images/posts/fun-with-windows-terminal/ubuntu-terminal-start.png "Starting Ubuntu Terminal")](/images/posts/fun-with-windows-terminal/ubuntu-terminal-start.png)
    And as great as this is, we can do better so lets add powerline

7. Execute the following in the new Ubuntu terminal
    ```bash
    sudo apt-get update 

    sudo apt install golang-go
    go get -u github.com/justjanne/powerline-go
    ```

    * [1] : This will update the package repository cache, only needed for an initial install
    * [3-4] : Installs Go and uses it to install powerline-go

8. Execute `code ~/.bashrc` and add the following to the bottom
    ```powershell
    GOPATH=$HOME/go
    function _update_ps1() {
        PS1="$($GOPATH/bin/powerline-go -modules nix-shell,venv,ssh,cwd,perms,git,hg,jobs,exit,root,vgo -error $?)"
    }
    if [ "$TERM" != "linux" ] && [ -f "$GOPATH/bin/powerline-go" ]; then
        PROMPT_COMMAND="_update_ps1; $PROMPT_COMMAND"
    fi
    ```
   I'll start with launching VSCode from the ubuntu terminal, assuming this is the first time you've done this the code server will be downloaded into the terminal.  This little gem will allow you to launch VS Code from your local machine against a file w/in Ubuntu.  This looks trivial because of how seamlessly this is delivered but there is a lot going on under the covers here.

   Adding these lines will enable powerline-go as part of bash.  One tweak I made to this code taken from the [powerline-go installation page](https://github.com/justjanne/powerline-go) was changing the list of default modules being loaded on line [3] to remove the username@computer from the powerline.

I'd love to take credit for figuring all of this out but [Scott Hanselman posted the article](https://www.hanselman.com/blog/HowToMakeAPrettyPromptInWindowsTerminalWithPowerlineNerdFontsCascadiaCodeWSLAndOhmyposh.aspx) that I followed originally to get this setup going, these steps are my adaptation building upon his work.  You can see below a screenshot of the final result.

<div style="padding-bottom: 200px">

[![Final Ubuntu Terminal](/images/posts/fun-with-windows-terminal/ubuntu-terminal.png "Final Ubuntu Terminal")](/images/posts/fun-with-windows-terminal/ubuntu-terminal.png)  

</div>

What do you think of WSL running Ubuntu via Windows Terminal? What is your linux distro of choice? What different customizations did you make?  Share in the comments below?

Special thanks to <a style="background-color:black;color:white;text-decoration:none;padding:4px 6px;font-family:-apple-system, BlinkMacSystemFont, &quot;San Francisco&quot;, &quot;Helvetica Neue&quot;, Helvetica, Ubuntu, Roboto, Noto, &quot;Segoe UI&quot;, Arial, sans-serif;font-size:12px;font-weight:bold;line-height:1.2;display:inline-block;border-radius:3px" href="https://unsplash.com/@josef_photography?utm_medium=referral&amp;utm_campaign=photographer-credit&amp;utm_content=creditBadge" target="_blank" rel="noopener noreferrer" title="Download free do whatever you want high-resolution photos from Daniel Josef"><span style="display:inline-block;padding:2px 3px"><svg xmlns="http://www.w3.org/2000/svg" style="height:12px;width:auto;position:relative;vertical-align:middle;top:-2px;fill:white" viewBox="0 0 32 32"><title>unsplash-logo</title><path d="M10 9V0h12v9H10zm12 5h10v18H0V14h10v9h12v-9z"></path></svg></span><span style="display:inline-block;padding:2px 3px">Daniel Josef</span></a> for the photo used in this post!