CREATE TABLE [dbo].[TB_LISTA_TESTE_QUESTOES] (
    [fk_teste_id_lista]   INT NOT NULL,
    [fk_questao_id_lista] INT NOT NULL,
    CONSTRAINT [FK_questao_teste] FOREIGN KEY ([fk_questao_id_lista]) REFERENCES [dbo].[TB_QUESTAO] ([Id_Questao]),
    CONSTRAINT [FK_teste_questao] FOREIGN KEY ([fk_teste_id_lista]) REFERENCES [dbo].[TB_TESTE] ([Id_teste])
);

