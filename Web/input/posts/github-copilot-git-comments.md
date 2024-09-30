Title: GitHub Copilot - Automating Git Comments and PR Summaries
Lead: I've been using GitHub Copilot for several months, and the most common question I get is - Is it worth the price? In this post, I'll show one key use case where Copilot in Visual Studio saves time and improves code quality by automating tasks like writing detailed git commit messages and pull request summaries-tasks that often get rushed, but are essential for long-term traceability.
Published: 9/12/2024
Image: images/posts/github-copilot.png
Author: JJ Bussert
Keywords: Visual Studio, Github, Github Copilot
Tags:
 - Visual Studio
 - Github
 - Github Copilot
---
# GitHub Copilot? One Use Case That Pays for Itself

I've been using GitHub Copilot for several months now, and it's surprising to me how many times I've been asked, *"Is it really worth the price?"* or *"Why would I pay for Copilot when I'm already paying high developer salaries?"* These are fair questions, and I get where people are coming from. To answer those questions I thought I'd share a few examples of how in my normal workflow of writing code in Visual Studio for this blog site, Copilot has enabled me to include better summaries of changes in my Git commits and Pull Requests (PRs) without adding any extra time to my workflow.

If you're interested in more examples where GitHub Copilot proves its value, check out my other posts on [GitHub Copilot](/tags/github-copilot) where I dive into more practical use cases.

---

## Why Source Control Commits Are Important But Overlooked

As developers, we all know how important it is to maintain good documentation and traceability in our source control history. The reality, especially for side projects such as this blog site, is that tasks like writing detailed commit messages or pull request summaries often fall by the wayside when we're trying to be productive. Sure, it's ideal to document every little detail, but how many times have you found yourself on a project with tight deadlines and budgets rushing to finish a task at 4:45 on a Friday and feeling pressured to skipp the extra effort of writing meaningful comments because "it doesn't really matter". Or maybe even worse it's a requirement for you to have this level of detail and if you don't get it in quickly you could be the one to cause a feature to miss being included in a release because of a source control comment being late, not detailed enough, inaccurate?  

Here's where GitHub Copilot can be a game changer. By automating the process of generating detailed commit messages and PR summaries, it allows you to improve traceability without sacrificing time. And while this might seem like saving a few minutes here and there, the long-term impact is significant-especially when you need to revisit code six months or two years later. And before you respond "there are already tools that help with this today" that is true, but the value to me in CoPilot is it's attempt to interpret what I was doing based on the change and describing it. Is it worth the price? Let's dive into a couple of simple examples from my experience working on this blog site to see this in action.

---

## Commit Messages 

While creating a recent post, I decided to update some NuGet dependencies in the `.csproj` file to address vulnerability warnings. These weren't critical for my setup-since my C# console app only runs within a GitHub Action to generate static content for my site-but it was still a best practice that I should get around to sooner than later.  
Normally, in cases like this, I would type a quick commit message like *"updated NuGet references to address vulnerability warnings."* Sure, all developers *should* include more detailed explanations, but let's be honest: business stakeholders rarely care about the level of detail in a git commit.

With GitHub Copilot, though, I was able to generate a much more detailed commit message in seconds. Copilot captured not just the fact that I updated packages but also listed the specific packages and the versions I upgraded to:

[![Copilot Commit Comments](/images/posts/github-copilot-git-comments/commit.png "Copilot Commit Comments")](/images/posts/github-copilot-git-comments/commit.png)  

This level of detail is more than I would normally provide, but since it was auto-generated, it was easy to include. And, as a solo committer on this project, this could be a crucial reference point for *future me* to understand exactly what was changed in the event of an issue or follow-up task.  In fact I'd normallly avoid including this level of detail because I don't want to risk a typo and have the comment not match the actual changes, automating it gives me confidence that it is correct (and even if I don't believe it it's really easy to compare the comment to the source file and manually verify).  

---

## Pull Request Summaries

Following that example I included that commit in a PR along with the content for a new blog post, titled ["Be the Idiot"](/posts/leadership-be-the-idiot). I normally try to take a few minutes to document what is in a Pull Request especialy when I'm included an unrelated, especially when I'm including a change thats unrelated to the main content. In reality - I'm rarely as detailed in my PR summaries as I probably should be unless it's an organizational requirement, what *value* does my PR summary have to the business? 

Here's where GitHub Copilot comes in to help me out. As shown in the screenshot, Copilot auto-generated a detailed PR summary for me, breaking down each change by file:

[![Copilot PR Comments](/images/posts/github-copilot-git-comments/pr.png "Copilot PR Comments")](/images/posts/github-copilot-git-comments/pr.png)  
It isn't perfect but that is a lot of great detail that I would normally skip over. I can quickly add some context to the summary to outline the purpose that cannot be inferred from the changes alone and move on.  In my opinion CoPilot has summarized the details that do not need to be included in the PR summary but included details that I'd usually skip over because I don't want to take the time to document them.

This might sound like I'm being lazy but in reality, I'm trying to balance the time I spend on tasks that provide value to the business (my desire to get blog content out to the likes of you) and tasks that I could do better but don't provide value.  Apply this example to a complex solution that you are developing in, where you have multiple developers working on the same codebase, and the value of this level of detail in the PR summary becomes even more important.  Have you ever needed to make a sweeping change across 50 or even 100+ files? How much time would it take you to document each change in a PR summary? Copilot's ability to assist in reviewing and documenting each change and summarizing for you could provide real time savings. 

Another benefit of this level of automated details is reminding me what is included in the PR. Sure I have the list of files in there but what if I made multiple changes in the file for different reasons?  I've had CoPilot summarize what it thought was done in a file and make me realize that I had accidentally forgotten to remove some test code in a file that I was experimenting with. I would have caught it in my own testing of the PR when I did my final validation but the sooner you find things like this the faster they are to address.

---

## Conclusion

- **Yes, we're talking about a few minutes here, a few minutes there.** So, I get where the arguments come from-"How much time am I really saving?" But think about this: In the past, I've often grouped changes together in GIT or PR commits that weren't strictly related because of looming deadlines, especially when every minute counts-like 4:45 on a Friday afternoon.

- **The real value becomes clear when reviewing changes in the future**-two years down the line, staring at a commit history and asking, "Okay, JJ, what were you thinking?" In those moments, detailed commit messages and PR summaries become priceless, and GitHub Copilot is helping me ensure I don't cut corners, even when under pressure.

- **Some might argue** that Copilot enables developers to be lazy, and sure, that's a risk with any Gen AI tool if you're the type to blindly accept whatever it gives you. But I believe the best devs will use tools like this to focus on what really matters: freeing them up to provid business value by not wasting time on tasks that can be automated.  

At the time of this post, GitHub Copilot is priced at $10 per month for individuals or $100 per year. For businesses, it's $19 per user, per month, and $39 per user for enterprise plans, depending on organization size.

**Is it worth it?** For me personally absolutely-especially when it means painlessly automating what most would argue is a best practice. Is it worth it for you and/or your team? If you are developing w/in Visual Studio or any other IDE that applies CoPilot in this way then I feel like this alone is worth the price of admission but I'd love to hear your thoughts.

Do you use GitHub Copilot today? Do you feel like it's worth the price? And if you're already using it, what's your favorite use case where you've seen it pay for itself? If not, what's holding you back? 
**Comment below** and let's start a conversation!
