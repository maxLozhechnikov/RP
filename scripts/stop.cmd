<<<<<<< Updated upstream
docker stop redis & docker rm redis
docker stop nats & docker rm nats

taskkill /f /im valuator.exe
taskkill /f /im nginx.exe
taskkill /f /im rankcalculator.exe
=======
taskkill /f /im valuator.exe
taskkill /f /im rankcalculator.exe
taskkill /f /im eventslogger.exe

cd ..\nginx\
nginx -s stop
>>>>>>> Stashed changes
