#!/bin/bash

git log  --decorate --graph -n 100 > BuildNotes.log --encoding=866
dotnet restore auth-service/auth-service.sln
dotnet msbuild auth-service/auth-service.sln  /p:Configuration=Release

dotnet test --logger:"trx;LogFileName=TestResults.xml" /Users/petr/Downloads/taxi/taxi/auth-service/AuthService.Tests/bin/Release/net7.0/AuthService.Tests.dll

$baseLocation = (Get-location).Path
$pathToTestResultsXml = $baseLocation + "\TestResults\TestResults.xml"
$testResultsXmlFileExists = Test-Path -Path $pathToTestResultsXml
if [ -f "$testResultsXmlFile" ]; then
  if xmllint --noout "$pathToTestResultsXml"; then
    totalResult=true
    while IFS= read -r line; do
      if [[ "$line" == *"outcome="* ]]; then
        outcome=$(echo "$line" | grep -o 'outcome="[^"]*"' | cut -d '"' -f 2)
        if [ "$outcome" != "Passed" ]; then
          totalResult=false
          break
        fi
      fi
    done < "$pathToTestResultsXml"

    if [ "$totalResult" = false ]; then
      echo "Not all tests passed."
      exit 1
    fi
  else
    echo "Invalid XML file."
    exit 1
  fi
else
  echo "Test results XML file does not exist."
  exit 1
fi
