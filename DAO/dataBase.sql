USE TestSql

CREATE TABLE Client
(
	idClient INT PRIMARY KEY IDENTITY(1,1),
	nom VARCHAR(50) NOT NULL,
	prenom VARCHAR(50) NOT NULL,
	email VARCHAR(100) UNIQUE NOT NULL,
	telephone VARCHAR(15),
	adresse VARCHAR(100),
	codePostal VARCHAR(10),
);


CREATE TABLE TestSql.Orders 
(
	idOrder INT PRIMARY KEY  IDENTITY(1,1),
	dateOrder DATETIME NOT NULL,
	totalAmount DECIMAL(10, 2) NOT NULL,
	client_id INT,
	CONSTRAINT FK_Client_Order FOREIGN KEY (client_id) REFERENCES Client(idClient)
)

INSERT INTO TestSql.Client (nom, prenom, email, telephone, adresse, codePostal)
VALUES
('Durand', 'Pierre', 'pierre.durand@example.com', '0601020304', '12 Rue de Paris', '75001'),
('Martin', 'Sophie', 'sophie.martin@example.com', '0611223344', '8 Avenue de Lyon', '69000'),
('Bernard', 'Luc', 'luc.bernard@example.com', '0622334455', '5 Rue du Havre', '76600'),
('Moreau', 'Claire', 'claire.moreau@example.com', '0633556677', '22 Boulevard de Nice', '06000'),
('Robert', 'Julien', 'julien.robert@example.com', '0644667788', '40 Rue de Lille', '59000');


INSERT INTO Orders (dateOrder, totalAmount, client_id) VALUES
(GETDATE(), 150.75, 1),
(GETDATE(), 89.99, 1),
(GETDATE(), 230.50, 2),
(GETDATE(), 59.90, 3);


