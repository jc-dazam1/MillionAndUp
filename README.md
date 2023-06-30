
# MillionAndUp

A large Real Estate company requieres creating an API to obtain information about properties in the US, this is in a database as shown in the image, its task is to create a set of services:

a) Create Property Building.
b) Add Image from Property.
c) Change Price.
d) Update Property.
e) List Property with filters.



## Architeture

![Logo]([https://dev-to-uploads.s3.amazonaws.com/uploads/articles/th5xamgrr6se0x5ro4g6.png](https://i.ibb.co/r58VsnX/architecture.png)
This API uses:
- .Net
- Sql Server
- C#
- nUnit
- Entity Framework
- Postman


## API Reference

#### Get all items

```http
  GET /api/items
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key |

#### Get item

```http
  GET /api/items/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

#### add(num1, num2)

Takes two numbers and returns the sum.

