Title: Azure Static Web Apps - TBD
Lead: TBD
Published: 4/1/2023
Image: images/posts/conny-schneider-xuTJZ7uD7PI-unsplash.jpg
Author: JJ Bussert
AuthorUrl: https://www.linkedin.com/in/jjbussert/
Keywords: Microsoft Azure, Azure Static Web App
Tags:
 - Microsoft Azure
 - Azure Static Web App
 - Architecture
---

As the demand for fast, scalable, and secure web solutions continues to grow, Azure Static Web Apps have emerged as a powerful and flexible platform for developers. This series is will guide you through the fundamentals of Azure Static Web Apps, deployment process, and look at comprehensive examples. By the end of this journey, you'll be well-equipped to harness the full potential of Azure Static Web Apps and take your web development projects to new heights.

## What is Azure Static Web Apps?

Azure Static Web Apps is a cloud-based platform that streamlines the process of building and deploying static web apps. It's a fully managed service that provides a simple, cost-effective, and secure way to host your static web apps. Azure Static Web Apps is built on top of Azure App Service, which means you can take advantage of all the benefits of App Service, including:

- **Scalability** - Azure Static Web Apps can scale up or down to meet your needs. You can also scale out to multiple instances to handle increased traffic.
- **Security** - Azure Static Web Apps is built on top of Azure App Service, which provides a secure and reliable platform for hosting your static web apps.
- **Reliability** - Azure Static Web Apps is built on top of Azure App Service, which provides a secure and reliable platform for hosting your static web apps.
- **Performance** - Azure Static Web Apps is built on top of Azure App Service, which provides a secure and reliable platform for hosting your static web apps.

## Why use Azure Static Web Apps?

