USE LibraryDB;
INSERT INTO Categories (Name, Description) VALUES ('Programming', 'Books about software development');
INSERT INTO Categories (Name, Description) VALUES ('History', 'Historical books');
INSERT INTO Authors (Name, Bio) VALUES ('Robert C. Martin', 'Uncle Bob');
INSERT INTO Authors (Name, Bio) VALUES ('B.R. Ambedkar', 'Father of Indian Constitution');
INSERT INTO Books (Title, TotalCopies, AvailableCopies, AuthorId, CategoryId) VALUES ('Clean Code', 10, 10, 1, 1);
INSERT INTO Books (Title, TotalCopies, AvailableCopies, AuthorId, CategoryId) VALUES ('Annihilation of Caste', 5, 5, 2, 2);
INSERT INTO Members (Name, Email, Phone, MembershipType, JoinDate) VALUES ('John Doe', 'john@test.com', '1234567890', 'Standard', '2026-07-10 00:00:00');
INSERT INTO Members (Name, Email, Phone, MembershipType, JoinDate) VALUES ('Jane Smith', 'jane@test.com', '0987654321', 'Premium', '2026-07-10 00:00:00');
