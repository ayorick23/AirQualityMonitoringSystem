# Air Quality Monitoring API

API RESTful desarrollada con ASP.NET Core 8, Entity Framework Core y MySQL para el monitoreo de calidad del aire en una planta industrial.
El sistema permite registrar sensores, almacenar lecturas ambientales, generar alertas automáticas basadas en parámetros de la OMS e integrar información climática externa mediante una API distribuida.

- [Air Quality Monitoring API](#air-quality-monitoring-api)
  - [Características principales](#características-principales)
  - [Tecnologías utilizadas](#tecnologías-utilizadas)
  - [Arquitectura del proyecto](#arquitectura-del-proyecto)
  - [Modelo de datos](#modelo-de-datos)
    - [SensorCalidadAire](#sensorcalidadaire)
    - [LecturaAire](#lecturaaire)
    - [AlertaAire](#alertaaire)
  - [Lógica de alertas OMS](#lógica-de-alertas-oms)
  - [Seguridad JWT](#seguridad-jwt)
    - [Usuario de prueba](#usuario-de-prueba)
  - [Endpoints disponibles](#endpoints-disponibles)
    - [Autenticación](#autenticación)
    - [Sensores](#sensores)
    - [Lecturas](#lecturas)
    - [Alertas](#alertas)
  - [Integración con API externa](#integración-con-api-externa)
  - [Configuración del Proyecto](#configuración-del-proyecto)
  - [Configuración de base de datos](#configuración-de-base-de-datos)
  - [Scripts SQL](#scripts-sql)
    - [Ubicación de migraciones](#ubicación-de-migraciones)
    - [Script SQL generado](#script-sql-generado)
  - [Ejecutar el proyecto](#ejecutar-el-proyecto)
  - [Swagger / OpenAPI](#swagger--openapi)
  - [Principios implementados](#principios-implementados)
  - [Posibles mejoras futuras](#posibles-mejoras-futuras)
  - [Autor](#autor)
  - [Licencia](#licencia)

## Características principales

- Registro de sensores de calidad del aire
- Registro de lecturas ambientales
- Generación automática de alertas OMS
- Filtros avanzados por fechas y contaminantes
- Integración con API externa de clima
- Arquitectura limpia (Clean Architecture)
- Seguridad mediante JWT Authentication
- Documentación automática con Swagger/OpenAPI
- Persistencia de datos con MySQL
- Entity Framework Core Code First
- Validaciones y manejo de errores HTTP

## Tecnologías utilizadas

- ASP.NET Core 8
- C#
- Entity Framework Core 8
- MySQL
- Pomelo EntityFrameworkCore MySQL
- JWT Authentication
- Swagger / OpenAPI
- HttpClient
- Open-Meteo API
- Clean Architecture
- Repository Pattern

## Arquitectura del proyecto

El proyecto implementa una arquitectura limpia para separar responsabilidades y mantener un código escalable y mantenible.

```text
AirQualityMonitoringSystem
│
├── AirQualityMonitoringSystem.API
│   ├── Controllers
│   ├── Program.cs
│   └── appsettings.json
│
├── AirQualityMonitoringSystem.Application
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── AirQualityMonitoringSystem.Domain
│   └── Entities
│
└── AirQualityMonitoringSystem.Infrastructure
    ├── Persistence
    ├── Repositories
    └── Migrations
```

## Modelo de datos

### SensorCalidadAire

Representa un sensor instalado en una zona de la planta industrial.

| Campo     | Tipo   |
| --------- | ------ |
| Id        | int    |
| Ubicacion | string |
| TipoGas   | string |
| Estado    | string |

### LecturaAire

Representa una lectura capturada por un sensor.

| Campo     | Tipo     |
| --------- | -------- |
| Id        | int      |
| SensorId  | int      |
| PM2_5     | decimal  |
| PM10      | decimal  |
| CO2       | decimal  |
| FechaHora | DateTime |

### AlertaAire

Representa una alerta generada automáticamente según parámetros de contaminación.

| Campo     | Tipo     |
| --------- | -------- |
| Id        | int      |
| SensorId  | int      |
| Nivel     | string   |
| Mensaje   | string   |
| FechaHora | DateTime |

## Lógica de alertas OMS

La API genera alertas automáticas según niveles de contaminación definidos por la Organización Mundial de la Salud (OMS).

| Nivel    | Condición                                   |
| -------- | ------------------------------------------- |
| Leve     | PM2.5 entre 25 y 50 µg/m³                   |
| Moderada | PM2.5 entre 51 y 100 µg/m³ o CO2 > 1000 ppm |
| Crítica  | PM2.5 > 150 µg/m³ o PM10 > 200 µg/m³        |
| Extrema  | CO2 > 5000 ppm o PM2.5 > 250 µg/m³          |

## Seguridad JWT

La API implementa autenticación JWT para proteger los endpoints.

### Usuario de prueba

```text
Usuario: admin
Contraseña: Admin123*
```

## Endpoints disponibles

### Autenticación

| Método | Endpoint        | Descripción       |
| ------ | --------------- | ----------------- |
| POST   | /api/auth/login | Generar token JWT |

### Sensores

| Método | Endpoint    | Descripción      |
| ------ | ----------- | ---------------- |
| GET    | /api/sensor | Obtener sensores |
| POST   | /api/sensor | Registrar sensor |

### Lecturas

| Método | Endpoint                  | Descripción                             |
| ------ | ------------------------- | --------------------------------------- |
| POST   | /api/lectura              | Registrar lectura                       |
| GET    | /api/lectura/filtro       | Filtrar lecturas                        |
| GET    | /api/lectura/enriquecidas | Obtener lecturas enriquecidas con clima |

### Alertas

| Método | Endpoint    | Descripción               |
| ------ | ----------- | ------------------------- |
| GET    | /api/alerta | Obtener alertas generadas |

## Integración con API externa

El proyecto consume datos climáticos externos utilizando:

[Open-Meteo API](https://open-meteo.com/?utm_source=chatgpt.com)

Información obtenida:

- Temperatura
- Humedad relativa

## Configuración del Proyecto

1.  Clonar el repositorio

    ```bash
    git clone https://github.com/ayorick23/AirQualityMonitoringSystem.git
    ```

2.  Abrir la solución

    Abrir el archivo:

    ```text
    AirQualityMonitoringSystem.sln
    ```

    en Visual Studio 2022.

3.  Configurar la cadena de conexión

    Editar el archivo:

    ```text
    appsettings.json
    ```

    y configurar:

    ```JSON
    "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=AirQualityDB;user=root;password=TU_PASSWORD;"
    }
    ```

## Configuración de base de datos

**Crear migraciones:**

```bash
dotnet ef migrations add InitialMigration --project AirQualityMonitoringSystem.Infrastructure --startup-project AirQualityMonitoringSystem.API
```

**Aplicar migraciones:**

```bash
dotnet ef database update --project AirQualityMonitoringSystem.Infrastructure --startup-project AirQualityMonitoringSystem.API
```

**Generar scripts SQL:**

```bash
dotnet ef migrations script --project AirQualityMonitoringSystem.Infrastructure --startup-project AirQualityMonitoringSystem.API -o script.sql
```

## Scripts SQL

El proyecto utiliza Entity Framework Core con enfoque Code First, por lo que la estructura de la base de datos se genera automáticamente mediante migraciones.

### Ubicación de migraciones

Las migraciones se encuentran en:

```text
AirQualityMonitoringSystem.Infrastructure/Migrations
```

### Script SQL generado

El script SQL de creación de tablas y relaciones puede generarse mediante el siguiente comando:

```bash
dotnet ef migrations script --project AirQualityMonitoringSystem.Infrastructure --startup-project AirQualityMonitoringSystem.API -o script.sql
```

El archivo generado:

```text
script.sql
```

incluye:

- Creación de tablas
- Relaciones
- Foreign Keys
- Constraints
- Índices
- Configuración completa de la base de datos

## Ejecutar el proyecto

Desde Visual Studio presionar:

```text
F5
```

Desde terminal:

```bash
dotnet run --project AirQualityMonitoringSystem.API
```

## Swagger / OpenAPI

Una vez ejecutado el proyecto:

```text
https://localhost:xxxx/swagger
```

## Principios implementados

- Clean Architecture
- Separation of Concerns
- Dependency Injection
- Repository Pattern
- DTO Pattern
- RESTful API Design
- Code First Development

## Posibles mejoras futuras

- [ ] Roles y permisos
- [ ] Refresh Tokens
- [ ] Dockerización
- [ ] CI/CD
- [ ] Logs centralizados
- [ ] Monitoreo en tiempo real
- [ ] WebSockets
- [ ] Dashboard frontend
- [ ] Unit Testing
- [ ] FluentValidation

## Autor

Proyecto desarrollado por Dereck Méndez para la materia de Programación Web I (Backend).

## Licencia

Uso académico y educativo.
