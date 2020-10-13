FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# Copia o projeto e restaura as dependencias
COPY *.sln .
COPY Omt.Api/*.csproj ./Omt.Api/
COPY Omt.Application/*.csproj ./Omt.Application/
COPY Omt.Domain/*.csproj ./Omt.Domain/
COPY Omt.InterestApi/*.csproj ./Omt.InterestApi/
COPY Omt.Service/*.csproj ./Omt.Service/
COPY Omt.Test/*.csproj ./Omt.Test/

RUN dotnet restore

# Copia o restante do projeto e realiza o build / publish
COPY Omt.Api/. ./Omt.Api/
COPY Omt.Application/. ./Omt.Application/
COPY Omt.Domain/. ./Omt.Domain/
COPY Omt.InterestApi/. ./Omt.InterestApi/
COPY Omt.Service/. ./Omt.Service/
COPY Omt.Test/. ./Omt.Test/

WORKDIR /app/Omt.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/Omt.Api/out ./
ENTRYPOINT ["dotnet", "Omt.Api.dll"]