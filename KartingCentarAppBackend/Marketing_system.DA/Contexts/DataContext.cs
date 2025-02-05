using System.Data;
using System.Security;
using Marketing_system.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;

namespace Marketing_system.DA.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Vozilo> vozilo { get; set; }
        public DbSet<CartService> servis { get; set; }
        public DbSet<Member> clan { get; set; }
        public DbSet<Category> kategorija {  get; set; }
        public DbSet<Debt> dugovanje { get; set; }
        public DbSet<Appointment> termin { get; set; }
        public DbSet<Reservation> rezervacija { get; set; }
        public DbSet<Client> klijent { get; set; }
        public DbSet<Voucher> vaucer { get; set; }
        public DbSet<PriceListItem> stavke_cenovnika { get; set; }
        public DbSet<Employee> zaposleni { get; set; }
        public DbSet<Training> trening { get; set; }
        public DbSet<FinancialTransaction> finansijska_transakcija { get; set; }
        public DbSet<Part> delovi { get; set; }
        public DbSet<PartItem> stavka_deo { get; set; }
        public DbSet<PartRequest> zahtev_za_nabavku { get; set; }
        public DbSet<Competition> takmicenje { get; set; }
        public DbSet<Success> uspeh { get; set; }
        public DbSet<Participate> ucestvuje { get; set; }
        public DbSet<Sponsor> sponzor { get; set; }
        public DbSet<Fund> sredstva { get; set; }
        public DbSet<TransactionMembership> finansijska_transakcija_clanarina { get; set; }
        public DbSet<TransactionFund> finansijska_transakcija_donacija { get; set; }
        public DbSet<TransactionRequest> finansijska_transakcija_zahtev { get; set; }
        public DbSet<TransactionReservation> finansijska_transakcija_rezervacija { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vozilo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("vozilo_id");
                entity.Property(e => e.Marka).HasColumnName("marka").IsRequired();  
                entity.Property(e => e.Model).HasColumnName("model").IsRequired();
                entity.Property(e => e.Kubikaza).HasColumnName("kubikaza").IsRequired();
                entity.Property(e => e.Upotrebljivo).HasColumnName("upotrebljivo").IsRequired();
                entity.Property(e => e.BrojVozila).HasColumnName("broj").IsRequired();
            });
            modelBuilder.Entity<CartService>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("servis_id");
                entity.Property(e => e.Date).HasColumnName("datum_servisa").IsRequired();
                entity.Property(e => e.Description).HasColumnName("opis_servisa").IsRequired();
                entity.Property(e => e.Vehicle_id).HasColumnName("vozilo_vozilo_id").IsRequired();
            });
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("clan_id");
                entity.Property(e => e.Name).HasColumnName("ime_cl").IsRequired();
                entity.Property(e => e.Surname).HasColumnName("prez_cl").IsRequired();
                entity.Property(e => e.Email).HasColumnName("email_cl").IsRequired();
                entity.Property(e => e.Phone).HasColumnName("tel_cl");
                entity.Property(e => e.Password).HasColumnName("lozinka_cl").IsRequired();
                entity.Property(e => e.City).HasColumnName("grad_st_cl").IsRequired();
                entity.Property(e => e.Street).HasColumnName("ulica_st_cl").IsRequired();
                entity.Property(e => e.StreetNumber).HasColumnName("br_ulice_cl").IsRequired();
                entity.Property(e => e.Birthday).HasColumnName("dat_rodj_cl").IsRequired();
                entity.Property(e => e.Status).HasColumnName("status_cl");
                entity.Property(e => e.Category_id).HasColumnName("kategorija_kat_id").IsRequired();
                entity.Property(e => e.MemberCard).HasColumnName("kartica_cl").IsRequired();
                entity.Property(e => e.Instruktor_id).HasColumnName("instruktor_zap_id").IsRequired();
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("kat_id");
                entity.Property(e => e.Name).HasColumnName("naziv_kat").IsRequired();
                entity.Property(e => e.Price).HasColumnName("iznos_cl").IsRequired();
            });
            modelBuilder.Entity<Member>()
                .HasOne(c => c.Category)
                .WithMany(a => a.Members)
                .HasForeignKey(c => c.Category_id);
            modelBuilder.Entity<Debt>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("dug_id");
                entity.Property(e => e.Amount).HasColumnName("iznos_duga").IsRequired();
                entity.Property(e => e.Description).HasColumnName("opis_duga").IsRequired();
                entity.Property(e => e.Member_id).HasColumnName("clan_clan_id").IsRequired();
                entity.Property(e => e.IsPaid).HasColumnName("placen").IsRequired();
            });
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("termin_id");
                entity.Property(e => e.StartTime).HasColumnName("dat_vreme_poc").IsRequired();
                entity.Property(e => e.EndTime).HasColumnName("dat_vreme_kraj").IsRequired();
                entity.Property(e => e.Track_id).HasColumnName("staza_staza_id").IsRequired();
            });
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("rez_id");
                entity.Property(e => e.NumberOfPeople).HasColumnName("br_ljudi").IsRequired();
                entity.Property(e => e.Client_id).HasColumnName("klijent_klijent_id").IsRequired();
                entity.Property(e => e.Appointment_id).HasColumnName("termin_termin_id").IsRequired();
                entity.Property(e => e.Name).HasColumnName("ime_rez").IsRequired();
                entity.Property(e => e.Surname).HasColumnName("prez_rez").IsRequired();
                entity.Property(e => e.Phone).HasColumnName("tel_rez").IsRequired();
                entity.Property(e => e.IsPaid).HasColumnName("placeno").IsRequired();
            });
            modelBuilder.Entity<Reservation>()
                .HasOne(t => t.Appointment)
                .WithOne(a => a.Reservation)
                .HasForeignKey<Reservation>(t => t.Appointment_id);
            modelBuilder.Entity<Reservation>()
                .HasOne(c => c.Client)
                .WithMany(a => a.Reservations)
                .HasForeignKey(c => c.Client_id);
            modelBuilder.Entity<PartItem>()
                .HasOne(c => c.CartService)
                .WithMany(a => a.PartItems)
                .HasForeignKey(c => c.CartService_id);
            modelBuilder.Entity<PartItem>()
                .HasOne(c => c.Part)
                .WithMany(a => a.PartItems)
                .HasForeignKey(c => c.Part_id);
            modelBuilder.Entity<PartRequest>()
                .HasOne(c => c.Part)
                .WithOne(a => a.PartRequest)
                .HasForeignKey<PartRequest>(c => c.Part_id);
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("klijent_id");
                entity.Property(e => e.Name).HasColumnName("ime_kor").IsRequired();
                entity.Property(e => e.Surname).HasColumnName("prez_kor").IsRequired();
                entity.Property(e => e.Email).HasColumnName("email_kor").IsRequired();
                entity.Property(e => e.Phone).HasColumnName("tel_kor");
                entity.Property(e => e.Password).HasColumnName("lozinka_kor").IsRequired();
                entity.Property(e => e.City).HasColumnName("grad_st_kor").IsRequired();
                entity.Property(e => e.Street).HasColumnName("ulica_st_kor").IsRequired();
                entity.Property(e => e.StreetNumber).HasColumnName("br_ul_kor").IsRequired();
                entity.Property(e => e.Status).HasColumnName("status_kor");
                entity.Property(e => e.NumberOfReservations).HasColumnName("br_rez").IsRequired();
                entity.Property(e => e.PenaltyPoints).HasColumnName("kazneni_poeni").IsRequired();
            });
            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("vaucer_id");
                entity.Property(e => e.ExpirationDate).HasColumnName("datum_isteka").IsRequired();
                entity.Property(e => e.Client_id).HasColumnName("klijent_klijent_id").IsRequired();
                entity.Property(e => e.Discount).HasColumnName("popust").IsRequired();
            });
            modelBuilder.Entity<PriceListItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("stavka_id");
                entity.Property(e => e.Name).HasColumnName("naziv_st").IsRequired();
                entity.Property(e => e.Amount).HasColumnName("iznos").IsRequired();
            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("zap_id");
                entity.Property(e => e.Name).HasColumnName("ime_zap").IsRequired();
                entity.Property(e => e.Surname).HasColumnName("prez_zap").IsRequired();
                entity.Property(e => e.Email).HasColumnName("email_zap").IsRequired();
                entity.Property(e => e.Phone).HasColumnName("tel_zap");
                entity.Property(e => e.Password).HasColumnName("lozinka_zap").IsRequired();
                entity.Property(e => e.City).HasColumnName("grad_st").IsRequired();
                entity.Property(e => e.Street).HasColumnName("ulica_st").IsRequired();
                entity.Property(e => e.StreetNumber).HasColumnName("ulicni_br").IsRequired();
                entity.Property(e => e.Birthday).HasColumnName("dat_rodj").IsRequired();
                entity.Property(e => e.EmploymentDate).HasColumnName("dat_zap").IsRequired();
                entity.Property(e => e.Status).HasColumnName("status_zap");
                entity.Property(e => e.Type).HasColumnName("tip_zap").IsRequired();
            });
            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("trening_id");
                entity.Property(e => e.Type).HasColumnName("tip_tr").IsRequired();
                entity.Property(e => e.Appointment_id).HasColumnName("termin_termin_id").IsRequired();
            });
            modelBuilder.Entity<Training>()
                .HasOne(t => t.Appointment)
                .WithOne(a => a.Training)
                .HasForeignKey<Training>(t => t.Appointment_id);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Trainings)
                .WithMany(i => i.Instruktors)
                .UsingEntity<Dictionary<string, object>>(
                    "organizuje",
                    j => j.HasOne<Training>().WithMany().HasForeignKey("trening_trening_id").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Employee>().WithMany().HasForeignKey("instruktor_zap_id").OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("instruktor_zap_id", "trening_trening_id");
                        j.ToTable("organizuje");
                    });
            modelBuilder.Entity<Member>()
                .HasMany(e => e.Trainings)
                .WithMany(i => i.Members)
                .UsingEntity<Dictionary<string, object>>(
                    "posecuje",
                    j => j.HasOne<Training>().WithMany().HasForeignKey("trening_trening_id").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Member>().WithMany().HasForeignKey("clan_clan_id").OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("clan_clan_id", "trening_trening_id");
                        j.ToTable("posecuje");
                    });
            modelBuilder.Entity<Employee>()
               .HasMany(e => e.Services)
               .WithMany(i => i.Servicers)
               .UsingEntity<Dictionary<string, object>>(
                   "vrsi",
                   j => j.HasOne<CartService>().WithMany().HasForeignKey("servis_servis_id").OnDelete(DeleteBehavior.Cascade),
                   j => j.HasOne<Employee>().WithMany().HasForeignKey("serviser_zap_id").OnDelete(DeleteBehavior.Cascade),
                   j =>
                   {
                       j.HasKey("serviser_zap_id", "servis_servis_id");
                       j.ToTable("vrsi");
                   });
            modelBuilder.Entity<FinancialTransaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("trans_id");
                entity.Property(e => e.Amount).HasColumnName("iznos_trans").IsRequired();
                entity.Property(e => e.Date).HasColumnName("dat_trans").IsRequired();
                entity.Property(e => e.Description).HasColumnName("opis_trans").IsRequired();
                entity.Property(e => e.Type).HasColumnName("vrsta_trans").IsRequired();
            });
            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("deo_id");
                entity.Property(e => e.Name).HasColumnName("naziv_dela").IsRequired();
                entity.Property(e => e.Producer).HasColumnName("proizvodjac").IsRequired();
                entity.Property(e => e.Total).HasColumnName("uk_kolicina").IsRequired();
            });
            modelBuilder.Entity<PartItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("stavka_id");
                entity.Property(e => e.Quantity).HasColumnName("kol_deo").IsRequired();
                entity.Property(e => e.CartService_id).HasColumnName("servis_servis_id").IsRequired();
                entity.Property(e => e.Part_id).HasColumnName("delovi_deo_id").IsRequired();
            });
            modelBuilder.Entity<PartRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("zahtev_id");
                entity.Property(e => e.Quantity).HasColumnName("kolicina").IsRequired();
                entity.Property(e => e.Part_id).HasColumnName("delovi_deo_id").IsRequired();
                entity.Property(e => e.Name).HasColumnName("naziv_dela").IsRequired();
                entity.Property(e => e.Producer).HasColumnName("proizvodjac").IsRequired();
                entity.Property(e => e.Date).HasColumnName("datum").IsRequired();
                entity.Property(e => e.Status).HasColumnName("status_zahteva").IsRequired();
            });
            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("tak_id");
                entity.Property(e => e.Name).HasColumnName("naz_tak").IsRequired();
                entity.Property(e => e.DateAndTime).HasColumnName("dat_tak").IsRequired();
                entity.Property(e => e.Description).HasColumnName("opis_tak").IsRequired();
            });
            modelBuilder.Entity<Success>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("uspeh_id");
                entity.Property(e => e.Place).HasColumnName("osv_mesto").IsRequired();
                entity.Property(e => e.Time).HasColumnName("vreme").IsRequired();
                entity.Property(e => e.Compete_id).HasColumnName("ucestvuje_ucestvuje_id").IsRequired();
            });
            modelBuilder.Entity<Participate>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ucestvuje_id");
                entity.Property(e => e.Member_id).HasColumnName("clan_clan_id").IsRequired();
                entity.Property(e => e.Competition_id).HasColumnName("takmicenje_tak_id").IsRequired();
            });
            modelBuilder.Entity<Fund>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("sred_id");
                entity.Property(e => e.Amount).HasColumnName("iznos_sred").IsRequired();
                entity.Property(e => e.Sponsor_id).HasColumnName("sponzor_sponzor_id").IsRequired();
            });
            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("sponzor_id");
                entity.Property(e => e.Name).HasColumnName("naz_spon").IsRequired();
            });
            modelBuilder.Entity<TransactionMembership>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("trans_id");
                entity.Property(e => e.Membership_id).HasColumnName("dugovanje_dug_id").IsRequired();
            });
            modelBuilder.Entity<TransactionRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("trans_id");
                entity.Property(e => e.Request_id).HasColumnName("zahtev_za_nabavku_zahtev_id").IsRequired();
            });
            modelBuilder.Entity<TransactionReservation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("trans_id");
                entity.Property(e => e.Reservation_id).HasColumnName("rezervacija_rez_id").IsRequired();
            });
            modelBuilder.Entity<TransactionFund>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("trans_id");
                entity.Property(e => e.Fund_id).HasColumnName("sredstva_sred_id").IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
