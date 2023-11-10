Setup project by:

cd to Itspecialist.Server
 <ItemGroup>
    <PackageReference Include="AutoMapper" Version="12.0.1" />
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0-rc.2.23479.6" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.0-rc.2.23480.2" />
  </ItemGroup>
  Add version to Foundation .csproj otherwise it is not working for some reason
dotnet ef migrations add InitialCreate
dotnet ef database update
