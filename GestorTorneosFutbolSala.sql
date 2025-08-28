CREATE DATABASE GestorTorneosFutbolSala;

-- Tabla de Torneo
CREATE TABLE Tournament(
Id INTEGER NOT NULL PRIMARY KEY, 
Name VARCHAR(80) NOT NULL, 
Age_Category INTEGER NOT NULL, 
Year INTEGER NOT NULL, 
Gender INTEGER NOT NULL, 
Created_Date DATETIME NOT NULL
);

-- Tabla de Equipo
CREATE TABLE Team (
Id INTEGER NOT NULL PRIMARY KEY, 
Name VARCHAR(80) NOT NULL, 
Origin_Location VARCHAR(80) NOT NULL,
Manager VARCHAR(100) NOT NULL, 
Contact_Phone VARCHAR(20) NOT NULL, 
Tournament_Id INTEGER NOT NULL, 
Created_Date DATETIME NOT NULL,

Points INTEGER NOT NULL DEFAULT 0,
Goals_For INTEGER NOT NULL DEFAULT 0,
Goals_Against INTEGER NOT NULL DEFAULT 0
);

-- Tabla de Jugador
CREATE TABLE Player(
Id INTEGER NOT NULL PRIMARY KEY,
Id_Number VARCHAR(50) NOT NULL,
FullName VARCHAR(150) NOT NULL,
BirthDate DATE NOT NULL,
Team_Id INTEGER NOT NULL,
Created_Date DATETIME NOT NULL,
Goals_Scored INTEGER NOT NULL DEFAULT 0,
Yellow_Cards INTEGER NOT NULL DEFAULT 0,
Blue_Cards INTEGER NOT NULL DEFAULT 0,
Red_Cards INTEGER NOT NULL DEFAULT 0,

CONSTRAINT FK_Player_Team FOREIGN KEY (Team_Id) REFERENCES Team(Id)
);

-- Tabla de Penal
CREATE TABLE Penalty(
Id INTEGER NOT NULL PRIMARY KEY,
Name VARCHAR(80) NOT NULL,
Amount DECIMAL(10,2) NOT NULL,
Active BIT NOT NULL,
Created_Date DATETIME NOT NULL
);

-- Tabla de Partido
CREATE TABLE Match(
Id INTEGER NOT NULL PRIMARY KEY,
Tournament_Id INTEGER NOT NULL,
Home_Team_Id INTEGER NOT NULL, 
Away_Team_Id INTEGER NOT NULL, 
Round_Number INTEGER NOT NULL,
Location VARCHAR(80) NOT NULL, 
Date DATETIME NOT NULL,
Home_Goals INTEGER NOT NULL DEFAULT 0,
Away_Goals INTEGER NOT NULL DEFAULT 0,
Created_Date DATETIME NOT NULL,

CONSTRAINT FK_Match_Tournament FOREIGN KEY (Tournament_Id) REFERENCES Tournament(Id),
CONSTRAINT FK_Match_HomeTeam FOREIGN KEY (Home_Team_Id) REFERENCES Team(Id),
CONSTRAINT FK_Match_AwayTeam FOREIGN KEY (Away_Team_Id) REFERENCES Team(Id)
);

-- Tabla de Incidente
CREATE TABLE Incident(
Id INTEGER NOT NULL PRIMARY KEY,
Match_Id INTEGER NOT NULL, 
Player_Id INTEGER NOT NULL,
Type INTEGER NOT NULL,
Minute INTEGER NOT NULL, 
Notes VARCHAR(200), 
Created_Date DATETIME NOT NULL,

CONSTRAINT FK_Incident_Match FOREIGN KEY (Match_Id) REFERENCES Match(Id),
CONSTRAINT FK_Incident_Player FOREIGN KEY (Player_Id) REFERENCES Player(Id)
);

-- Tabla de Multa
CREATE TABLE Fine(
Id INTEGER NOT NULL PRIMARY KEY,
Player_Id INTEGER NOT NULL,
Penalty_Id INTEGER NOT NULL,
Date DATE NOT NULL,
Amount DECIMAL(10,2) NOT NULL,
Paid BIT NOT NULL,
Created_Date DATETIME NOT NULL,

CONSTRAINT FK_Fine_Player FOREIGN KEY (Player_Id) REFERENCES Player(Id),
CONSTRAINT FK_Fine_Penalty FOREIGN KEY (Penalty_Id) REFERENCES Penalty(Id)
);

-- Tabla de Usuario
CREATE TABLE "User"(
    Id INTEGER NOT NULL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Role INTEGER NOT NULL -- corresponde al UserRoleEnum
);
-----------------------------------------------------------------
-- Datos de la tabla Torneo
INSERT INTO Tournament VALUES (1, 'Copa Juvenil', 18, 2025, 1, '2025-07-10');
INSERT INTO Tournament VALUES (2, 'Liga de Verano', 15, 2025, 2, '2025-08-10');

-- Datos de la tabla Equipo
INSERT INTO Team VALUES (1, 'Equipo Furia', 'San Jose ', 'Miguel Martinez', '1876-2541', 1, '2025-05-12', 0, 0, 0);
INSERT INTO Team VALUES (2, 'Equipo  Águilas', 'Heredia', 'Marta Lopez', '8888-1235', 2, '2025-05-12', 0, 0, 0);

-- Datos de la tabla Jugador
INSERT INTO Player VALUES (1, '110665331', 'Carlos Ramirez', '2007-06-15', 1, '2025-08-10', 0, 0, 0, 0);
INSERT INTO Player VALUES (2, '110665332', 'Ana Morales', '2008-03-22', 2, '2025-08-10', 0, 0, 0, 0);

