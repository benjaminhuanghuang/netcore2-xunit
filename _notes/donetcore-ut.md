## Setup
### Create Solution
  dotnet new sln

### Create project to be test
```
  mkdir <project>
  cd <project>
  dotnet new classlib
```
### Add project to solution
```
  dotnet sln add .\<project>\<project>.csproj
```

### Create xUnit Test Project and add it to solution
```
  mkdir <tests-project>
  cd <tests-project>
  dotnet new xunit
  dotnet sln add .\<test project>\<test project>.csproj
```
  xUnit test project need xUnit framework and xUnit runner

### Add reference to the xUnit test project
```
  dotnet add reference ../<project to be test>/<project to be test>.csproj
```

### Project structure
  - https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
```
/unit-testing-using-dotnet-test
    unit-testing-using-dotnet-test.sln
    /PrimeService
        Source Files
        PrimeService.csproj
    /PrimeService.Tests
        Test Source Files
        PrimeServiceTests.csproj
```

## Run Test
  dotnet test
  

