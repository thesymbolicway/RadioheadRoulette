using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyricsScraperNET;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RadioheadRoulette.Pages
{
    public class IndexModel : PageModel
    {
        public string Lyric { get; set; }

        public async Task OnGetAsync()
        {
            int totalTracks = 157;
            int randomTrackNumber = new Random().Next(1, totalTracks);

            string query = $"Radiohead {randomTrackNumber}";
            var result = await LyricsScraper.GetLyricsAsync(query);
            if (result != null)
            {
                Lyric = result.Lyrics;
            }
            else
            {
                Lyric = $"Lyrics for {query} not found.";
            }
        }
    }
}
