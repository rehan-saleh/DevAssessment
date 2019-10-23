# AvantiPoint Developer Assessment

This developer assessment has been designed to help both assess your skills as a Cross Platform mobile developer and to help you grow and learn critical pieces of knowledge as a developer. The assessment was designed by [Dan Siegel](https://github.com/DanSiegel) to better train developers in what they need to be able to accomplish.

| Time to Complete | Skill Level |
|:----------------:|:-----------:|
| <= 1 Day | Pass |
| 2 Days | Mid-Level |
| 3 Days | Junior (1+ year experience) |
| 4 Days | Junior (no experience) |
| 5 Days | Intern / Student |
| 4+ Days | Seek other opportunities |

The time it takes you to go through the assessment says a lot about your competency as a developer. Note the overlap from the last level and the previous two. For developers who currently believe they are beyond a Junior level developer or have more than two years of experience in development, this excercise should not take you beyond 3 days of active development. Also note here that a single Day is defined as 8 hours of work.

## Getting Started

As part of the automated repo creation, a number of issues have been added to this repo for you. You'll want to get started with them right away. You will want to clone this repository to your local machine and add your project files in this repository. Note that if you jumped the gun and created a local repository you can always rebase with the master branch before pushing your changes. As a good practice and to help with the final review of your assessment be sure to follow a branching strategy with PR's for each issue back to the master branch.

You may find for some issues that you have multiple ways of completing a task. One such example could be that you have the opportunity to bring in a 3rd party library, or write some functionality, or perhaps there were multiple 3rd party solutions available. Be sure to note in your PR's why you chose to do what you are doing for your project.

## Tips

### Git & GitHub

- Don't try to show off with Git unless you've truly invested in your knowledge of the Git CLI. Utilize a quality Git client such as GitKraken or SourceTree. Both of these clients allow you to easily visualize changes. Why were changes made in your project? Did you need to check in every single line? Are you sure you want to stage and commit a hunk of code you used for debugging?
- You have two options when cloning from GitHub, HTTPS & SSH... Use SSH...
- Remember commit messages have 2 parts. The short description and the extended message. You can only see the short description in the change log and must drill down into a specific commit to see the extended message.
- GitHub allows you to automatically close issues when a PR is merged by adding `fixes #12` (with the actual issue number) in either the commit message or in the body of the PR.

### Development

- This assessment is not designed to have you develop a stunningly beautiful app but to test your skills as a developer. There may be some Views that you create that may be incredibly basic simply stating the something like "Hello from ViewA" to indicate that you navigated to ViewA.
- The assessment is designed to be similtaneously instructive on what to do, and purposely vague so as to not provide you all of the answers and to leave you the room to decide how you should solve a problem. If you're not sure how to proceed it is because you need to make a decision. When you find this has happened be sure to make note of it in your PR and explain why you went the route you did.
- If you find yourself running into a bug from a previous step file an issue and label it as a bug in the repo.
- Have a feature or something extra you need to do to support an issue from the assessment? Add an issue in the repo referencing the other issue.
- While you are only required to include Xamarin.Forms and either Prism.DryIoc.Forms or Prism.DryIoc.Forms.Extended, it is recommended that you use some common libraries where and IF they make sense to use them:
  - PropertyChanged.Fody || ReactiveUI.Fody
  - ReactiveUI
  - FFImageLoading
  - Shiny Library
  - Prism.Plugin.Logging (AppCenter / Syslog / Console)
  - Mobile.BuildTools

## DevOps for Mobile

This repository contains several YAML files for Azure DevOps. If you have not already done so you can create an account with Azure DevOps and configure your first Pipeline from the YAML included here. Be sure to add a P12 Certificate and Provisioning Profile in the Secure Files and create a Variable Group called `iOS-Signing` with the following variable names:

| Variable Name | Value |
|:-------------:|:-----:|
| DevelopmentCertificate | {name of the p12 certificate in the Secure Files} |
| CertificatePassword | {the password for your p12 certificate} |
| DevelopmentProvisioningProfile | {provisioning profile name} |

Be sure to update the `azure-pipelines.yml` as you will need to set `AppCenterUser` to your username in App Center. You will also want to be sure to either create an Android and iOS App in App Center using the names `DevAssessment.iOS` & `DevAssessment.Android` or you will need to again update the YAML file.

**NOTE** It is not required that you set up a CI/CD pipeline but it is recommended. You can set up a project in Azure DevOps that is public to get all of the build time you want and you'll be able to release to App Center so you can test and see on your device how the app has progressed as you have worked through the issues.
