# Radix Job Demo


A simple demo app to show how jobs can be used in Radix.

Regenerate Job Scheduler client:
```
docker run --user 1000:1000 -v ./src:/src --rm openapitools/openapi-generator-cli:v7.10.0 generate -g csharp -i https://raw.githubusercontent.com/equinor/radix-job-scheduler/main/swaggerui/html/swagger.json -c src/openapi-config.yaml -o src/RadixJobClient
```

Regenerate Job Scheduler server:

```
docker run --user 1000:1000 -v ./src:/src --rm openapitools/openapi-generator-cli:v7.10.0 generate -g aspnetcore -i https://raw.githubusercontent.com/equinor/radix-job-scheduler/main/swaggerui/html/swagger.json -c src/openapi-config-server.yaml -o src/RadixJobServer
```
