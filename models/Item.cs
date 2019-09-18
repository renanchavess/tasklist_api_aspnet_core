using System;

namespace tasklist_api_aspnet_core.models
{
    public class Item
    {        
        public Item()
        {
            this.Id = 0;
            this.Title = null;
            this.Description = null;
            this.Status = false;
            this.Created = DateTime.MinValue;
            this.Edited = DateTime.MinValue;
            this.Finished = DateTime.MinValue;
        }

        public Item(int id, string title, string desciption, bool status)
        {
            this.Id = id;
            this.Title = title;
            this.Description = desciption;
            this.Status = status;
            this.Created = DateTime.MinValue;
            this.Edited = DateTime.MinValue;
            this.Finished = DateTime.MinValue;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }
        
        public DateTime Edited { get; set; }

        public DateTime Finished { get; set; }

        public bool Status { get; set; }
    }
}