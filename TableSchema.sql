-- Table: Logininformation
CREATE TABLE Logininformation (
    StaffId TEXT PRIMARY KEY,
    Username TEXT NOT NULL,
    Password TEXT NOT NULL
);

-- Table: StaffInformation
CREATE TABLE StaffInformation (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StaffId TEXT,
    Name TEXT NOT NULL,
    Gender TEXT NOT NULL,
    Position TEXT,
    Contact TEXT,
    FOREIGN KEY (StaffId) REFERENCES Logininformation(StaffId) ON DELETE CASCADE
);


CREATE TABLE PatientInformation (
    PatientId INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    Name NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,             -- e.g., 'Male', 'Female', 'Other'
    Age INT NOT NULL,
    Date DATE NOT NULL,                       -- Date of record or admission
    Contact NVARCHAR(20),                     -- Phone number or contact info
    Building NVARCHAR(50),                    -- Building/ward name
    RoomNo NVARCHAR(10),                      -- Room number as string
    Status NVARCHAR(50),                      -- e.g., 'Admitted', 'Discharged'
    Price DECIMAL(10,2),                      -- Billing or service price
    Symptoms NVARCHAR(500),                   -- Description of symptoms
    Perception NVARCHAR(500)                  -- Doctor's perception or notes
);


CREATE TABLE Medicines (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Type NVARCHAR(50),
    Quantity INT,
    Dosage NVARCHAR(100)
);


-- Insert sample data
INSERT INTO Logininformation (StaffId, Username, Password) VALUES
('adm12', 'admin', 'admin123'),
('doc123', 'doctor1', 'docpass1'),
('nur123', 'nurse1', 'nursepass1');
