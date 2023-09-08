-- 1) Retrieve all information from the Sales.Customer table
select * from Sales.Customer;

-- 2) Retrieve all information from the Sales.Store table sorted by Name in alphabetical order
select * from Sales.Store as s 
order by s.Name;

-- 3) Retrieve all information from the HumanResources.Employee table about ten employees who were born after 1989-09-28
select top 10 * from HumanResources.Employee as e
where e.BirthDate > '1989-09-28';

-- 4) Retrieve employees from the HumanResources.Employee table whose last character of LoginID is 0. 
-- Output only NationalIDNumber, LoginID, JobTitle. Data must be sorted by JobTitle
select e.NationalIDNumber, e.LoginID, e.JobTitle 
from HumanResources.Employee as e
where right(e.LoginID, 1) = '0'
order by e.JobTitle;

-- 5) Retrieve from the Person.Person table all information about records that have been updated in 2008 (ModifiedDate) 
-- and MiddleName contains value and Title does not contain a value
select * from Person.Person as p
where year(p.ModifiedDate) = '2008' and p.MiddleName is not null and p.Title is null;

-- 6) Display department name (HumanResources.Department.Name) WITHOUT repetition in which there are employees. 
-- Use HumanResources.EmployeeDepartmentHistory and HumanResources.Department tables
select distinct d.Name as DepartmantName
from HumanResources.Department as d
inner join HumanResources.EmployeeDepartmentHistory as edh
on d.DepartmentID = edh.DepartmentID;

-- 7) Group data from Sales.SalesPerson table by TerritoryID and print the amount of CommissionPct if it is greater than 0
select sp.TerritoryID, sum(sp.CommissionPct) as AmountOfCommissionPct 
from Sales.SalesPerson as sp
where sp.CommissionPct > 0
group by sp.TerritoryID;

-- 8) Display all employee information (HumanResources.Employee) which have the largest number vacations (HumanResources.Employee.VacationHours)
select * from HumanResources.Employee as e
where e.VacationHours = (
	select max(e.VacationHours) 
	from HumanResources.Employee
);

-- 9) Display all employee information (HumanResources.Employee) which have a position (HumanResources.Employee.JobTitle) 
-- 'Sales Representative' or 'Network Administrator' or 'Network Manager'
select * from HumanResources.Employee as e
where e.JobTitle = 'Sales Representative' or e.JobTitle = 'Network Administrator' or e.JobTitle = 'Network Manager';

-- 10) Display all employee information (HumanResources.Employee) and their orders (Purchasing.PurchaseOrderHeader). 
-- IF THE EMPLOYEE DOES NOT HAVE ORDERS SHOULD BE DISPLAYED TOO!!!
select e.*, poh.* from HumanResources.Employee as e
left join Purchasing.PurchaseOrderHeader as poh
on e.BusinessEntityID = poh.EmployeeID;