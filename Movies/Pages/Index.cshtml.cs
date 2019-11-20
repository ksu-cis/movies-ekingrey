using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        //public MovieDatabase movieDatabase = new MovieDatabase();

        public List<Movie> Movies;

        [BindProperty]
        public string search { get; set; }
        [BindProperty]
        public List<string> rating { get; set; } = new List<string>();
        [BindProperty]
        public float? minIMDB { get; set; }
        [BindProperty]
        public float? maxIMDB { get; set; }
        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public void OnPost()
        {

            Movies = MovieDatabase.All;

            if(search != null)
            {
                Movies = MovieDatabase.Search(Movies, search);
            }
            if (rating.Count != 0)
            {
                Movies = MovieDatabase.FilterByMPAA(Movies, rating);
            }
            if (minIMDB != null)
            {
                Movies = MovieDatabase.FilterByMinimumIMDB(Movies, (float)minIMDB);
            }
            if (maxIMDB != null)
            {
                Movies = MovieDatabase.FilterByMaximumIMDB(Movies, (float)maxIMDB);
            }

            //if(search!= null && rating.Count != 0)
            //{
            //    Movies = movieDatabase.SearchAndFilter(search, rating);
            //    Movies = movieDatabase.Filter(rating);
            //}
            //else if(rating.Count != 0)
            //{

            //    Movies = movieDatabase.Filter(rating);
            //}
            //else if(search != null)
            //{
            //    Movies = movieDatabase.Search(search);
            //}
            //else
            //{
            //    Movies = movieDatabase.All;
            //}
        }
            
        
    }
}
