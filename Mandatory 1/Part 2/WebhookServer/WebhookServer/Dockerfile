# Use the official Microsoft .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory
WORKDIR /app

# Copy the .csproj file and restore the NuGet packages
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining files and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official Microsoft .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory
WORKDIR /app

# Copy the build output from the build environment
COPY --from=build-env /app/out .

# Copy the certificate file
COPY certificate.pfx .

# Copy the files
COPY invoice_completed.txt .
COPY invoice_processing.txt .
COPY payment_processed.txt .
COPY payment_received.txt .


# Set the environment variable for the ASP.NET Core environment
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS="http://+:7080;https://+:7443"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/app/certificate.pfx"

# Use a build argument for the password
ARG CERT_PASSWORD
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=$CERT_PASSWORD

# Expose the ports used by the application (use the ports from the "WebhookServer" profile)
EXPOSE 7080
EXPOSE 7443

# Start the application
ENTRYPOINT ["dotnet", "WebhookServer.dll"]