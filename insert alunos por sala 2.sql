select Count(*), Estado_Id, TipoDeEnsino from dbo.AlunosPorSalas group by TipoDeEnsino,Estado_id ;
