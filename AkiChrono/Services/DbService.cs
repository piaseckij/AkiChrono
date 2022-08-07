using System;
using System.Linq;
using System.Windows;
using AkiChrono.Model;
using AkiChrono.Model.Dtos;
using AkiChrono.Validators;
using FluentValidation;

namespace AkiChrono.Services;

public class DbService
{
    private readonly ChronoDbContext _context;
    private UserInputValidator _validator;
    private Plane _plane;
    private TimeSpan _flightTime;
    public DbService(ChronoDbContext context)
    {
        _context = context;
    }

    public void AddFlight(UserInputDto dto)
    {
        try
        {
            _plane = GetPlaneById(dto.PlaneId);
            _validator = new UserInputValidator(_plane);
            _validator.ValidateAndThrow(dto);

            var record = new Record
            {
                DateAdded = DateTime.Now,
                Pilot = dto.InputPilotName,
                TimeSum = dto.InputFlightTimeSum,
                PlaneId = dto.PlaneId
            };

            _flightTime = record.TimeSum - _plane.TotalTime;

            _context.Add(record);

            EditPlane(record);

            _context.SaveChanges();

            MessageBox.Show("Lot został dodany");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    private void EditPlane(Record record)
    {

        _plane.TimeAirframe += _flightTime;
        _plane.TotalTime += _flightTime;
        _plane.TimeEngine += _flightTime;
        _plane.TimeProp += _flightTime;
        _context.SaveChanges();
    }

    private Plane GetPlaneById(int planeId)
    {
        var plane = _context.Planes.FirstOrDefault(x => x.Id == planeId);

        if (plane is null) throw new Exception("Internal error");

        return plane;
    }
}