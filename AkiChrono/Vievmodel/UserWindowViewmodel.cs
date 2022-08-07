using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AkiChrono.Commands;
using AkiChrono.Model;
using AkiChrono.Model.Dtos;
using AkiChrono.Services;
using AkiChrono.Validators;
using FluentValidation;

namespace AkiChrono.Vievmodel;

public class UserWindowViewmodel : ViewmodelBase
{
    private readonly ChronoDbContext _context;
    private readonly DbService _dbService;
    private DateTime inputFlightDate = DateTime.Now;
    private TimeSpan inputFlightTimeSum;
    private string inputPilotName;
    private List<Record> lastRecords;
    private List<Plane> planes;
    private Plane selectedPlane;
    private TimeSpan timeFlown;


    public UserWindowViewmodel(ChronoDbContext context, DbService dbService)
    {
        _context = context;
        _dbService = dbService;

        SelectedPlane = GetPlanes().FirstOrDefault();
    }

    public List<Record> LastRecords
    {
        get => lastRecords;
        set
        {
            lastRecords = GetLastFlights();
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

    public List<Plane> Planes => GetPlanes();

    public Plane SelectedPlane
    {
        get => selectedPlane;
        set
        {
            selectedPlane = value;
            LastRecords = GetLastFlights();
            OnPropertyChanged();
        }
    }

    public string InputPilotName
    {
        get => inputPilotName;
        set
        {
            inputPilotName = value;
            OnPropertyChanged();
        }
    }

    public DateTime InputFlightDate
    {
        get => inputFlightDate;
        set
        {
            inputFlightDate = value;
            OnPropertyChanged();
        }
    }

    public TimeSpan InputFlightTimeSum
    {
        get => inputFlightTimeSum;
        set
        {
            inputFlightTimeSum = value;
            OnPropertyChanged();
        }
    }

    public ICommand SubmitCommand => new SubmitCommand(this);

    private List<Record> GetLastFlights()
    {
        var lastFlights = _context.Records.Where(x => x.PlaneId == SelectedPlane.Id).ToList();

        if (lastFlights is null) throw new ArgumentNullException(nameof(lastFlights));

        return lastFlights;
    }

    private List<Plane> GetPlanes()
    {
        var planesFromDb = _context.Planes.ToList();
        if (planesFromDb is null) throw new ArgumentNullException(nameof(planesFromDb));
        return planesFromDb;
    }

    public void AddFlight()
    {
        var inputDto = new UserInputDto(InputPilotName, InputFlightDate, InputFlightTimeSum, SelectedPlane.Id);

        _dbService.AddFlight(inputDto);

        LastRecords = _context.Records.ToList();
    }
}