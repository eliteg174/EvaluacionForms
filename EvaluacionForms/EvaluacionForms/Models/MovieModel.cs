using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluacionForms
{
    public class MovieModel
    {

        public String _id { get; set; }
        public String title { get; set; }
        public String image { get; set; }
        public String category { get; set; }
        public String description { get; set; }
        public String rating { get; set; }


        public MovieModel(String Title= "title", String Category= "category", String Description = "description", String Rating = "rating", String Image = "image")
        {
            this.title = Title;
            this.category = Category;
            this.description = Description;
            this.rating = Rating;
            this.image = Image;
        }

        public override string ToString()
        {
            return string.Format("[MovieModel: title={0}, category={1}, description={2}, rating={3}, image={4}]", title, category, description, rating, image);
        }
    }
}
