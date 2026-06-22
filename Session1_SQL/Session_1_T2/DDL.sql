CREATE TABLE DEPARTMENT(
  id int PRIMARY KEY AUTO_INCREMENT,
  name varchar(255) UNIQUE
);

CREATE TABLE EMPLOYEE(
  id int PRIMARY KEY AUTO_INCREMENT,
  name varchar(255),
  hire_date DATE,
  salary double,
  dept_id int REFERENCES DEPARTMENT(id),
  manager_id int REFERENCES EMPLOYEE(id)
);

CREATE TABLE PROJECT(
  id int PRIMARY KEY AUTO_INCREMENT,
  name varchar(255) UNIQUE
);

CREATE TABLE PROJ_ASSIGN(
  proj_id int REFERENCES PROJECT(id),
  emp_id int REFERENCES EMPLOYEE(id),
  PRIMARY KEY(proj_id,emp_id),
  hours_logged int NOT NULL
);