using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Ventas
{
    public class PersonaMap : IEntityTypeConfiguration<Entidades.Ventas.Persona>
    {
        public void Configure(EntityTypeBuilder<Entidades.Ventas.Persona> builder)
        {
            builder.ToTable("persona").HasKey(p => p.idpersona);
        }

    }
}
