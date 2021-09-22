#------------------------------------------------------------------------------------------------------------------------
#
# USAGE:        Creates Docker image for building and packing the Nuget Packages.
#               1. Build the image
#               2. Run the container to get the packages out of the image.
#
# BUILD:        docker build -t kdcllc/bet:nuget-build -f "Dockerfile" --build-arg VERSION=4.0.0-preview1 --build-arg NUGET_RESTORE="-v=m" .
#
# RUN:          1. docker run -d --name bet.nuget.build kdcllc/bet:nuget-build
#               2. docker cp bet.nuget.build:/app/nugets ${PWD}/packages
#------------------------------------------------------------------------------------------------------------------------

FROM kdcllc/dotnet-sdk:6.0-focal as builder

ARG VERSION
WORKDIR /app

COPY ./img ./img
COPY .git ./.git

RUN dotnet pack Bet.Extensions.sln -c Release -p:Version=${VERSION} --no-build -o /app/nugets
