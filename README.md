# GraphQL API Documentation

This document provides an overview of the **GraphQL API** implementation, its **pros and cons**, and instructions on how to **test** it using **Postman**.

---

## 1. Overview of GraphQL

GraphQL is a query language for APIs that allows clients to request exactly the data they need, and nothing more. It enables more efficient data retrieval compared to REST APIs and supports complex queries, mutations, and real-time subscriptions.

---

## 2. Pros and Cons of GraphQL

### **Pros**
- **Efficient Data Retrieval**: Request only the data you need.
- **Single Endpoint**: All queries and mutations are sent to one endpoint.
- **Strongly Typed**: Automatically validates data and provides clear documentation.
- **No Versioning**: API evolves without needing version changes.

### **Cons**
- **Complexity**: Setting up and maintaining GraphQL can be more involved than REST.
- **Performance**: Complex queries can put strain on the server.
- **Caching Challenges**: Requires custom strategies for caching.

---

## 3. How We Implemented the GraphQL API

### **Step 1: Set Up the Project**

1. **Create a .NET Web API** using:
   ```bash
   dotnet new webapi -n GraphQLHotChocolateAPI
   ```
2. **Install HotChocolate and EF Core:**
   ```
   dotnet add package HotChocolate.AspNetCore
   dotnet add package HotChocolate.EntityFramework
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   ```

### **Step 2: Define the Mutations**
We implemented Create, Update, and Delete mutations for managing products. For example:
```
public async Task<ProductInfo> CreateProduct(ProductInput input)
{
    var newProduct = new ProductInfo
    {
        name = input.Name,
        code = input.Code,
        sku = input.Sku,
        qty = input.Qty,
        stock = input.Stock
    };

    _context.ProductInfo.Add(newProduct);
    await _context.SaveChangesAsync();
    return newProduct;
}
```

## 4. Testing the API with Postman

### **Create Product Mutation**

1. **Method**: POST  
2. **URL**: `http://localhost:5000/graphql`  
3. **Body (GraphQL Tab)**:
   ```graphql
   mutation {
     createProduct(input: { name: "New Product", code: "NP123", sku: "SKU001", qty: "100", stock: "In Stock" }) {
       id name code sku qty stock
     }
   }
  ```

### **Update Product Mutation**

1. **Method**: POST  
2. **URL**: `http://localhost:5000/graphql`  
3. **Body (GraphQL Tab)**:
   ```graphql
   mutation {
     updateProduct(id: 1, input: { name: "Updated Product", code: "UP123", sku: "SKU999", qty: "150", stock: "Out of Stock" }) {
       id name code sku qty stock
     }
   }
  ```

### **Delete Product Mutation**

1. **Method**: POST  
2. **URL**: `http://localhost:5000/graphql`  
3. **Body (GraphQL Tab)**:
   ```graphql
   mutation {
     deleteProduct(id: 1)
   }
  ```

### **Fetch Products Query**
1. **Method**: POST  
2. **URL**: `http://localhost:5000/graphql`  
3. **Body (GraphQL Tab)**:
   ```graphql
   query {
     getProducts {
       id
       name
       code
       sku
       qty
       stock
     }
   }
   ```

![Alt text](path/to/image.png)

