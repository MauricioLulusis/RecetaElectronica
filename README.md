# Receta Electrónica - Proyecto .NET

## Descripción

Este proyecto consiste en un sistema de gestión de Recetas Médicas Electrónicas.  
Permite validar, registrar y visualizar recetas asociadas a pacientes, médicos, obras sociales y coberturas, respetando reglas de cantidad y validaciones dinámicas parametrizables.  
Además, permite la generación de un comprobante en formato **PDF con diseño personalizado**.

## Funcionalidades implementadas

- ✅ Validación dinámica de cantidad de medicamentos por:
  - Obra social
  - Cobertura
  - Edad del paciente
  - Límites mínimo y máximo
  - Tope monetario
- ✅ Registro de recetas asociadas a:
  - Pacientes
  - Médicos
  - Coberturas
  - Medicamentos
- ✅ Generación de **PDF personalizado**, incluyendo:
  - Encabezado de la receta
  - Datos del paciente y médico
  - Listado de medicamentos
  - Logo de la Universidad de la Cuenca del Plata
  - Pie de página con nombres del equipo
- ✅ Visualización en formato HTML de la receta
- ✅ Listado de todas las recetas generadas
- ✅ Pruebas Unitarias con **xUnit y Moq**
- ✅ Configuración de base de datos en memoria para pruebas

## Tecnologías utilizadas

- **.NET Core / ASP.NET Core**
- **Entity Framework Core**  
  - SQL Server en producción
  - InMemoryDatabase para testing
- **PDFSharpCore**  
  - Generación de PDFs manualmente sin depender de `DinkToPdf`
- **xUnit**  
  - Pruebas unitarias
- **Moq**  
  - Mockeo de dependencias en pruebas
- **Swagger/OpenAPI**
  - Documentación y pruebas de los endpoints REST

## Estructura del Proyecto

/RecetaElectronica
├── Context/ # DbContext y Configuraciones
├── Modelo/ # Entidades del dominio
├── Servicios/ # Lógica de negocio y generación de PDF
├── Controllers/ # API Controllers
└── Program.cs # Configuración general del proyecto

/TestReceta
└── RecetaServiceTests.cs # Pruebas Unitarias del Servicio de Recetas


## Cómo ejecutar

1. Ejecutar el proyecto **RecetaElectronica**.
2. Acceder a **Swagger** en: `https://localhost:<puerto>/swagger`
3. Probar los siguientes endpoints:
   - `GET /api/Recetas/validar`
   - `POST /api/Recetas/guardar`
   - `GET /api/Recetas/ver/{recetaId}`
   - `GET /api/Recetas/ver-html/{recetaId}`
   - `GET /api/Recetas`  

## Cómo ejecutar las pruebas

1. Clic derecho sobre el proyecto **TestReceta** > **Ejecutar pruebas**.
2. O desde **Test Explorer** en Visual Studio.
3. O usando la terminal:
   ```bash
   dotnet test
