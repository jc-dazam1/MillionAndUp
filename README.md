
# MillionAndUp

A large Real Estate company requieres creating an API to obtain information about properties in the US, this is in a database as shown in the image, its task is to create a set of services:

a) Create Property Building.
b) Add Image from Property.
c) Change Price.
d) Update Property.
e) List Property with filters.

## Architeture

![Logo](https://i.ibb.co/44vHdB0/architecture.png)

This API uses:
- .Net
- Sql Server
- C#
- nUnit
- Entity Framework
- Postman

## Steps

SQL Server steps:
- Create a Database with Name : "APIMUP".
- Create a user to Login "sa" with password "sa".
Visual Studio steps:
- Enter to "Package Manager Console"
- Execute command: "Add-Migration InitialCreate"
- Execute command: "Update-database"
To execute UnitTest in Visual Studio:
- Open Project.
- Open folder "Unit Tests".
- Select TestAPI.cs and click right.
- Select "Run Tests"
To execute tests in Postman.
- Download files "Million And Up.postmnan_col" and "MillionVars.postm".
- Open Postman.
- Select Import option and select two files.
- Execute in order and see the results.

## API Reference

## Users

#### Authenticate User to get Token

Authenticate Method to generate Token

```http
  POST /api/Users/authenticate
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Name`      | `string` | **Required**. Id of item to fetch |
| `Password`      | `string` | **Required**. Id of item to fetch |


## Properties 

#### Get all properties

Get all Properties exist.

```http
  GET /api/Properties/GetAllProperties
```

Not necessary parameters.

#### Get Property

Get a Property with ID especific.

```http
  GET /api/Properties/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |


#### Update Property (Property)

Update a property attributes.

```http
  PUT /api/Properties/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |
| `Name`    | `string` | **Required**. Name of item to fetch |
| `Price`      | `string` | **Not Required**. Price of item to fetch |
| `CodeInternal`    | `string` | **Not Required**. Code Internal of item to fetch |
| `Address`    | `string` | **Not Required**. Address of item to fetch |
| `Year`    | `string` | **Not Required**. Year of item to fetch |
| `IdOwner`    | `string` | **Not Required**. IdOwner of item to fetch |

#### Delete Property (ID)

Delete Property specific.

```http
  DELETE /api/Properties/${id}
```


| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |


#### Get Property with filters

Get a Property with any attribute especific.

```http
  GET /api/Properties/GetPropertiesFilter
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Not Required**. Id of item to fetch |
| `Name`    | `string` | **Not Required**. Name of item to fetch |
| `Price`      | `string` | **Not Required**. Price of item to fetch |
| `CodeInternal`    | `string` | **Not Required**. Code Internal of item to fetch |
| `Address`    | `string` | **Not Required**. Address of item to fetch |
| `Year`    | `string` | **Not Required**. Year of item to fetch |
| `IdOwner`    | `string` | **Not Required**. IdOwner of item to fetch |

#### Update Price Property (Price)

Update a property's price.

```http
  PUT /api/Properties/Property/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |
| `Price`      | `string` | **Not Required**. Price of item to fetch |

#### Create Property (Property)

Create a property object.

```http
  POST /api/Properties
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Name`    | `string` | **Not Required**. Name of item to fetch |
| `Price`      | `string` | **Not Required**. Price of item to fetch |
| `CodeInternal`    | `string` | **Not Required**. Code Internal of item to fetch |
| `Address`    | `string` | **Not Required**. Address of item to fetch |
| `Year`    | `string` | **Not Required**. Year of item to fetch |
| `IdOwner`    | `string` | **Not Required**. IdOwner of item to fetch |


## PropertyImages

#### Image from Property

Add Image from Property

```http
  POST /api/PropertyImages
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `idProperty`    | `string` | **Not Required**. idProperty of item to fetch |
| `file`      | `string` | **Not Required**. file of item to fetch |
| `enabled`    | `boolean` | **Not Required**. If is enabled or not. |





