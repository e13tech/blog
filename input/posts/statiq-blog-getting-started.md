Title: Blog using Statiq - Getting Started
Lead: Statiq is a static code generator that is being used to generate the e13.tech blog, learn how you can do the same.
Published: 11/1/2020
Image: images/philipp-katzenberger-iIJrUoeRoCQ-unsplash.jpg
Author: JJ Bussert
Tags:
 - Statiq
 - C#
 - Markdown
 - Github
---
[Statiq](https://statiq.dev/) is a [static content generator](https://en.wikipedia.org/wiki/Web_template_system#Static_site_generators) written in c# that is used to generate the site you are reading right now.  It is an incredibly robust and feature full project, Below is a series of steps that you can walk through to create your own blog similar to this one.  

The source for the app that generates this site is open source at https://github.com/e13tech/blog.  Feel free to browse the source and get inspiration for your own project.

1. Create a new .NET console app and add the Statiq.Web Package

	<pre class='language-powershell line-numbers'><code>dotnet new console --name AwesomeBlog
   cd AwesomeBlog
   dotnet add package Statiq.Web --version 1.0.0-beta.13
   md input
   md theme\input</code></pre>

   Most of this is fairly intuitive but in case you need some more details
    * [1] : Create a .NET console app that will be the generator for your site
    * [2] : Navigate into the directory for your new console app
    * [3] : Add the Statiq.Web nuget package, at the time of writing this Statiq is still prerelease so specify the version
    * [4] : Create the input directory that will host
    * [5] : Create the theme input directory that will contain the layout and other site assets

2. Create a bootstrapper Program.cs

    <pre class='language-csharp line-numbers match-braces'><code>using System.Threading.Tasks;
   using Statiq.App;
   using Statiq.Web;
   
   namespace Your.AwesomeBlog
   {
     public class Program
     {
       public static async Task<int> Main(string[] args) =>
         await Bootstrapper
           .Factory
           .CreateWeb(args)
           .RunAsync();
     }
   }</code></pre>
   A very straight forward Program.cs, notable lines:
    * [2] : The core Statiq framework namespace with the original Bootstrapper.Factory comes from
    * [3] : The Statiq Web namespace which provides the .CreateWeb(..)
    * [9-13] : Have the Main(string[]) method await the call to the Statiq </code></pre>

3. Create a new <code>index.md</code> file within the <code>input</code> directory with the following content

    <pre class='language-markdown line-numbers'><code>Title: My First Statiq page
    ---
    # Hello World!

    Hello from my first Statiq page.</code></pre>

    There are countless great sources online explaining how [Markdown](https://statiq.dev/framework/content/template-languages#markdown) works including the official Statiq website.  In a follow-up post I will go through an example of how I am utilizing this input files.

4. Launch the built-in previewer from a [terminal window](xref:fun-with-windows-terminal-getting-started)
    
    <pre class='language-powershell line-numbers'><code>dotnet run -- preview</code></pre>

    If all went well Statiq will display a bunch of diagnostic information and then host your new site at https://localhost:5080 with livereload meaning that you can edit your site content in your favorite editor such as VS Code and the browser will reload to display your changes as you save.  

Most of these steps here are borrowed directly from the [Statiq Quick Start](https://statiq.dev/web/#quick-start) and adjusted for my content.  Combining [Clean Blog Template](https://github.com/statiqdev/CleanBlog) with a responsive web template such as one from as a starting point will get you most of the way towards having a blog of your own, lets look at some of the modifications I made beyond this.

[Statiq Web](https://statiq.dev/web/) is built on top of [Statiq Framework](https://statiq.dev/framework) and this series covers a small fraction of the functionality of this fantastic project.  So far I am very happy with this platform and am anticipating the release of [Statiq Docs](https://statiq.dev/docs/) which is built on top of the Statiq Web with a focus on generating .NET API documentation.

What static content generator have you used? Do you have a blog of your own that's statically generated? Share your experiences in the comments below.

### Deploy to Azure Static Web App using Github Actions

As you can read about [here](xref:statiq-blog-getting-started) the source for this blog is hosted https://github.com/e13tech/blog but 

[Static Web Apps](https://azure.microsoft.com/en-us/services/app-service/static/) is an offering in Azure that is currently in preview that streamlines the deployment of applications from GitHub.  It has a few limitations in preview but 

1. From the GitHub repository
  [![New GitHub Action](/images/posts/statiq-blog/1.png "New GitHub Action")](/images/posts/statiq-blog/1.png)  
  Create a new workflow

2. Test
