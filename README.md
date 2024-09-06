# e13tech Blog generated using Statiq

[![Azure Static Web Apps CI/CD](https://github.com/e13tech/blog/actions/workflows/azure-static-web-apps-mango-meadow-0fa386910.yml/badge.svg)](https://github.com/e13tech/blog/actions/workflows/azure-static-web-apps-mango-meadow-0fa386910.yml)

This repository contains the source code for the [e13tech](https://e13.tech) blog, hosted on Azure Static Web Apps and powered by [Statiq Web](https://www.statiq.dev/web/). 

## Getting Started

### Prerequisites

To get started with this blog repository, you'll need the following:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later.
- [Git](https://git-scm.com/) (for cloning the repository).
- [Azure Subscription](https://azure.microsoft.com/en-us/free/) (to host the Static Web App if you plan on deploying a new instance).

### Clone the Repository

```bash
git clone https://github.com/e13tech/blog.git
cd blog
```

### Running the Blog Locally
To preview the blog locally, use:

```bash
dotnet run -- preview
```
This command builds and serves the blog at http://localhost:5080.

For more detailed output while debugging, use:

```bash
dotnet run -- preview -l Debug
```
GitHub Actions Deployment
The blog is deployed to Azure Static Web Apps via a GitHub Actions workflow. Any commits to the main branch trigger an automatic deployment to the production instance of the blog. The workflow uses the Azure/static-web-apps-deploy action.

### Preview Deployments
When you create a Pull Request (PR), GitHub Actions will automatically create a preview version of the blog on Azure Static Web Apps. This allows you to review the changes in an isolated environment before merging them into main. The preview environment is available through a unique URL, and it will be automatically deleted when the PR is closed or merged.

The GitHub Actions workflow for deployment is defined in the .github/workflows directory of this repository.

Secrets and Configuration
To deploy, ensure you have added the necessary secrets to your GitHub repository:

AZURE_STATIC_WEB_APPS_API_TOKEN_MANGO_MEADOW_0FA386910: This secret is the deployment token for your Azure Static Web App instance. It is required for authentication during the deployment process.
You can manage these secrets in the GitHub repository under Settings > Secrets and Variables > Actions.

### Dependencies
This blog uses the following dependencies:

[Statiq Web](https://www.statiq.dev/web): A powerful static site generation framework built on top of .NET.

### Contributing
Contributions are welcome! Please fork the repository and create a new branch for your feature, bugfix, or blog post. Once your changes are ready, open a pull request, and a preview deployment will be generated for review.

### License
This project is licensed under the MIT License. See the LICENSE file for details.