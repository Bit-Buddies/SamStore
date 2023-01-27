using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.WebAPI.Core.API.Models
{
    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Error { get; set; } = new ResponseErrorMessages();

        public ResponseResult(string title, int status)
        {
            Title = title;
            Status = status;
        }

        public void AddError(string errorMessage)
        {
            Error.ErrorMessages.Add(new ErrorViewModel(errorMessage));
        }
    }

    public class ResponseErrorMessages
    {
        public List<ErrorViewModel> ErrorMessages { get; set; } = new List<ErrorViewModel>();
    }

    public class ErrorViewModel
    {
        public string ErrorMessage { get; set; }

        public ErrorViewModel(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
