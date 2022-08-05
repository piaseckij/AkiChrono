using System;
using System.Collections.Generic;
using System.Linq;
using AkiChrono.Model;

namespace AkiChrono.Vievmodel;

public class UserWindowViewmodel : ViewmodelBase
{
    private readonly ChronoDbContext _context;
    private List<Plane> planes;
    private Plane selectedPlane;
    private TimeSpan timeFlown;

    public UserWindowViewmodel(ChronoDbContext context)
    {
        _context = context;

        Planes = new List<Plane>();
        Planes.AddRange(context.Planes.ToList());
        SelectedPlane = context.Planes.FirstOrDefault();
        LastRecords = context.Records.ToList();
    }
    private List<Record> lastRecords;

    public List<Record> LastRecords
    {
        get => lastRecords;
        set
        {
            lastRecords = _context.Records.Where(x => x.PlaneId == SelectedPlane.Id).ToList();
            OnPropertyChanged();
        }
    }

    public TimeSpan TimeFlown
    {
        get => timeFlown;
        set
        {
            timeFlown = value;
            OnPropertyChanged();
        }
    }

    public List<Plane> Planes
    {
        get => planes;
        set
        {
            planes = value;
            OnPropertyChanged();
        }
    }

    public Plane SelectedPlane
    {
        get => selectedPlane;
        set
        {
            selectedPlane = value;
            LastRecords = _context.Records.ToList();
            OnPropertyChanged();
        }
    }
}