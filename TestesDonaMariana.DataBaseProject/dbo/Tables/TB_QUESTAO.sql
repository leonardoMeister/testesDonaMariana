CREATE TABLE [dbo].[TB_QUESTAO] (
    [Id_Questao]          INT          IDENTITY (1, 1) NOT NULL,
    [enunciado_quest]     VARCHAR (50) NULL,
    [alternativa_correta] INT          NULL,
    [Fk_materia_id]       INT          NOT NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([Id_Questao] ASC),
    CONSTRAINT [Fk_materia_id] FOREIGN KEY ([Fk_materia_id]) REFERENCES [dbo].[TB_MATERIA] ([Id_materia])
);

