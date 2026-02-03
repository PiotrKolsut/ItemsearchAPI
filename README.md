# ItemSearchAPI

The API for item search based on barcode or name.

## Features

- Search items by barcode
- Search items by name (partial match)
- Get all available items

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later

### Running the API

1. Navigate to the project directory:
   ```bash
   cd ItemSearchAPI
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. The API will be available at `http://localhost:5189`

4. Access Swagger UI for API documentation: `http://localhost:5189/swagger`

## API Endpoints

### Get All Items
- **GET** `/api/items`
- Returns all available items

### Search by Barcode
- **GET** `/api/items/search/barcode/{barcode}`
- Returns a specific item by barcode
- Example: `/api/items/search/barcode/1234567890123`

### Search by Name
- **GET** `/api/items/search/name/{name}`
- Returns all items that contain the search term in their name (case-insensitive)
- Example: `/api/items/search/name/laptop`

## Sample Data

The API comes with sample data including:
- Laptop (Barcode: 1234567890123)
- Mouse (Barcode: 2345678901234)
- Keyboard (Barcode: 3456789012345)
- Monitor (Barcode: 4567890123456)
- Headphones (Barcode: 5678901234567)
- And more...

## Response Format

All responses are in JSON format.

### Success Response Example:
```json
{
  "id": 1,
  "name": "Laptop",
  "barcode": "1234567890123",
  "description": "High-performance laptop",
  "price": 999.99
}
```

### Error Response Example:
```json
"Item with barcode '9999999999999' not found"
```

