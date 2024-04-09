﻿using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IReservationCatsRepository
    {
        Task<IEnumerable<ReservationCats>> GetAll(bool includeCats = false, bool includeReservations = false);
        Task<ReservationCats> GetById(int ID, bool includeCat = false, bool includeReservation = false);
        Task Save(ReservationCats reservationCat);
        Task Delete(ReservationCats reservationCat);
    }
}
