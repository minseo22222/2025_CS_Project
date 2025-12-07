-- 2단계: Production 및 BOM 테이블 생성 스크립트
-- 기존 생산 테이블 삭제 (순서 중요: 자식 → 부모)
DROP TABLE ProductionMaterials;
DROP TABLE ProductionHistory;
DROP TABLE BOM; 
DROP SEQUENCE seq_production_materials;

-------------------------------------------------
-- BOM 테이블
-------------------------------------------------
CREATE TABLE BOM (
    ParentID    NUMBER(10),
    ChildID     NUMBER(10),
    RequiredQty NUMBER(10),
    CONSTRAINT PK_BOM PRIMARY KEY (ParentID, ChildID),
    CONSTRAINT FK_BOM_Parent FOREIGN KEY (ParentID) REFERENCES PRODUCT(ProductID),
    CONSTRAINT FK_BOM_Child  FOREIGN KEY (ChildID)  REFERENCES PRODUCT(ProductID)
);

-------------------------------------------------
-- ProductionHistory 테이블
-------------------------------------------------
CREATE TABLE ProductionHistory (
    ProdID      VARCHAR2(20) PRIMARY KEY,
    ProductID   NUMBER(10) NOT NULL,
    ProdDate    DATE DEFAULT SYSDATE,
    TotalQty    NUMBER(10),
    DefectQty   NUMBER(10),
    GoodQty     NUMBER(10),
    Manager     VARCHAR2(50),
    CONSTRAINT FK_PH_Product FOREIGN KEY (ProductID) REFERENCES PRODUCT(ProductID)
);

-------------------------------------------------
-- ProductionMaterials 테이블
-------------------------------------------------
CREATE TABLE ProductionMaterials (
    No          NUMBER(10) PRIMARY KEY,
    ProdID      VARCHAR2(20),
    MaterialID  NUMBER(10),
    Quantity    NUMBER(10),
    CONSTRAINT FK_PM_Main FOREIGN KEY (ProdID) REFERENCES ProductionHistory(ProdID) ON DELETE CASCADE,
    CONSTRAINT FK_PM_Product FOREIGN KEY (MaterialID) REFERENCES PRODUCT(ProductID)
);

-- SEQUENCE 생성 (자동 증가 번호용)
CREATE SEQUENCE seq_production_materials
START WITH 1
INCREMENT BY 1;

COMMIT;