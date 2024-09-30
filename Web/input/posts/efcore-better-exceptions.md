Title: EF Core - More Intuitive Exceptions
Lead: Discover how EntityFramework.Exceptions can help simplify your error handling by eliminating the need for manually tracking SQL Server error codes, and learn how to write cleaner, more maintainable code.
Published: 9/9/2024
Image: images/posts/efcore-better-exceptions.png
Author: JJ Bussert
Keywords: EF Core, SQL Server, C#
Tags:
 - EF Core
 - SQL Server
 - C#
---

<div class="video-responsive">
    <?# YouTube QKwZlWvfh-o height=600 /?>
</div>

# Handling EF Core Exceptions Gracefully: A Cleaner Approach with EntityFramework.Exceptions

While scrolling through my YouTube feed, a video titled ["Stop Dealing with EF Core Exceptions Wrong!"](https://www.youtube.com/watch?v=QKwZlWvfh-o) caught my attention. It highlighted an issue I've seen far too often in projects-overcomplicating our solutions to handle specific errors that seem unavoidable. It's something I've dealt with frequently when working with EF Core.

One key frustration is dealing with SQL Server error codes in Entity Framework. When an exception arises, you're often forced to dig into specific error codes, writing redundant and bloated error-handling logic. This not only clutters your codebase but also increases the risk of missing or improperly handling certain cases. 

The good news is there's a better way.

## The Problem: Handling SQL Server Errors Manually

Let's take an example from the excellent post over at [Giorgi's blog](https://www.giorgi.dev/entity-framework/introducing-entityframework-exceptions/). Giorgi demonstrates the approach I've used in the past to use SQL Server error error codes when I had specific handling to be done. Imagine something like this:

```csharp
try
{
    // Code that may throw an exception, like saving to the database
    context.SaveChanges();
}
catch (SqlException ex) when (ex.Number == 2627) // Violation of unique constraint
{
    // Handle the specific exception, maybe log it or show user-friendly message
    Console.WriteLine("A duplicate entry exists.");
}
catch (SqlException ex) when (ex.Number == 547) // Foreign key violation
{
    // Handle foreign key constraint violation
    Console.WriteLine("You cannot delete this record as it is referenced elsewhere.");
}
catch (SqlException ex) when (ex.Number == 2601) // Another form of unique constraint violation
{
    // Handle another case of duplicate entry
    Console.WriteLine("Duplicate record found.");
}
```
This approach works, but it's not clean. You have to track each error code manually, and your error handling can easily spiral out of control as your project grows.

## The Cleaner Solution: EntityFramework.Exceptions

EntityFramework.Exceptions is a package that simplifies the entire process, allowing us to focus more on writing meaningful, maintainable code instead of error-handling boilerplate.

With this package, the tedious manual checks for error codes are abstracted away. The library catches common database-related exceptions and converts them into more specific .NET exceptions that you can handle gracefully. Here's an example of how you can clean up the error-handling process:

Implementing EntityFramework.Exceptions
First, you'll need to install the package. In my case I'll use the SqlServer version, just make sure you choose the correct package for your database type:

```bash
dotnet add package EntityFramework.Exceptions.SqlServer
```
Then, update your DbContext to configure it with EntityFramework.Exceptions. This snippet is taken from a Program.cs where I am configuring a ServiceCollection to inject MyDbContext as needed:

```csharp
var serviceProvider = new ServiceCollection()
	.AddDbContext<MyDbContext>(options =>
	{
		options.UseSqlServer("connection string");
		options.UseExceptionProcessor();
	})
	.BuildServiceProvider();
```
Now, your error-handling code becomes much cleaner:

```csharp
try
{
    // Save changes without manually checking for specific SQL error codes
    context.SaveChanges();
}
catch (UniqueConstraintException ex)
{
    Console.WriteLine("A duplicate entry exists.");
}
catch (ReferenceConstraintException ex)
{
    Console.WriteLine("You cannot delete this record as it is referenced elsewhere.");
}
```
No more manually sifting through error codes; the package does all the heavy lifting for you, making your code much cleaner and easier to maintain.

And possibly more important, this exception handling code is not specific to SqlServer anymore. If you decide to switch to a different database provider or you want to share your code with another team that is using a different database, you won't need to change your error handling code. This may not be a concern for every team but if it is then this is a huge win for maintainability, shareability, and future-proofing your code. 

## The Trade-Off: Replacing Standard Exception Handling
One caution however, this package effectively replaces the standard exception handling in EF Core, so you'll need to ensure you're comfortable with the trade-offs. For example you probably do not want to implement in a large existing codebase that is already coded to handle direct error codes, save this for the next new project or major rewrite that warrants the effort.  As much as I am looking forward to using this package in my next project, I will be cautious to ensure that the team is aware of the change and that we are all comfortable with the new approach.

## Conclusion: Writing Cleaner Code Together
This is far from a new package and I wish I had run across it sooner. This will help me drastically reduce the amount of error-handling boilerplate in my projects and make the code more intuitive to read without an over abundance of line comments to explain what the codes mean for the next dev, it's an elegant solution that helps you write code that is more intuitive and cleaner over all.

What about you? Have you run into similar frustrations with EF Core exception handling in your projects? Will you start using EntityFramework.Exceptions, or do you already have a different go-to package? Let's write cleaner, more maintainable code together-share your thoughts in the comments below!