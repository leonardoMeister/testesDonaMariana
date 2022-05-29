CREATE TABLE [dbo].[TB_TESTE] (
    [Id_teste]         INT          IDENTITY (1, 1) NOT NULL,
    [nome_teste]       VARCHAR (50) NULL,
    [fk_disciplina_id] INT          NULL,
    CONSTRAINT [PK_TB_TESTE] PRIMARY KEY CLUSTERED ([Id_teste] ASC),
    CONSTRAINT [FK_disciplina_teste] FOREIGN KEY ([fk_disciplina_id]) REFERENCES [dbo].[TB_DISCIPLINA] ([Id_disciplina])
);

