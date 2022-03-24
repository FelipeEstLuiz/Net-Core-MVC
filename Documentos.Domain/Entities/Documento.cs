using System;

namespace Documentos.Domain.Entities
{
    public sealed class Documento
    {
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Revisao { get; set; }
        public DateTime DataPlanejada { get; set; }
        public decimal Valor { get; set; }

        public Documento(
            string codigo,
            string titulo,
            string revisao,
            DateTime dataPlanejada,
            decimal valor
        )
        {
            Codigo = codigo;
            Titulo = titulo;
            Revisao = revisao;
            DataPlanejada = dataPlanejada;
            Valor = valor;
        }

        public void Update(
            string titulo,
            string revisao,
            DateTime dataPlanejada,
            decimal valor
        )
        {
            Titulo = titulo;
            Revisao = revisao;
            DataPlanejada = dataPlanejada;
            Valor = valor;
        }
    }
}
