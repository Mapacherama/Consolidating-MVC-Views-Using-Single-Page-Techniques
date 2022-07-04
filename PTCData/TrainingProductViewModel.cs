﻿using System;
using System.Collections.Generic;

namespace PTCData
{
    public class TrainingProductViewModel
    {
        public TrainingProductViewModel()
        {
            Init();
            // Initialize blank list
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();            
        }

        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        public TrainingProduct Entity { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public string Mode { get; set; }
        public string EventCommand { get; set; }
        public bool IsValid { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        private void Init()
        {
            EventCommand = "List";

            ListMode();
        }

        private void ListMode()
        {
            IsValid = true;
            IsDetailAreaVisible = false;
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;

            Mode = "List";
        }

        private void AddMode()
        {
            IsDetailAreaVisible = true;
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;

            Mode = "Add";
        }

        private void Add()
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

        public void HandleRequest()
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

        private void Save()
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