For me the biggest reason to use Azure Static Web Apps is the simplicity. With the [recent annoucement](https://aka.ms/swa/database-connections) that you can automatically generate REST and GraphQL APIs from your static web apps, you can now build a full stack web application without having to worry about the tedious part of writing a backend. This is a huge win for developers who want to focus on building great user experiences.  Now you can easily bundle a multi-tier application including:

- Frontend - HTML, CSS, JavaScript, and other static assets
- Backend - Azure Function
- Database - Azure SQL Database, Azure Cosmos DB, or any other database that supports REST or GraphQL APIs
- Authentication - Azure Active Directory, Facebook, Google, Twitter, or any other identity provider that supports OpenID Connect
- CI/CD - GitHub Actions or Azure DevOps Pipelines auto generated and configured for you
- **Forces Serverless Patterns** - Apps that are built for serverless architectures are inherently easier to scalable, secure, and are (in my opinion) more reliable.  This is likely the most challenging point for developers to get their head around.  The idea of not having a server to manage is a foreign concept to many developers.  However, the benefits of serverless architectures are well documented and are becoming more and more popular. If you are interested in learning more about serverless architectures I would recommend checking out [Serverless apps: Architecture, patterns, and Azure implementation](https://learn.microsoft.com/en-us/dotnet/architecture/serverless/).

All of this in your choice of programming language. You can even use your own custom domain name and provided SSL certificate to get your app production ready.

## Pre-requisites

There are a couple of things you will need to get started.

1. **An Azure account**

    This should be obvious but you will need an Azure account to use Azure Static Web Apps.  If you don't have one you can create one [here](https://azure.microsoft.com/en-us/free/).

2.  **A git based repository** 

    Everything to do with Azure Static Web Apps is done through a git repository hosted in either Github or Azure DevOps.  If you don't have a repository you can create one for free on your platform of choice.  

3. **Command line tools**

    I used the winget command line tool to install the following tools.  You can find more information about winget [here](https://docs.microsoft.com/en-us/windows/package-manager/winget/).

	<pre class='language-powershell line-numbers' style='white-space:pre-wrap;'><code>winget install CoreyButler.NVMforWindows
   nvm install 16
   nvm use 16
   winget install -e Git.Git</code></pre>

   All of these are fairly straight forward
    * [1] : I recommend using NVMforWindows to manage your node versions.  This will allow you to easily switch between different versions of node.
    * [2-3] : Azure CLI and Azure Function Core Tools are both installed using npm.  As of the time of authoring this I ran into issues with later versions of npm with some types of apps so I recommend using npm version 16.
    * [1] : Azure CLI that enables you to interact with Azure resources
    * [2] : StaticWebApps CLI specifically for interacting with Azure Static Web Apps
    * [3] : Azure Function Core Tools that enables you to interact with Azure Functions
      - Note: You should be able to install the Azure Function Core Tools using npm but I had issues with this.  I would recommend using winget to install this.
    * [4] : Git CLI that enables you to interact with git repositories (you likely already have this installed but just in case)

4. **An Application**

    Last you will obviously need an application to deploy.  The front end must be able to be statically built along with (optionally) an api that is written to be serverless. In following posts I will be demonstrating how to build simple applications in different languages & frameworks to serve as examples and also demonstrating differences between them.  

## My Approach

It took me a while to come up with what I felt was the best approach to implementing Azure Static Web Apps.  I wanted to be able to build a simple application that could be deployed to Azure Static Web Apps and then be able to easily add additional functionality to it.  I also wanted to be able to easily switch between different languages and frameworks to demonstrate the differences between them.  And most importantly I wanted the ultimate solution to be intuitive and easy to understand.  A solution that makes sense today but is confusing tomorrow is not a solution. 

    1. use an npm package.json to manage dependencies and scripts
    2. use a .env file to manage environment variables
    3. use efcore to manage database migrations
    4. use Azure B2C for authentication
    
I know what you are thinking, "This blog is almost always about C# based solutions and now I need npm?"  I hear you however there are a few reasons why I chose this approach.  First, I wanted a solution that would work regardless of the language or framework you are using.  My first example will be in C# & Blazor however I often am building out front ends in Angular, React, etc. and I wanted a solution that would work for all of them so that I didn't need do more than update the scripts that are being called.  Second, I wanted a solution that is easy to maintain.  The various CLI tools that I want to use are all available as npm packages and from what I could see the npm versions of these commands are available faster than other package managers such as choco or winget.  Third, I wanted the final solution to allow devs to locally run and setup everything they need to run the application as closely to how it would be running in production as possible.  Lastly, I needed the solution to be easy to tweak and customize.  Not every solution is going to be the same, not every project will have the same requirements or conventions. I wanted a solution that would allow developers to easily customize it to fit their needs and not try to force them to accomodate an approach that may not fit perfectly.

I also wanted this solution to work no matter what environment I was developing in.  I primary use Visual Studio however when I'm working on a front end I often use VS Code because the tooling is better.  For the rest of this series I will be validating everything in VS Code because its more accessible to the majority of developers but I will call out how to do things in Visual Studio as well.

## Core Directory Structure & Files

```text
.
├── Api/
│   └── local.settings.json
│   └── ...
├── Db/
│   └── staticwebapp.database.config.json
│   └── ...
├── Web/
│   └── Properties/launchSettings.json (Blazor WSAM)
│   └── ...
├── .env
├── package.json
├── ...
```

Obviously the actual Api/Db/Web code will contain your actual 

#### The NPM package.json

<pre class='language-json line-numbers' style='white-space:pre-wrap;'><code>{
  "scripts": {
    "start": "concurrently \"npm run start-api\" \"npm run start-web\" \"npm run start-swa\"",

    "start-api": "cd Api && func start --csharp",
    "start-web": "cd Web && dotnet watch run",
    "start-swa": "swa start --data-api-location db",

    "db-reset": "cd Db && dotnet ef database drop -f && dotnet ef database update && dotnet run",
    "db-migrate": "cd Db && dotnet ef migrations add \"$(date +%s)\"",
    "db-update": "cd Db && dotnet ef database update",
    "db-drop": "cd Db && dotnet ef database drop -f"
  },
  "devDependencies": {
    "@azure/static-web-apps-cli": "^1.1.1",
    "azure-functions-core-tools": "^4.0.5095",
    "concurrently": "^8.0.1"
  }
}</code></pre>

There's a lot going on here so let's break it down.

* [3] : start script - the main entry point for the application.  This will start the api, web, and swa cli tools all at once.  This is accomplished by using the concurrently npm package to start 3 other scripts in parallel.
* [5-7] : start-* scripts - these scripts are used to start the various parts of the application.  The important part about this approach
    * start-api script will start the api using the Azure Function Core Tools.  In my case I am using C# however this approach can accomodate other languages simply by updating the argument to the func command.
    * start-web script will start the web application using dotnet watch.  This example is using Blazor WebAssembly however this approach can accomodate other frameworks simply by updating the command that is being run.
    * start-swa script will start the Azure Static Web Apps (SWA) CLI w/ the --data-api-location parameter to tell it where the database definition is located.
* [9-12] : db-* scripts - these scripts are used to manage the database using efcore
    * db-reset script will drop the database, run all migrations, and then seed the database.  
    * The db-migrate script will create a new migration using the current timestamp as the name.  A helper script for devs to be able to build out migrations without needing to look up the efcore commands or the standard naming convention for the current project.
    * The db-update script will ensure the target Database is up to date.
    * The db-drop script will drop the database.  This will be important when we are automating creating a database per staging environment.
* [15-17] : devDependencies - the various npm packages that are used to manage the application.  These are all installed using npm install.

### The .env file

Another key consideration in this approach was where environment specific configurations were going to pulled from and to streamline the process as much as possible for the developers without needing them to read a long setup doc to set everything up.  I adopted using an .env file because support for it was already built into the swa cli and it was relatively easy to use that for other parts of the application as well.  In my simple case I ended up with a very simple .env file that looks like this:

<pre class='language-json line-numbers' style='white-space:pre-wrap;'><code>DB_CONNECTION_STRING=[REDACTED]</code></pre>

The DB_CONNECTION_STRING is used by the data-api to auto-generate Rest & GraphQL endpoints for the application to use.  And I was able to easily use this with efcore migrations and the api.  

The biggest advantage of this is that the .env file is ONLY used in development.  When the application is deployed and runnin in Azure the environment variables are pulled from the configuration settings in Azure.

### The local.settings.json file and launchSettings.json file

The npm scripts are all expecting the Api and Web projects to run locally on a certain 

## Tradeoffs

Like any approach there are tradeoffs.  The biggest tradeoff with this approach is that using `npm start` to start the application will start 3 processes.  This is not a huge deal but it does mean you need to understand that when you are launching the application you need to kill all 3 processes when you are done.  That is one of the reasons why I broke the start script into 3 parts so that if you want you can start them in separate terminal windows, or use VS Code / Visual Studio to start pieces that you want to attach debuggers to.  

Not a huge deal but something to be aware of.

## What's Next

Depending on yours needs you can take a look at other posts in this series to understand how to set those up to work with this approach.  What types of front ends are you developing with? What do you use for auth? Leave a comment below and let me know.

* [Api - C#](xref:azure-swa-api-csharp)
* [Db - EF Core](xref:azure-swa-db-efcore)
* [Db - Rest APIs](xref:azure-swa-db-rest)
* [Db - GraphQL APIs](xref:azure-swa-db-graphql)
* [Db - Integrated Auth](xref:azure-swa-db-auth)
* [Web - Blazor WebAssembly](xref:azure-swa-web-blazor)
* [Web - React](xref:azure-swa-web-react)