# radix-job-demo

A simple demo app to show how jobs can be used in Radix.

Regenerate Job Scheduler client:
openapi-generator-cli generate -g csharp-netcore -i https://www.radix.equinor.com/guides/configure-jobs/swagger.json -c openapi-config.yaml -o RadixJobClient