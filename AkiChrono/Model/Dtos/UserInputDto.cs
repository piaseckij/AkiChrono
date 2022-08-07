using System;

namespace AkiChrono.Model.Dtos;

public class UserInputDto
{
    public UserInputDto(string inputPilotName, DateTime inputFlightDate, TimeSpan inputFlightTimeSum, int planeId)
    {
        InputPilotName = inputPilotName;
        InputFlightDate = inputFlightDate;
        InputFlightTimeSum = inputFlightTimeSum;
        PlaneId = planeId;
    }

    public int PlaneId { get; set; }
    public string InputPilotName { get; set; }
    public DateTime InputFlightDate { get; set; }
    public TimeSpan InputFlightTimeSum { get; set; }
}