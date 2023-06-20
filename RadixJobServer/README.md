# RadixJobServer - ASP.NET Core 5.0 Server

This is the API Server for the Radix job scheduler server.

## Run

Linux/OS X:

```
sh build.sh
```

Windows:

```
build.bat
```
## Run in Docker

```
cd src/RadixJobServer
docker build -t radixjobserver .
docker run -p 5000:8080 radixjobserver
```
