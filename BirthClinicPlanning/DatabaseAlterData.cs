using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanning.Data;
using BirthClinicPlanning.Models;

namespace BirthClinicPlanning
{
    public class DatabaseAlterData
    {
        private BirthClinicPlanningContext _context;

        public DatabaseAlterData(BirthClinicPlanningContext context)
        {
            _context = context;
        }

        public void CancelReservation(int reservationId)
        {
            DateTime dateTime = new DateTime(1, 1, 1, 0, 0, 0, 0);

            Reservation reservation = _context.Reservations.Find(reservationId);

            reservation.ReservationStartDate = dateTime;
            reservation.ReservationEndDate = dateTime;
            reservation.RelativesId = null;

            _context.Update(reservation);
            _context.SaveChanges();
        }

        public void EndBirth(int birthId)
        {
            Birth birth = _context.Births.Find(birthId);

            birth.PlannedEndDate = DateTime.Now;

            _context.Update(birth);
            _context.SaveChanges();
        }
    }
}
