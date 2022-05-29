CREATE TABLE [dbo].[TB_MATERIA] (
    [Id_materia]    INT          IDENTITY (1, 1) NOT NULL,
    [disciplina_Id] INT          NOT NULL,
    [nome_materia]  VARCHAR (50) NULL,
    CONSTRAINT [PK_TB_MATERIA] PRIMARY KEY CLUSTERED ([Id_materia] ASC),
    CONSTRAINT [Fk_tbDisciplina_id] FOREIGN KEY ([disciplina_Id]) REFERENCES [dbo].[TB_DISCIPLINA] ([Id_disciplina])
);

