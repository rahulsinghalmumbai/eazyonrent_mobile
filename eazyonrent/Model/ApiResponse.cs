using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eazyonrent.Model
{
    public class ApiResponseItem<T>
    {
        public string? ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        public T? ItemList { get; set; }
    }
    public class ApiResponseCat<T>
    {
        public string? ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        public T? CategoriesList { get; set; }
    }
}
