-- =============================================
-- TABELA: cliente
-- =============================================
CREATE TABLE cliente (
    id    INT          NOT NULL AUTO_INCREMENT,
    nome  VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL,
    cpf   CHAR(11)     NOT NULL,
    ativo TINYINT(1)   NOT NULL DEFAULT 1,
    PRIMARY KEY (id),
    UNIQUE KEY uq_cliente_cpf   (cpf),
    UNIQUE KEY uq_cliente_email (email)
);

-- =============================================
-- TABELA: fornecedor
-- =============================================
CREATE TABLE fornecedor (
    id       INT          NOT NULL AUTO_INCREMENT,
    nome     VARCHAR(100) NOT NULL,
    email    VARCHAR(150) NOT NULL,
    cnpj     CHAR(14)     NOT NULL,
    telefone VARCHAR(20)  NOT NULL,  
    ativo    TINYINT(1)   NOT NULL DEFAULT 1,
    PRIMARY KEY (id),
    UNIQUE KEY uq_fornecedor_cnpj  (cnpj),
    UNIQUE KEY uq_fornecedor_email (email)
);

-- =============================================
-- TABELA: produto
-- =============================================
CREATE TABLE produto (
    id      INT            NOT NULL AUTO_INCREMENT,
    nome    VARCHAR(100)   NOT NULL,
    preco   DECIMAL(10, 2) NOT NULL,
    estoque INT            NOT NULL DEFAULT 0,
    ativo   TINYINT(1)     NOT NULL DEFAULT 1,
    PRIMARY KEY (id)
);

-- =============================================
-- TABELA: venda (depende de produto e cliente)
-- =============================================
CREATE TABLE venda (
    id             INT            NOT NULL AUTO_INCREMENT,
    id_produto     INT            NOT NULL,
    id_cliente     INT            NOT NULL,
    data_venda     DATETIME       NOT NULL,
    valor_unitario DECIMAL(10, 2) NOT NULL,
    quantidade     INT            NOT NULL,
    total_venda    DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT fk_venda_produto FOREIGN KEY (id_produto)
        REFERENCES produto (id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_venda_cliente FOREIGN KEY (id_cliente)
        REFERENCES cliente (id) ON DELETE RESTRICT ON UPDATE CASCADE
);