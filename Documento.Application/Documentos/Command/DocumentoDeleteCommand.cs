namespace Documentos.Application.Documentos.Command
{
    public class DocumentoDeleteCommand : DocumentoCommand
    {
        public DocumentoDeleteCommand(string codigo)
        {
            Codigo = codigo;
        }
    }
}
