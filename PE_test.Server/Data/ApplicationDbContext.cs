namespace PE_test.Server.Data;

public partial class ApplicationDbContext : DbContext {
    public ApplicationDbContext() {}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public virtual DbSet<CmpHeatMetersVal> CmpHeatMetersVals { get; set; }

    public virtual DbSet<CmpHeatMetersValLast> CmpHeatMetersValLasts { get; set; }

    public virtual DbSet<CmpPressuresVal> CmpPressuresVals { get; set; }

    public virtual DbSet<CmpPressuresValLast> CmpPressuresValLasts { get; set; }

    public virtual DbSet<TblClient> TblClients { get; set; }

    public virtual DbSet<TblCommunicationCard> TblCommunicationCards { get; set; }

    public virtual DbSet<TblComponent> TblComponents { get; set; }

    public virtual DbSet<TblComponentValue> TblComponentValues { get; set; }

    public virtual DbSet<TblConnProvider> TblConnProviders { get; set; }

    public virtual DbSet<TblConnServer> TblConnServers { get; set; }

    public virtual DbSet<TblConnType> TblConnTypes { get; set; }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    public virtual DbSet<TblDataBindingType> TblDataBindingTypes { get; set; }

    public virtual DbSet<TblDataType> TblDataTypes { get; set; }

    public virtual DbSet<TblDcvalue> TblDcvalues { get; set; }

    public virtual DbSet<TblDcvlimitBindingType> TblDcvlimitBindingTypes { get; set; }

    public virtual DbSet<TblDevice> TblDevices { get; set; }

    public virtual DbSet<TblDeviceComponent> TblDeviceComponents { get; set; }

    public virtual DbSet<TblDeviceType> TblDeviceTypes { get; set; }

    public virtual DbSet<TblFile> TblFiles { get; set; }

    public virtual DbSet<TblLanguage> TblLanguages { get; set; }

    public virtual DbSet<TblLocation> TblLocations { get; set; }

    public virtual DbSet<TblLocationType> TblLocationTypes { get; set; }

    public virtual DbSet<TblManufacture> TblManufactures { get; set; }

    public virtual DbSet<TblMbusDimension> TblMbusDimensions { get; set; }

    public virtual DbSet<TblMemoryType> TblMemoryTypes { get; set; }

    public virtual DbSet<TblMenuFile> TblMenuFiles { get; set; }

    public virtual DbSet<TblModuleType> TblModuleTypes { get; set; }

    public virtual DbSet<TblModulesInDevice> TblModulesInDevices { get; set; }

    public virtual DbSet<TblObject> TblObjects { get; set; }

    public virtual DbSet<TblObjectComplexity> TblObjectComplexities { get; set; }

    public virtual DbSet<TblObjectPriority> TblObjectPriorities { get; set; }

    public virtual DbSet<TblObjectState> TblObjectStates { get; set; }

    public virtual DbSet<TblRequestPriority> TblRequestPriorities { get; set; }

    public virtual DbSet<TblSoftware> TblSoftwares { get; set; }

    public virtual DbSet<TblStreet> TblStreets { get; set; }

