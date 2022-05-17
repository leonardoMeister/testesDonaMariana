using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.MateriaDir;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.TesteDir;
using Newtonsoft.Json;


namespace TestesDonaMariana.Serializador.Shared
{
    public class DataContextDadosDomain
    {
        private string caminhoArquivo = "ContextoDadosDomain.json";


        private List<Materia> listaMate;
        private List<Disciplina> listaDisciplina;
        private List<Questao> listaQuestao;
        private List<Teste> listaTeste;

        public List<Materia> ListaMate { get => listaMate; set => listaMate = value; }
        public List<Disciplina> ListaDisciplina { get => listaDisciplina; set => listaDisciplina = value; }
        public List<Questao> ListaQuestao { get => listaQuestao; set => listaQuestao = value; }
        public List<Teste> ListaTeste { get => listaTeste; set => listaTeste = value; }

        public DataContextDadosDomain()
        {
            if (File.Exists(caminhoArquivo) == false)
                File.Create(caminhoArquivo);

            listaMate = new List<Materia>();
            listaDisciplina = new List<Disciplina>();
            listaQuestao = new List<Questao>();
            listaTeste = new List<Teste>();

        }

        public DataContextDadosDomain(List<Materia> listaMate, List<Disciplina> listaDisciplina,
            List<Questao> listaQuestao, List<Teste> listaTeste)
        {
            if (File.Exists(caminhoArquivo) == false)
                File.Create(caminhoArquivo);

            this.listaMate = listaMate;
            this.listaDisciplina = listaDisciplina;
            this.listaQuestao = listaQuestao;
            this.listaTeste = listaTeste;
        }

        public DataContextDadosDomain CarregarTarefasDoArquivo()
        {
            if (File.Exists(caminhoArquivo) == false)
            {
                File.Create(caminhoArquivo);
                return new DataContextDadosDomain();
            }


            string tarefasJson = File.ReadAllText(caminhoArquivo);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;
            settings.PreserveReferencesHandling = PreserveReferencesHandling.All;

            DataContextDadosDomain arquivo = JsonConvert.DeserializeObject<DataContextDadosDomain>(tarefasJson, settings);
            if (arquivo is null)
                return new DataContextDadosDomain();

            else return arquivo;
        }

        public void GravarTarefasEmArquivo(DataContextDadosDomain contextoDomain)
        {

            if (File.Exists(caminhoArquivo) == false)
                File.Create(caminhoArquivo);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;
            settings.PreserveReferencesHandling = PreserveReferencesHandling.All;

            string tarefasJson = JsonConvert.SerializeObject(contextoDomain, settings);

            File.WriteAllText(caminhoArquivo, tarefasJson);
        }
    }
}
