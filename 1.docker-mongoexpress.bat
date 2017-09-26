docker run --link mongo1:mongo -d -p 8081:8081 mongo-express
echo Press a key to continue
pause
start http://localhost:8081