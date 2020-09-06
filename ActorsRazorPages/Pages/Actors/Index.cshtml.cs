using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActorsRazorPages.Models;

namespace ActorsRazorPages.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private IData data;
        public IList<Actor> Actors { get; set; }

        public IndexModel(IData data)
        {
            this.data = data;
        }


        
        public void OnGet()
        {
            Actors = data.ActorsInitializeData();
        }
    }
}