DELIMITER //

CREATE FUNCTION fn_get_emp_tenure(emp_id int)
RETURNS int
BEGIN
  DECLARE years_worked int;
  DECLARE emp_date DATE;
    SET emp_date = (Select hire_date from EMPLOYEE where id = emp_id);
    SET years_worked = (TIMESTAMPDIFF(YEAR, emp_date, CURRENT_DATE()));

  RETURN years_worked;
END //

DELIMITER ;

SELECT name, fn_get_emp_tenure(id) AS tenure_years
FROM EMPLOYEE;

DELIMITER //

CREATE FUNCTION fn_annual_salary(emp_id int)
RETURNS double
BEGIN
  DECLARE sal double;
  DECLARE annual_sal double;
    SET sal = (Select salary from EMPLOYEE where id = emp_id);

    IF sal IS NULL THEN
      SET annual_sal = 0;
    ELSE
      SET annual_sal = sal * 12;
    END IF;

  RETURN annual_sal;
END //

DELIMITER ;

Select name, fn_annual_salary(id) as ANNUAL_SALARY from EMPLOYEE;

DELIMITER //

CREATE PROCEDURE sp_dept_salary_report(
  IN p_dept_id INT,
  OUT p_emp_count INT,
  OUT p_total_salary DOUBLE,
  OUT p_avg_salary DOUBLE,
  OUT p_top_earner VARCHAR(255)
)
BEGIN

  SELECT e.name as emp_name, d.name as dept_name, e.salary
  from DEPARTMENT d
  LEFT JOIN EMPLOYEE e on e.dept_id = d.id
  WHERE d.id = p_dept_id;

  SELECT COUNT(e.id), SUM(e.salary), AVG(e.salary)
  INTO p_emp_count, p_total_salary, p_avg_salary
  FROM EMPLOYEE e
  WHERE e.dept_id = p_dept_id;

  SELECT name INTO p_top_earner
  FROM EMPLOYEE
  WHERE dept_id = p_dept_id
  ORDER BY salary DESC
  LIMIT 1;

END //

DELIMITER ;

CALL sp_dept_salary_report(1, @count, @total, @avg, @top_earner);
SELECT @count, @total, @avg, @top_earner;

DELIMITER //
CREATE PROCEDURE sp_give_raise(
  IN p_dept_id INT,
  IN p_percentage DOUBLE,
  OUT p_status VARCHAR(255)
)
BEGIN
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    SET p_status = 'Error: raise failed, transaction rolled back';
  END;
  START TRANSACTION;
  UPDATE EMPLOYEE
  SET salary = salary * (1 + p_percentage / 100)
  WHERE dept_id = p_dept_id;
  COMMIT;
  SET p_status = 'Success';
END //
DELIMITER ;

CALL sp_give_raise(1, 10, @status);
SELECT @status;
SELECT name, salary FROM EMPLOYEE WHERE dept_id = 1;




