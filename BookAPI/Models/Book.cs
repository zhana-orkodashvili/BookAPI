using System;
using System.Collections.Generic;

namespace BookAPI.Models;

public partial class Book
{
    public string BookId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime? PublicationDate { get; set; }
}
