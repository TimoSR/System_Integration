FROM mysql:latest

# /docker-entrypoint-initdb.d/ is important, as this is the directory that MySQL uses to initialize the database on startup.
COPY mysql_backup.sql /mnt

# Expose port 3306 for MySQL
EXPOSE 3306