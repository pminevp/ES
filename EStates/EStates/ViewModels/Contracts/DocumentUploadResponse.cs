using AutoMapper;
using ES.Data.Models;

namespace EStates.ViewModels.Contracts
{
    public class DocumentUploadResponse : BaseResponse
    {
        public DocumentFileViewModel SelectedDocument { get; set; }

        public void ParseToViewModel(DocumentFile entity)
        {
            SelectedDocument = Mapper.Map<DocumentFileViewModel>(entity);
        }
    }
}
