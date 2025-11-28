-- 기존 테이블 삭제(존재하지 않아도 에러 무시하려면 직접 BEGIN...EXCEPTION 사용)
DROP TABLE TradeDetail;
DROP TABLE Trade;
DROP TABLE Inventory;
DROP TABLE Warehouse;
DROP TABLE Product;

-------------------------------------------------
-- 상품 테이블 : Product
-------------------------------------------------
CREATE TABLE Product ( -- 상품
    ProductID   NUMBER(10)      PRIMARY KEY,          -- 상품코드
    ProductName VARCHAR2(100)   NOT NULL,             -- 상품명
    UnitPrice   NUMBER(12,2),                         -- 기준단가
    category    VARCHAR2(20),                         -- 상품구분(완제품/원재료)
    CONSTRAINT chk_category CHECK (category IN ('완제품','원재료'))
);

-------------------------------------------------
-- 창고 테이블 : Warehouse
-------------------------------------------------
CREATE TABLE Warehouse ( -- 창고
    WarehouseID   NUMBER(10) PRIMARY KEY,             -- 창고코드
    WarehouseName VARCHAR2(100)                       -- 창고명
);

-------------------------------------------------
-- 재고 테이블 : Inventory (현재고)
-------------------------------------------------
CREATE TABLE Inventory ( -- 재고
    WarehouseID NUMBER(10),                           -- 창고코드(FK)
    ProductID   NUMBER(10),                           -- 상품코드(FK)
    Quantity    NUMBER(10) DEFAULT 0,                 -- 현재수량
    CONSTRAINT PK_Inventory PRIMARY KEY (WarehouseID, ProductID),
    CONSTRAINT FK_Inventory_Warehouse FOREIGN KEY (WarehouseID) REFERENCES Warehouse(WarehouseID),
    CONSTRAINT FK_Inventory_Product FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-------------------------------------------------
-- 거래 헤더 테이블 : Trade (매매관리 상단)
-------------------------------------------------
CREATE TABLE Trade (
    TradeID        NUMBER(10)    PRIMARY KEY,         -- 거래번호
    TradeDate      DATE          NOT NULL,            -- 거래일자
    TradeType      VARCHAR2(10)  NOT NULL,            -- 매입 / 매출 구분
    CustomerID     NUMBER(10),                        -- 거래처번호(FK, 추후 추가)
    StaffID        NUMBER(10),                        -- 담당자번호(FK, 추후 추가)
    DefaultWhID    NUMBER(10),                        -- 기본 창고(해당 거래의 창고)
    PaymentMethod  VARCHAR2(30),                      -- 결제수단
    TotalAmount    NUMBER(12,2) DEFAULT 0,            -- 총금액
    CONSTRAINT chk_trade_type CHECK (TradeType IN ('매입','매출')),
    CONSTRAINT fk_trade_wh FOREIGN KEY (DefaultWhID) REFERENCES Warehouse(WarehouseID)
    -- fk_trade_customer, fk_trade_staff 제약조건은
    -- 거래처/직원 테이블 설계 후 추가 예정
);

-------------------------------------------------
-- 거래 상세 테이블 : TradeDetail (매매상세 그리드)
-------------------------------------------------
CREATE TABLE TradeDetail (
    TradeID     NUMBER(10)   NOT NULL,               -- 거래번호(FK, 헤더와 연결)
    LineNo      NUMBER(4)    NOT NULL,               -- 행번호(1,2,3... 순번)
    ProductID   NUMBER(10)   NOT NULL,               -- 상품코드(FK → Product)
    Quantity    NUMBER(10)   NOT NULL,               -- 수량
    UnitPrice   NUMBER(12,2) NOT NULL,               -- 단가(거래 시점 가격 스냅샷)
    Amount      NUMBER(12,2) NOT NULL,               -- 금액 = 수량 * 단가
    CONSTRAINT PK_TradeDetail PRIMARY KEY (TradeID, LineNo),
    CONSTRAINT FK_TD_Trade   FOREIGN KEY (TradeID) REFERENCES Trade(TradeID),
    CONSTRAINT FK_TD_Product FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
