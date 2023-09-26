# Fast Food Image Detection API
Project Description
This project uses ML.NET to classify fast food categories over an HTTP request or over uploaded images. The project can identify the following fast food categories:

Baked Patato,Burger,Crispy Chickem,Donut,Fries,Hot Dog,Pizza,Sandwich,Taco,Taquito
## Project Description
In this project, there is a controller named FastFoodDetectionController with the following features:

- POST /Detect: This endpoint takes a JSON request and classifies fast food images using the data provided in the request. The request content should be as follows:

  
```json
{
  "type": 0,
  "data": "string"
}
```
- type: Specifies the input type, where 0 represents a URL and 1 represents a file path.
- data: Contains the URL or file path, depending on the specified type.
The response returns the classification result in JSON format.
## Technologies
This project utilizes the following technologies and tools:
- .NET Core 7.0
- ML.NET
## How to Use
The project can be started by following these steps:

1. Clone the project:
```bash
git clone https://github.com/your-repo-url.git
```
2. Navigate to the project directory:
```bash
cd project-directory
```
3. Restore project dependencies:
```bash
dotnet restore
```
4. Run the application:
```bash
dotnet run
```
5. The application should now be running at http://localhost:5000.

## Usage Instructions
Example Usage
You can use the following curl command to classify images:
```bash
curl -X POST -H "Content-Type: application/json" -d '{"type": 0, "data": "URL_or_FilePath"}' http://localhost:5000/Detect
```
This command sends a JSON request and receives the classification result.
## Requirements

You need the following requirements to run this project:

- .NET Core 7.0
- ML.NET


  
