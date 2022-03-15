FROM mysql:5.7.22
EXPOSE 3306
COPY ./RestWithDotNet5/db/migrations/ /home/database/
COPY ./RestWithDotNet5/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh
