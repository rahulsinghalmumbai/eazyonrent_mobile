using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eazyonrent.Model
{
    public class ListerItemResult : INotifyPropertyChanged
    {
        private string _location = "Noida"; 
        private List<string> _Images;

        public int ListerItemId { get; set; }
        public string? ItemName { get; set; }
        public string? CompanyName { get; set; }
        public int ListerId { get; set; }
        public int? viewCount { get; set; }
        public decimal? ItemCost { get; set; }
        public string? ItemDescriptions { get; set; }
        public DateTime? Availablefrom { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? CategoryId { get; set; }

        // Additional properties for UI
        public string Location
        {
            get => _location;
            set
            {
                _location = value ?? "Noida";
                OnPropertyChanged();
            }
        }

        public List<string> Images
        {
            get => _Images;
            set
            {
                _Images = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public List<ItemImageResult> ItemImageList { get; set; }
    }
}