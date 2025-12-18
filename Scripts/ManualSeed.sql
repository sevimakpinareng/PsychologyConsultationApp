-- Run this script in the target database context before testing merges.
-- It adds the Specialty column when missing so the MERGE below succeeds.
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE dbo.Users(
        Id INT IDENTITY(1,1) PRIMARY KEY,
        FullName NVARCHAR(200) NOT NULL,
        Email NVARCHAR(200) NOT NULL,
        PasswordHash NVARCHAR(200) NOT NULL,
        Role NVARCHAR(50) NOT NULL,
        Specialty NVARCHAR(200) NULL
    );
END
ELSE
BEGIN
    IF COL_LENGTH('Users','Specialty') IS NULL
    BEGIN
        ALTER TABLE dbo.Users ADD Specialty NVARCHAR(200) NULL;
    END
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Appointments')
BEGIN
    CREATE TABLE dbo.Appointments(
        Id INT IDENTITY(1,1) PRIMARY KEY,
        PatientId INT NOT NULL,
        SpecialistId INT NOT NULL,
        AppointmentDate DATE NOT NULL,
        AppointmentTime TIME(0) NOT NULL,
        Status NVARCHAR(50) NOT NULL DEFAULT 'Bekliyor',
        ComplaintText NVARCHAR(MAX) NULL,
        SessionNotes NVARCHAR(MAX) NULL,
        CONSTRAINT FK_Appointments_Patient FOREIGN KEY (PatientId) REFERENCES dbo.Users(Id),
        CONSTRAINT FK_Appointments_Specialist FOREIGN KEY (SpecialistId) REFERENCES dbo.Users(Id)
    );
END
ELSE
BEGIN
    IF COL_LENGTH('Appointments','ComplaintText') IS NULL
    BEGIN
        ALTER TABLE dbo.Appointments ADD ComplaintText NVARCHAR(MAX) NULL;
    END
    IF COL_LENGTH('Appointments','SessionNotes') IS NULL
    BEGIN
        ALTER TABLE dbo.Appointments ADD SessionNotes NVARCHAR(MAX) NULL;
    END
END;

MERGE dbo.Users AS target
USING (VALUES
    (101, 'Dr. Ayşe Demir', 'Psikolog - Anksiyete'),
    (102, 'Dr. Mehmet Yıldız', 'Psikiyatrist - Depresyon'),
    (103, 'Dr. Elif Kaya', 'Psikolog - Uyku'),
    (104, 'Dr. Caner Koç', 'Psikiyatrist - Sınav Stresi'),
    (105, 'Dr. Selin Acar', 'Psikolog - Çocuk & Ergen')
) AS src(Id, FullName, Specialty)
ON target.Id = src.Id
WHEN MATCHED THEN
    UPDATE SET FullName = src.FullName, Specialty = src.Specialty, Role = 'Uzman'
WHEN NOT MATCHED THEN
    INSERT (Id, FullName, Email, PasswordHash, Role, Specialty)
    VALUES (src.Id, src.FullName, CONCAT('uzman', src.Id, '@mail.com'), '1234', 'Uzman', src.Specialty);
