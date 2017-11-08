using ES.Data.Models.AppModels;
using System.Collections.Generic;

namespace EStates.ViewModels
{
    public class BaseResponse
    {
        public List<ErrorMessages> Error { get; set; } = new List<ErrorMessages>();

        public void AddError(int errorCode, string errorMessage)
                                    => Error.Add(new ErrorMessages
                                    {
                                        ErrorId = errorCode,
                                        ErrorDescription = errorMessage
                                    });
    }
}