using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eazyonrent.Model
{
    public class BookingHistoryResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<BookingHistoryItem> HistoryList { get; set; }
    }
    public class BookingHistoryItem
    {
        public int renterItemId { get; set; }
        public int listerId { get; set; }
        public string companyName { get; set; }
        public int rating { get; set; }
        public string review { get; set; }
        public string itemName { get; set; }
        public int itemId { get; set; }
        public DateTime rentFromDate { get; set; }
        public DateTime rentToDate { get; set; }
        public bool status { get; set; }
        public List<ItemImageHistory> itemImageList { get; set; }

        // Formatted properties for display
        public string FormattedFromDate => rentFromDate.ToString("dd MMM yyyy");
        public string FormattedToDate => rentToDate.ToString("dd MMM yyyy");
        public string DateRange => $"{FormattedFromDate} - {FormattedToDate}";
        public string StatusText => status ? "Active" : "Completed";
        public string StatusColor => status ? "#4CAF50" : "#9E9E9E";
    }
    public class ItemImageHistory
    {
        public int imageId { get; set; }
        public int? listerItemId { get; set; }
        public string imageName { get; set; }
        public object imageFiles { get; set; }
    }
}
