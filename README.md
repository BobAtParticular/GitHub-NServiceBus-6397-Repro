# GitHub-NServiceBus-6397-Repro

Attempted a repro for [NServiceBus issue 6397](https://github.com/Particular/NServiceBus/issues/6397).

## MongoDB container

`docker run -d -p 27017:27017 --name TestMongoDB mongo:latest --replSet tr0`

`docker exec -it TestMongoDB mongo --eval 'rs.initiate()'`

## RabbitMQ container

`docker run -d --hostname my-rabbit --name my-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3-management`