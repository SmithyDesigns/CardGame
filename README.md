# CardGame
To check before pulling repo
dotnet --version
<!-- dotnet new webapi -n CardGameApi start new app -->

clone repo and run then the following
dotnet run
dotnet build
dotnet watch run

Git
git branch
git checkout -b <my-new-branch>
git status
git add .
git commit -m "some message"
git push -u origin <my-new-branch>

dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations remove InitialCreate