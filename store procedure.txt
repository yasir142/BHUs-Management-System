USE [basicHUs];
GO

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

ALTER PROCEDURE [dbo].[InsertPatientAndMedicine]
    @StaffId INT,
    @Name NVARCHAR(100),
    @Gender NVARCHAR(10),
    @Age INT,
    @Date DATE,
    @Contact NVARCHAR(50),
    @Building NVARCHAR(50),
    @RoomNo NVARCHAR(10),
    @Status NVARCHAR(50),
    @Price DECIMAL(10,2),
    @Symptoms NVARCHAR(MAX),
    @Perception NVARCHAR(MAX),
    @MedicineName NVARCHAR(MAX),    -- comma-separated medicine names
    @QuantityGiven INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1️⃣ Insert into PatientInformation
        INSERT INTO PatientInformation
        (StaffId, Name, Gender, Age, Date, Contact, Building, RoomNo, Status, Price, Symptoms, Perception)
        VALUES
        (@StaffId, @Name, @Gender, @Age, @Date, @Contact, @Building, @RoomNo, @Status, @Price, @Symptoms, @Perception);

        DECLARE @NewPatientId INT = SCOPE_IDENTITY();

        -- 2️⃣ Split comma-separated MedicineName values
        DECLARE @Medicine NVARCHAR(100);
        DECLARE @Pos INT = 0;
        DECLARE @PrevPos INT = 1;
        DECLARE @MedicineList NVARCHAR(MAX) = LTRIM(RTRIM(@MedicineName + ',')); -- Ensure trailing comma

        WHILE CHARINDEX(',', @MedicineList, @PrevPos) > 0
        BEGIN
            SET @Pos = CHARINDEX(',', @MedicineList, @PrevPos);
            SET @Medicine = LTRIM(RTRIM(SUBSTRING(@MedicineList, @PrevPos, @Pos - @PrevPos)));

            IF LEN(@Medicine) > 0
            BEGIN
                -- 3️⃣ Insert each medicine into PatientMedicine
                INSERT INTO PatientMedicine
                (PatientId, MedicineName, StaffId, QuantityGiven, [Date])
                VALUES
                (@NewPatientId, @Medicine, @StaffId, @QuantityGiven, GETDATE());

                -- 4️⃣ Update the Medicines table: subtract given quantity
                UPDATE Medicines
                SET RemainingQuantity = RemainingQuantity - @QuantityGiven
                WHERE Name = @Medicine;
            END

            SET @PrevPos = @Pos + 1;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
