/*
 Navicat MySQL Data Transfer

 Source Server         : DMS
 Source Server Type    : MySQL
 Source Server Version : 80033 (8.0.33)
 Source Host           : localhost:3306
 Source Schema         : dms

 Target Server Type    : MySQL
 Target Server Version : 80033 (8.0.33)
 File Encoding         : 65001

 Date: 26/05/2023 15:37:00
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for account
-- ----------------------------
DROP TABLE IF EXISTS `account`;
CREATE TABLE `account`  (
  `Id` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserName` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserRole` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `UserName`(`UserName` ASC) USING BTREE,
  CONSTRAINT `account_chk_1` CHECK (regexp_like(`Id`,_utf8mb4'^[0-9]+$')),
  CONSTRAINT `account_chk_2` CHECK (`UserRole` in (_utf8mb4'1',_utf8mb4'2',_utf8mb4'3',_utf8mb4'4',_utf8mb4'5'))
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of account
-- ----------------------------

-- ----------------------------
-- Table structure for dormitory
-- ----------------------------
DROP TABLE IF EXISTS `dormitory`;
CREATE TABLE `dormitory`  (
  `DormitoryNumber` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FloorNumber` int NULL DEFAULT NULL,
  `AvailableBed` int NULL DEFAULT NULL,
  `SumBed` int NULL DEFAULT NULL,
  PRIMARY KEY (`DormitoryNumber`) USING BTREE,
  CONSTRAINT `dormitory_chk_1` CHECK (regexp_like(`DormitoryNumber`,_utf8mb4'^[A-Za-z0-9]+$')),
  CONSTRAINT `dormitory_chk_2` CHECK (`FloorNumber` >= 0),
  CONSTRAINT `dormitory_chk_3` CHECK (`AvailableBed` >= 0),
  CONSTRAINT `dormitory_chk_4` CHECK (`SumBed` >= 0)
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dormitory
-- ----------------------------

-- ----------------------------
-- Table structure for leaveapplication
-- ----------------------------
DROP TABLE IF EXISTS `leaveapplication`;
CREATE TABLE `leaveapplication`  (
  `Id` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `StudentId` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `StartTime` datetime NOT NULL,
  `EndTime` datetime NOT NULL,
  `Reason` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ApplicationStatus` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Applicant` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `StudentId`(`StudentId` ASC) USING BTREE,
  INDEX `Applicant`(`Applicant` ASC) USING BTREE,
  CONSTRAINT `leaveapplication_ibfk_1` FOREIGN KEY (`StudentId`) REFERENCES `student` (`StudentId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `leaveapplication_ibfk_2` FOREIGN KEY (`Applicant`) REFERENCES `teacher` (`WorkId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of leaveapplication
-- ----------------------------

-- ----------------------------
-- Table structure for notification
-- ----------------------------
DROP TABLE IF EXISTS `notification`;
CREATE TABLE `notification`  (
  `Id` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Caption` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Content` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PublishTime` datetime NOT NULL,
  `Receiver` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of notification
-- ----------------------------

-- ----------------------------
-- Table structure for repairrequest
-- ----------------------------
DROP TABLE IF EXISTS `repairrequest`;
CREATE TABLE `repairrequest`  (
  `ID` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `StudentId` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DormitoryNumber` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoomNumber` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RequestType` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `QuestionDescribe` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RequestTime` datetime NOT NULL,
  `ProcessStatus` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  INDEX `StudentId`(`StudentId` ASC) USING BTREE,
  INDEX `DormitoryNumber`(`DormitoryNumber` ASC, `RoomNumber` ASC) USING BTREE,
  CONSTRAINT `repairrequest_ibfk_1` FOREIGN KEY (`StudentId`) REFERENCES `student` (`StudentId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `repairrequest_ibfk_2` FOREIGN KEY (`DormitoryNumber`, `RoomNumber`) REFERENCES `room` (`Dormitory`, `RoomNumber`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of repairrequest
-- ----------------------------

-- ----------------------------
-- Table structure for room
-- ----------------------------
DROP TABLE IF EXISTS `room`;
CREATE TABLE `room`  (
  `RoomNumber` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Dormitory` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SumBed` int NULL DEFAULT NULL,
  `AvailableBed` int NULL DEFAULT NULL,
  `DeviceStatus` char(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`RoomNumber`, `Dormitory`) USING BTREE,
  INDEX `Dormitory`(`Dormitory` ASC) USING BTREE,
  CONSTRAINT `room_ibfk_1` FOREIGN KEY (`Dormitory`) REFERENCES `dormitory` (`DormitoryNumber`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `room_chk_1` CHECK (regexp_like(`Dormitory`,_utf8mb4'^[A-Za-z0-9]+$')),
  CONSTRAINT `room_chk_2` CHECK (`SumBed` >= 0),
  CONSTRAINT `room_chk_3` CHECK (`AvailableBed` >= 0)
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of room
-- ----------------------------

-- ----------------------------
-- Table structure for staff
-- ----------------------------
DROP TABLE IF EXISTS `staff`;
CREATE TABLE `staff`  (
  `Name` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `WorkId` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Sector` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `PhoneNumber` char(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Email` char(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DormitoryInCharge` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`WorkId`) USING BTREE,
  INDEX `DormitoryInCharge`(`DormitoryInCharge` ASC) USING BTREE,
  CONSTRAINT `staff_ibfk_1` FOREIGN KEY (`DormitoryInCharge`) REFERENCES `dormitory` (`DormitoryNumber`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `staff_chk_1` CHECK (`Sector` in (_utf8mb4'Department A',_utf8mb4'Department B',_utf8mb4'Department C',_utf8mb4'Department D',_utf8mb4'Department E')),
  CONSTRAINT `staff_chk_2` CHECK (regexp_like(`PhoneNumber`,_utf8mb4'^[0-9]+$')),
  CONSTRAINT `staff_chk_3` CHECK (`DormitoryInCharge` in (_utf8mb4'1',_utf8mb4'2',_utf8mb4'3',_utf8mb4'4',_utf8mb4'5'))
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of staff
-- ----------------------------

-- ----------------------------
-- Table structure for student
-- ----------------------------
DROP TABLE IF EXISTS `student`;
CREATE TABLE `student`  (
  `Name` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `StudentId` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Department` int NULL DEFAULT NULL,
  `Gender` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Age` int NULL DEFAULT NULL,
  `PhoneNumber` char(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `DormitoryNumber` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `WhetherLeave` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LeaveDate` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`StudentId`) USING BTREE,
  CONSTRAINT `student_chk_1` CHECK (`Department` in (1,2,3,4,5)),
  CONSTRAINT `student_chk_2` CHECK (`Gender` in (_utf8mb4'Male',_utf8mb4'Female')),
  CONSTRAINT `student_chk_3` CHECK (`Age` between 18 and 50),
  CONSTRAINT `student_chk_4` CHECK (regexp_like(`PhoneNumber`,_utf8mb4'^[0-9]+$')),
  CONSTRAINT `student_chk_5` CHECK (regexp_like(`DormitoryNumber`,_utf8mb4'^[A-Za-z0-9]+$')),
  CONSTRAINT `student_chk_6` CHECK (`WhetherLeave` in (_utf8mb4'Yes',_utf8mb4'No'))
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of student
-- ----------------------------

-- ----------------------------
-- Table structure for teacher
-- ----------------------------
DROP TABLE IF EXISTS `teacher`;
CREATE TABLE `teacher`  (
  `Name` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `WorkId` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PhoneNumber` char(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Department` int NULL DEFAULT NULL,
  `Email` char(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DormitoryInCharge` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`WorkId`) USING BTREE,
  INDEX `DormitoryInCharge`(`DormitoryInCharge` ASC) USING BTREE,
  CONSTRAINT `teacher_ibfk_1` FOREIGN KEY (`DormitoryInCharge`) REFERENCES `dormitory` (`DormitoryNumber`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `teacher_chk_1` CHECK (regexp_like(`PhoneNumber`,_utf8mb4'^[0-9]+$')),
  CONSTRAINT `teacher_chk_2` CHECK (`Department` in (1,2,3,4,5)),
  CONSTRAINT `teacher_chk_3` CHECK (`DormitoryInCharge` in (_utf8mb4'1',_utf8mb4'2',_utf8mb4'3',_utf8mb4'4',_utf8mb4'5'))
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of teacher
-- ----------------------------

-- ----------------------------
-- Table structure for visitor
-- ----------------------------
DROP TABLE IF EXISTS `visitor`;
CREATE TABLE `visitor`  (
  `Id` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IDNumber` char(18) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PhoneNumber` char(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CheckInTime` datetime NOT NULL,
  `CheckOutTime` datetime NOT NULL,
  `DormitoryNumber` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `DormitoryNumber`(`DormitoryNumber` ASC) USING BTREE,
  CONSTRAINT `visitor_ibfk_1` FOREIGN KEY (`DormitoryNumber`) REFERENCES `dormitory` (`DormitoryNumber`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `visitor_chk_1` CHECK (regexp_like(`PhoneNumber`,_utf8mb4'^[0-9]+$')),
  CONSTRAINT `visitor_chk_2` CHECK (regexp_like(`DormitoryNumber`,_utf8mb4'^[A-Za-z0-9]+$'))
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of visitor
-- ----------------------------

SET FOREIGN_KEY_CHECKS = 1;
