using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecetaElectronica.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    MedicamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.MedicamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                });

            migrationBuilder.CreateTable(
                name: "ObrasSociales",
                columns: table => new
                {
                    ObraSocialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasSociales", x => x.ObraSocialId);
                });

            migrationBuilder.CreateTable(
                name: "Coberturas",
                columns: table => new
                {
                    CoberturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ObraSocialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coberturas", x => x.CoberturaId);
                    table.ForeignKey(
                        name: "FK_Coberturas_ObrasSociales_ObraSocialId",
                        column: x => x.ObraSocialId,
                        principalTable: "ObrasSociales",
                        principalColumn: "ObraSocialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObraSocialId = table.Column<int>(type: "int", nullable: false),
                    CoberturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Pacientes_Coberturas_CoberturaId",
                        column: x => x.CoberturaId,
                        principalTable: "Coberturas",
                        principalColumn: "CoberturaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_ObrasSociales_ObraSocialId",
                        column: x => x.ObraSocialId,
                        principalTable: "ObrasSociales",
                        principalColumn: "ObraSocialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    RecetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paciente = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    CoberturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.RecetaId);
                    table.ForeignKey(
                        name: "FK_Recetas_Coberturas_CoberturaId",
                        column: x => x.CoberturaId,
                        principalTable: "Coberturas",
                        principalColumn: "CoberturaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recetas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReglasCantidad",
                columns: table => new
                {
                    ReglaCantidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraSocialId = table.Column<int>(type: "int", nullable: false),
                    CoberturaId = table.Column<int>(type: "int", nullable: true),
                    Minimo = table.Column<int>(type: "int", nullable: true),
                    Maximo = table.Column<int>(type: "int", nullable: true),
                    EdadMinima = table.Column<int>(type: "int", nullable: true),
                    EdadMaxima = table.Column<int>(type: "int", nullable: true),
                    Frecuencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TopeMonetario = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReglasCantidad", x => x.ReglaCantidadId);
                    table.ForeignKey(
                        name: "FK_ReglasCantidad_Coberturas_CoberturaId",
                        column: x => x.CoberturaId,
                        principalTable: "Coberturas",
                        principalColumn: "CoberturaId");
                    table.ForeignKey(
                        name: "FK_ReglasCantidad_ObrasSociales_ObraSocialId",
                        column: x => x.ObraSocialId,
                        principalTable: "ObrasSociales",
                        principalColumn: "ObraSocialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecetaMedicamentos",
                columns: table => new
                {
                    RecetaMedicamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecetaId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaMedicamentos", x => x.RecetaMedicamentoId);
                    table.ForeignKey(
                        name: "FK_RecetaMedicamentos_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "MedicamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaMedicamentos_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "RecetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medicamentos",
                columns: new[] { "MedicamentoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Paracetamol 500mg" },
                    { 2, "Ibuprofeno 400mg" },
                    { 3, "Amoxicilina 500mg" },
                    { 4, "Azitromicina 500mg" },
                    { 5, "Omeprazol 20mg" },
                    { 6, "Losartán 50mg" },
                    { 7, "Atorvastatina 20mg" },
                    { 8, "Metformina 850mg" },
                    { 9, "Levotiroxina 50mcg" },
                    { 10, "Salbutamol Inhalador" },
                    { 11, "Amiodarona 200mg" },
                    { 12, "Clonazepam 0.5mg" },
                    { 13, "Sertralina 50mg" },
                    { 14, "Cetirizina 10mg" },
                    { 15, "Loratadina 10mg" },
                    { 16, "Diclofenac 75mg" },
                    { 17, "Ranitidina 150mg" },
                    { 18, "Fluconazol 150mg" },
                    { 19, "Enalapril 10mg" },
                    { 20, "Carvedilol 25mg" }
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "MedicoId", "Apellido", "Matricula", "Nombre" },
                values: new object[,]
                {
                    { 1, "Gonzalez", "MP12345", "Ricardo" },
                    { 2, "Martinez", "MP54321", "Lucia" },
                    { 3, "Lopez", "MP98765", "Juan" }
                });

            migrationBuilder.InsertData(
                table: "ObrasSociales",
                columns: new[] { "ObraSocialId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Omint" },
                    { 2, "Osde" },
                    { 3, "Swiss Medical" }
                });

            migrationBuilder.InsertData(
                table: "Coberturas",
                columns: new[] { "CoberturaId", "Nombre", "ObraSocialId" },
                values: new object[,]
                {
                    { 1, "Omint2000", 1 },
                    { 2, "Omint2000K", 1 },
                    { 3, "Omint2500K", 1 },
                    { 4, "Smg30", 3 },
                    { 5, "Smg50", 3 },
                    { 6, "SmgPlatinum", 3 },
                    { 7, "Osde210", 2 },
                    { 8, "Osde310", 2 },
                    { 9, "Osde450", 2 }
                });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "PacienteId", "Apellido", "CoberturaId", "Direccion", "Dni", "FechaNacimiento", "Nombre", "ObraSocialId", "Telefono" },
                values: new object[,]
                {
                    { 1, "Perez", 1, "Calle Falsa 123", "12345678", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", 1, "3764000000" },
                    { 2, "Gomez", 7, "Avenida Siempre Viva 742", "23456789", new DateTime(1985, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", 2, "3764111111" },
                    { 4, "Fernandez", 4, "Boulevard Mitre 321", "45678901", new DateTime(2005, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", 3, "3764333333" },
                    { 5, "Martinez", 5, "Los Pinos 789", "56789012", new DateTime(1950, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego", 3, "3764444444" },
                    { 6, "Diaz", 2, "Ruta Nacional 12 Km 20", "67890123", new DateTime(1999, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofia", 1, "3764555555" },
                    { 7, "Silva", 6, "Barrio Centro Manzana 10", "78901234", new DateTime(2010, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucas", 3, "3764666666" }
                });

            migrationBuilder.InsertData(
                table: "ReglasCantidad",
                columns: new[] { "ReglaCantidadId", "CoberturaId", "EdadMaxima", "EdadMinima", "Frecuencia", "Maximo", "Minimo", "ObraSocialId", "TopeMonetario" },
                values: new object[,]
                {
                    { 1, 1, 0, 50, "Indefinido", 5, 0, 1, 0m },
                    { 2, 1, 49, 0, "Indefinido", 3, 0, 1, 0m },
                    { 3, 2, 0, 0, "Indefinido", 3, 0, 1, 0m },
                    { 4, 4, 0, 18, "Indefinido", 2, 0, 3, 0m },
                    { 5, 5, 0, 50, "Indefinido", 5, 0, 3, 0m },
                    { 6, 5, 49, 0, "Indefinido", 3, 0, 3, 0m },
                    { 7, 6, 0, 0, "Indefinido", 0, 0, 3, 40000m },
                    { 8, 7, 0, 0, "Anual", 8, 0, 2, 0m },
                    { 9, 8, 0, 0, "Mensual", 2, 0, 2, 0m },
                    { 10, 9, 0, 0, "Anual", 30, 0, 2, 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coberturas_ObraSocialId",
                table: "Coberturas",
                column: "ObraSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CoberturaId",
                table: "Pacientes",
                column: "CoberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ObraSocialId",
                table: "Pacientes",
                column: "ObraSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaMedicamentos_MedicamentoId",
                table: "RecetaMedicamentos",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaMedicamentos_RecetaId",
                table: "RecetaMedicamentos",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_CoberturaId",
                table: "Recetas",
                column: "CoberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_MedicoId",
                table: "Recetas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReglasCantidad_CoberturaId",
                table: "ReglasCantidad",
                column: "CoberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReglasCantidad_ObraSocialId",
                table: "ReglasCantidad",
                column: "ObraSocialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "RecetaMedicamentos");

            migrationBuilder.DropTable(
                name: "ReglasCantidad");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Coberturas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "ObrasSociales");
        }
    }
}
