INSERT INTO DEPARTMENT (name) VALUES ('AML');
INSERT INTO DEPARTMENT (name) VALUES ('GRC');
INSERT INTO DEPARTMENT (name) VALUES ('NEO');
INSERT INTO DEPARTMENT (name) VALUES ('LOS');

INSERT INTO EMPLOYEE (name,hire_date,salary,dept_id,manager_id) VALUES ('John Doe', '2012-08-01', 1000000, 1, NULL);
INSERT INTO EMPLOYEE (name,hire_date,salary,dept_id,manager_id) VALUES ('Callum Turner', '2015-03-12', 85000, 1, 1);
INSERT INTO EMPLOYEE (name,hire_date,salary,dept_id,manager_id) VALUES ('Taylor Swift', '2014-01-20', 920000, 2, NULL);
INSERT INTO EMPLOYEE (name,hire_date,salary,dept_id,manager_id) VALUES ('Amelia Earhart', '2018-07-09', 67000, 2, 3);
INSERT INTO EMPLOYEE (name,hire_date,salary,dept_id,manager_id) VALUES ('Alexander Hamilton', '2016-11-02', 88000, 3, 1);
INSERT INTO EMPLOYEE (name,hire_date,salary,dept_id,manager_id) VALUES ('Ada Lovelace', '2019-05-25', 790000, 4, NULL);
INSERT INTO EMPLOYEE (name,hire_date,salary,dept_id,manager_id) VALUES ('Zara Sheikh', '2026-06-15', NULL, 2, 3);

INSERT INTO PROJECT (name) VALUES ('Core Banking Migration');
INSERT INTO PROJECT (name) VALUES ('Fraud Detection Upgrade');
INSERT INTO PROJECT (name) VALUES ('Regulatory Reporting Automation');
INSERT INTO PROJECT (name) VALUES ('Customer Onboarding Revamp');

INSERT INTO PROJ_ASSIGN (proj_id, emp_id, hours_logged) VALUES (1, 1, 120);
INSERT INTO PROJ_ASSIGN (proj_id, emp_id, hours_logged) VALUES (1, 2, 95);
INSERT INTO PROJ_ASSIGN (proj_id, emp_id, hours_logged) VALUES (1, 3, 60);
INSERT INTO PROJ_ASSIGN (proj_id, emp_id, hours_logged) VALUES (1, 4, 80);
INSERT INTO PROJ_ASSIGN (proj_id, emp_id, hours_logged) VALUES (2, 5, 150);
INSERT INTO PROJ_ASSIGN (proj_id, emp_id, hours_logged) VALUES (2, 6, 110);
INSERT INTO PROJ_ASSIGN (proj_id, emp_id, hours_logged) VALUES (3, 2, 40);
INSERT INTO PROJ_ASSIGN (proj_id, emp_id, hours_logged) VALUES (4, 3, 70);