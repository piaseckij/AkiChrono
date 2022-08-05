using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AkiChrono.Model;

namespace AkiChrono.Utils;

public class DbSeeder
{
    private readonly ChronoDbContext _context;

    public DbSeeder(ChronoDbContext context)
    {
        _context = context;
        Seed();
    }

    private void Seed()
    {
        if (!_context.Database.CanConnect()) throw new Exception("Error connecting to Db");

        if (!_context.Planes.Any())
        {
            _context.Planes.AddRange(GetPlanes());
            _context.SaveChanges();
        }

        //if (!_context.Records.Any())
        //{
        _context.Records.RemoveRange(_context.Records.Take(_context.Records.Count()));
        _context.Records.AddRange(GetRecords());
        _context.SaveChanges();
        //}
    }

    private static List<Record> GetRecords()
    {
        return new List<Record>
        {
            new()
            {
                Pilot = "Jacek",
                PlaneId = 1,
                TimeSum = TimeSpan.FromHours(2),
                DateAdded = DateTime.Now.AddHours(-2)
            },
            new()
            {
                Pilot = "Zenon",
                PlaneId = 2,
                TimeSum = TimeSpan.FromHours(2),
                DateAdded = DateTime.Now.AddHours(-1)
            },

            new()
            {
                Pilot = "Tomek",
                PlaneId = 2,
                TimeSum = TimeSpan.FromHours(2),
                DateAdded = DateTime.Now.AddHours(-3)
            }
        };
    }

    private List<Plane> GetPlanes()
    {
        return new List<Plane>
        {
            new()
            {
                Name = "SP-AKI",
                TimeAirframe = TimeSpan.FromHours(1000),
                TimeEngine = TimeSpan.FromHours(100),
                TimeProp = TimeSpan.FromHours(500),
                TotalTime = TimeSpan.FromHours(1)
            },

            new()
            {
                Name = "SP-AKA",
                TimeAirframe = TimeSpan.FromHours(1000),
                TimeEngine = TimeSpan.FromHours(100),
                TimeProp = TimeSpan.FromHours(500),
                TotalTime = TimeSpan.FromHours(1)
            }
        };
    }
}