using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO.Models
{
    public class Book
    {
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Description { get; set; }
        public string Category { get; set; } = null!;

        public override string ToString()
        {
            return $"Livre : {Isbn}\n" +
                   $"   Titre : {Title}\n" +
                   $"   Auteur : {Author}\n" +
                   $"   Catégorie : {Category}\n" +
                   $"   Description : {Description?.Substring(0, 20)}...\n" +
                   new string('_', 20);
        }
    }
}
