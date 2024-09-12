Title: GitHub Copilot - Automating Git Comments and PR Summaries
Lead: I've been using GitHub Copilot for several months, and the most common question I get is- "Is it worth the price?" With developer salaries already high, why add another tool? In this post, I'll show one key use case where Copilot in Visual Studio saves time and improves code quality by automating tasks like writing detailed git commit messages and pull request summaries-tasks that often get rushed, but are essential for long-term traceability.
Published: 9/12/2024
Image: images/posts/github-copilot.png
Author: JJ Bussert
AuthorUrl: https://www.linkedin.com/in/jjbussert/
Keywords: Visual Studio, Github, Github Copilot
Tags:
 - Visual Studio
 - Github
 - Github Copilot
---
# GitHub? One Use Case That Pays for Itself

I've been using GitHub Copilot for several months now, and it's surprising to me how many times I've been asked, *"Is it really worth the price?"* or *"Why would I pay for Copilot when I'm already paying high developer salaries?"* These are fair questions, and I get where people are coming from. This time I want to focus on just one specific use case where Copilot can easily pay for itself in my opinion when used within **Visual Studio** to assist with generating Git commit and PR (pull request) comments. Keep in mind that your experience may vary with other tools.

If you're interested in more examples where GitHub Copilot proves its value, check out [my other posts on GitHub Copilot](https://www.e13.tech/tags/github-copilot) where I dive into more practical use cases.

---

## Why Source Control Commits Are Important But Overlooked

As developers, we all know how important it is to maintain good documentation and traceability in our code. The reality, however, is that tasks like writing detailed commit messages or pull request summaries often fall by the wayside when we're up against deadlines. Sure, it's ideal to document every little detail, but how many times have you found yourself rushing to finish a task at 4:45 on a Friday and skipped the extra effort of writing meaningful comments because you don't want to be the one to cause a feature to miss being included in a release because of a source control comment?  

Here's where GitHub Copilot can be a game changer. By automating the process of generating detailed commit messages and PR summaries, it allows you to improve traceability without sacrificing time. And while this might seem like saving a few minutes here and there, the long-term impact is significant-especially when you need to revisit code six months or two years later. Is it worth the price? Let's dive into a couple of simple examples from my experience working on this blog site to see this in action.

---

## Automating Commit Messages 

While creating a recent post, I decided to update some NuGet dependencies in the `.csproj` file to address vulnerability warnings. These weren't critical for my setup-since my C# console app only runs within a GitHub Action to generate static content for my site-but it was still a best practice that I should get around to sooner than later.  
Normally, in cases like this, I would type a quick commit message like *"updated NuGet references to address vulnerability warnings."* Sure, all developers *should* include more detailed explanations, but let's be honest: business stakeholders rarely care about the level of detail in a git commit.

With GitHub Copilot, though, I was able to generate a much more detailed commit message in seconds. Copilot captured not just the fact that I updated packages but also listed the specific packages and the versions I upgraded to:

[![Copilot Commit Comments](/images/posts/github-copilot-git-comments/commit.png "Copilot Commit Comments")](/images/posts/github-copilot-git-comments/commit.png)  

This level of detail is more than I would normally provide, but since it was auto-generated, it was easy to include. And, as a solo committer on this project, this could be a crucial reference point for *future me* to understand exactly what was changed in the event of an issue or follow-up task.  In fact I'd normallly avoid including this level of detail because I don't want to risk a typo and have the comment not match the actual changes, automating it gives me confidence that it is correct (and even if I don't believe it it's really easy to compare the comment to the source file and manually verify).  
So, while not all of this information might seem important at the moment, tools like Copilot help me ensure that this level of detail is preserved without much extra effort. Version numbers in particular might be important to figure out where a version was introduced if in the future a vulnerability is found in a specific version of a package. Sure you can also inspect the `.csproj` file to see the version numbers, but having it in the commit message as well might help you get to that answer faster depending on where you are searching from.

---

## Pull Request Summaries - (and verification!)

In a recent pull request for my blog, I updated package references, added a new image, and introduced a new blog post about leadership, titled ["Be the Idiot"](https://www.e13.tech/posts/leadership-be-the-idiot). I normally try to take a few minutes to document as much as I can in the Pull Request, but in reality, how often do we have the time to write detailed PR summaries for every file? More often than not, PRs are rushed, especially if they involve multiple file changes.  Some companies do have requirements for detailed PR summaries, and filling those details out fully can take time.

Here's where GitHub Copilot comes in. As shown in the screenshot, Copilot auto-generated a detailed PR summary for me, breaking down each change by file:

[![Copilot PR Comments](/images/posts/github-copilot-git-comments/pr.png "Copilot PR Comments")](/images/posts/github-copilot-git-comments/pr.png)  

This level of detail would normally take me several minutes to compile manually. Even with just three file changes, it's easy to skip documenting these updates properly. But if I had made a sweeping change across 50 or 100 files, Copilot's ability to assist in reviewing and documenting each change could prove invaluable. Again, especially in environments where this level of detail is actually a requirement (ever had to spend 30 minutes writing a summary of what changed because you're worried you might miss something?)

Copilot not only helped me by providing a detailed summary, but it also allowed me to double-check that all relevant changes were captured. It's easy to miss an unrelated file that snuck into a PR, but with Copilot highlighting the details, I caught a couple of changes that would've gone unnoticed otherwise. In larger PRs, this kind of support could help prevent a lot of back-and-forth during reviews.

Possibly even more important, for companies that require detailed PR summaries this enables the devs to focus on the "functionality" that is being included in the PR rather than spending time double checking which files where changed and what was changed in each file. Again is this level of detail necessary for PRs? If the release goes to production without a hitch and everything is working as expected, then no, but if there is an issue, you'll be glad for as much detail as you can get to unravel what was the cause of the issue.

---

## Conclusion

- **Yes, we're talking about a few minutes here, a few minutes there.** So, I get where the arguments come from-"How much time am I really saving?" But think about this: In the past, I've often grouped changes together in GIT or PR commits that weren't strictly related because of looming deadlines, especially when every minute counts-like 4:45 on a Friday afternoon.

- **The real value becomes clear when troubleshooting**-two years down the line, staring at a commit history and asking, "Okay, JJ, what were you thinking?" In those moments, detailed commit messages and PR summaries become priceless, and GitHub Copilot is helping me ensure I don't cut corners, even when under pressure.

- **Some might argue** that Copilot enables developers to be lazy, and sure, that's a risk. But I believe the best devs will use tools like this to focus on what really matters: providing business value, not wasting time on tasks that can be automated.  

**If your team is still going to have one commit or PR per two-week sprint no matter what you say, then sure, this may not be worth it for you.** But this value isn't for those teams-it's for the devs that truly *want to be better*, those who care about the traceability and quality of their work. 

At the time of this post, GitHub Copilot is priced at $10 per month for individuals or $100 per year. For businesses, it's $19 per user, per month, and $39 per user for enterprise plans, depending on organization size.

**Is it worth it?** Absolutely-especially when it means gaining better traceability into what your developers did, when, and why, while empowering them to focus on tasks that provide real value to your business. With Copilot handling the "paperwork," developers can concentrate on what truly provides value.

---

What about you? Do you use GitHub Copilot today? Do you feel like it's worth the price? If not, what's holding you back? And if you're already using it, what's your favorite use case where you've seen it pay for itself?  
**Comment below** and let's start a conversation!
