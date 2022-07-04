using System.Collections.Generic;

namespace PTCData
{
    public class TrainingProductViewModel
    {
        public TrainingProductViewModel()
        {
            IsValid = true;
            IsDetailAreaVisible = false;
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            // Initialize blank list
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            EventCommand = "List";
        }

        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        public string EventCommand { get; set; }
        public bool IsValid { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "add":
                    IsDetailAreaVisible = true;
                    IsListAreaVisible = false;
                    IsSearchAreaVisible = false;
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;
            }
        }

        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);
        }
    }
}
