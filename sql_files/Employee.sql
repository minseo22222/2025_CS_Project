-------------------------------------------------
-- 1. 기존 직원 관련 테이블 삭제
--    (실습용이므로 단순 DROP 사용, 없으면 에러 날 수 있음)
-------------------------------------------------
DROP TABLE Employee;
DROP TABLE Departments;
DROP TABLE Ranks;

-------------------------------------------------
-- 2. 부서 코드 테이블 : Departments
--    (예시 부서들, 필요하면 이름 바꿔도 됨)
-------------------------------------------------
CREATE TABLE Departments (
    DeptName VARCHAR2(50) PRIMARY KEY         -- 부서명 (예: 생산부, 영업부 ...)
);

INSERT INTO Departments (DeptName) VALUES ('생산부');
INSERT INTO Departments (DeptName) VALUES ('영업부');
INSERT INTO Departments (DeptName) VALUES ('구매부');
INSERT INTO Departments (DeptName) VALUES ('품질관리부');
INSERT INTO Departments (DeptName) VALUES ('관리부');

-------------------------------------------------
-- 3. 직급 코드 테이블 : Ranks
-------------------------------------------------
CREATE TABLE Ranks (
    RankName VARCHAR2(30) PRIMARY KEY,        -- 직급명 (예: 사원, 대리 ...)
    SortNo   NUMBER                           -- 정렬용 순서 (1:사원 ~ 6:임원)
);

INSERT INTO Ranks (RankName, SortNo) VALUES ('사원', 1);
INSERT INTO Ranks (RankName, SortNo) VALUES ('대리', 2);
INSERT INTO Ranks (RankName, SortNo) VALUES ('과장', 3);
INSERT INTO Ranks (RankName, SortNo) VALUES ('차장', 4);
INSERT INTO Ranks (RankName, SortNo) VALUES ('부장', 5);
INSERT INTO Ranks (RankName, SortNo) VALUES ('임원', 6);

-------------------------------------------------
-- 4. 직원 테이블 : Employee
--    (ERD 의 "직원" 테이블에 해당)
-------------------------------------------------
CREATE TABLE Employee (
    EmployeeID      VARCHAR2(20) PRIMARY KEY, -- 사원 번호
    Name            VARCHAR2(50) NOT NULL,    -- 이름
    Rank            VARCHAR2(30),             -- 직급명 (FK → Ranks.RankName)
    Department      VARCHAR2(50),             -- 부서명 (FK → Departments.DeptName)
    HireDate        DATE DEFAULT SYSDATE,     -- 입사일
    PhoneNumber     VARCHAR2(20),             -- 전화번호
    ResignationDate DATE                      -- 퇴사일 (재직중이면 NULL)
);

-- 직급 FK
ALTER TABLE Employee
    ADD CONSTRAINT fk_employee_rank
        FOREIGN KEY (Rank)
        REFERENCES Ranks(RankName);

-- 부서 FK
ALTER TABLE Employee
    ADD CONSTRAINT fk_employee_dept
        FOREIGN KEY (Department)
        REFERENCES Departments(DeptName);
