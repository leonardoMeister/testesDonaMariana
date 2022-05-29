CREATE TABLE [dbo].[TB_ALTERNATIVA] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Alternativa]   VARCHAR (50) NULL,
    [FK_Questao_id] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Questao_id] FOREIGN KEY ([FK_Questao_id]) REFERENCES [dbo].[TB_QUESTAO] ([Id_Questao])
);

