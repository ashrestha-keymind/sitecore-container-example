# Sitecore Container Example

- Conainter location: https://github.com/Sitecore/container-deployment/releases/tag/10.3.1.009452.1563
- Image list: https://raw.githubusercontent.com/Sitecore/docker-images/master/tags/sitecore-tags.md

## Getting Started
- .\compose-init.ps1 -LicenseXmlPath "C:\Projects\license.xml"
    > Update the license path as needed.

- Execute the docker compose command to start the containers.
    > docker-compose up -d 


## Fews changes made to the default scripts/files
- Added `.env.default` file. This file contains the (basic)default values that will be copied to the `.env` file on first initialization. When the script first initializes it updated the `.env` file with password/keys/cert values which should not be committed. The `.env` file has been added to `.gitignore` to avoid accidental commits.

## Accessing the containers
Access Sitecore containers > [Reference here](https://doc.sitecore.com/xp/en/developers/103/developer-tools/run-your-first-sitecore-instance.html#access-sitecore-containers)

You access the containers serviced by the reverse proxy with the HTTPS protocol, using their configured hostnames (for ex https://xp0cm.localhost).

The rest of the exposed containers are preconfigured to use specific ports (see ports in the docker-compose.yml file). In the default configuration of Docker Desktop for Windows, you access these ports on localhost.

This means you can access your Sitecore Experience Platform - Single (XP0) containers like this:

- Sitecore Content Management (cm): https://xp0cm.localhost
- Sitecore Identity Server (id): https://xp0id.localhost
- Sitecore xConnect Server (xconnect): http://localhost:8081
- Apache Solr (solr): http://localhost:8984
- Microsoft SQL Server (mssql): localhost,14330
- Traefik: http://localhost:8079

# Troubleshooting
## Not able to access SOLR using the URL provided above
- If using edge/chrome, the browser automatically redirect all the traffic to HTTPS protocal. SOLR URL will not work with this at this time.

    Solution (for chrome/edge)

        - Go to Edge browser and type following statement in address bar.
            `edge://net-internals/#hsts`
        - Scroll down to `Delete domain security policies`.
        - Type 'localhost'.
        - Select `Delete`.


