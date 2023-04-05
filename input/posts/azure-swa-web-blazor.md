Title: Azure Static Web Apps - Blazor WebAssembly
Lead: Say goodbye to complex web hosting setups and hello to Azure Static Web Apps - the cloud-based platform that streamlines the process of building and deploying static web apps.
Published: 3/2/2023
Image: images/posts/pankaj-patel-u2Ru4QBXA5Q-unsplash.jpg
Author: JJ Bussert
AuthorUrl: https://www.linkedin.com/in/jjbussert/
Keywords: Microsoft Azure, Azure Static Web App, Architecture, C#, Blazor, Blazor WebAssembly, SWA, VS Code
Tags:
 - Microsoft Azure
 - Azure Static Web App
 - C#
 - Blazor
 - Blazor WebAssembly
 - VS Code
---

# Azure Static Web Apps - Blazor WebAssembly

In the (Getting Started)[xref:azure-swa-getting-started] post, we discussed the basics of Azure Static Web Apps and how to get started with a simple static web app. In this post, we will take a look at an example of a Blazor WebAssembly app and how to deploy it to Azure Static Web Apps.

## Create a new Blazor WebAssembly app

To get started, we will create a new Blazor WebAssembly app using the .NET CLI. Open a terminal and run the following commands:

<pre class='language-powershell line-numbers' style='white-space:pre-wrap;'><code>winget install 
npm install --save-dev @azure/static-web-apps-cli
dotnet new blazorwasm -o App
cd App
dotnet add package Microsoft.AspNetCore.Components.WebAssembly.StaticWebAssets
cd ..
func init MyProject.Api --dotnet
Rename-Item MyProject.Api Api
</code></pre>



<span>Special Thanks to <a href="https://unsplash.com/@pankajpatel?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText">Pankaj Patel</a> on <a href="https://unsplash.com/photos/u2Ru4QBXA5Q?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText">Unsplash</a> for the photo used for this post</span>