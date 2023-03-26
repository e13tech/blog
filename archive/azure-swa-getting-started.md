Title: Azure Static Web Apps - Getting Started
Lead: Say goodbye to complex web hosting setups and hello to Azure Static Web Apps - the cloud-based platform that streamlines the process of building and deploying static web apps.
Published: 3/1/2023
Image: images/posts/conny-schneider-xuTJZ7uD7PI-unsplash.jpg
Author: JJ Bussert
AuthorUrl: https://www.linkedin.com/in/jjbussert/
Keywords: Microsoft Azure, Azure Static Web App
Tags:
 - Microsoft Azure
 - Azure Static Web App
---

The development world is flooded with options these days, from traditional web hosting to cloud-based solutions and everything in between. It can be overwhelming and time-consuming to navigate the many available options and choose the best one for your project, but what if you just need to host .... That's where Azure Static Web Apps comes in. Azure Static Web Apps is a great option provided by Microsoft that allows developers to build and deploy static web apps quickly and easily, with a focus on the code and what value the app can provide rather than the infrastructure side that may not be as familiar. In this post, we'll take a look at how to get started with Azure Static Web Apps and how to deploy a static web app to Azure.

## Why choose Azure Static Web Apps?
There are a few key reasons why I get excited about SWA, all of which are focused on lowering the barrier to entry for developers. 

Here are a few of them:

1. **The Price is right**

    Azure Static Web Apps is free to get started with.  This means that you can host your app on Azure without having to worry about paying for it.  You can read more about the pricing [here](https://azure.microsoft.com/en-us/pricing/details/app-service/static/).

2. **CI/CD is provided for you**

    Azure Static Web Apps provides a built-in CI/CD pipeline that will build and deploy your app to Azure.  This means that you don't have to worry about setting up a CI/CD pipeline for your app, you can focus on the code and what value it provides.

3. **Start properly with a tiered application**

    Azure Static Web Apps provides everything you need to build a typical tiered web app, including a front-end, back-end, and database.  This means that you can build a full-stack web app without having to worry about setting up a database or a back-end API.

4. **Included ssl and custom domains**

    Azure Static Web Apps provides built-in SSL and custom domains for your app.  This means that you can host your app on a custom domain and have it secured with SSL without having to worry about setting up a certificate or configuring a reverse proxy.

5. **Built in branch deployments**

    Azure Static Web Apps provides built-in [branch deployments](https://docs.microsoft.com/en-us/azure/static-web-apps/review-deploy-staging-environments?tabs=azure-devops) for your app.  This means that you can deploy your app to a unique URL for each branch in your repository.  This is incredibly useful for testing changes in isolation before merging them into your main branch.

## How do I get started with Azure Static Web Apps?

It's pretty simple to get started with SWA, I'll focus on doing everything from the command line for ease use.  I will use winget to install everything, if you don't have winget installed you can install it from [here](https://docs.microsoft.com/en-us/windows/package-manager/winget/).

1. Use winget to install the necessary tools

	<pre class='language-powershell line-numbers' style='white-space:pre-wrap;'><code>winget install Microsoft.AzureCLI
   winget install Microsoft.Azure.StaticWebApps
   winget install Microsoft.Azure.FunctionsCoreTools</code></pre>

   All of these are fairly straight forward
    * [1] : Azure CLI that enables you to interact with Azure resources
    * [2] : StaticWebApps CLI specifically for interacting with Azure Static Web Apps
    * [3] : Azure Function Core Tools that enables you to interact with Azure Functions

2. Create an azure account if you don't already have one

    This should be obvious but you will need an Azure account to use Azure Static Web Apps.  If you don't have one you can create one [here](https://azure.microsoft.com/en-us/free/).

3. Create a repository on Github or Azure DevOpos

    Everything to do with Azure Static Web Apps is done through a repository.  You can use Github or Azure DevOps to host your repository.  If you don't have a repository you can create one for free on your platform of choice.

4. Prep your code environment of choice

    You can use any code environment of choice to develop your app.  I will be using Visual Studio Code for this example.  If you don't have Visual Studio Code installed you can install it [here](https://code.visualstudio.com/).

If you 

Now you're ready to get going with Azure Static Web Apps! In part 2 of this series we'll take a look at actually creating an app.

<span>Special Thanks to <a href="https://unsplash.com/@choys_?utm_source=unsplash&amp;utm_medium=referral&amp;utm_content=creditCopyText">Conny Schneider</a> on <a href="https://unsplash.com/?utm_source=unsplash&amp;utm_medium=referral&amp;utm_content=creditCopyText">Unsplash</a> for the photo used for this post</span>