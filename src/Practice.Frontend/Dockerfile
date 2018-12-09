FROM microsoft/dotnet:2.1-sdk AS build
COPY . /var/deploy
WORKDIR /var/deploy/src/Practice.Frondend
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /var/deploy
COPY --from=build /var/deploy/src/Practice.Frondend/out ./
ENTRYPOINT ["dotnet", "Practice.Frontend.dll"]
