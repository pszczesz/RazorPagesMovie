﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }

        public async Task OnGetAsync(string movieGenre, string searchString) {
            IQueryable<string> genreQuery = _context.Movie.OrderBy(m => m.Genre).Select(m => m.Genre);
            var movies = from m in _context.Movie select m;
            if (!String.IsNullOrEmpty(searchString)) {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre)) {
                movies = movies.Where(m => m.Genre == movieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
            SearchString = searchString;

        }
    }
}
