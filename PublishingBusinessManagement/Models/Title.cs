﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PublishingBusinessManagement.Models;

public partial class Title
{
    public string TitleId { get; set; } = null!;

    public string Title1 { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? PubId { get; set; }

    public decimal? Price { get; set; }

    public decimal? Advance { get; set; }

    public int? Royalty { get; set; }

    public int? YtdSales { get; set; }

    public string? Notes { get; set; }

    public DateTime Pubdate { get; set; }

    public virtual Publisher? Pub { get; set; }
    [JsonIgnore]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    [JsonIgnore]
    public virtual ICollection<Titleauthor> Titleauthors { get; set; } = new List<Titleauthor>();
}
