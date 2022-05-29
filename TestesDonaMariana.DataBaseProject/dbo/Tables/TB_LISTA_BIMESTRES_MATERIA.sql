CREATE TABLE [dbo].[TB_LISTA_BIMESTRES_MATERIA] (
    [FK_tb_materia_id]  INT NOT NULL,
    [Fk_tb_bimestre_id] INT NOT NULL,
    CONSTRAINT [FK_Table_Bimestre_id] FOREIGN KEY ([Fk_tb_bimestre_id]) REFERENCES [dbo].[TB_BIMESTRE] ([Id_Bimeste]),
    CONSTRAINT [FK_Table_Materia_id] FOREIGN KEY ([FK_tb_materia_id]) REFERENCES [dbo].[TB_MATERIA] ([Id_materia])
);

