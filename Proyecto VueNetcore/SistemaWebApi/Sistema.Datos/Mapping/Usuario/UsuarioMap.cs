using Sistema.Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema.Datos.Mapping.Usuario
{
    public class UsuarioMap : IEntityTypeConfiguration<Entidades.Usuarios.Usuario>
    {
        public void Configure(EntityTypeBuilder<Entidades.Usuarios.Usuario> builder)
        {
            builder.ToTable("usuario").HasKey(u => u.idusuario);  
        }
    }
}
