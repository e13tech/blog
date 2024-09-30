Title: Fun with Windows Terminal - WSL / Kali
Lead: You cannot look at Windows Terminal without delving into WSL, Next up Kali - the security focused distro
Published: 4/3/2020
Image: images/blurrystock-HIbAmybJHVs-unsplash.jpg
Author: JJ Bussert
Keywords: Windows Terminal, Kali, WSL, GitHub, VS Code
Tags:
 - Windows Terminal
 - Kali
 - WSL
 - GitHub
 - VS Code
---
[Previously](xref:windows-terminal-getting-started) I explained how to get started with windows terminal by setting up PowerShell Core as the default profile, [Next I setup Ubuntu](xref:windows-terminal-wsl-ubuntu) as my first [WSL (Windows Subsystem for Linux)](https://en.wikipedia.org/wiki/Windows_Subsystem_for_Linux) distro but why stop there?  Next we'll go through setting up [Kali](https://en.wikipedia.org/wiki/Kali_Linux), a Linux distro known for being designed for digital forensics and penetration testing (aka a heavy focus on digital security scenarios which is why I like having access to it).  

For this post I'll assume that you have already setup Ubuntu or another WSL distro to look at how easy it is to add additional distros once the pre-reqs have been completed for another.

If you want to use the same icons and backgrounds as me you can find them in my [terminal github repository](https://github.com/JJBussert/terminal) where I sync my setup to.

1. Go to the Microsoft App Store > Search for "WSL"
    [![WSL](/images/posts/fun-with-windows-terminal/appstore-wsl.png "WSL")](/images/posts/fun-with-windows-terminal/appstore-wsl.png)
    
2. For this walkthrough choose Kali
    [![Linux Distros](/images/posts/fun-with-windows-terminal/appstore-distros.png "Linux Distros")](/images/posts/fun-with-windows-terminal/appstore-distros.png)

3. Kali is now ready to finish setting up
    [![Launch Kali](/images/posts/fun-with-windows-terminal/kali-launch.png "Launch Kali")](/images/posts/fun-with-windows-terminal/kali-launch.png)
    [![Install Kali](/images/posts/fun-with-windows-terminal/kali-install.png "Install Kali")](/images/posts/fun-with-windows-terminal/kali-install.png)
    [![Configure Kali](/images/posts/fun-with-windows-terminal/kali-configure.png "Configure Kali")](/images/posts/fun-with-windows-terminal/kali-configure.png)
    The steps are intuitive, last one being setting up a username for yourself in this distro

5. Launch Windows Terminal and execute `code $settings` > this will bring up VS Code with the Windows Terminal profile.json in it, look for a section with commandline="Windows.Terminal.Wsl" and name="Kali" and update it like below.
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
                  "guid": "{46ca431a-3a87-5fb3-83cd-11ececc031d2}",
                  "hidden": false,
                  "name": "kali",
                  "source": "Windows.Terminal.Wsl",
                  "backgroundImage": "C:\\_\\_terminal\\kali.png",
                  "backgroundImageOpacity": 0.3,
                  "backgroundImageAlignment": "bottomRight",
                  "backgroundImageStretchMode": "none",
                  "icon": "C:\\_\\_terminal\\icon-kali.png"
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

6. Now in Windows terminal you should see Kali as an option for a new tab and you should see something like this:
    [![Starting Kali Terminal](/images/posts/fun-with-windows-terminal/kali-terminal-start.png "Starting Kali Terminal")](/images/posts/fun-with-windows-terminal/kali-terminal-start.png)
    And as great as this is, we can do better so lets add powerline

7. Execute the following in the new Kali terminal
    ```bash
    sudo apt-get update 

    sudo apt install golang-go
    sudo apt install git
    go get -u github.com/justjanne/powerline-go
    ```

    * [1] : This will update the package repository cache, only needed for an initial install
    * [3-5] : Installs Go, Git, and uses them to install powerline-go

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
   Similar to the Ubuntu post the WSL Kali distro includes the `code` command for downloading and installing the VSCode server to seamlessly execute VSCode installed on your local machine.

   Adding these lines will enable powerline-go as part of bash.  One tweak I made to this code taken from the [powerline-go installation page](https://github.com/justjanne/powerline-go) was changing the list of default modules being loaded on line [3] to remove the username@computer from the powerline.

If you compare my [Ubuntu](xref:windows-terminal-wsl-ubuntu) and Kali posts you'll see that the process is nearly identical, a slight tweak to the steps to install git because Kali doesn't come with it by default and you end up with the same result.  Clearly overkill but if you have penetration tests or any other security related scripts that you sync to a git repo it may be convenient to setup powerline like I have here.  You can see below a screenshot of the final result.

<div style="padding-bottom: 200px">

[![Final Kali Terminal](/images/posts/fun-with-windows-terminal/kali-terminal.png "Final Kali Terminal")](/images/posts/fun-with-windows-terminal/kali-terminal.png)  

</div>

What do you think of WSL running Kali via Windows Terminal? What is your linux distro of choice? What different customizations did you make?  Share in the comments below?

Special thanks to <a style="background-color:black;color:white;text-decoration:none;padding:4px 6px;font-family:-apple-system, BlinkMacSystemFont, &quot;San Francisco&quot;, &quot;Helvetica Neue&quot;, Helvetica, Ubuntu, Roboto, Noto, &quot;Segoe UI&quot;, Arial, sans-serif;font-size:12px;font-weight:bold;line-height:1.2;display:inline-block;border-radius:3px" href="https://unsplash.com/@blurrystock?utm_medium=referral&amp;utm_campaign=photographer-credit&amp;utm_content=creditBadge" target="_blank" rel="noopener noreferrer" title="Download free do whatever you want high-resolution photos from blurrystock"><span style="display:inline-block;padding:2px 3px"><svg xmlns="http://www.w3.org/2000/svg" style="height:12px;width:auto;position:relative;vertical-align:middle;top:-2px;fill:white" viewBox="0 0 32 32"><title>unsplash-logo</title><path d="M10 9V0h12v9H10zm12 5h10v18H0V14h10v9h12v-9z"></path></svg></span><span style="display:inline-block;padding:2px 3px">blurrystock</span></a> for the photo used in this post!