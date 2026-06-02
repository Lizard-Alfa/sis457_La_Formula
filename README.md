# sis457_La_Formula - Sistema de Gestión para Librería

## Descripción del negocio
**La Formula** es una librería especializada que ofrece:
- Material escolar
- Libros
- Material de oficina
- Materiales para arte & diseño
- Material de arquitectura

## Entidades tentativas

### Inventario (tabla principal)
| Campo | Tipo | Descripción |
|-------|------|-------------|
| Id | INT (PK) | Identificador único |
| NombreProducto | VARCHAR(100) | Nombre del producto |
| Descripcion | VARCHAR(255) | Opcional |
| Codigo | VARCHAR(50) | Código de barras o SKU |
| Marca | VARCHAR(50) | Marca del producto |
| Categoria | VARCHAR(50) | Escolar, Libros, Oficina, Arte, Arquitectura |
| UbicacionBodega | VARCHAR(50) | Estante o zona de almacenamiento |
| PrecioBs | DECIMAL(10,2) | Precio en bolivianos |
| Unidad | VARCHAR(20) | Ej: Caja, Paquete, Docena, Metro |
| Cantidad | INT | Stock disponible |
| Factor | DECIMAL(10,2) | Cantidad de piezas por unidad |
| PrecioPorPieza | DECIMAL(10,2) | PrecioBs / (Cantidad * Factor) |

### Entidades complementarias
| Entidad | Campos |
|---------|--------|
| Cliente | Id, Nombre, Email, Teléfono, Dirección |
| Venta | Id, ClienteId, Fecha, Total, Estado |
| DetalleVenta | Id, VentaId, ProductoId, Cantidad, Subtotal |
| Usuario | Id, NombreUsuario, ContraseñaHash, Rol |

## Tecnologías
- .NET 8 / Visual Studio 2026
- SQL Server
- Entity Framework Core

## Estructura del proyecto
sis457_La_Formula/
├── BaseDatos/
│ └── script_ddl.sql
├── CadLaFormula/
├── ClnLaFormula/
├── CpLaFormula/
└── README.md

# Base de datos
**Nombre**: `LabLaFormula`

## Integrantes
- Sanchez Saigua Iver
- Alfaro Fernandez Jhon Franz

## Estado
[X] En desarrollo - Primeras 24 horas