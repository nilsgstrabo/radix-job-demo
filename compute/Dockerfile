FROM docker.io/golang:1.22-alpine3.20 as build



RUN addgroup -S -g 1001 radix-non-root-group
# Add a new user "radix-non-root-user" with user id 1001 and include in group
RUN adduser -S -u 1001 -G radix-non-root-group radix-non-root-user


RUN apk --no-cache add ca-certificates

WORKDIR /build
COPY go.mod .
COPY go.sum .
RUN go mod download
COPY . .
RUN go build -o app .


FROM alpine:3

WORKDIR /dist
COPY --from=build /etc/ssl/certs/ca-certificates.crt /etc/ssl/certs/
COPY --from=build /etc/passwd /etc/passwd
COPY --from=build /build/app .
USER 1001
CMD ["/dist/app"]
