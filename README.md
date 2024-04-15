# AGSR.WebApi


#Set passwords in .env file

Example .env file:
MSSQL_SA_PASSWORD=yourStrong(!)Password
SSL_CERTIFICATE_PASSWORD=12345

# Generate ssl certificate

1. Open a terminal and navigate to the root directory of the project.

2. Run the following commands to generate certificate:
for /f "tokens=2 delims==" %a in ('findstr "SSL_CERTIFICATE_PASSWORD=" .env') do set SSL_CERTIFICATE_PASSWORD=%a
dotnet dev-certs https -ep ./Certificates/agsr_cert.pfx -p %SSL_CERTIFICATE_PASSWORD%
dotnet dev-certs https --trust

## Running with Docker Compose

1. Install Docker and Docker Compose on your computer if they are not installed already.

2. Open a terminal and navigate to the root directory of the project.

3. Run the following command to start the application using Docker Compose:
docker-compose up --build 


## Running with an IDE

Alternatively, you can run the project using an IDE such as Visual Studio or others.
Follow the specific IDE’s instructions for importing and running the project.