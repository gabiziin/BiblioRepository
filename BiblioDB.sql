CREATE DATABASE BiblioDB;
USE BiblioDB;
DROP DATABASE BiblioDB;

CREATE TABLE TipoUsuario(
IdTipoUsuario INT PRIMARY KEY IDENTITY (1,1),
DescricaoTipoUsuario VARCHAR(150) NOT NULL
);

INSERT INTO TipoUsuario (DescricaoTipoUsuario)
VALUES ('Administrador'),('Outros');

SELECT * FROM TipoUsuario;
UPDATE TipoUsuario SET DescricaoTipoUsuario = 'Administrador'
WHERE IdTipoUsuario = 1;

CREATE TABLE Usuario(
IdUsuario INT PRIMARY KEY IDENTITY (1,1),
NomeUsuario VARCHAR(150) NOT NULL,
EmailUsuario VARCHAR(150) NOT NULL,
SenhaUsuario CHAR(6) NOT NULL,
UsuarioTp INT NOT NULL,

FOREIGN KEY (UsuarioTp) REFERENCES TipoUsuario (IdTipoUsuario)

);

/*CRUD Usuario*/
/*CREATE*/
INSERT INTO Usuario (NomeUsuario,EmailUsuario,SenhaUsuario,UsuarioTp) 
VALUES ('admin','admin@email.com','admin',1),
('outros','outros@email.com','outros',2),
('Juia','juia@email.com','jui123',2),
('Atlas','atlas@email.com','atl123',1),
('Fernando','compostura@email.com','fer123',2),
('Wil','COMFORCA@email.com','WIL123',1);

/*READ*/
SELECT IdUsuario, NomeUsuario, EmailUsuario, SenhaUsuario, DescricaoTipoUsuario
FROM Usuario 
INNER JOIN TipoUsuario ON UsuarioTp = IdTipoUsuario;

/*UPDATE*/
UPDATE Usuario SET NomeUsuario = '@NomeUsuario',EmailUsuario = '@EmailUsuario',SenhaUsuario = '@SenhaUsuario',
UsuarioTp = '@UsuarioTp' WHERE IdUsuario = '@IdUsuario';

/*DELETE*/
DELETE FROM Usuario WHERE IdUsuario = 0;

/*AUTENTICACAO*/
SELECT * FROM Usuario WHERE NomeUsuario = 'Juia' AND SenhaUsuario='jui231';

/*SEARCHBYID*/
SELECT * FROM Usuario WHERE IdUsuario = 1;

DROP TABLE IF EXISTS Genero;

SELECT * FROM Usuario;

-- Criação da tabela Genero
CREATE TABLE Genero (
    IdGenero INT PRIMARY KEY IDENTITY (1,1),
    DescricaoGenero VARCHAR(150) NOT NULL
);

-- Inserção de valores na tabela Genero
INSERT INTO Genero (DescricaoGenero)
VALUES 
('Ação'), ('Aventura'), ('Autoajuda'), ('Biografia'), ('Clássico'),('Culinária'), ('Drama'), ('Distopia'), ('Fantasia'), ('Ficção Científica'),
('Histórico'), ('Humor'), ('Infantil'), ('Mistério'), ('Poesia'),('Policial'), ('Romance'), ('Suspense'), ('Terror'), ('Thriller'), 
('Filosofia');

-- Consulta dos valores na tabela Genero
SELECT * FROM Genero;

-- Criação da tabela Livro
DROP TABLE Livro;
CREATE TABLE Livro (
    IdLivro INT PRIMARY KEY IDENTITY (1,1),
    TituloLivro VARCHAR(150) NOT NULL,
    EditoraLivro VARCHAR(150) NOT NULL,
    AutorLivro VARCHAR(150) NOT NULL,
    DtPubli DATE NOT NULL,
    SinopseLivro VARCHAR(150) NOT NULL,
    UrlLivro VARCHAR(MAX) NOT NULL,
	UrlPDF VARCHAR(MAX) NOT NULL,
    GeneroId INT NOT NULL,
    FOREIGN KEY (GeneroId) REFERENCES Genero (IdGenero)
);

INSERT INTO Livro (TituloLivro, EditoraLivro, AutorLivro, DtPubli, SinopseLivro, UrlLivro, UrlPDF, GeneroId) 
VALUES 
('1984', 'Companhia das Letras', 'George Orwell', '1949/06/08', 'Uma distopia sobre um governo totalitário.', '~/img/1984.jpg', '~/pdfs/1984.pdf', 1),
('Dom Quixote', 'Penguin Classics', 'Miguel de Cervantes', '1605/01/16', 'A história do cavaleiro errante e seus ideais.', '~/img/dom_quixote.jpg', '~/pdfs/dom_quixote.pdf', 1),
('Orgulho e Preconceito', 'L&PM Editores', 'Jane Austen', '1813/01/28', 'Um romance sobre amor e classe social.', '~/img/orgulho_preconceito.jpg', '~/pdfs/orgulho_preconceito.pdf', 2),
('O Pequeno Príncipe', 'Agir', 'Antoine de Saint-Exupéry', '1943/04/06', 'Um conto filosófico e cativante.', '~/img/pequeno_principe.jpg', '~/pdfs/pequeno_principe.pdf', 4),
('O Senhor dos Anéis', 'HarperCollins', 'J.R.R. Tolkien', '1954/07/29', 'Uma aventura épica na Terra Média.', '~/img/senhor_dos_aneis.jpg', '~/pdfs/senhor_dos_aneis.pdf', 3),
('Moby Dick', 'Penguin Classics', 'Herman Melville', '1851/10/18', 'A busca obsessiva pela baleia branca.', '~/img/moby_dick.jpg', '~/pdfs/moby_dick.pdf', 4),
('Crime e Castigo', 'Editora 34', 'Fiódor Dostoiévski', '1866/01/15', 'Um estudo psicológico de culpa e redenção.', '~/img/crime_castigo.jpg', '~/pdfs/crime_castigo.pdf', 5),
('Hamlet', 'Oxford University Press', 'William Shakespeare', '1603/03/26', 'Uma tragédia sobre vingança e moralidade.', '~/img/hamlet.jpg', '~/pdfs/hamlet.pdf', 2),
('O Apanhador no Campo de Centeio', 'Editora do Autor', 'J.D. Salinger', '1951/07/16', 'Um relato da crise da juventude.', '~/img/apanhador_centeio.jpg', '~/pdfs/apanhador_centeio.pdf', 3),
('Guerra e Paz', 'Editora Martin Claret', 'Liev Tolstói', '1869/01/01', 'Uma narrativa épica sobre a Rússia napoleônica.', '~/img/guerra_paz.jpg', '~/pdfs/guerra_paz.pdf', 5);


SELECT * FROM Livro;

/*CRUD Livro*/
/*READ*/
SELECT TituloLivro, EditoraLivro, UrlLivro, DescricaoGenero
FROM Livro 
INNER JOIN Genero ON GeneroId = IdGenero;

/*FILTER*/
SELECT TituloLivro, EditoraLivro, UrlLivro, DescricaoGenero
FROM Livro 
INNER JOIN Genero ON GeneroId = IdGenero
WHERE GeneroId = 1;

