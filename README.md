# radix-job-demo

A simple demo app to show how jobs can be used in Radix.

Regenerate Job Scheduler client:
```
openapi-generator-cli generate -g csharp-netcore -i https://raw.githubusercontent.com/equinor/radix-public-site/main/public-site/docs/src/guides/jobs/swagger.json -c openapi-config.yaml -o RadixJobClient
```

Regenerate Job Scheduler server:

```
openapi-generator-cli generate -g aspnetcore -i https://raw.githubusercontent.com/equinor/radix-public-site/main/public-site/docs/src/guides/configure-jobs/swagger.json -c openapi-config-server.yaml -o RadixJobServer2
```