-- Datos de la tabla Penal
INSERT INTO Penalty VALUES (1, 'Retraso',  50.00, 1, '2025-05-12');
INSERT INTO Penalty VALUES (2, 'Tarjeta amarilla', 10000.00, 1, '2025-08-15');

-- Datos de la tabla Partido
INSERT INTO Match VALUES (1, 1, 1, 2, 1, 'Estadio Nacional', '2025-08-15', 0, 0, '2025-07-01');
INSERT INTO Match VALUES (2, 1, 1, 2, 2, 'Estadio Nacional', '2025-08-16', 2, 1, '2025-07-02'); -- Equipo Furia gana
INSERT INTO Match VALUES (3, 1, 2, 1, 3, 'Estadio Nacional', '2025-08-17', 3, 3, '2025-07-03'); -- Empate

-- Datos de la tabla Incidente
INSERT INTO Incident VALUES (1, 1, 1, 2, 35, 'Tarjeta amarilla por falta', '2025-08-15');

-- Datos de la tabla Multa
INSERT INTO Fine VALUES (1, 1, 1, '2025-08-16', 50.00, 0, '2025-08-16');
INSERT INTO Fine VALUES (2, 2, 2, '2025-08-16', 10000.00, 0, '2025-08-16');

-- Datos de la tabla User
INSERT INTO "User" VALUES (1, 'Administrador', 'admin', 'admin123', 0);
INSERT INTO "User" VALUES (2, 'Sub-Administrador', 'subadmin', 'subadmin123', 1);
INSERT INTO "User" VALUES (3, 'Arbitro', 'arbitro', 'arbitro123', 2);


-----------------------------------------------------------------
-- Select para todas las tablas
SELECT * FROM Tournament;
SELECT * FROM Team;
SELECT * FROM Player;
SELECT * FROM Penalty;
SELECT * FROM Match;
SELECT * FROM Incident;
SELECT * FROM Fine;
SELECT * FROM "User";
-----------------------------------------------------------------
-- Consulta para el registro de Top 10 goleadores: 
SELECT TOP 10 
    pla.Id_Number AS CEDULA, 
    pla.FullName AS NOMBRE, 
    tea.Name AS NOMBRE_EQUIPO, 
    pla.Goals_Scored AS CANTIDAD_GOLES
FROM Player pla
JOIN Team tea ON pla.Team_Id = tea.Id  -- Relaciona jugador con su respectivo equipo
ORDER BY pla.Goals_Scored DESC;        -- Ordena descendente por cantidad de goles
-----------------------------------------------------------------

-- Consulta para la tabla de posiciones de los equipos:
SELECT 
    tea.Name AS NOMBRE_EQUIPO,
    -- se calculan los puntos del equipo según las reglas del torneo:
    -- 3 ganadoe, 1 por empate, 0 perdedor
    SUM(
        IIF(tea.Id = mat.Home_Team_Id AND mat.Home_Goals > mat.Away_Goals, 3,    -- 3 puntos si el equipo local ganó
            IIF(tea.Id = mat.Away_Team_Id AND mat.Away_Goals > mat.Home_Goals, 3, -- 3 puntos si el equipo visitante ganó
            IIF((tea.Id = mat.Home_Team_Id OR tea.Id = mat.Away_Team_Id) AND mat.Home_Goals = mat.Away_Goals, 1, 0)-- 1 punto para ambos equipos si resulta empate
        )
    )) AS PUNTOS,
    -- se hace la suma de todos los goles a favor de cada equipo
    SUM(
        IIF(tea.Id = mat.Home_Team_Id, mat.Home_Goals,     -- si es el equipo local, se suman los goles del equipo local
            IIF(tea.Id = mat.Away_Team_Id, mat.Away_Goals, 0) -- si es el equipo visitante, se suman los goles del equipo visitante
        )
    ) AS GOLES
FROM Team tea
LEFT JOIN Match mat ON tea.Id = mat.Home_Team_Id OR tea.Id = mat.Away_Team_Id
GROUP BY tea.Name
-- primero se ordena por puntos, en caso de empate se ordena por goles y en caso de empate se ordena alfabeticamente
ORDER BY PUNTOS DESC, GOLES DESC, tea.Name ASC;

-----------------------------------------------------------------

-- Consulta de sanciones por equipo: 
SELECT 
    tea.Name AS NOMBRE_EQUIPO,
    pla.Id_Number AS CEDULA_JUGADOR,
    pla.FullName AS NOMBRE_JUGADOR,
    pen.Name AS SANCION,
    COUNT(inc.Id) * pen.Amount AS MONTO      -- Total a pagar
FROM Incident inc
JOIN Player pla ON inc.Player_Id = pla.Id   -- Rleaciona incidente con el jugador
JOIN Penalty pen ON inc.Type = pen.Id       -- Relaciona incidente con su tipo de penalización
JOIN Team tea ON pla.Team_Id = tea.Id       -- Relaciona al jugador con su respectivo equipo
GROUP BY tea.Name, pla.Id_Number, pla.FullName, pen.Name, pen.Amount
ORDER BY tea.Name, pla.FullName;


-- Consulta de sanciones en general (todos los jugadores): 
SELECT 
    pla.Id_Number AS CEDULA,
    pla.FullName AS NOMBRE,
    pen.Name AS SANCION,
    SUM(fin.Amount) AS MONTO_TOTAL               -- Total a pagar por sanciones de dicho jugador
FROM Fine fin
JOIN Player pla ON fin.Player_Id = pla.Id        -- Relaciona multa con el jugador 
JOIN Penalty pen ON fin.Penalty_Id = pen.Id      -- Relaciona multa con su tipo de penalización
GROUP BY pla.Id_Number, pla.FullName, pen.Name
ORDER BY pla.FullName;
-----------------------------------------------------------------







