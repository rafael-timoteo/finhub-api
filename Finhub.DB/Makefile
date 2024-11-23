up:
	docker-compose up -d

down:
	docker-compose down

destroy-container:
	docker-compose down --volumes --remove-orphans
	docker volume prune -f
	docker network prune -f