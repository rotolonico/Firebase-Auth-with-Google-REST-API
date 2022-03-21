# Firebase-Auth-with-Google-REST-API
## Integration example of Firbease Authentication Google provider in Unity using REST APIs

### Master branch
Implements the copy/paste method to bring the auth token back to the client. (deprecated)

### Loopback-ip branch
Redirects the auth token to localhost on a specific port. The client will listen on the same port to fetch the token.

### Cloud-function-setup branch
Redirects the auth token to a cloud function that stores it safely on realtime database. The client will invoke a second cloud function periodically to check if the token has landed and, eventually, fetch it.

### Libraries used:
- [RestClient](https://github.com/proyecto26/RestClient)
- [FullSerializer](https://github.com/jacobdufault/fullserializer)
