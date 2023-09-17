#!/bin/bash
set -e

pushd "tools/buildpackages/GetTrustedInstaller"
    msbuild -p:Configuration="Release" GetTrustedInstaller.csproj
    msbuild -p:Configuration="Release" GetTrustedInstallerc.csproj
popd

cp "tools/buildpackages/GetTrustedInstaller/bin/Release/GetTrustedInstaller.exe" "packages"
cp "tools/buildpackages/GetTrustedInstaller/bin/Release/GetTrustedInstallerc.exe" "packages"

pushd "tools/buildpackages/GetTrustedInstaller"
    msbuild -p:Configuration="Release" -t:clean GetTrustedInstaller.csproj
    msbuild -p:Configuration="Release" -t:clean GetTrustedInstallerc.csproj
    rm -r "bin"
    rm -r "obj"
popd
