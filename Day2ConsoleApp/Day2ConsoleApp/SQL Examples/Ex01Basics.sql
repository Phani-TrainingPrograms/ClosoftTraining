-- .\SQLEXPRESS : .\ Means localhost\InstanceName. Free SQL Server copy given for learning purposes. 

--Create database : Database is a collection of data in the form of rows and columns. Each set of data is called as Table. Table has rows and columns. Columns refer the structure of the table (Schema) rows contain the data of the table.
--Todo: Check if the DB exists, else create the db...
Create database TitanDb
Use TitanDb --Means any statements from now shall be executed on that database. 

---------Creating table. Each table has schema(Structure of data). Table name is recommended to be singular. 
Create Table Employee
(
	EmpId int PRIMARY KEY IDENTITY(1000, 1),--Auto generating ID, 
	EmpName nvarchar(100) NOT NULL, 
	EmpAddress nvarchar(500) NOT NULL,
	EmpSalary int NOT NULL
)

-------------insert some records to it------------------------
INSERT INTO Employee values('Phaniraj', 'Bangalore', 45000) --To pass all values into the table in the order of the columns. 
INSERT INTO Employee(EmpAddress, EmpName, EmpSalary) values('Mysore','Suresh', 50000) -- Scenario where there are default values for few columns and U dont want to pass the values explicitly.
INSERT INTO Employee values('Ohm', 'Hosur', 60000)
-------------------Extract the records: SELECT statement----------------
SELECT * FROM Employee where Status = 1 
SELECT * FROM Employee where Status <> 1 
SELECT * FROM Employee where EmpAddress = 'Hosur'
SELECT * FROM Employee order by EmpName desc --descending order, asc for ascending order.  
--------------------Update the records: UPDATE statement---------------------
Update Employee
Set EmpAddress = 'BENGALURU' 
Where EmpAddress = 'Bangalore'
--Update tableName set colName ='Value', colName2 = 'value2'.... WHERE colName = 'conditional_Value'

---------------------Delete the record: DELETE Statement---------------------
DELETE FROM Employee Where EmpId = 1000
--Use a concept called Soft Delete, it shall not delete the record from the table, rather a column would be available to set whether the data should be used or not.

UPDATE Employee
SET Status = 0
Where EmpId = 1001

----------------Add/Drop Column in the table----------------
Alter Table Employee
Add Status Bit NULL

Alter table Employee
Drop column Status


