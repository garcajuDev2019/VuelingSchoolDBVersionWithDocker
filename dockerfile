FROM microsoft/dotnet-framework:4.7.2-sdk AS Build

COPY ./install.ps1 c:/temp/
CMD Set-ExecutionPolicy Bypass

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
WORKDIR C:/temp
RUN ./install.ps1

RUN git clone https://github.com/garcajuDev2019/VuelingSchoolDBVersionWithDocker.git

WORKDIR C:/VuelingSchool/
RUN nuget restore ./VuelingSchool.sln

RUN ./Build.ps1

#COPY ./VuelingSchool.DataAccess.Repository/bin/Debug/RepositoryConfiguration.xml .

ENTRYPOINT C:\VuelingSchool\VuelingSchool.Presentation.Console\publish\VuelingSchool.Presentation.Console.exe
# ENTRYPOINT powershell -command c:\OnInit.ps1

# CMD ping www.github.com