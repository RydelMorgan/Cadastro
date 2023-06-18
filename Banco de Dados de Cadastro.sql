create database auesolucoes;
use auesolucoes;
SET lc_time_names = 'pt_BR';
CREATE TABLE `auesolucoes`.`cadastros` (
  `codcontato` INT NOT NULL AUTO_INCREMENT,
  `cidade` VARCHAR(45) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  `sexo` CHAR(1) NOT NULL,
  `data_cadastro` DATE NOT NULL,
  PRIMARY KEY (`codcontato`));
INSERT INTO cadastros (nome, cidade, sexo, data_cadastro) VALUES
('Paulo', 'Juiz de Fora', 'M', '20230617'),
('Lavinia', 'Vienna', 'F', '20230517'),
('Thiado', 'São Paulo', 'M', '20230217'),
('Cassio', 'Rio de Janeiro', 'M', '20230117'),
('Predo', 'Varginha', 'M', '20230117'),
('Claudio', 'Juiz de Fora', 'M', '20230617'),
('Leticia', 'Juiz de Fora', 'F', '20230517'),
('Fernando', 'Matias Barbosa', 'M', '20231211'),
('João', 'Porto', 'M', '20230716'),
('Camila', 'Florianópolis', 'F', '20230815'),
('Gustavo', 'Belém', 'M', '20230914'),
('Laura', 'Goiânia', 'F', '20231013'),
('Renato', 'Natal', 'M', '20231112'),
('Maria', 'São Paulo', 'F', '20231211'),
('Carlos', 'Rio de Janeiro', 'M', '20240110'),
('Ana', 'Belo Horizonte', 'F', '20240209'),
('Pedro', 'Brasília', 'M', '20240308'),
('Mariana', 'Salvador', 'F', '20240407');