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

        public override void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "paul":
                    break;

                default:
                    break;
            }

            base.HandleRequest();
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
            base.Add();
        }

        protected override void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            // Get Product Data
            Entity = mgr.Get(
              Convert.ToInt32(EventArgument));

            // Put View Model into Edit Mode
            base.Edit();
        }

        protected override void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductId =
              Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);

            Get();

            base.Delete();
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
            base.Save();
        }

        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();

            base.ResetSearch();
        }

        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);

            base.Get();
        }
    }
}
