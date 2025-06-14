namespace Services.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<Reservation>> GetUserReservations(string userId, Tracking tracking, CancellationToken cancellationToken);
    Task<Reservation> GetUserLastReservation(string userId, Tracking tracking, CancellationToken cancellationToken);
    Task<List<HotelEvaluations>> GetUserEvaluationsToHotels(string userId, Tracking tracking, CancellationToken cancellationToken);
    Task<List<Hotel>> GetUserHotels(string userId, Tracking tracking, CancellationToken cancellationToken);

}