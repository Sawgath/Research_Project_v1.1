CREATE TABLE [User] (
  User_Id  int IDENTITY NOT NULL, 
  UserName varchar(255) NULL, 
  Password varchar(255) NULL, 
  Email    varchar(255) NULL, 
  Age      int NULL, 
  Gender   varchar(255) NULL, 
  CONSTRAINT User_Id 
    PRIMARY KEY (User_Id));
CREATE TABLE Event_Type (
  Event_Type_Id   int IDENTITY NOT NULL, 
  Event_Type_Name varchar(255) NULL, 
  PRIMARY KEY (Event_Type_Id));
CREATE TABLE User_Driving_Data (
  User_Id             int NOT NULL, 
  Session_Id          int NOT NULL, 
  DBTimeStamp         datetime NOT NULL, 
  Street_Name         varchar(255) NULL, 
  Speed_Limit         float(10) NULL, 
  Longitude           float(10) NULL, 
  Latitude            float(10) NULL, 
  Horizontal_Accuracy float(10) NULL, 
  Speed               float(10) NULL, 
  TimeStamp           timestamp NULL, 
  Gravity_X           float(10) NULL, 
  Gravity_Y           float(10) NULL, 
  Gravity_Z           float(10) NULL, 
  Rotation_Rate_X     float(10) NULL, 
  Rotation_Rate_Y     float(10) NULL, 
  Rotation_Rate_Z     float(10) NULL, 
  Magnetic_Flied_X    float(10) NULL, 
  Magnetic_Field_Y    float(10) NULL, 
  Magnetic_Field_Z    float(10) NULL, 
  PRIMARY KEY (User_Id, 
  Session_Id, 
  DBTimeStamp));
CREATE TABLE User_Driving_Events (
  User_Id       int NOT NULL, 
  Event_Type_Id int NOT NULL, 
  Event_Time    timestamp NULL, 
  PRIMARY KEY (User_Id, 
  Event_Type_Id));
ALTER TABLE User_Driving_Data ADD CONSTRAINT FKUser_Drivi955305 FOREIGN KEY (User_Id) REFERENCES [User] (User_Id) ON UPDATE Cascade ON DELETE Cascade;
ALTER TABLE User_Driving_Events ADD CONSTRAINT FKUser_Drivi908262 FOREIGN KEY (User_Id) REFERENCES [User] (User_Id) ON UPDATE Cascade ON DELETE Cascade;
ALTER TABLE User_Driving_Events ADD CONSTRAINT FKUser_Drivi117992 FOREIGN KEY (Event_Type_Id) REFERENCES Event_Type (Event_Type_Id) ON UPDATE Cascade ON DELETE Cascade;
