using WebApplication2.Endpoints;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("CategoriesStoreDB");
builder.Services.AddDbContext<CategoriesContext>(options => 
    options.UseSqlServer(connString));

var app = builder.Build();

app.MapCategoriesEndpoints();

app.Run();


/*
Crear backend RestFul en NET que se conecte a la siguiente Base de datos

=== BD: SQL Server sin certificado
Server: 50.21.176.30
Usuario : aspirante1
pass: aspirante1
DB : Evaluaciones
Tabla : Categoria [idCategoria,categoria,fecha_registro,fecha_actualizacion,estatus]
=== TrustServerCertificate=true

En la cadena se tiene que poner bueno todos los certificados 

Crear un recurso Get que obtenga todas las categorías con estatus 1
Crear un recurso Post que Agregue una categoría

Crear un recurso Put que actualice una categoría, 
deberá permitir actualizar solo las columnas [categoria,estatus] y al actualziar

modificara la columna fecha_actualizacion con la fecha en que se realizo la actualización del registro

2292952656
*/