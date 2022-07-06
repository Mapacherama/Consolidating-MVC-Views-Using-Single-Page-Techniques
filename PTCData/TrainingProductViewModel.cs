using PTCCommon;
using System;
using System.Collections.Generic;

namespace PTCData
{
    public class TrainingProductViewModel : ViewModelBase
    {
        public TrainingProductViewModel() : base()
        {

        }

        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        public TrainingProduct Entity { get; set; }

        protected override void Init()
        {
            // Initialize blank list
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();

            base.Init();
        }



        protected override void Add()
        {
            IsValid = true;

            // Initialize Entity Object
            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = string.Empty;
            Entity.Price = 0;

            // Put ViewModel into Add Mode
            AddMode();
        }

        protected override void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            // Get Product Data
            Entity = mgr.Get(
              Convert.ToInt32(EventArgument));

            // Put View Model into Edit Mode
            EditMode();
        }

        protected override void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductId =
              Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);

            Get();

            ListMode();
        }

        public override void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "save":
                    Save();
                    Get();
                    break;

                case "edit":
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                case "cancel":
                    IsDetailAreaVisible = false;
                    IsListAreaVisible = true;
                    IsSearchAreaVisible = true;
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;
            }
        }

        protected override void Save()
        {
            TrainingProductManager mgr =
        new TrainingProductManager();

            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }
            // Set any validation errors
            ValidationErrors = mgr.ValidationErrors;
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
            }
        }

        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);
        }
    }
}
