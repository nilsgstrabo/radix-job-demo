# Radix Job Demo


A simple demo app to show how jobs can be used in Radix.

Regenerate Job Scheduler client:
```
openapi-generator-cli generate -g csharp-netcore -i https://raw.githubusercontent.com/equinor/radix-job-scheduler/main/swaggerui/html/swagger.json -c src/openapi-config.yaml -o src/RadixJobClient
```

Regenerate Job Scheduler server:

```
openapi-generator-cli generate -g aspnetcore -i https://raw.githubusercontent.com/equinor/radix-job-scheduler/main/swaggerui/html/swagger.json -c src/openapi-config-server.yaml -o src/RadixJobServer
```
