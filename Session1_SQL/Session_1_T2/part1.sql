SELECT
  e.name,
  e.hire_date,
  e.salary,
  d.name AS dept_name
FROM EMPLOYEE e
LEFT JOIN DEPARTMENT d ON d.id = e.dept_id;

SELECT d.name, COUNT(e.id) as num_emp
FROM DEPARTMENT d
LEFT JOIN EMPLOYEE e ON d.id = e.dept_id
GROUP BY d.id;

SELECT e.name, d.name AS department, e.hire_date
FROM EMPLOYEE e
LEFT JOIN PROJ_ASSIGN p ON e.id = p.emp_id
LEFT JOIN DEPARTMENT d ON e.dept_id = d.id
WHERE p.proj_id IS NULL;

SELECT SUM(e.salary) AS expenditure, AVG(e.salary) AS avg_salary, COUNT(e.id) AS num_emp, d.name AS department
FROM DEPARTMENT d
LEFT JOIN EMPLOYEE e ON e.dept_id = d.id
GROUP BY d.id
ORDER BY expenditure DESC;

Select e.name, s.name as manager
from Employee e
LEFT JOIN Employee s on e.manager_id = s.id;

Select SUM(pa.hours_logged) as total_hours, COUNT(pa.emp_id) as total_emp, p.name
FROM Project p
LEFT JOIN PROJ_ASSIGN pa on p.id = pa.proj_id
GROUP BY (p.id)
having total_emp > 3
ORDER BY(total_hours) DESC;

Select p.name as Project, d.name as Department, COUNT(pa.emp_id) as emp_count
FROM DEPARTMENT d
CROSS JOIN Project p
LEFT JOIN EMPLOYEE e on d.id = e.dept_id
LEFT JOIN PROJ_ASSIGN pa on e.id = pa.emp_id AND p.id = pa.proj_id
GROUP BY Department, Project;

