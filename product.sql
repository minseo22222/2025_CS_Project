--------------------------------------------------------
-- 1. 공통 상품 테이블
--------------------------------------------------------
CREATE TABLE Product (
    product_code   VARCHAR2(50)   PRIMARY KEY,
    product_name   VARCHAR2(200)  NOT NULL,
    stock_qty      NUMBER         DEFAULT 0 NOT NULL,
    product_type   CHAR(1)        CHECK (product_type IN ('R', 'F')) NOT NULL
);

--------------------------------------------------------
-- 2. 원자재 테이블 (구매 전용)
--------------------------------------------------------
CREATE TABLE RawMaterial (
    product_code    VARCHAR2(50) PRIMARY KEY,
    purchase_price  NUMBER       NOT NULL,
    CONSTRAINT fk_rawmaterial_product
        FOREIGN KEY (product_code)
        REFERENCES Product(product_code)
        ON DELETE CASCADE
);

--------------------------------------------------------
-- 3. 완제품 테이블 (판매 전용)
--------------------------------------------------------
CREATE TABLE FinishedProduct (
    product_code   VARCHAR2(50) PRIMARY KEY,
    sale_price     NUMBER        NOT NULL,
    CONSTRAINT fk_finishedproduct_product
        FOREIGN KEY (product_code)
        REFERENCES Product(product_code)
        ON DELETE CASCADE
);