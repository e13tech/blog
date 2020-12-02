Title: Deploying Statiq to Azure Static Web App
Lead: Statiq is a static code generator that is being used to generate the e13.tech blog, learn how you can do the same.
Published: 11/1/2020
Image: images/philipp-katzenberger-iIJrUoeRoCQ-unsplash.jpg
Author: JJ Bussert
Tags:
 - Statiq
 - Azure
 - Azure Static Web App
 - Github
 - Github Actions
---
[Statiq](https://statiq.dev/) is a [static content generator](https://en.wikipedia.org/wiki/Web_template_system#Static_site_generators) written in c# that is used to generate the site you are reading right now.  It is an incredibly robust and feature full project, Below is a series of steps that you can walk through to create your own blog similar to this one.  

The source for the app that generates this site is open source at https://github.com/e13tech/blog.  Feel free to browse the source and get inspiration for your own project.

### Deploy to Azure Static Web App using Github Actions

As you can read about [here](xref:statiq-blog-getting-started) the source for this blog is hosted https://github.com/e13tech/blog but 

[Static Web Apps](https://azure.microsoft.com/en-us/services/app-service/static/) is an offering in Azure that is currently in preview that streamlines the deployment of applications from GitHub.  It has a few limitations in preview but 

1. From the GitHub repository

    [![New GitHub Action](/images/posts/statiq-blog/1.png "New GitHub Action")](/images/posts/statiq-blog/1.png)  
    
    Create a new workflow

2. Create new Static Web App resource in the Azure Portal
    [![New SWA](/images/posts/azure-swa.png "New SWA")](/images/posts/azure-swa.png)  
    [![New SWA](/images/posts/azure-swa-details.png "New SWA")](/images/posts/azure-swa-details.png)  

3. Update the auto generated workflow yml for Statiq
    <pre class='language-yaml line-numbers'><code>name: Build & Deploy

   on:
     pull_request:
     types: [opened, synchronize, reopened, closed]
     branches: [main]
    
   jobs:
     build:
       if: github.event_name == 'push' || (github.event_name == 'pull_request' && github.event.action != 'closed')
       runs-on: ubuntu-latest
    
       steps:
       - uses: actions/checkout@v2
       - name: Setup .NET Core
         uses: actions/setup-dotnet@v1
         with:
           dotnet-version: 5.0.100
       - name: Install dependencies
         run: dotnet restore
       - name: Build
         run: dotnet build --configuration Release --no-restore
       - name: Run
         run: dotnet run --output output --noclean
       - name: Build And Deploy
         id: builddeploy
         uses: Azure/static-web-apps-deploy@v0.0.1-preview
         with:
           azure_static_web_apps_api_token: ${{ secrets.AZURE_STATIC_WEB_APPS_API_TOKEN_... }}
           repo_token: ${{ secrets.GITHUB_TOKEN }}
           action: "upload"
           app_location: "output" # App source code path
           api_location: "" # Api source code path - optional
           output_location: "" # Built app content directory - optional
    
   close_pull_request_job:
     if: github.event_name == 'pull_request' && github.event.action ==     'closed'
     runs-on: ubuntu-latest
     name: Close Pull Request Job
     steps:
       - name: Close Pull Request
         id: closepullrequest
         uses: Azure/static-web-apps-deploy@v0.0.1-preview
         with:
           azure_static_web_apps_api_token: ${{ secrets.AZURE_STATIC_WEB_APPS_API_TOKEN_... }}
           action: "close"</code></pre>
    
   This is a large file but my changes can be broken down into a few segments
    * [3-6] : Setup a trigger on pull requests going into the main branch. My preference is to have feature branches for my blog articles and to create a PR for each into main while I work on them
    * [14-22] : The series of steps that prepares a .NET 5 environment
      * [23-24] : Run the console app directing the generated content to an <code>output</code> directory
    * [34] : app_location needs to match the same path that was used on [24], in this example <code>output</code>