-------------------------------------------------
-- 자재명세서 테이블 : BOM (Bill of Materials)
-------------------------------------------------
CREATE TABLE BOM (
    ParentID    NUMBER(10),     -- 완제품 품번 (Product 테이블 FK)
    ChildID     NUMBER(10),     -- 원자재 품번 (Product 테이블 FK)
    RequiredQty NUMBER(10),     -- 필요 수량 (예: 모니터 1개당 나사 4개)
    CONSTRAINT PK_BOM PRIMARY KEY (ParentID, ChildID),
    CONSTRAINT FK_BOM_Parent FOREIGN KEY (ParentID) REFERENCES Product(ProductID),
    CONSTRAINT FK_BOM_Child  FOREIGN KEY (ChildID)  REFERENCES Product(ProductID)
);