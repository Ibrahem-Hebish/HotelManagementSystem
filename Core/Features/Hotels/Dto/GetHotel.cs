using Core.Features.Evaluations.Dtos;
using Core.Features.Rooms.Dtos;

namespace Core.Features.Hotels.Dto;

public class GetHotel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string Street { get; set; } = "";
    public List<GetRoom> Rooms { get; set; } = [];
    public List<GetEvaluation> Evaluations { get; set; } = [];
}


