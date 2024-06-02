# Sitecore Container Example

- Reference: https://doc.sitecore.com/xp/en/developers/103/developer-tools/containers-in-sitecore-development.html
- Container location: https://github.com/Sitecore/container-deployment/releases/tag/10.3.1.009452.1563
- Image list: https://raw.githubusercontent.com/Sitecore/docker-images/master/tags/sitecore-tags.md

## Getting Started

### Initial setup
- .\compose-init.ps1 -LicenseXmlPath "C:\Projects\license.xml"
    > Update the license path as needed.

### Run the container
- Execute the docker compose command to start the containers: `docker-compose up -d`
    > Ignore this warning: _pull access denied for sitecore-xp0-cm, repository does not exist or may require 'docker login': denied: requested access to the resource is denied_
    
    > First build could take 20 minutes or more

### Populate SOLR schema
- CMS > Control Panel > `Populate SOLR Managed Schema`.

### Built SOLR index
- CMS > Control Panel > `Indexing Manager`. Built all indexes.

### Publish Solution
- Visual Studio Web publish

### SYNC unicorn serialization
- [CMS URL]/Unicorn.aspx

### Publish Site from CMS

## Fews changes made to the default scripts/files
- Added `.env.default` file. This file contains the (basic)default values that will be copied to the `.env` file on first initialization. When the script first initializes it updated the `.env` file with password/keys/cert values which should not be committed. The `.env` file has been added to `.gitignore` to avoid accidental commits.

## Accessing the containers
Access Sitecore containers > [Reference here](https://doc.sitecore.com/xp/en/developers/103/developer-tools/run-your-first-sitecore-instance.html#access-sitecore-containers)

Check the `.env` file for the password

- Sitecore Content Management (cm): https://xp0cm.localhost
- Sitecore Identity Server (id): https://xp0id.localhost
- Sitecore xConnect Server (xconnect): http://localhost:8081
- Apache Solr (solr): http://localhost:8984
- Microsoft SQL Server (mssql): localhost,14330
- Traefik: http://localhost:8079

## How to debug?
- Refer to https://doc.sitecore.com/xp/en/developers/103/developer-tools/debug-code-running-in-containers.html

# Troubleshooting
## Docker: Port in use issue
- The container uses the same ports as IIS (80/443). Make sure to stop IIS or any other applications that might be using the port.

## Not able to access SOLR using the URL provided above
- If using edge/chrome, the browser automatically redirect all the traffic to HTTPS protocal. SOLR URL will not work with this at this time.

    Solution (for chrome/edge)

        - Go to Edge browser and type following statement in address bar.
            `edge://net-internals/#hsts`
        - Scroll down to `Delete domain security policies`.
        - Type 'localhost'.
        - Select `Delete`.

## For Error: a network with name ********* exists but was not created by compose
- Remove the container and all the existing networks

    To remove container: `docker compose down`

    To remove network: `docker network prune`

    To start the container follow the steps listed under "Run the container" section above.

## For common containers issues
- First thing to do is stop/restart all the containers

    To stop container: `docker compose stop`

    To start the container follow the steps listed under "Run the container" section above.

- If stopping/restarting the container does not work, remove the container and restart.

    To remove containers: `docker compose down`

    To start the container follow the steps listed under "Run the container" section above.

        > To remove containers, and also remove images: `docker compose down --rmi <all/local>`

## Use this as the last option

    Clean the Persistent storage. NOTE: this will remove all the data including the changes to DB. Commit/backup any changes before executing the following script.

    `.\clean.ps1`

