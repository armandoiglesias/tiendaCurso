# tiendaCurso

docker network create TiendaMicroservice

docker run --name sqlServer -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=@A1s2d3f4g5h6" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server
docker network connect TiendaMicroservice sqlServer 

docker run --name mySQL -d -p 3306:3306 -e "MYSQL_ROOT_PASSWORD=@A1s2d3f4g5h6" mysql
docker network connect TiendaMicroservice mySQL


docker run --name postgresCurso -e POSTGRES_PASSWORD="@A1s2d3f4g5h6" -d -p 5432:5432 postgres 
docker network connect TiendaMicroservice postgresCurso

docker run -d --hostname myRabbit --name myRabbitServer rabbitmq:3
docker network connect TiendaMicroservice myRabbitServer

docker run -d --hostname myRabbit --name myRabbitServerWeb rabbitmq:3-management
docker network connect TiendaMicroservice myRabbitServerWeb
