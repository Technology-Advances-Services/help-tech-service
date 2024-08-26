using Microsoft.EntityFrameworkCore;
using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Model.Entities;
using HelpTechService.Location.Domain.Model.Aggregates;
using HelpTechService.Report.Domain.Model.Aggregates;
using HelpTechService.Report.Domain.Model.Entities;
using HelpTechService.Subscription.Domain.Model.Aggregates;

namespace HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public partial class HelpTechContext : DbContext
    {
        public HelpTechContext() { }

        public HelpTechContext
            (DbContextOptions<HelpTechContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_agendas_id");

                entity.ToTable("agendas");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");
                entity.Property(e => e.TechnicalsId).HasColumnName("technicals_id");

                entity.HasOne(d => d.Technical).WithMany(p => p.Agendas)
                    .HasForeignKey(d => d.TechnicalsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_agendas_technicals_id");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_chat_id");

                entity.ToTable("chats");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ChatsRoomsId).HasColumnName("chats_rooms_id");
                entity.Property(e => e.ConsumersId).HasColumnName("consumers_id");
                entity.Property(e => e.Message)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("message");
                entity.Property(e => e.ShippingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("shipping_date");
                entity.Property(e => e.TechnicalsId).HasColumnName("technicals_id");

                entity.HasOne(d => d.ChatRoom).WithMany(p => p.Chats)
                    .HasForeignKey(d => d.ChatsRoomsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chats_chats_rooms_id");

                entity.HasOne(d => d.Consumer).WithMany(p => p.Chats)
                    .HasForeignKey(d => d.ConsumersId)
                    .HasConstraintName("fk_chats_consumers_id");

                entity.HasOne(d => d.Technical).WithMany(p => p.Chats)
                    .HasForeignKey(d => d.TechnicalsId)
                    .HasConstraintName("fk_chats_technicals_id");
            });

            modelBuilder.Entity<ChatMember>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("chats_members");

                entity.Property(e => e.ChatsRoomsId).HasColumnName("chats_rooms_id");
                entity.Property(e => e.ConsumersId).HasColumnName("consumers_id");
                entity.Property(e => e.TechnicalsId).HasColumnName("technicals_id");

                entity.HasOne(d => d.ChatRoom).WithMany()
                    .HasForeignKey(d => d.ChatsRoomsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chats_members_chats_rooms_id");

                entity.HasOne(d => d.Consumer).WithMany()
                    .HasForeignKey(d => d.ConsumersId)
                    .HasConstraintName("fk_chats_members_consumers_id");

                entity.HasOne(d => d.Technical).WithMany()
                    .HasForeignKey(d => d.TechnicalsId)
                    .HasConstraintName("fk_chats_members_technicals_id");
            });

            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_chat_room_id");

                entity.ToTable("chats_rooms");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_complaint_id");

                entity.ToTable("complaints", tb =>
                {
                    tb.HasTrigger("tg_update_consumer_state");
                    tb.HasTrigger("tg_update_technical_state");
                });

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");
                entity.Property(e => e.JobsId).HasColumnName("jobs_id");
                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");
                entity.Property(e => e.Sender)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sender");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
                entity.Property(e => e.TypesComplaintsId).HasColumnName("types_complaints_id");

                entity.HasOne(d => d.Job).WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.JobsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_complaints_jobs_id");

                entity.HasOne(d => d.TypeComplaint).WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.TypesComplaintsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_complaints_types_complaints_id");
            });

            modelBuilder.Entity<Consumer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_consumer_id");

                entity.ToTable("consumers");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.DistrictsId).HasColumnName("districts_id");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");
                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("genre");
                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.ProfileUrl)
                    .IsUnicode(false)
                    .HasColumnName("profile_url");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.HasOne(d => d.District).WithMany(p => p.Consumers)
                    .HasForeignKey(d => d.DistrictsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_consumers_districts_id");
            });

            modelBuilder.Entity<ConsumerCredential>(entity =>
            {
                entity.HasKey(e => e.ConsumersId).HasName("pk_consumer_credential_consumers_id");

                entity.ToTable("consumers_credentials");

                entity.Property(e => e.ConsumersId)
                    .ValueGeneratedNever()
                    .HasColumnName("consumers_id");
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.HasOne(d => d.Consumer).WithOne(p => p.ConsumerCredential)
                    .HasForeignKey<ConsumerCredential>(d => d.ConsumersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_consumers_credentials_consumers_id");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_contract_id");

                entity.ToTable("contracts");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ConsumersId).HasColumnName("consumers_id");
                entity.Property(e => e.FinalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("final_date");
                entity.Property(e => e.MembershipsId).HasColumnName("memberships_id");
                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
                entity.Property(e => e.TechnicalsId).HasColumnName("technicals_id");

                entity.HasOne(d => d.Consumer).WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ConsumersId)
                    .HasConstraintName("fk_contracts_consumers_id");

                entity.HasOne(d => d.Membership).WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.MembershipsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_contracts_memberships_id");

                entity.HasOne(d => d.Technical).WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.TechnicalsId)
                    .HasConstraintName("fk_contracts_technicals_id");
            });

            modelBuilder.Entity<CriminalRecord>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_criminal_record_id");

                entity.ToTable("criminals_records");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FileUrl)
                    .IsUnicode(false)
                    .HasColumnName("file_url");
                entity.Property(e => e.TechnicalsId).HasColumnName("technicals_id");

                entity.HasOne(d => d.Technical).WithMany(p => p.CriminalsRecords)
                    .HasForeignKey(d => d.TechnicalsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_criminals_records_technicals_id");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_department_id");

                entity.ToTable("departments");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_district_id");

                entity.ToTable("districts");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DepartmentsId).HasColumnName("departments_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Department).WithMany(p => p.Districts)
                    .HasForeignKey(d => d.DepartmentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_districts_departments_id");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_job_id");

                entity.ToTable("jobs", tb => tb.HasTrigger("tg_register_data_chats_rooms"));

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");
                entity.Property(e => e.AgendasId).HasColumnName("agendas_id");
                entity.Property(e => e.AmountFinal).HasColumnName("amount_final");
                entity.Property(e => e.AnswerDate)
                    .HasColumnType("datetime")
                    .HasColumnName("answer_date");
                entity.Property(e => e.ConsumersId).HasColumnName("consumers_id");
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");
                entity.Property(e => e.LaborBudget).HasColumnName("labor_budget");
                entity.Property(e => e.MaterialBudget).HasColumnName("material_budget");
                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
                entity.Property(e => e.Time)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("time");
                entity.Property(e => e.WorkDate)
                    .HasColumnType("datetime")
                    .HasColumnName("work_date");

                entity.HasOne(d => d.Agenda).WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.AgendasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jobs_agendas_id");

                entity.HasOne(d => d.Consumer).WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.ConsumersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jobs_consumers_id");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_membership_id");

                entity.ToTable("memberships");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Policies)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("policies");
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_review_id");

                entity.ToTable("reviews");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ConsumersId).HasColumnName("consumers_id");
                entity.Property(e => e.Opinion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("opinion");
                entity.Property(e => e.Score).HasColumnName("score");
                entity.Property(e => e.ShippingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("shipping_date");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
                entity.Property(e => e.TechnicalsId).HasColumnName("technicals_id");

                entity.HasOne(d => d.Consumer).WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ConsumersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reviews_consumers_id");

                entity.HasOne(d => d.Technical).WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.TechnicalsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reviews_technicals_id");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_specialty_id");

                entity.ToTable("specialties");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Technical>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_technical_id");

                entity.ToTable("technicals", tb => tb.HasTrigger("tg_register_data_agendas"));

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.Availability)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("availability");
                entity.Property(e => e.DistrictsId).HasColumnName("districts_id");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");
                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("genre");
                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.ProfileUrl)
                    .IsUnicode(false)
                    .HasColumnName("profile_url");
                entity.Property(e => e.SpecialtiesId).HasColumnName("specialties_id");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.HasOne(d => d.District).WithMany(p => p.Technicals)
                    .HasForeignKey(d => d.DistrictsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_technicals_districts_id");

                entity.HasOne(d => d.Specialty).WithMany(p => p.Technicals)
                    .HasForeignKey(d => d.SpecialtiesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_technicals_specialties_id");
            });

            modelBuilder.Entity<TechnicalCredential>(entity =>
            {
                entity.HasKey(e => e.TechnicalsId).HasName("pk_technical_credential_technicals_id");

                entity.ToTable("technicals_credentials");

                entity.Property(e => e.TechnicalsId)
                    .ValueGeneratedNever()
                    .HasColumnName("technicals_id");
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.HasOne(d => d.Technical).WithOne(p => p.TechnicalCredential)
                    .HasForeignKey<TechnicalCredential>(d => d.TechnicalsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_technicals_credentials_technicals_id");
            });

            modelBuilder.Entity<TypeComplaint>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_type_complaint_id");

                entity.ToTable("types_complaints");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}