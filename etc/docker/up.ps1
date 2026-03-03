docker network create bookstore --label=bookstore
docker-compose -f containers/rabbitmq.yml up -d
docker-compose -f containers/redis.yml up -d
exit $LASTEXITCODE