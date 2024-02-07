﻿using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories;

public class RocketseatAuctionDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\MiguelFelipeReisBrit\\Documents\\Code\\leilaoDbNLW.db");
    }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
}
