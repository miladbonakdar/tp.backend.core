# tp backend core

- first you need to have your own nuget.config file 
 see the example file and change these two variables `GitHubUserName` `GitHubPAT` and save file as `nuget.config` 

 - in `tp.backend.core` directory you can pack the package with this command 
 ```shell
 dotnet pack --configuration Release
 ```

> but automatically when you are building the package with release it will add the new nuget pac in bin library, and don't forget to add new version

- at the end you just need to run this command to push the package to github package repo
```shell
dotnet nuget push "bin/Release/tp.backend.core.1.x.x.nupkg" --source "github"
```