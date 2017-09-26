%~d0
cd %~dp0
docker volume create --name mongodata
docker run --name mongo1 -d -p 27017:27017 -v mongodata:/data/db mongo
pause
