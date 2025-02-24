-- Drop tables in the correct order to maintain referential integrity
DROP TABLE IF EXISTS advantive.milestones;
DROP TABLE IF EXISTS advantive.tasks;
DROP TABLE IF EXISTS advantive.project;

-- Create project table
CREATE TABLE advantive.project (
       id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
       project_name NVARCHAR(100) NOT NULL,
       description NVARCHAR(255),
       created_by UNIQUEIDENTIFIER,
       created_on DATETIME DEFAULT GETDATE(),
       synchronized_on DATETIME,
       modified_by UNIQUEIDENTIFIER,
       modified_on DATETIME,
       version INT,
       is_deleted BIT
);

-- Create tasks table
CREATE TABLE advantive.tasks (
     id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
     project_id UNIQUEIDENTIFIER NOT NULL,
     task_name NVARCHAR(100) NOT NULL,
     description NVARCHAR(255),
     due_date DATETIME,
     created_by UNIQUEIDENTIFIER,
     created_on DATETIME DEFAULT GETDATE(),
     synchronized_on DATETIME,
     modified_by UNIQUEIDENTIFIER,
     modified_on DATETIME,
     version INT,
     is_deleted BIT,
     FOREIGN KEY (project_id) REFERENCES advantive.project(id)
);

-- Create milestones table
CREATE TABLE advantive.milestones (
      id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
      project_id UNIQUEIDENTIFIER NOT NULL,
      milestone_name NVARCHAR(100) NOT NULL,
      description NVARCHAR(255),
      due_date DATETIME,
      created_by UNIQUEIDENTIFIER,
      created_on DATETIME DEFAULT GETDATE(),
      synchronized_on DATETIME,
      modified_by UNIQUEIDENTIFIER,
      modified_on DATETIME,
      version INT,
      is_deleted BIT,
      FOREIGN KEY (project_id) REFERENCES advantive.project(id)
);