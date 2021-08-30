
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build


RUN mkdir -p /root/src/app  
WORKDIR /root/src/app  
EXPOSE 80
EXPOSE 443
COPY WebAPIOEE     WebAPIOEE  
WORKDIR /root/src/app/WebAPIOEE

RUN dotnet restore ./WebAPIOEE.csproj  
RUN dotnet publish -c release -o published 


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime

WORKDIR /root/  
COPY --from=build /root/src/app/WebAPIOEE/published .

#CMD ["dotnet", " --info"]
ENTRYPOINT [ "dotnet","./WebAPIOEE.dll" ]
#ENTRYPOINT ["./WebAPIOEE.dll"]