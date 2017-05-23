CREATE TABLE [User] (
  User_Id  int IDENTITY NOT NULL, 
  UserName varchar(255) NULL, 
  Password varchar(255) NULL, 
  Email    varchar(255) NULL, 
  Age      int NULL, 
  Gender   varchar(255) NULL, 
  Salt     varchar(255) NOT NULL, 
  Token    varchar(255) NOT NULL, 
  CONSTRAINT User_Id 
    PRIMARY KEY (User_Id));
CREATE TABLE Event_Type (
  Event_Type_Id   int IDENTITY NOT NULL, 
  Event_Type_Name varchar(255) NULL, 
  PRIMARY KEY (Event_Type_Id));
CREATE TABLE User_Driving_Data (
  Data_Id             int IDENTITY NOT NULL, 
  User_Id             int NULL, 
  Session_Id          nvarchar(255) NOT NULL, 
  Street_Name         varchar(255) NULL, 
  Speed_Limit         float(10) NULL, 
  Longitude           float(10) NULL, 
  Latitude            float(10) NULL, 
  Horizontal_Accuracy float(10) NULL, 
  Speed               float(10) NULL, 
  TimeStamp           datetime NULL, 
  User_Acceleration_X float(10) NULL, 
  User_Acceleration_Y float(10) NULL, 
  User_Acceleration_Z float(10) NULL, 
  Gravity_X           float(10) NULL, 
  Gravity_Y           float(10) NULL, 
  Gravity_Z           float(10) NULL, 
  Rotation_Rate_X     float(10) NULL, 
  Rotation_Rate_Y     float(10) NULL, 
  Rotation_Rate_Z     float(10) NULL, 
  Magnetic_Flied_X    float(10) NULL, 
  Magnetic_Field_Y    float(10) NULL, 
  Magnetic_Field_Z    float(10) NULL, 
  Frequency           int NULL, 
  PRIMARY KEY (Data_Id));
CREATE TABLE User_Driving_Events (
  Event_Id      int IDENTITY NOT NULL, 
  Event_Type_Id int NOT NULL, 
  Session_Id    nvarchar(255) NOT NULL, 
  Event_Time    datetime NULL, 
  PRIMARY KEY (Event_Id));
CREATE TABLE Session_History (
  Session_Id nvarchar(255) NOT NULL, 
  User_Id    int NOT NULL, 
  Start_Time datetime NULL, 
  End_Time   datetime NULL, 
  PRIMARY KEY (Session_Id));
ALTER TABLE User_Driving_Events ADD CONSTRAINT FKUser_Drivi117992 FOREIGN KEY (Event_Type_Id) REFERENCES Event_Type (Event_Type_Id) ON UPDATE Cascade ON DELETE Cascade;
ALTER TABLE Session_History ADD CONSTRAINT FKSession_Hi512699 FOREIGN KEY (User_Id) REFERENCES [User] (User_Id);
ALTER TABLE User_Driving_Data ADD CONSTRAINT FKUser_Drivi237016 FOREIGN KEY (Session_Id) REFERENCES Session_History (Session_Id);
ALTER TABLE User_Driving_Events ADD CONSTRAINT FKUser_Drivi871005 FOREIGN KEY (Session_Id) REFERENCES Session_History (Session_Id);
