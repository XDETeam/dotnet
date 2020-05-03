# SDE for .NET

## TODO:Development template

### Specs assembly

A project starts from creating a "specs" assembly (e.g. Sde.Team.Specs).

Having in mind meta-programming (TODO:DevOps, *-as-a-Code) concept of the SDE vision (TODO:link), the main purpose of this application is to construct and manage the product including code/documentation generation, hosting, deployment, testing, etc. That's why it's preferrable form is a console application that will be a CLI for all these responsibilities.

Being a meta-program it can reference all other assemblies and other projects in the solution. That's why it is a perfect entry-point for documentation and testing, so we can place it there.

Being the first step in the development process it's also intended to be a sandbox. To setup quckly a typical environment (e.g. web app with some particular BD backend, security, etc) and start coding right in the Sandbox. Then extract (using integrated advisor as an option) some specific interfaces/classes/etc to the dedicated assemblies when they become mature.

Sample employments to develop:
- Templates and generators (boilerplates, single-file templates, snippets). Something more close to Gatsby SSG (that works with structured content) that can go through the whole solution DOM. Sophisticated boilerplates (like ready to use admin portal).
- Build/CI/CD.
- Host documentation/collaboration server.
