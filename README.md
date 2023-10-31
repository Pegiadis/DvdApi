# DvdRental API

![CI-Pipeline status](https://github.com/Pegiadis/DvdApi/actions/workflows/build-and-test.yml/badge.svg)
![CD-Pipeline status](https://github.com/Pegiadis/DvdApi/actions/workflows/continuous-deployment.yml/badge.svg)



## Tools
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
![Google Cloud Platform](https://img.shields.io/badge/Google%20Cloud-4285F4?style=for-the-badge&logo=google-cloud&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/github%20actions-%232671E5.svg?style=for-the-badge&logo=githubactions&logoColor=white)
![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)










## Description

This project aims to develop a RESTful API, built with C# and ASP.NET Core to perform CRUD (Create, Read, Update, Delete) operations on the sample PostgreSQL database(https://www.postgresqltutorial.com/postgresql-getting-started/postgresql-sample-database/). The postgres db is hosted on GCP in the cloud SQL service
and the api in a docker on GCP in the cloud run service. The api is deployed automatically with github actions.



## Endpoints

### Actor API Endpoints

Below is a list of available endpoints for the `Actor` resource:

| Method | Endpoint                              | URL                                                                                           | Description                                   |
|--------|---------------------------------------|-----------------------------------------------------------------------------------------------|-----------------------------------------------|
| GET    | `/api/actors`                        | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/actors](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/actors)                        | Retrieve all actors                           |
| GET    | `/api/actors/{id}`                   | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/actors/{id}](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/actors/{id})                   | Retrieve a specific actor by its ID           |
| POST   | `/api/actors`                        | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/actors](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/actors)                        | Create a new actor                            |
| PUT    | `/api/actors/{id}`                   | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/actors/{id}](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/actors/{id})                   | Update a specific actor by its ID             |
| DELETE | `/api/actors/{id}`                   | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/actors/{id}](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/actors/{id})                   | Delete a specific actor by its ID             |

Replace `{id}` in the URL with the specific actor's ID you want to reference.

### Film API Endpoints

Below is a list of available endpoints for the `Film` resource:

| Method | Endpoint                              | URL                                                                                           | Description                                    |
|--------|---------------------------------------|-----------------------------------------------------------------------------------------------|------------------------------------------------|
| GET    | `/api/films`                         | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/films](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/films)                                  | Retrieve all films                             |
| GET    | `/api/films/{id}`                    | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/films/{id}](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/films/{id})                                | Retrieve a specific film by its ID             |
| POST   | `/api/films`                         | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/films](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/films)                                  | Create a new film                              |
| PUT    | `/api/films/{id}`                    | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/films/{id}](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/films/{id})                                | Update a specific film by its ID               |
| DELETE | `/api/films/{id}`                    | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/films/{id}](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/films/{id})                                | Delete a specific film by its ID               |

### Customer API Endpoints

Below is a list of available endpoints for the `Customer` resource:

| Method | Endpoint                              | URL                                                                                           | Description                                    |
|--------|---------------------------------------|-----------------------------------------------------------------------------------------------|------------------------------------------------|
| GET    | `/api/customers`                     | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/customers](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/customers)                              | Retrieve all customers                         |

Replace `{id}` in the URLs with the specific entity's ID you want to reference.

### Inventory API Endpoints

Below is a list of available endpoints for the `Inventory` resource:

| Method | Endpoint                             | URL                                                                                              | Description                                    |
|--------|--------------------------------------|--------------------------------------------------------------------------------------------------|------------------------------------------------|
| GET    | `/api/inventory`                     | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/inventory](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/inventory)                              | Retrieve all inventory items                   |

### Staff API Endpoints

Below is a list of available endpoints for the `Staff` resource:

| Method | Endpoint                             | URL                                                                                              | Description                                    |
|--------|--------------------------------------|--------------------------------------------------------------------------------------------------|------------------------------------------------|
| GET    | `/api/staff`                         | [https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/staff](https://dvdrestapiv2-tjp3smyhka-ew.a.run.app/api/staff)                                      | Retrieve all staff members                     |




## ERD Diagram

![ERD Diagram](./Docs/ERD.png)

## References
1. https://learn.microsoft.com/en-us/aspnet/web-api/overview/older-versions/build-restful-apis-with-aspnet-web-api
2. https://luis-hernandez.medium.com/creating-a-rest-web-api-in-c-with-asp-net-core-5-0-and-visual-studio-code-809ea7b4f815
3. https://www.freecodecamp.org/news/create-a-rest-api-with-dot-net-5-and-c-sharp/
4. https://www.kindsonthegenius.com/how-to-create-rest-api-in-net-using-c-and-visual-studio/
5. https://tutorials.eu/creating-a-csharp-rest-api-client-example/


