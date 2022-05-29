CREATE TABLE [dbo].[TB_DISCIPLINA] (
    [Id_disciplina]         INT          IDENTITY (1, 1) NOT NULL,
    [nome_disciplina]       VARCHAR (50) NULL,
    [ano_letivo_disciplina] VARCHAR (50) NULL,
    CONSTRAINT [PK_TB_DISCIPLINA] PRIMARY KEY CLUSTERED ([Id_disciplina] ASC)
);

