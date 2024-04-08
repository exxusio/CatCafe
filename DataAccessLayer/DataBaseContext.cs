using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer
{
    public class DataBaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionsBuilder.UseSqlServer("Data Source=EXXUSIO\\SQLEXXUSIO;Initial Catalog=testik;Integrated Security=True;Trust Server Certificate=True",
                b => b.MigrationsAssembly("DataAccessLayer"));

            return new DataBaseContext(optionsBuilder.Options);
        }
    }

    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> accounts { get; set; }

        public virtual DbSet<Breeds> breeds { get; set; }

        public virtual DbSet<Cats> cats { get; set; }

        public virtual DbSet<ReservationCats> reservationCats { get; set; }

        public virtual DbSet<Contents> contents { get; set; }

        public virtual DbSet<Employees> employees { get; set; }

        public virtual DbSet<Events> events { get; set; }

        public virtual DbSet<Orders> orders { get; set; }

        public virtual DbSet<Positions> positions { get; set; }

        public virtual DbSet<Products> products { get; set; }

        public virtual DbSet<Reservations> reservations { get; set; }

        public virtual DbSet<Reviews> reviews { get; set; }

        public virtual DbSet<ReservationTables> reservationTables { get; set; }

        public virtual DbSet<Tables> tables { get; set; }

        public virtual DbSet<Types> types { get; set; }

        public virtual DbSet<Visitors> visitors { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Data Source=EXXUSIO\\SQLEXXUSIO;Initial Catalog=testik;Integrated Security=True;Trust Server Certificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.accountID).HasName("accounts_pkey");

                entity.ToTable("Accounts", "Visitors");

                entity.HasIndex(e => e.visitorID, "accounts_visitorid_key").IsUnique();

                entity.Property(e => e.accountID).HasColumnName("accountID");
                entity.Property(e => e.login)
                    .HasMaxLength(50)
                    .HasColumnName("login");
                entity.Property(e => e.password)
                    .HasMaxLength(50)
                    .HasColumnName("password");
                entity.Property(e => e.registrationDate).HasColumnName("registrationDate");
                entity.Property(e => e.visitorID).HasColumnName("visitorID");

                entity.HasOne(d => d.visitor).WithOne(p => p.account)
                    .HasForeignKey<Accounts>(d => d.visitorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accounts_visitorid_fkey");
            });

            modelBuilder.Entity<Breeds>(entity =>
            {
                entity.HasKey(e => e.breedID).HasName("breeds_pkey");

                entity.ToTable("Breeds", "Cats");

                entity.Property(e => e.breedID).HasColumnName("breedID");
                entity.Property(e => e.description)
                    .HasDefaultValueSql("'Информация отсутствует.'::text")
                    .HasColumnName("description");
                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Cats>(entity =>
            {
                entity.HasKey(e => e.catID).HasName("cats_pkey");

                entity.ToTable("Cats", "Cafe");

                entity.Property(e => e.catID).HasColumnName("catID");
                entity.Property(e => e.breedID).HasColumnName("breedID");
                entity.Property(e => e.characterDescription)
                    .HasDefaultValueSql("'Информация отсутствует.'::text")
                    .HasColumnName("characterDescription");
                entity.Property(e => e.dateOfBirth).HasColumnName("dateOfBirth");
                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.photography).HasColumnName("photography");

                entity.HasOne(d => d.breed).WithMany(p => p.cat)
                    .HasForeignKey(d => d.breedID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cats_breedid_fkey");
            });

            modelBuilder.Entity<ReservationCats>(entity =>
            {
                entity.HasKey(e => e.reservationCatID).HasName("cats_pkey");

                entity.ToTable("Cats", "Reservations");

                entity.Property(e => e.reservationCatID).HasColumnName("reservationCatID");
                entity.Property(e => e.catID).HasColumnName("catID");
                entity.Property(e => e.reservationID).HasColumnName("reservationID");

                entity.HasOne(d => d.cat).WithMany(p => p.reservationCat)
                    .HasForeignKey(d => d.catID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cats_catid_fkey");

                entity.HasOne(d => d.reservation).WithMany(p => p.reservationCat)
                    .HasForeignKey(d => d.reservationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cats_reservationid_fkey");
            });

            modelBuilder.Entity<Contents>(entity =>
            {
                entity.HasKey(e => e.contentID).HasName("contents_pkey");

                entity.ToTable("Contents", "Orders");

                entity.Property(e => e.contentID).HasColumnName("contentID");
                entity.Property(e => e.orderID).HasColumnName("orderID");
                entity.Property(e => e.productID).HasColumnName("productID");
                entity.Property(e => e.quantity).HasColumnName("quantity");

                entity.HasOne(d => d.order).WithMany(p => p.content)
                    .HasForeignKey(d => d.orderID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contents_orderid_fkey");

                entity.HasOne(d => d.product).WithMany(p => p.content)
                    .HasForeignKey(d => d.productID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contents_productid_fkey");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.employeeID).HasName("employees_pkey");

                entity.ToTable("Employees", "Cafe");

                entity.Property(e => e.employeeID).HasColumnName("employeeID");
                entity.Property(e => e.aboutEmployee)
                    .HasDefaultValueSql("'Информация отсутствует.'::text")
                    .HasColumnName("aboutEmployee");
                entity.Property(e => e.hireDate).HasColumnName("hireDate");
                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.photography).HasColumnName("photography");
                entity.Property(e => e.positionID).HasColumnName("positionID");
                entity.Property(e => e.salary)
                    .HasPrecision(10, 2)
                    .HasColumnName("salary");
                entity.Property(e => e.surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.HasOne(d => d.position).WithMany(p => p.employee)
                    .HasForeignKey(d => d.positionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_positionid_fkey");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.eventID).HasName("events_pkey");

                entity.ToTable("Events", "Cafe");

                entity.Property(e => e.eventID).HasColumnName("eventID");
                entity.Property(e => e.description).HasColumnName("description");
                entity.Property(e => e.eventDate).HasColumnName("eventDate");
                entity.Property(e => e.eventTime).HasColumnName("eventTime");
                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
                entity.Property(e => e.photography).HasColumnName("photography");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.orderID).HasName("orders_pkey");

                entity.ToTable("Orders", "Cafe");

                entity.Property(e => e.orderID).HasColumnName("orderID");
                entity.Property(e => e.orderDate).HasColumnName("orderDate");
                entity.Property(e => e.orderTime).HasColumnName("orderTime");
                entity.Property(e => e.tableID).HasColumnName("tableID");
                entity.Property(e => e.visitorID).HasColumnName("visitorID");

                entity.HasOne(d => d.reservationTable).WithMany(p => p.orders)
                    .HasForeignKey(d => d.tableID)
                    .HasConstraintName("orders_tableid_fkey");

                entity.HasOne(d => d.visitor).WithMany(p => p.order)
                    .HasForeignKey(d => d.visitorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_visitorid_fkey");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasKey(e => e.positionID).HasName("positions_pkey");

                entity.ToTable("Positions", "Employees");

                entity.Property(e => e.positionID).HasColumnName("positionID");
                entity.Property(e => e.description)
                    .HasMaxLength(100)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.productID).HasName("products_pkey");

                entity.ToTable("Products", "Cafe");

                entity.Property(e => e.productID).HasColumnName("productID");
                entity.Property(e => e.description).HasColumnName("description");
                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
                entity.Property(e => e.photography).HasColumnName("photography");
                entity.Property(e => e.price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");
                entity.Property(e => e.typeID).HasColumnName("typeID");

                entity.HasOne(d => d.type).WithMany(p => p.product)
                    .HasForeignKey(d => d.typeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_typeid_fkey");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.reservationID).HasName("reservations_pkey");

                entity.ToTable("Reservations", "Cafe");

                entity.Property(e => e.reservationID).HasColumnName("reservationID");
                entity.Property(e => e.reservationDate).HasColumnName("reservationDate");
                entity.Property(e => e.reservationTime).HasColumnName("reservationTime");
                entity.Property(e => e.visitorID).HasColumnName("visitorID");

                entity.HasOne(d => d.visitor).WithMany(p => p.reservation)
                    .HasForeignKey(d => d.visitorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservations_visitorid_fkey");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.reviewID).HasName("reviews_pkey");

                entity.ToTable("Reviews", "Cafe");

                entity.Property(e => e.reviewID).HasColumnName("reviewID");
                entity.Property(e => e.rating).HasColumnName("rating");
                entity.Property(e => e.reviewDate).HasColumnName("reviewDate");
                entity.Property(e => e.reviewText).HasColumnName("reviewText");
                entity.Property(e => e.reviewTime).HasColumnName("reviewTime");
                entity.Property(e => e.visitorID).HasColumnName("visitorID");

                entity.HasOne(d => d.visitor).WithMany(p => p.review)
                    .HasForeignKey(d => d.visitorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reviews_visitorid_fkey");
            });

            modelBuilder.Entity<ReservationTables>(entity =>
            {
                entity.HasKey(e => e.reservationTableID).HasName("tables_pkey");

                entity.ToTable("Tables", "Reservations");

                entity.Property(e => e.reservationTableID).HasColumnName("reservationTableID");
                entity.Property(e => e.reservationID).HasColumnName("reservationID");
                entity.Property(e => e.tableID).HasColumnName("tableID");

                entity.HasOne(d => d.reservation).WithMany(p => p.table)
                    .HasForeignKey(d => d.reservationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tables_reservationid_fkey");

                entity.HasOne(d => d.table).WithMany(p => p.reservationTable)
                    .HasForeignKey(d => d.tableID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tables_tableid_fkey");
            });

            modelBuilder.Entity<Tables>(entity =>
            {
                entity.HasKey(e => e.tableID).HasName("tables_pkey");

                entity.ToTable("Tables", "Cafe");

                entity.Property(e => e.tableID).HasColumnName("tableID");
                entity.Property(e => e.capacity).HasColumnName("capacity");
                entity.Property(e => e.tableNumber).HasColumnName("tableNumber");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.HasKey(e => e.typeID).HasName("types_pkey");

                entity.ToTable("Types", "Products");

                entity.Property(e => e.typeID).HasColumnName("typeID");
                entity.Property(e => e.typeName)
                    .HasMaxLength(100)
                    .HasColumnName("typeName");
            });

            modelBuilder.Entity<Visitors>(entity =>
            {
                entity.HasKey(e => e.visitorID).HasName("visitors_pkey");

                entity.ToTable("Visitors", "Cafe");

                entity.Property(e => e.visitorID).HasColumnName("visitorID");
                entity.Property(e => e.dateOfBirth).HasColumnName("dateOfBirth");
                entity.Property(e => e.emailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("emailAddress");
                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.phoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phoneNumber");
                entity.Property(e => e.surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}