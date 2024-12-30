CREATE TABLE Candidates (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Party NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
GO
CREATE TABLE Votes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CandidateId INT NOT NULL FOREIGN KEY REFERENCES Candidates(Id),
    VoteCount INT NOT NULL DEFAULT 0,
    LastUpdated DATETIME NOT NULL DEFAULT GETDATE()
);
GO

drop table Candidates;


CREATE PROCEDURE AddOrUpdateVote
    @CandidateId INT,
    @VoteCount INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Votes WHERE CandidateId = @CandidateId)
    BEGIN
        UPDATE Votes
        SET VoteCount = VoteCount + @VoteCount, LastUpdated = GETDATE()
        WHERE CandidateId = @CandidateId;
    END
    ELSE
    BEGIN
        INSERT INTO Votes (CandidateId, VoteCount, LastUpdated)
        VALUES (@CandidateId, @VoteCount, GETDATE());
    END
END;
GO



CREATE PROCEDURE GetVotesByCandidate
    @CandidateId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT VoteCount
    FROM Votes
    WHERE CandidateId = @CandidateId;
END;
GO
CREATE PROCEDURE GetAllCandidates
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, Party, CreatedAt
    FROM Candidates;
END;
GO
EXEC sp_help 'Candidates';
EXEC sp_help 'Votes';
