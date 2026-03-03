./build-image.ps1 -ProjectPath "../../src/Acme.BookStore.DbMigrator/Acme.BookStore.DbMigrator.csproj" -ImageName bookstore/dbmigrator
./build-image.ps1 -ProjectPath "../../src/Acme.BookStore.HttpApi.Host/Acme.BookStore.HttpApi.Host.csproj" -ImageName bookstore/httpapihost
./build-image.ps1 -ProjectPath "../../angular" -ImageName bookstore/angular -ProjectType "angular"
./build-image.ps1 -ProjectPath "../../src/Acme.BookStore.AuthServer/Acme.BookStore.AuthServer.csproj" -ImageName bookstore/authserver
