
# Run locally 
dapr run --app-port 5057 --app-id book-api --app-protocol http --dapr-http-port 3500 -d ../../../../dapr/components -- dotnet run

# Test 
curl -d ""  http://localhost:5057/api/v1/books 
{"isbn":"cf468ea1-f335-4ba3-9e95-2d952d2fe91e","title":"Title","authors":["szerzo"]}