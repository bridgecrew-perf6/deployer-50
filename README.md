# Deployer
* Maintains a software project deployment structure in a SVN repository.

* Composes releases from different application modules from versioned components (shared resources). 

* Picks what to deploy on what site.

![](Deployer.png)

## Command line
`Deployer.exe [<url of svn repository>]`

**Example 1**

`Deployer.exe`

Starts the Deployer with no explicit repository URL. The URL needs to be entered manually. If the Deployer's working directory is set to within a working copy, Deployer determines the URL of the repository automatically.

**Example 2**

`Deployer.exe svn://svn.server.com/yourrepo/`

Starts the Deployer with given repository URL. 

## Repository-oriented, working with TortoiseSVN

Deployer works directly with a svn repository on the server.

Deployer does not require any local working copies to be checked out. It does not load anything from local data files. Everything is read from and stored to the repository on the server.

Deployer can be started from whatever place having access to the svn server.

Deployer launches the TortoiseSVN Repo-browser and TortoiseSVN Checkout dialog.

![](OperationFlow.png)

**Note:**
Everything what Deployer can do can be done manually as well by using standard subversion client operations manipulating with the repository.

Deployer just visualizes the repository structure in a human friendly way and makes repetitive operations easy (like creation of branch on many sub-repositories).

## Subversion versions supported

Deployer being a .net application uses SharpSvn2019 library to access the repository, supporting repository formats up to 12.

It was tested to work well with TortoiseSVN version 1.13.

## Modules, Releases and Installs

| Term    | Description                                                  |
| ------- | ------------------------------------------------------------ |
| Module  | For example an application that as part of a larger system, is having its own set data files in separate directory structure, independently on another modules. |
| Release | Composition of specific versions of different resources. For example a specific version of an  application (module). A specific release of a module can be linked to chosen installation sites. |
| Install | The selection of files as they appear on a computer on a concrete installation site. Composed of specific releases of one or more modules. |



## Repository Layout

![](RepoLayout.png)

The repository is expected to have the following structure:

* **shared**
  * whatever/component/folder/structure
    * trunk *<--- this is referenced from releases using externals*
  * whatever/component/folder/structure
    * trunk
  * etc...
* **release**
  * <app module name>
    * head
      * Master   *<--- Here the externals to shared are placed. This is referenced from installs.*
    * integration
    * candidate
    * final
* **install**
  * whatever/deployment/site
    * trunk *<--- Here the externals to releases are placed*

## Link types used

**HEAD** (trunk@HEAD)

* Follows the most recent state of the master branch (trunk)

* Ideal for development

**PEG** (trunk@revisionNo)

* Loosely pinned to a concrete revision, can receive latest changes (optional per-file)

* Enables easy commit of local changes back to trunk

* Good for integration

**BRANCH**

* Fixed to a concrete revision, can’t receive updates from trunk easily 

* Local changes do not affect trunk (merge necessary)

* Very safe, resistant to less skilled users, still allows for mods

* Good for QA testing

**TAG**

* Fixed to a concrete revision, does not allow for committing changes back

* Good for deployment to production sites

## Release types
Deployer recognizes the following predefined types of releases that differ in what link type they use.
 *  **head** ... uses HEAD externals
 *  **integration** ... uses PEG externals (pins the trunk to its current revision)
 *  **candidate** ... uses BRANCH external (creates a branch for each linked resource)
 *  **final** ... uses TAG externals (creates a tag for each linked resource)

## New release creation
A new release is always created as a copy of an existing release. 
![](NewReleaseDialog.png)

When creating the new release, the Deployer automatically creates necessary branches/tags subfolders  in all the resources referenced by externals.

## Linking a release of a module to an installation
Deployer supports easy linking of selected release to given installation.

1. Pick the installation you want to modify in the `Inastalls` box
2. Pick the module and its release you want to be linked to the installation in the `Releases` box
3. Press the `Link` button.
4. See the linked release version changing in the `App Modules Linked` window.

## No authentication handling

Deployer does not handle the authentication in any way.

It relies on the credentials already being cached by the previous access to the repositories via a svn client (TortoiseSVN) on the same computer.

If the credentials are not yet cached and the authentication is still required for some repository, the Deployer most likely crashes with some authentication related exception dialog.

**Resolution:** use Tortoise SVN to connect to the repository and check "Remember user name and password" when asked for credentials. Run Deployer again, this time it should be ok.

