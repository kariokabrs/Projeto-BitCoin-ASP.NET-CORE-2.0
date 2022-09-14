using CbWebApp.Domains;
using Microsoft.EntityFrameworkCore;

namespace CbWebApp.Context
{
    /// <summary>
    /// Contexto da Conexão com o banco da Consultoria Bitcoin
    /// </summary>
    public partial class DB_A40F70_cbContext : DbContext
    {
        public DB_A40F70_cbContext(DbContextOptions<DB_A40F70_cbContext> options) : base(options) { }

        #region DBSet
        public virtual DbSet<BancoUsuario> BancoUsuario { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<ContratoParcela> ContratoParcela { get; set; }
        public virtual DbSet<ContratoResponsavel> ContratoResponsavel { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<FilialUsuario> FilialUsuario { get; set; }
        public virtual DbSet<Lembrete> Lembrete { get; set; }
        public virtual DbSet<LembreteEnvolvido> LembreteEnvolvido { get; set; }
        public virtual DbSet<Propriedade> Propriedade { get; set; }
        public virtual DbSet<PropriedadeDominio> PropriedadeDominio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<BancoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdBancoUsuario);

                entity.ToTable("Banco_Usuario");

                entity.Property(e => e.IdBancoUsuario).HasColumnName("id_Banco_Usuario");

                entity.Property(e => e.IdPdBanco).HasColumnName("id_PD_Banco");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.NuAgencia)
                    .IsRequired()
                    .HasColumnName("nu_Agencia")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NuAgenciaDigito)
                    .HasColumnName("nu_Agencia_Digito")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NuConta)
                    .IsRequired()
                    .HasColumnName("nu_Conta")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NuContaDigito)
                    .HasColumnName("nu_Conta_Digito")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPdBancoNavigation)
                    .WithMany(p => p.BancoUsuario)
                    .HasForeignKey(d => d.IdPdBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Banco_Usuario_Propriedade_Dominio");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.BancoUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Banco_Usuario_Usuarios");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato);

                entity.Property(e => e.IdContrato).HasColumnName("id_Contrato");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_Cadastro")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtEmissao)
                    .HasColumnName("dt_Emissao")
                    .HasColumnType("date");

                entity.Property(e => e.DtRetorno)
                    .HasColumnName("dt_Retorno")
                    .HasColumnType("date");

                entity.Property(e => e.FlAtivo)
                    .HasColumnName("fl_Ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdCliente).HasColumnName("id_Cliente");

                entity.Property(e => e.NmRespCadastro)
                    .HasColumnName("nm_Resp_Cadastro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NuContrato)
                    .HasColumnName("nu_Contrato")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.NuParcela).HasColumnName("nu_Parcela");

                entity.Property(e => e.NuRendimento)
                    .IsRequired()
                    .HasColumnName("nu_Rendimento")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VlContrato)
                    .HasColumnName("vl_Contrato")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<ContratoParcela>(entity =>
            {
                entity.HasKey(e => e.IdContratoParcela);

                entity.ToTable("Contrato_Parcela");

                entity.Property(e => e.IdContratoParcela).HasColumnName("id_Contrato_Parcela");

                entity.Property(e => e.DtPagamento)
                    .HasColumnName("dt_Pagamento")
                    .HasColumnType("date");

                entity.Property(e => e.FlReaplicar).HasColumnName("fl_Reaplicar");

                entity.Property(e => e.IdContrato).HasColumnName("id_Contrato");

                entity.Property(e => e.NuParcela).HasColumnName("nu_Parcela");

                entity.Property(e => e.VlComissao)
                    .HasColumnName("vl_Comissao")
                    .HasColumnType("money");

                entity.Property(e => e.VlRendimento)
                    .HasColumnName("vl_Rendimento")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.ContratoParcela)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrato_Parcela_Contrato");
            });

            modelBuilder.Entity<ContratoResponsavel>(entity =>
            {
                entity.HasKey(e => e.IdContratoResponsavel);

                entity.ToTable("Contrato_Responsavel");

                entity.Property(e => e.IdContratoResponsavel).HasColumnName("id_Contrato_Responsavel");

                entity.Property(e => e.IdContrato).HasColumnName("id_Contrato");

                entity.Property(e => e.IdPdFilial).HasColumnName("id_PD_Filial");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.NuComissao)
                    .IsRequired()
                    .HasColumnName("nu_Comissao")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.ContratoResponsavel)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrato_Responsavel_Contrato");

                entity.HasOne(d => d.IdPdFilialNavigation)
                    .WithMany(p => p.ContratoResponsavel)
                    .HasForeignKey(d => d.IdPdFilial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrato_Responsavel_Propriedade_Dominio");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ContratoResponsavel)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contrato_Responsavel_Usuario");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.Property(e => e.IdDocumento).HasColumnName("id_Documento");

                entity.Property(e => e.DsDocumento)
                    .IsRequired()
                    .HasColumnName("ds_Documento")
                    .IsUnicode(false);

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_Cadastro")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdOrigem).HasColumnName("id_Origem");

                entity.Property(e => e.IdPdTipoDocumento).HasColumnName("id_PD_Tipo_Documento");

                entity.Property(e => e.NmDocumento)
                    .IsRequired()
                    .HasColumnName("nm_Documento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmExtensao)
                    .IsRequired()
                    .HasColumnName("nm_Extensao")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.NmOrigem)
                    .IsRequired()
                    .HasColumnName("nm_Origem")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmRespCadastro)
                    .HasColumnName("nm_Resp_Cadastro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NuTamanho)
                    .HasColumnName("nu_Tamanho")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPdTipoDocumentoNavigation)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.IdPdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documento_Propriedade_Dominio");
            });

            modelBuilder.Entity<FilialUsuario>(entity =>
            {
                entity.HasKey(e => e.IdFilialUsuario);

                entity.ToTable("Filial_Usuario");

                entity.Property(e => e.IdFilialUsuario).HasColumnName("id_Filial_Usuario");

                entity.Property(e => e.IdPdFilial).HasColumnName("id_PD_Filial");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.HasOne(d => d.IdPdFilialNavigation)
                    .WithMany(p => p.FilialUsuario)
                    .HasForeignKey(d => d.IdPdFilial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Filial_Usuario_Propriedade_Dominio");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.FilialUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Filial_Usuario_Usuarios");
            });

            modelBuilder.Entity<Lembrete>(entity =>
            {
                entity.HasKey(e => e.IdLembrete);

                entity.Property(e => e.IdLembrete).HasColumnName("id_Lembrete");

                entity.Property(e => e.DsLembrete)
                    .IsRequired()
                    .HasColumnName("ds_Lembrete")
                    .IsUnicode(false);

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_Cadastro")
                    .HasColumnType("date");

                entity.Property(e => e.DtLembrete)
                    .HasColumnName("dt_Lembrete")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("id_Cliente");

                entity.Property(e => e.IdRespCadastro).HasColumnName("id_Resp_Cadastro");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.LembreteIdClienteNavigation)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Lembrete_Usuarios1");

                entity.HasOne(d => d.IdRespCadastroNavigation)
                    .WithMany(p => p.LembreteIdRespCadastroNavigation)
                    .HasForeignKey(d => d.IdRespCadastro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lembrete_Usuarios");
            });

            modelBuilder.Entity<LembreteEnvolvido>(entity =>
            {
                entity.HasKey(e => e.IdLembreteEnvolvido);

                entity.ToTable("Lembrete_Envolvido");

                entity.Property(e => e.IdLembreteEnvolvido).HasColumnName("id_Lembrete_Envolvido");

                entity.Property(e => e.IdLembrete).HasColumnName("id_Lembrete");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.HasOne(d => d.IdLembreteNavigation)
                    .WithMany(p => p.LembreteEnvolvido)
                    .HasForeignKey(d => d.IdLembrete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lembrete_Envolvido_Lembrete");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.LembreteEnvolvido)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lembrete_Envolvido_Usuarios");
            });

            modelBuilder.Entity<Propriedade>(entity =>
            {
                entity.HasKey(e => e.IdPropriedade);

                entity.Property(e => e.IdPropriedade).HasColumnName("id_Propriedade");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_Cadastro")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlAtivo)
                    .HasColumnName("fl_Ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FlEditavel)
                    .HasColumnName("fl_Editavel")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NmPropriedade)
                    .IsRequired()
                    .HasColumnName("nm_Propriedade")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PropriedadeDominio>(entity =>
            {
                entity.HasKey(e => e.IdPropriedadeDominio);

                entity.ToTable("Propriedade_Dominio");

                entity.Property(e => e.IdPropriedadeDominio).HasColumnName("id_Propriedade_Dominio");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_Cadastro")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlAtivo)
                    .HasColumnName("fl_Ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdPropriedade).HasColumnName("id_Propriedade");

                entity.Property(e => e.NmPropriedadeDominio)
                    .IsRequired()
                    .HasColumnName("nm_Propriedade_Dominio")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmRespCadastro)
                    .IsRequired()
                    .HasColumnName("nm_Resp_Cadastro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPropriedadeNavigation)
                    .WithMany(p => p.PropriedadeDominio)
                    .HasForeignKey(d => d.IdPropriedade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Propriedade_Dominio_Propriedade");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_Cadastro")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtNascimento)
                    .HasColumnName("dt_Nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.FlAlerta).HasColumnName("fl_Alerta");

                entity.Property(e => e.FlAtivo)
                    .HasColumnName("fl_Ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdPdTipoUsuario).HasColumnName("id_PD_Tipo_Usuario");

                entity.Property(e => e.NmBairro)
                    .HasColumnName("nm_Bairro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmLogradouro)
                    .HasColumnName("nm_Logradouro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmMunicipio)
                    .HasColumnName("nm_Municipio")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmOrgaoRg)
                    .HasColumnName("nm_Orgao_RG")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NmProfissao)
                    .HasColumnName("nm_Profissao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmRespCadastro)
                    .HasColumnName("nm_Resp_Cadastro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NmUf)
                    .HasColumnName("nm_UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NmUsuario)
                    .IsRequired()
                    .HasColumnName("nm_Usuario")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NuCep)
                    .HasColumnName("nu_CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NuCpfCnpj)
                    .HasColumnName("nu_CPF_CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.NuLogradouro)
                    .HasColumnName("nu_Logradouro")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NuLogradouroComp)
                    .HasColumnName("nu_Logradouro_Comp")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NuRg)
                    .HasColumnName("nu_RG")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NuTelCelular)
                    .HasColumnName("nu_Tel_Celular")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.NuTelFixo)
                    .HasColumnName("nu_Tel_Fixo")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Propriedade_Dominio");
            });
        }
    }
}