    public virtual DbSet<TblUnit> TblUnits { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblValueList> TblValueLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Rubisafe;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CmpHeatMetersVal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cmpHeatMeters_Val");

            entity.Property(e => e.DT)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("dT");
            entity.Property(e => e.DevCompId).HasColumnName("DevCompID");
            entity.Property(e => e.DeviceTime).HasColumnType("datetime");
            entity.Property(e => e.Energy).HasColumnType("decimal(26, 4)");
            entity.Property(e => e.EnergyHs)
                .HasColumnType("decimal(26, 4)")
                .HasColumnName("EnergyHS");
            entity.Property(e => e.EnergyHw)
                .HasColumnType("decimal(26, 4)")
                .HasColumnName("EnergyHW");
            entity.Property(e => e.Flow).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.FlowHs)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("FlowHS");
            entity.Property(e => e.FlowHw)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("FlowHW");
            entity.Property(e => e.Mass).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.MeterTime).HasColumnType("datetime");
            entity.Property(e => e.NonworkTime).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OnTime).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Power).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.PowerHs)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PowerHS");
            entity.Property(e => e.PowerHw)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PowerHW");
            entity.Property(e => e.RecordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RecordID");
            entity.Property(e => e.RecordTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Tflow)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TFlow");
            entity.Property(e => e.TflowHs)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TFlowHS");
            entity.Property(e => e.TflowHw)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TFlowHW");
            entity.Property(e => e.Tret)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TRet");
            entity.Property(e => e.TretHs)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TRetHS");
            entity.Property(e => e.TretHw)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TRetHW");
            entity.Property(e => e.Volume).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.VolumeAdd).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.VolumeHs)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("VolumeHS");
            entity.Property(e => e.VolumeHw)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("VolumeHW");
            entity.Property(e => e.WorkTime).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.WorkTime2).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.DevComp).WithMany()
                .HasForeignKey(d => d.DevCompId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cmpHeatMeters_Val_tblDeviceComponents");
        });

        modelBuilder.Entity<CmpHeatMetersValLast>(entity =>
        {
            entity.HasKey(e => e.DevCompId);

            entity.ToTable("cmpHeatMeters_Val_Last");

            entity.Property(e => e.DevCompId)
                .ValueGeneratedNever()
                .HasColumnName("DevCompID");
            entity.Property(e => e.DT)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("dT");
            entity.Property(e => e.DTRt)
                .HasColumnType("datetime")
                .HasColumnName("dT_RT");
            entity.Property(e => e.Duration1Rt)
                .HasColumnType("datetime")
                .HasColumnName("Duration1_RT");
            entity.Property(e => e.Duration2Rt)
                .HasColumnType("datetime")
                .HasColumnName("Duration2_RT");
            entity.Property(e => e.Duration3Rt)
                .HasColumnType("datetime")
                .HasColumnName("Duration3_RT");
            entity.Property(e => e.Energy).HasColumnType("decimal(26, 4)");
            entity.Property(e => e.EnergyHs)
                .HasColumnType("decimal(26, 4)")
                .HasColumnName("EnergyHS");
            entity.Property(e => e.EnergyHsRt)
                .HasColumnType("datetime")
                .HasColumnName("EnergyHS_RT");
            entity.Property(e => e.EnergyHw)
                .HasColumnType("decimal(26, 4)")
                .HasColumnName("EnergyHW");
            entity.Property(e => e.EnergyHwRt)
                .HasColumnType("datetime")
                .HasColumnName("EnergyHW_RT");
            entity.Property(e => e.EnergyRt)
                .HasColumnType("datetime")
                .HasColumnName("Energy_RT");
            entity.Property(e => e.ErrorCode1Rt)
                .HasColumnType("datetime")
                .HasColumnName("ErrorCode1_RT");
            entity.Property(e => e.ErrorCode2Rt)
                .HasColumnType("datetime")
                .HasColumnName("ErrorCode2_RT");
            entity.Property(e => e.ErrorCodeRt)
                .HasColumnType("datetime")
                .HasColumnName("ErrorCode_RT");
            entity.Property(e => e.Flow).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.FlowHs)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("FlowHS");
            entity.Property(e => e.FlowHsRt)
                .HasColumnType("datetime")
                .HasColumnName("FlowHS_RT");
            entity.Property(e => e.FlowHw)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("FlowHW");
            entity.Property(e => e.FlowHwRt)
                .HasColumnType("datetime")
                .HasColumnName("FlowHW_RT");
            entity.Property(e => e.FlowMassRt)
                .HasColumnType("datetime")
                .HasColumnName("FlowMass_RT");
            entity.Property(e => e.FlowRt)
                .HasColumnType("datetime")
                .HasColumnName("Flow_RT");
            entity.Property(e => e.Mass).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.MassRt)
                .HasColumnType("datetime")
                .HasColumnName("Mass_RT");
            entity.Property(e => e.NonworkTime).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NonworkTimeRt)
                .HasColumnType("datetime")
                .HasColumnName("NonworkTime_RT");
            entity.Property(e => e.OnTime).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OnTimeRt)
                .HasColumnType("datetime")
                .HasColumnName("OnTime_RT");
            entity.Property(e => e.Power).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.PowerHs)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PowerHS");
            entity.Property(e => e.PowerHsRt)
                .HasColumnType("datetime")
                .HasColumnName("PowerHS_RT");
            entity.Property(e => e.PowerHw)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PowerHW");
            entity.Property(e => e.PowerHwRt)
                .HasColumnType("datetime")
                .HasColumnName("PowerHW_RT");
            entity.Property(e => e.PowerRt)
                .HasColumnType("datetime")
                .HasColumnName("Power_RT");
            entity.Property(e => e.Tflow)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TFlow");
            entity.Property(e => e.TflowHs)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TFlowHS");
            entity.Property(e => e.TflowHsRt)
                .HasColumnType("datetime")
                .HasColumnName("TFlowHS_RT");
            entity.Property(e => e.TflowHw)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TFlowHW");
            entity.Property(e => e.TflowHwRt)
                .HasColumnType("datetime")
                .HasColumnName("TFlowHW_RT");
            entity.Property(e => e.TflowRt)
                .HasColumnType("datetime")
                .HasColumnName("TFlow_RT");
            entity.Property(e => e.Tret)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TRet");
            entity.Property(e => e.TretHs)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TRetHS");
            entity.Property(e => e.TretHsRt)
                .HasColumnType("datetime")
                .HasColumnName("TRetHS_RT");
            entity.Property(e => e.TretHw)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TRetHW");
            entity.Property(e => e.TretHwRt)
                .HasColumnType("datetime")
                .HasColumnName("TRetHW_RT");
            entity.Property(e => e.TretRt)
                .HasColumnType("datetime")
                .HasColumnName("TRet_RT");
            entity.Property(e => e.Volume).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.VolumeAdd).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.VolumeAddRt)
                .HasColumnType("datetime")
                .HasColumnName("VolumeAdd_RT");
            entity.Property(e => e.VolumeHs)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("VolumeHS");
            entity.Property(e => e.VolumeHsRt)
                .HasColumnType("datetime")
                .HasColumnName("VolumeHS_RT");
            entity.Property(e => e.VolumeHw)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("VolumeHW");
            entity.Property(e => e.VolumeHwRt)
                .HasColumnType("datetime")
                .HasColumnName("VolumeHW_RT");
            entity.Property(e => e.VolumeRt)
                .HasColumnType("datetime")
                .HasColumnName("Volume_RT");
            entity.Property(e => e.WorkTime).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.WorkTime2).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.WorkTime2Rt)
                .HasColumnType("datetime")
                .HasColumnName("WorkTime2_RT");
            entity.Property(e => e.WorkTimeRt)
                .HasColumnType("datetime")
                .HasColumnName("WorkTime_RT");

            entity.HasOne(d => d.DevComp).WithOne(p => p.CmpHeatMetersValLast)
                .HasForeignKey<CmpHeatMetersValLast>(d => d.DevCompId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cmpHeatMeters_Val_Last_tblDeviceComponents");
        });

        modelBuilder.Entity<CmpPressuresVal>(entity =>
        {
            entity.HasKey(e => e.RecordId).IsClustered(false);

            entity.ToTable("cmpPressures_Val");

            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.DevCompId).HasColumnName("DevCompID");
            entity.Property(e => e.DeviceTime).HasColumnType("datetime");
            entity.Property(e => e.MeterTime).HasColumnType("datetime");
            entity.Property(e => e.RecordTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.DevComp).WithMany(p => p.CmpPressuresVals)
                .HasForeignKey(d => d.DevCompId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cmpPressures_Val_tblDeviceComponents");
        });

        modelBuilder.Entity<CmpPressuresValLast>(entity =>
        {
            entity.HasKey(e => e.DevCompId);

            entity.ToTable("cmpPressures_Val_Last");

            entity.Property(e => e.DevCompId)
                .ValueGeneratedNever()
                .HasColumnName("DevCompID");
            entity.Property(e => e.P00Rt)
                .HasColumnType("datetime")
                .HasColumnName("P00_RT");
            entity.Property(e => e.P01Rt)
                .HasColumnType("datetime")
                .HasColumnName("P01_RT");
            entity.Property(e => e.P02Rt)
                .HasColumnType("datetime")
                .HasColumnName("P02_RT");
            entity.Property(e => e.P03Rt)
                .HasColumnType("datetime")
                .HasColumnName("P03_RT");
            entity.Property(e => e.P04Rt)
                .HasColumnType("datetime")
                .HasColumnName("P04_RT");
            entity.Property(e => e.P05Rt)
                .HasColumnType("datetime")
                .HasColumnName("P05_RT");
            entity.Property(e => e.P06Rt)
                .HasColumnType("datetime")
                .HasColumnName("P06_RT");
            entity.Property(e => e.P07Rt)
                .HasColumnType("datetime")
                .HasColumnName("P07_RT");
            entity.Property(e => e.P08Rt)
                .HasColumnType("datetime")
                .HasColumnName("P08_RT");
            entity.Property(e => e.P09Rt)
                .HasColumnType("datetime")
                .HasColumnName("P09_RT");
            entity.Property(e => e.P10Rt)
                .HasColumnType("datetime")
                .HasColumnName("P10_RT");

            entity.HasOne(d => d.DevComp).WithOne(p => p.CmpPressuresValLast)
                .HasForeignKey<CmpPressuresValLast>(d => d.DevCompId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cmpPressures_Val_Last_tblDeviceComponents");
        });

        modelBuilder.Entity<TblClient>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("tblClients_PK");

            entity.ToTable("tblClients");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Caption).HasMaxLength(50);
            entity.Property(e => e.ClientCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Fax)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.PostCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.StLt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.StNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.StreetId).HasColumnName("StreetID");
            entity.Property(e => e.Web)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");

            entity.HasOne(d => d.Country).WithMany(p => p.TblClients)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblCountries_tblClients_FK1");

            entity.HasOne(d => d.Location).WithMany(p => p.TblClients)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblLocations_tblClients_FK1");

            entity.HasOne(d => d.Street).WithMany(p => p.TblClients)
                .HasForeignKey(d => d.StreetId)
                .HasConstraintName("tblStreets_tblClients_FK1");
        });

        modelBuilder.Entity<TblCommunicationCard>(entity =>
        {
            entity.HasKey(e => e.CommCardId).HasName("tblCommunicationCards_PK");

            entity.ToTable("tblCommunicationCards");

            entity.HasIndex(e => e.ConnProviderId, "IX_ConnProviderID");

            entity.Property(e => e.CommCardId).HasColumnName("CommCardID");
            entity.Property(e => e.ActiveHello).HasDefaultValue(true);
            entity.Property(e => e.CardNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConnProviderId).HasColumnName("ConnProviderID");
            entity.Property(e => e.DefaultAccessPort).HasDefaultValue(true);
            entity.Property(e => e.DefaultHelloLocalPort).HasDefaultValue(true);
            entity.Property(e => e.DefaultHelloRemotePort).HasDefaultValue(true);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pin2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PIN2");
            entity.Property(e => e.Pincode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PINCode");
            entity.Property(e => e.Puk2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PUK2");
            entity.Property(e => e.Pukcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PUKCode");
            entity.Property(e => e.ValidityEnd)
                .HasDefaultValue(new DateTime(3000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime");
            entity.Property(e => e.ValidityStart)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ConnProvider).WithMany(p => p.TblCommunicationCards)
                .HasForeignKey(d => d.ConnProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCommunicationCards_tblConnProviders");
        });

        modelBuilder.Entity<TblComponent>(entity =>
        {
            entity.HasKey(e => e.ComponentId).HasName("tblComponents_PK");

            entity.ToTable("tblComponents");

            entity.Property(e => e.ComponentId).HasColumnName("ComponentID");
            entity.Property(e => e.Keyword).HasMaxLength(50);
            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblComponentValue>(entity =>
        {
            entity.HasKey(e => e.CompValueId).HasName("tblComponentValues_PK");

            entity.ToTable("tblComponentValues");

            entity.Property(e => e.CompValueId)
                .ValueGeneratedNever()
                .HasColumnName("CompValueID");
            entity.Property(e => e.ComponentId).HasColumnName("ComponentID");
            entity.Property(e => e.DataTypeId).HasColumnName("DataTypeID");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasDefaultValue("");
            entity.Property(e => e.FieldName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsDcvlimitsAvailable).HasColumnName("IsDCVLimitsAvailable");
            entity.Property(e => e.Keyword).HasMaxLength(50);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.ValueListId).HasColumnName("ValueListID");

            entity.HasOne(d => d.Component).WithMany(p => p.TblComponentValues)
                .HasForeignKey(d => d.ComponentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblComponents_tblComponentValues_FK1");

            entity.HasOne(d => d.DataType).WithMany(p => p.TblComponentValues)
                .HasForeignKey(d => d.DataTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblDataTypes_tblComponentValues_FK1");

            entity.HasOne(d => d.Unit).WithMany(p => p.TblComponentValues)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblUnits_tblComponentValues_FK1");

            entity.HasOne(d => d.ValueList).WithMany(p => p.TblComponentValues)
                .HasForeignKey(d => d.ValueListId)
                .HasConstraintName("tblValueLists_tblComponentValues_FK1");
        });

        modelBuilder.Entity<TblConnProvider>(entity =>
        {
            entity.HasKey(e => e.ConnProviderId);

            entity.ToTable("tblConnProviders");

            entity.Property(e => e.ConnProviderId).HasColumnName("ConnProviderID");
            entity.Property(e => e.Apnaddress)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("APNAddress");
            entity.Property(e => e.Apnpassword)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("APNPassword");
            entity.Property(e => e.Apnuser)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("APNUser");
            entity.Property(e => e.Caption).HasMaxLength(50);
            entity.Property(e => e.ConnTypeiD).HasDefaultValue(1);
            entity.Property(e => e.Dns)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DNS");
            entity.Property(e => e.EventsConnServerId).HasColumnName("EventsConnServerID");
            entity.Property(e => e.Gateway)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Smscenter)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMSCenter");
            entity.Property(e => e.SubnetMask)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ConnType).WithMany(p => p.TblConnProviders)
                .HasForeignKey(d => d.ConnTypeiD)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblConnProviders_tblConnTypes");

            entity.HasOne(d => d.EventsConnServer).WithMany(p => p.TblConnProviders)
                .HasForeignKey(d => d.EventsConnServerId)
                .HasConstraintName("FK_tblConnProviders_tblConnServers");
        });

        modelBuilder.Entity<TblConnServer>(entity =>
        {
            entity.HasKey(e => e.ConnServerId);

            entity.ToTable("tblConnServers");

            entity.Property(e => e.ConnServerId).HasColumnName("ConnServerID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Caption).HasMaxLength(50);
            entity.Property(e => e.Certificate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.SyncTime)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<TblConnType>(entity =>
        {
            entity.HasKey(e => e.ConnTypeId);

            entity.ToTable("tblConnTypes");

            entity.Property(e => e.ConnTypeId)
                .ValueGeneratedNever()
                .HasColumnName("ConnTypeID");
            entity.Property(e => e.Caption).HasMaxLength(50);
        });

        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("tblContacts");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Caption).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("tblCountries_PK");

            entity.ToTable("tblCountries");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Caption).HasMaxLength(50);
        });

        modelBuilder.Entity<TblDataBindingType>(entity =>
        {
            entity.HasKey(e => e.BindingTypeId);

            entity.ToTable("tblDataBindingTypes");

            entity.Property(e => e.BindingTypeId)
                .ValueGeneratedNever()
                .HasColumnName("BindingTypeID");
            entity.Property(e => e.Keyword).HasMaxLength(50);
        });

        modelBuilder.Entity<TblDataType>(entity =>
        {
            entity.HasKey(e => e.DataTypeId).HasName("tblDataTypes_PK");

            entity.ToTable("tblDataTypes");

            entity.Property(e => e.DataTypeId).HasColumnName("DataTypeID");
            entity.Property(e => e.Caption)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sqlsize)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SQLSize");
        });

        modelBuilder.Entity<TblDcvalue>(entity =>
        {
            entity.HasKey(e => e.DcvalueId).IsClustered(false);

            entity.ToTable("tblDCValues");

            entity.HasIndex(e => new { e.DevCompId, e.IsDeleted, e.CompValueId, e.ModuleId, e.SerialNo }, "CL_tblDCValues").IsClustered();

            entity.HasIndex(e => e.CompValueId, "IX_CompValueID");

            entity.HasIndex(e => new { e.ModuleId, e.SerialNo, e.DcvalueId }, "IX_ModuleID");

            entity.HasIndex(e => new { e.SerialNo, e.DcvalueId, e.ModuleId }, "IX_SerialNo");

            entity.Property(e => e.DcvalueId).HasColumnName("DCValueID");
            entity.Property(e => e.BindingTypeId).HasColumnName("BindingTypeID");
            entity.Property(e => e.Caption).HasMaxLength(200);
            entity.Property(e => e.CompValueId).HasColumnName("CompValueID");
            entity.Property(e => e.DcvlimitBindingTypeId).HasColumnName("DCVLimitBindingTypeID");
            entity.Property(e => e.DevCompId).HasColumnName("DevCompID");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");

            entity.HasOne(d => d.BindingType).WithMany(p => p.TblDcvalues)
                .HasForeignKey(d => d.BindingTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDCValues_tblDataBindingTypes");

            entity.HasOne(d => d.CompValue).WithMany(p => p.TblDcvalues)
                .HasForeignKey(d => d.CompValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDCValues_tblDCValues");

            entity.HasOne(d => d.DcvlimitBindingType).WithMany(p => p.TblDcvalues)
                .HasForeignKey(d => d.DcvlimitBindingTypeId)
                .HasConstraintName("FK_tblDCValues_tblDCVLimitBindingTypes");

            entity.HasOne(d => d.DevComp).WithMany(p => p.TblDcvalues)
                .HasForeignKey(d => d.DevCompId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDCValues_tblDeviceComponents");

            entity.HasOne(d => d.Module).WithMany(p => p.TblDcvalues)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK_tblDCValues_tblModulesInDevices");

            entity.HasOne(d => d.Unit).WithMany(p => p.TblDcvalues)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK_tblDCValues_tblUnits");
        });

        modelBuilder.Entity<TblDcvlimitBindingType>(entity =>
        {
            entity.HasKey(e => e.DcvlimitBindingTypeId);

            entity.ToTable("tblDCVLimitBindingTypes");

            entity.Property(e => e.DcvlimitBindingTypeId)
                .ValueGeneratedNever()
                .HasColumnName("DCVLimitBindingTypeID");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Keyword).HasMaxLength(100);
        });

        modelBuilder.Entity<TblDevice>(entity =>
        {
            entity.HasKey(e => e.DeviceId).HasName("tblDevices_PK");

            entity.ToTable("tblDevices", tb => tb.HasTrigger("trgAddDeviceLevel"));

            entity.HasIndex(e => new { e.CommCardId, e.ConnCheckTime, e.IsDeleted }, "IX_CommCard");

            entity.HasIndex(e => new { e.ConnCheckTime, e.IsDeleted, e.CommCardId }, "IX_ConnCheck");

            entity.HasIndex(e => e.ObjectId, "IX_ObjectID");

            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.CommCardId).HasColumnName("CommCardID");
            entity.Property(e => e.ConnCheckTime).HasDefaultValue(43200);
            entity.Property(e => e.ConnLimitKb)
                .HasDefaultValue((short)-1)
                .HasColumnName("ConnLimitKB");
            entity.Property(e => e.ConnectionChanged).HasColumnType("datetime");
            entity.Property(e => e.ConnectionStatus).HasDefaultValue((byte)2);
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.DeviceTypeId).HasColumnName("DeviceTypeID");
            entity.Property(e => e.IsProgrammable).HasDefaultValue(true);
            entity.Property(e => e.LastRequestId).HasColumnName("LastRequestID");
            entity.Property(e => e.MemoryFlash)
                .HasDefaultValue((short)1)
                .HasColumnName("MemoryFLASH");
            entity.Property(e => e.MemorySram).HasColumnName("MemorySRAM");
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.ObjectId).HasColumnName("ObjectID");
            entity.Property(e => e.PowerStatus).HasDefaultValue((byte)2);
            entity.Property(e => e.RequestPriorityId).HasColumnName("RequestPriorityID");
            entity.Property(e => e.SerialNo).HasDefaultValueSql("('')");
            entity.Property(e => e.SoftwareId).HasColumnName("SoftwareID");
            entity.Property(e => e.SyncDeviceTime).HasColumnType("datetime");
            entity.Property(e => e.SyncRequestTime).HasColumnType("datetime");
            entity.Property(e => e.SyncServerTime).HasColumnType("datetime");

            entity.HasOne(d => d.CommCard).WithMany(p => p.TblDevices)
                .HasForeignKey(d => d.CommCardId)
                .HasConstraintName("tblCommunicationCards_tblDevices_FK1");

            entity.HasOne(d => d.DeviceType).WithMany(p => p.TblDevices)
                .HasForeignKey(d => d.DeviceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblDeviceTypes_tblDevices_FK1");

            entity.HasOne(d => d.MemoryFlashNavigation).WithMany(p => p.TblDeviceMemoryFlashNavigations)
                .HasForeignKey(d => d.MemoryFlash)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDevices_tblMemoryTypes");

            entity.HasOne(d => d.MemorySramNavigation).WithMany(p => p.TblDeviceMemorySramNavigations)
                .HasForeignKey(d => d.MemorySram)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDevices_tblMemoryTypes1");

            entity.HasOne(d => d.Menu).WithMany(p => p.TblDevices)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK_tblDevices_tblMenuFiles");

            entity.HasOne(d => d.Object).WithMany(p => p.TblDevices)
                .HasForeignKey(d => d.ObjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDevices_tblObjects");

            entity.HasOne(d => d.RequestPriority).WithMany(p => p.TblDevices)
                .HasForeignKey(d => d.RequestPriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDevices_tblRequestPriorities");

            entity.HasOne(d => d.Software).WithMany(p => p.TblDevices)
                .HasForeignKey(d => d.SoftwareId)
                .HasConstraintName("tblSoftware_tblDevices_FK1");
        });

        modelBuilder.Entity<TblDeviceComponent>(entity =>
        {
            entity.HasKey(e => e.DevCompId).HasName("tblDeviceComponents_PK");

            entity.ToTable("tblDeviceComponents");

            entity.HasIndex(e => e.ComponentId, "IX_ComponentID");

            entity.HasIndex(e => e.DeviceId, "IX_DeviceID");

            entity.HasIndex(e => new { e.DeviceId, e.SerialNo, e.ComponentId }, "IX_DeviceSerialComponent");

            entity.HasIndex(e => new { e.SerialNo, e.IsDeleted }, "IX_Serial");

            entity.Property(e => e.DevCompId).HasColumnName("DevCompID");
            entity.Property(e => e.Caption).HasDefaultValue("");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.ComponentId).HasColumnName("ComponentID");
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.LastParsedRt)
                .HasColumnType("datetime")
                .HasColumnName("LastParsedRT");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.SerialNoStr).HasMaxLength(50);

            entity.HasOne(d => d.Component).WithMany(p => p.TblDeviceComponents)
                .HasForeignKey(d => d.ComponentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDeviceComponents_tblComponents");

            entity.HasOne(d => d.Device).WithMany(p => p.TblDeviceComponents)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblDeviceComponents_tblDevices");

            entity.HasOne(d => d.Module).WithMany(p => p.TblDeviceComponents)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK_tblDeviceComponents_tblModulesInDevices");
        });

        modelBuilder.Entity<TblDeviceType>(entity =>
        {
            entity.HasKey(e => e.DeviceTypeId).HasName("tblDeviceTypes_PK");

            entity.ToTable("tblDeviceTypes");

            entity.Property(e => e.DeviceTypeId)
                .ValueGeneratedNever()
                .HasColumnName("DeviceTypeID");
            entity.Property(e => e.Caption)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PagePath)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblFile>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PK_tblImages");

            entity.ToTable("tblFiles");

            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.AddTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FileBody).HasColumnType("text");
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FileType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.TblFiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblFiles_tblUsers");
        });

        modelBuilder.Entity<TblLanguage>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("tblLanguages_PK");

            entity.ToTable("tblLanguages");

            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.Caption).HasMaxLength(50);
            entity.Property(e => e.CultureName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId)
                .HasName("tblLocations_PK")
                .IsClustered(false);

            entity.ToTable("tblLocations", tb => tb.HasTrigger("trgUpdateAddressByLocation"));

            entity.HasIndex(e => e.CountryId, "IX_CountryID");

            entity.HasIndex(e => e.ParentLocationId, "IX_ParentLocationID").IsClustered();

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Caption).HasMaxLength(50);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.LocationTypeId).HasColumnName("LocationTypeID");
            entity.Property(e => e.ParentLocationId).HasColumnName("ParentLocationID");

            entity.HasOne(d => d.LocationType).WithMany(p => p.TblLocations)
                .HasForeignKey(d => d.LocationTypeId)
                .HasConstraintName("tblCountries_tblLocations_FK1");

            entity.HasOne(d => d.ParentLocation).WithMany(p => p.InverseParentLocation)
                .HasForeignKey(d => d.ParentLocationId)
                .HasConstraintName("tblLocations_tblLocations_FK1");
        });

        modelBuilder.Entity<TblLocationType>(entity =>
        {
            entity.HasKey(e => e.LocationTypeId).HasName("PK__tblLocationTypes__7093AB15");

            entity.ToTable("tblLocationTypes");

            entity.Property(e => e.LocationTypeId).HasColumnName("LocationTypeID");
            entity.Property(e => e.Caption).HasMaxLength(50);
        });

        modelBuilder.Entity<TblManufacture>(entity =>
        {
            entity.HasKey(e => e.Manufacture).HasName("PK__tblManufactures__6EAB62A3");

            entity.ToTable("tblManufactures");

            entity.Property(e => e.Manufacture)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ErrorFunction).HasMaxLength(50);
            entity.Property(e => e.ErrorsTableFunction).HasMaxLength(50);
        });

        modelBuilder.Entity<TblMbusDimension>(entity =>
        {
            entity.HasKey(e => e.MbusDimensionId).HasName("tblMbusDimensions_PK");

            entity.ToTable("tblMbusDimensions");

            entity.Property(e => e.MbusDimensionId).HasColumnName("MbusDimensionID");
            entity.Property(e => e.Caption)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblMemoryType>(entity =>
        {
            entity.HasKey(e => e.MemoryTypeId);

            entity.ToTable("tblMemoryTypes");

            entity.Property(e => e.MemoryTypeId)
                .ValueGeneratedNever()
                .HasColumnName("MemoryTypeID");
            entity.Property(e => e.Caption)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblMenuFile>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("tblMenuFiles_PK");

            entity.ToTable("tblMenuFiles");

            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.FileId).HasColumnName("FileID");

            entity.HasOne(d => d.File).WithMany(p => p.TblMenuFiles)
                .HasForeignKey(d => d.FileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblMenuFiles_tblFiles");
        });

        modelBuilder.Entity<TblModuleType>(entity =>
        {
            entity.HasKey(e => e.ModTid).HasName("tblModuleTypes_PK");

            entity.ToTable("tblModuleTypes");

            entity.Property(e => e.ModTid).HasColumnName("ModTID");
            entity.Property(e => e.AlwaysWriteClv).HasColumnName("AlwaysWriteCLV");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.Manufacture)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ModuleIcon)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModuleName).HasMaxLength(100);
            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ManufactureNavigation).WithMany(p => p.TblModuleTypes)
                .HasForeignKey(d => d.Manufacture)
                .HasConstraintName("FK_tblModuleTypes_tblManufactures");
        });

        modelBuilder.Entity<TblModulesInDevice>(entity =>
        {
            entity.HasKey(e => e.ModuleId)
                .HasName("tblModulesInDevices_PK")
                .IsClustered(false);

            entity.ToTable("tblModulesInDevices");

            entity.HasIndex(e => new { e.DeviceId, e.ModuleIndex, e.IsDeleted, e.ModTid }, "CL_tblModulesInDevices").IsClustered();

            entity.HasIndex(e => new { e.ModTid, e.IsDeleted }, "IX_ModTID");

            entity.HasIndex(e => e.ModuleId, "IX_ModuleID").IsUnique();

            entity.HasIndex(e => e.ModuleIndex, "IX_ModuleIndex");

            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.LastParsedRt)
                .HasColumnType("datetime")
                .HasColumnName("LastParsedRT");
            entity.Property(e => e.LockTime).HasColumnType("datetime");
            entity.Property(e => e.LockUserId).HasColumnName("LockUserID");
            entity.Property(e => e.ModTid).HasColumnName("ModTID");

            entity.HasOne(d => d.Device).WithMany(p => p.TblModulesInDevices)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblDevices_tblModulesInDevices_FK1");

            entity.HasOne(d => d.LockUser).WithMany(p => p.TblModulesInDevices)
                .HasForeignKey(d => d.LockUserId)
                .HasConstraintName("FK_tblModulesInDevices_tblUsers");

            entity.HasOne(d => d.ModT).WithMany(p => p.TblModulesInDevices)
                .HasForeignKey(d => d.ModTid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblModuleTypes_tblModulesInDevices_FK1");
        });

        modelBuilder.Entity<TblObject>(entity =>
        {
            entity.HasKey(e => e.ObjectId).HasName("tblObjects_PK");

            entity.ToTable("tblObjects", tb =>
                {
                    tb.HasTrigger("trgAddObjectLevel");
                    tb.HasTrigger("trgUpdateAddress");
                });

            entity.HasIndex(e => e.ObjectStateId, "IX_ObjectState");

            entity.HasIndex(e => new { e.CountryId, e.LocationId, e.StreetId, e.StNo, e.StLt }, "IX_location");

            entity.Property(e => e.ObjectId).HasColumnName("ObjectID");
            entity.Property(e => e.CertNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CertifiedFrom).HasColumnType("datetime");
            entity.Property(e => e.CertifiedUntil).HasColumnType("datetime");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasDefaultValue("");
            entity.Property(e => e.Latitude)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Longitude)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ObjectComplexityId)
                .HasDefaultValue(5)
                .HasColumnName("ObjectComplexityID");
            entity.Property(e => e.ObjectPriorityId)
                .HasDefaultValue(5)
                .HasColumnName("ObjectPriorityID");
            entity.Property(e => e.ObjectStateId)
                .HasDefaultValue((byte)1)
                .HasColumnName("ObjectStateID");
            entity.Property(e => e.RegistrationNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StLt)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StreetId).HasColumnName("StreetID");
            entity.Property(e => e.SupervisorContactId).HasColumnName("SupervisorContactID");

            entity.HasOne(d => d.Country).WithMany(p => p.TblObjects)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblCountries_tblObjects_FK1");

            entity.HasOne(d => d.Location).WithMany(p => p.TblObjects)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("tblLocations_tblObjects_FK1");

            entity.HasOne(d => d.ObjectComplexity).WithMany(p => p.TblObjects)
                .HasForeignKey(d => d.ObjectComplexityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblObjects_tblObjectComplexity");

            entity.HasOne(d => d.ObjectPriority).WithMany(p => p.TblObjects)
                .HasForeignKey(d => d.ObjectPriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblObjects_tblObjectPriorities");

            entity.HasOne(d => d.ObjectState).WithMany(p => p.TblObjects)
                .HasForeignKey(d => d.ObjectStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblObjects_tblObjectStates");

            entity.HasOne(d => d.Street).WithMany(p => p.TblObjects)
                .HasForeignKey(d => d.StreetId)
                .HasConstraintName("tblStreets_tblObjects_FK1");

            entity.HasOne(d => d.SupervisorContact).WithMany(p => p.TblObjects)
                .HasForeignKey(d => d.SupervisorContactId)
                .HasConstraintName("FK_tblObjects_tblContacts");
        });

        modelBuilder.Entity<TblObjectComplexity>(entity =>
        {
            entity.HasKey(e => e.ObjectComplexityId).HasName("PK__tblObjectComplex__3D491139");

            entity.ToTable("tblObjectComplexity");

            entity.Property(e => e.ObjectComplexityId)
                .ValueGeneratedNever()
                .HasColumnName("ObjectComplexityID");
        });

        modelBuilder.Entity<TblObjectPriority>(entity =>
        {
            entity.HasKey(e => e.ObjectPriorityId).HasName("PK__tblObjectPriorit__6AA5C795");

            entity.ToTable("tblObjectPriorities");

            entity.Property(e => e.ObjectPriorityId)
                .ValueGeneratedNever()
                .HasColumnName("ObjectPriorityID");
        });

        modelBuilder.Entity<TblObjectState>(entity =>
        {
            entity.HasKey(e => e.ObjectStateId);

            entity.ToTable("tblObjectStates");

            entity.Property(e => e.ObjectStateId).HasColumnName("ObjectStateID");
            entity.Property(e => e.Keyword).HasMaxLength(50);
        });

        modelBuilder.Entity<TblRequestPriority>(entity =>
        {
            entity.HasKey(e => e.RequestPriorityId);

            entity.ToTable("tblRequestPriorities");

            entity.Property(e => e.RequestPriorityId).HasColumnName("RequestPriorityID");
            entity.Property(e => e.Keyword).HasMaxLength(50);
        });

        modelBuilder.Entity<TblSoftware>(entity =>
        {
            entity.HasKey(e => e.SoftwareId).HasName("tblSoftware_PK");

            entity.ToTable("tblSoftware");

            entity.Property(e => e.SoftwareId)
                .ValueGeneratedNever()
                .HasColumnName("SoftwareID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.FileId).HasColumnName("FileID");

            entity.HasOne(d => d.File).WithMany(p => p.TblSoftwares)
                .HasForeignKey(d => d.FileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblSoftware_tblFiles");
        });

        modelBuilder.Entity<TblStreet>(entity =>
        {
            entity.HasKey(e => e.StreetId).HasName("tblStreets_PK");

            entity.ToTable("tblStreets", tb => tb.HasTrigger("trgUpdateAddressByStreet"));

            entity.Property(e => e.StreetId).HasColumnName("StreetID");
            entity.Property(e => e.Caption).HasMaxLength(50);
        });

        modelBuilder.Entity<TblUnit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("tblUnits_PK");

            entity.ToTable("tblUnits");

            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Keyword).HasMaxLength(50);
            entity.Property(e => e.MbusDimensionId).HasColumnName("MbusDimensionID");

            entity.HasOne(d => d.MbusDimension).WithMany(p => p.TblUnits)
                .HasForeignKey(d => d.MbusDimensionId)
                .HasConstraintName("FK_tblUnits_tblMbusDimensions");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("tblUsers_PK");

            entity.ToTable("tblUsers");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AlarmSndOff).HasDefaultValue(true);
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsMobileEnabled).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LastWebUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LoginFailCount).HasColumnName("loginFailCount");
            entity.Property(e => e.Organization)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.PinCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.UserSesionId)
                .HasMaxLength(200)
                .HasColumnName("UserSesionID");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Client).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblClients_tblUsers_FK1");

            entity.HasOne(d => d.Language).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblLanguages_tblUsers_FK1");
        });

        modelBuilder.Entity<TblValueList>(entity =>
        {
            entity.HasKey(e => e.ValueListId).HasName("tblValueLists_PK");

            entity.ToTable("tblValueLists");

            entity.Property(e => e.ValueListId).HasColumnName("ValueListID");
            entity.Property(e => e.Keyword).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
