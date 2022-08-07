using System;
using System.Windows;
using AkiChrono.Model;
using AkiChrono.Model.Dtos;
using AkiChrono.Validators;
using FluentValidation;

namespace AkiChrono.Services;

public class DbService
{
    private readonly ChronoDbContext _context;
    private readonly UserInputValidator _validator;

    public DbService(ChronoDbContext context)
    {
        _context = context;
        _validator = new UserInputValidator();
    }

    public void AddFlight(UserInputDto dto)
    {
        try
        {
            _validator.ValidateAndThrow(dto);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            return;
        }

        var record = new Record
        {
            DateAdded = DateTime.Now,
            Pilot = dto.InputPilotName,
            TimeSum = dto.InputFlightTimeSum,
            PlaneId = dto.PlaneId
        };

        _context.Add(record);
        _context.SaveChanges();

        MessageBox.Show("Lot został dodany");
    }
}