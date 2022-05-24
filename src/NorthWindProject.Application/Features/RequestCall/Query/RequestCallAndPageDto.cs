using System.Collections.Generic;

namespace NorthWindProject.Application.Features.RequestCall.Query
{
    public class RequestCallAndPageDto
    {
        public int PagesCount { get; set; }
        public IList<RequestCallDto> RequestCalls { get; set; }
    }
}