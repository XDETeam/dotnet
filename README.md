# TODO:WIP
# SDE for .NET

## Development template

SDE recursively uses and develops itself.

### The Specs

A project starts from creating a "Specs" assembly (e.g. Sde.Team.Specs). This is a bridge between documentation that we usually imply when talking about specification and application itself that expected to be precisely specified by the documentation, but usually it is not.

This idea is motivated by SDE vision (TODO:link) and meta-programming concept. So this Specs assembly is a meta-program. It codes everything about product inside and outputs the product itself. This abstract definition results in multiple valuable roles below.

Prototyping. By reusing existing setups we can quickly establish an environment of the typical application (e.g. web application with DB support, security module and admin UI integrated) and start playing with samples. 

Structuring. By definition it is the source of the whole application. So initially all artifacts appears there. Later some of them may be extracted into dedicated assemblies (using some advisory tools as an option) and referenced, but anyway it contains a big picture of the product. And this picture is in code form (like a big DOM) and therefore it can be effectively employed in documentation generation, deployment and many other automations. TODO:Link namespace vs assembly investigation from labs that will explain why single Specs assembly as a playground is an additional advantage for a better solution structuring.

Generation and templating. We are talking about more sophisticated implementation. Close to be an SSG like Gatsby, but for code. This can be simple generators for producing interfaces/classes/TypeScript declarations/HTML forms/SQL tables/SQL procedures from an entity declaration. And also very complex project templates including something like Kubernetes, CI/CD, distributed and heterogeneous storage systems, etc.

Documentation. This is the main goal it is built for. To specify an application.

Testing. By having the whole solution picture inside, Specs is one of the best places to contain tests. And tests are the vital part of documentation.

DevOps toolkit. The Specs is highly advised to be a console application based on the provided CLI template. As a result it can contain and organize all required DevOps tasks. You define a "deploy" process, code describes how this deployment is implemented thus producing documentation and deployment tool simultaneously. A lot of ready-to-use solutions for CI/CD/documentation/collaboration/etc.

### Ubiquitous language

Right in the [Specs assembly](#specs) we can start to layout our ideas. And better to start this from defining vocabulary which is frequently called "ubiquitous language".

Notes:
* I think we can simply have a convention of single-word-class for defining term in this language.
* Consider idea of a close-to-complete elimination of classes (primarily use interfaces) and put them into IoC like we regulary do this for services. 
* Category-style of request handling. Better to have multi-dimensional in IoC, but HttpRequest<T> &rarr; JsonRequest<T> &rarr; ValidRequest<T> &rarr; DbRequest<T> &rarr; ... also worth to consider.
* InBox namespace is also a good option to put any stuff we don't know where to put yet. Inside code can be grouped by some namespaces.
