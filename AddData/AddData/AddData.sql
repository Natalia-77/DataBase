

INSERT INTO tblCurators (Name, Surname) VALUES ('Ilon', 'Mask')
INSERT INTO tblCurators (Name, Surname) VALUES ('Donald', 'Trump')
INSERT INTO tblCurators (Name, Surname) VALUES ('Kim', 'Chen')

INSERT INTO tblFaculties (Name) VALUES ('Computer Science')
INSERT INTO tblFaculties (Name) VALUES ('Design')
INSERT INTO tblFaculties (Name) VALUES ('Cyber')

INSERT INTO tblDepartments (Name, Building, FacultyId) VALUES ('Software Development',1,59)
INSERT INTO tblDepartments (Name, Building, FacultyId) VALUES ('Pattern design',2,60)
INSERT INTO tblDepartments (Name, Building, FacultyId) VALUES ('Huperloop',3,61)

INSERT INTO tblGroups (Name, Year, DepartmentId) VALUES ('OPY225', 3, 46)
INSERT INTO tblGroups (Name, Year, DepartmentId) VALUES ('TRE121', 1, 47)
INSERT INTO tblGroups (Name, Year, DepartmentId) VALUES ('UUY555', 4, 48)

INSERT INTO tblGroupsCurators (CuratorId, GroupId) VALUES (49,43)
INSERT INTO tblGroupsCurators (CuratorId, GroupId) VALUES (50,44)
INSERT INTO tblGroupsCurators (CuratorId, GroupId) VALUES (51,45)

INSERT INTO tblSubjects (Name) VALUES ('Green')
INSERT INTO tblSubjects (Name) VALUES ('Red')
INSERT INTO tblSubjects (Name) VALUES ('Black')

INSERT INTO tblTeachers (IsProfessor, Name, Salary, Surname) VALUES (1, 'Mario', 25000, 'Martor')
INSERT INTO tblTeachers (IsProfessor, Name, Salary, Surname) VALUES (1, 'Misha', 30000, 'Partoy')
INSERT INTO tblTeachers (IsProfessor, Name, Salary, Surname) VALUES (0, 'Lava', 35000, 'Cool')

INSERT INTO tblLectures (Date, SubjectId, TeacherId) VALUES (GETDATE() + DATEADD(hh, 1, current_timestamp), 37, 39)
INSERT INTO tblLectures (Date, SubjectId, TeacherId) VALUES (GETDATE() + DATEADD(hh, 1, current_timestamp), 38, 37)
INSERT INTO tblLectures (Date, SubjectId, TeacherId) VALUES (GETDATE() + DATEADD(hh, 1, current_timestamp), 39, 38)

INSERT INTO tblStudents (Name, Rating, Surname) VALUES ('Sergey', 3, 'Serenko')
INSERT INTO tblStudents (Name, Rating, Surname) VALUES ('Maria', 4, 'Ivanova')
INSERT INTO tblStudents (Name, Rating, Surname) VALUES ('Oleg', 5, 'Redko')

INSERT INTO tblGroupsLectures (GroupId, LectureId) VALUES (43,37)
INSERT INTO tblGroupsLectures (GroupId, LectureId) VALUES (44,39)
INSERT INTO tblGroupsLectures (GroupId, LectureId) VALUES (45,38)

INSERT INTO tblGroupsStudents (GroupId, StudentId) VALUES (44,38)
INSERT INTO tblGroupsStudents (GroupId, StudentId) VALUES (43,37)
INSERT INTO tblGroupsStudents (GroupId, StudentId) VALUES (45,39)