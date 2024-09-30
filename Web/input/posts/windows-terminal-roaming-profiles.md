Title: Fun with Windows Terminal - Roaming Profiles
Lead: Custom terminal profiles can be lots of fun (and useful/practical too!) but it can be terribly limiting to have to redo all of the steps every time.
Published: 4/4/2020
Image: images/luca-bravo-XJXWbfSo2f0-unsplash.jpg
Author: JJ Bussert
Keywords: Windows Terminal, VS Code, Github
Tags:
 - Windows Terminal
 - VS Code
 - Github
---
Clearly I'm a big fan of the [Windows Terminal](https://github.com/Microsoft/Terminal) but what i'm not a huge fan of is repeating myself.  As a consultant at any point in time I may have several different computers to work with and although the steps aren't terribly complicated it can be frustrating to try and keep multiple terminal profiles synchronized across several different computers. In addition to synchronization of the profiles it also seemed like others may enjoy seeing what I have configured to start their own setup from here, so enter my Github terminal [repository](https://github.com/JJBussert/terminal).

The easy part of the equation was using Github, a public vehicle for sharing code with the world but getting the settings out of the default user profile directories wasn't quite as straight forward. One requirement I had was a fairly dummy-proof way of syncing everything up without trying to remember what I changed, where the change was, and when I applied changes last if it's a system I don't use regularly.

Here are the scripts that I came up with, you can find these along with the icons and backgrounds at my [terminal github repository](https://github.com/JJBussert/terminal).

### Clone Repo locally
```powershell
cd c:\_
md c:\_\_terminal
git clone https://github.com/jjbussert/terminal _terminal
cd c:\_\_terminal
```

 This needs to be done once, feel free to clone mine directly or copy/fork what I started to make your own!

 ### hardlinks.ps1
```powershell
if(Test-Path Microsoft.PowerShell_profile.ps1) 
{ 
   Remove-Item Microsoft.PowerShell_profile.ps1 
}
New-Item `
   -Name Microsoft.PowerShell_profile.ps1 `
   -ItemType HardLink `
   -Value $env:HOME\Documents\Powershell\Microsoft.PowerShell_profile.ps1 

if(Test-Path profiles.json) 
{ 
   Remove-Item profiles.json 
}
New-Item `
   -Name profiles.json `
   -ItemType HardLink `
   -Value $env:HOME\AppData\Local\Packages\Microsoft.WindowsTerminal_*\LocalState\profiles.json
```
 * [1-3 & 10-12] : There are two files that we want to synchronize on our host system, these 2 if blocks will remove the files and setup hard links to those files in their locations in the $env:HOME directory where the shells expect them to be
 * [5-8] : This is the profile configuration of powershell core
 * [14-17] : this is the json containing the profiles for Windows Terminal itself

 The key consideration for this script is to be able to execute it and either initialize the environment or upgrade it if this has already been run before.  This script sets up hard links to the key files if they haven't already been setup, this way I can use git to synchronize files involved.  

### Conclusion
And that's it! Now keeping multiple system profiles in sync is a simple as a git pull just like you are likely already using in your day to day work.  These steps are specifically about the host Windows system but you can easily do something similar for the WSL distros to sync the .bashrc files.  

So what do you think of the repository for my Windows Terminal setup? Did you copy/clone your own? What adjustments did you make to your setup? Share in the comments below!

Special thanks to <a style="background-color:black;color:white;text-decoration:none;padding:4px 6px;font-family:-apple-system, BlinkMacSystemFont, &quot;San Francisco&quot;, &quot;Helvetica Neue&quot;, Helvetica, Ubuntu, Roboto, Noto, &quot;Segoe UI&quot;, Arial, sans-serif;font-size:12px;font-weight:bold;line-height:1.2;display:inline-block;border-radius:3px" href="https://unsplash.com/@lucabravo?utm_medium=referral&amp;utm_campaign=photographer-credit&amp;utm_content=creditBadge" target="_blank" rel="noopener noreferrer" title="Download free do whatever you want high-resolution photos from Luca Bravo"><span style="display:inline-block;padding:2px 3px"><svg xmlns="http://www.w3.org/2000/svg" style="height:12px;width:auto;position:relative;vertical-align:middle;top:-2px;fill:white" viewBox="0 0 32 32"><title>unsplash-logo</title><path d="M10 9V0h12v9H10zm12 5h10v18H0V14h10v9h12v-9z"></path></svg></span><span style="display:inline-block;padding:2px 3px">Luca Bravo</span></a> for the photo used in this post!